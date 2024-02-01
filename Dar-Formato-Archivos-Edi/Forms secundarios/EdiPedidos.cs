using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Dar_Formato_Archivos_Edi.Clases.ClienteEdiPedido;
using Dar_Formato_Archivos_Edi.Clases.PedidoRelacionado;
using Dar_Formato_Archivos_Edi.Clases.ClienteLis;
using Dar_Formato_Archivos_Edi.Clases.ClienteEdiPedidoDireccion;
using Dar_Formato_Archivos_Edi.Clases.ClienteEdiNotificaEvento;
using Dar_Formato_Archivos_Edi.Clases.ClienteEdiEstatusSeguimiento;
using Dar_Formato_Archivos_Edi.DataAccess.DataAccess_ClienteEdiPedido;
using Dar_Formato_Archivos_Edi.DataAccess.DataAccess_PedidoRelacionado;
using Dar_Formato_Archivos_Edi.DataAccess.DataAccess_ClienteLis;
using System.Threading;
using Dar_Formato_Archivos_Edi.PopUp;
using Dar_Formato_Archivos_Edi.Clases.ClienteEdiArchivo;
using Dar_Formato_Archivos_Edi.DataAccess;

namespace Dar_Formato_Archivos_Edi.Forms_secundarios
{
    public partial class EdiPedidos : Form
    {

        public RichTextBox TxtFormatoTexto;
        public Label lblNombreArchivo;
        public Button btnTexto;

        public EdiPedidos(RichTextBox e, Label l, Button b)
        {
            this.TxtFormatoTexto = e;
            this.lblNombreArchivo = l;
            this.btnTexto = b;

            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            groupBox1.ForeColor = Color.White;
            groupBox2.ForeColor = Color.White;
            groupBox3.ForeColor = Color.White;

            kdgvEventosReportadosAppMobil.ForeColor = Color.Black;

            new List<Label>() { lbl824, lbl997, lblUnidad }.ForEach(lbls =>
            {
                lbls.MouseHover += HoverEnter;
            });

            // Cargar combobox Empresa
            Dictionary<string, string> empresas = new Dictionary<string, string>();
            empresas.Add("hgdb_lis", "HG");
            empresas.Add("chdb_lis", "CH");
            empresas.Add("rldb_lis", "RL");
            empresas.Add("lindadb", "LINDA");

            cboEmpresa.DataSource = new BindingSource(empresas, null); ;
            cboEmpresa.ValueMember = "Key";
            cboEmpresa.DisplayMember = "Value";
        }

        public static void HoverEnter(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.Cursor = Cursors.Hand;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                limpiar();
                // Llenar textbox con informacion de Estatus Edi
                //int ClienteEdiPedidoId = Convert.ToInt32(txtClienteEdiPedidoId.Text);
                int ClienteEdiPedidoId;
                Int64 Shipment;
                
                string empresa = cboEmpresa.SelectedValue.ToString();

                if (rbtnShipment.Checked)
                {
                    var isNumber = Int64.TryParse(txtClienteEdiPedidoId.Text, out Shipment);

                    if (!isNumber)
                    {
                        MessageBox.Show("Shipment no valido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtClienteEdiPedidoId.Clear();
                        return;
                    }

                    // Obtener ClienteEdiPedidoId a traves del shipment
                    var List_ClienteEdiPedido = GetClienteEdiPedidoShipment(Shipment, empresa);
                    
                    if (!List_ClienteEdiPedido.Any())
                    {
                        MessageBox.Show("No se encontro el shipment: " + Shipment.ToString(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (List_ClienteEdiPedido.Count > 1)
                    {
                        var f = new EdiShipmentDuplicado(List_ClienteEdiPedido);

                        DialogResult resultado = f.ShowDialog();
                        if (resultado == DialogResult.OK)
                        {
                            // Accede a los datos seleccionados en FormularioSecundario
                            ClienteEdiPedidoId = f.ClienteEdiPedido;
                            txtClienteEdiPedidoId.Text = ClienteEdiPedidoId.ToString();
                            rbtnArchivoId.Checked = true;
                            rbtnShipment.Checked = false;
                            
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        ClienteEdiPedidoId = List_ClienteEdiPedido.First().ClienteEdiPedidoId;
                    }
                }
                else
                {
                    var isNumber = int.TryParse(txtClienteEdiPedidoId.Text, out ClienteEdiPedidoId);

                    if (!isNumber)
                    {
                        MessageBox.Show("Numero no valido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtClienteEdiPedidoId.Clear();
                        return;
                    }
                }

                //int Viaje = Convert.ToInt32(txtViaje);
                ClienteEdiPedido cep = SetClienteEdiEstatus(ClienteEdiPedidoId, empresa);

                // Llenar textbox con Informacion de la relacion
                SetInformacionRelacion(ClienteEdiPedidoId, cep.SQL_DB);

                // Llenar DataGrid con informacion ClienteEdiPedidoDireccion
                SetClienteEdiPedidoDireccion(ClienteEdiPedidoId, empresa);

                // Llenar DataGrid con informacion ClienteEdiNotificaEvento
                SetClienteEdiNotificaEvento(ClienteEdiPedidoId, empresa);

                // Llenar DataGrid con informacion ClienteEdiNotificaEvento
                SetClienteEdiEstatusSeguimiento(ClienteEdiPedidoId, empresa);

                //Marcar textbox en rojo para la informacion pendiente
                MarcarInformacionInvalida();
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Ocurrio un error: " + ex.Message);
            }
        }

        #region Set_Informacion
        public ClienteEdiPedido SetClienteEdiEstatus(int ClienteEdiPedidoId, string empresa)
        {

            // Obtener Estatus Edi
            ClienteEdiPedido clienteEdiPedido = GetClienteEdiPedido(ClienteEdiPedidoId, empresa);

            txtEstatus.Text = clienteEdiPedido.EstatusId.ToString() + " - " + clienteEdiPedido.Estatus;
            txtSCAC.Text = clienteEdiPedido.SCAC;
            txtFechaIngreso.Text = clienteEdiPedido.FechaIngreso.ToString("dd/MM/yyyy HH:mm:ss");
            txtShipment.Text = clienteEdiPedido.Shipment;

            return clienteEdiPedido;
        }

        public void SetInformacionRelacion(int ClienteEdiPedidoId, string sqldb)
        {
            PedidoRelacionado pedidoRelacionado = new PedidoRelacionado();
            pedidoRelacionado.ClienteEdiPedidoId = ClienteEdiPedidoId;
            // Obtener Informacion de la relacion
            if (sqldb == "chdb_lis")
            {
                pedidoRelacionado = GetDesp_pedido_edi(ClienteEdiPedidoId, sqldb);
            }
            else
            {
                pedidoRelacionado = GetPedidoRelacionado(ClienteEdiPedidoId, sqldb);
            }

            if (pedidoRelacionado != null)
            {
                // Obtener viaje de la tabla desp_pedido
                if (pedidoRelacionado.id_pedido > 0 && pedidoRelacionado.no_viaje == 0 && sqldb != "chdb_lis")
                {
                    pedidoRelacionado = GetDesp_pedido_viaje(ClienteEdiPedidoId, sqldb);

                    if (pedidoRelacionado.no_viaje == 0)
                    {
                        MessageBox.Show("El pedido no cuenta con viaje", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                pedidoRelacionado.ClienteEdiPedidoId = ClienteEdiPedidoId;
                txtPedido.Text = pedidoRelacionado.id_pedido.ToString();
                txtViaje.Text = pedidoRelacionado.no_viaje.ToString();
                //txtClienteEdiPedidoId.Text = pedidoRelacionado.ClienteEdiPedidoId.ToString(); // Se comento por que estaba reemplazando el valor cuando se buscaba por shipment



                // Llenar DataGrid con informacion ClienteEdiNotificaEvento
                SetClienteEdiNotificaEventoAppMobil(Convert.ToInt32(txtViaje.Text), ClienteEdiPedidoId, sqldb);

                // Obtener informacion del cliente y la geocerca
                List<ClienteLis> lista_cliente = new List<ClienteLis>() {
                        new ClienteLis()
                        {
                            tipo_cliente = "Remitente",
                            id_cliente = pedidoRelacionado.id_remitente
                        },
                        new ClienteLis()
                        {
                            tipo_cliente = "Remitente Ext",
                            id_cliente = pedidoRelacionado.id_remitente_ext
                        },
                        new ClienteLis()
                        {
                            tipo_cliente = "Destinatario",
                            id_cliente = pedidoRelacionado.id_destinatario
                        },
                        new ClienteLis()
                        {
                            tipo_cliente = "Destinatario Ext",
                            id_cliente = pedidoRelacionado.id_destinatario_ext
                        }

                };

                List<ClienteLis> cliente_dataList = GetClienteLis(lista_cliente.Where(vl => vl.id_cliente != null).ToList(), sqldb);

                foreach (ClienteLis item in cliente_dataList)
                {
                    switch (item.tipo_cliente)
                    {
                        case "Remitente":
                            txtRemitente.Text = item.id_cliente.ToString() + " - " + item.nombre_cliente;
                            //txtTipoSitioRem.Text = item.tipositio.ToString();
                            txtSiteIDRem.Text = item.siteID == null ? "" : item.siteID.ToString();
                            txtNombreSitioRem.Text = item.ubicacion == null ? "" : item.ubicacion.ToString();
                            txtSitioRemDesc.Text = item.descripcion;
                            break;
                        case "Remitente Ext":
                            txtRemitenteAlt.Text = item.id_cliente.ToString() + " - " + item.nombre_cliente;
                            //txtTipoSitioRemAlt.Text = item.tipositio.ToString();
                            txtSiteIDRemAlt.Text = item.siteID == null ? "" : item.siteID.ToString();
                            txtNombreSitioRemAlt.Text = item.ubicacion == null ? "" : item.ubicacion.ToString();
                            txtSitioRemAltDesc.Text = item.descripcion;
                            break;
                        case "Destinatario":
                            txtDestinatario.Text = item.id_cliente.ToString() + " - " + item.nombre_cliente;
                            //txtTipoSitioDest.Text = item.tipositio.ToString();
                            txtSiteIDDest.Text = item.siteID == null ? "" : item.siteID.ToString();
                            txtNombreSitioDest.Text = item.ubicacion == null ? "" : item.ubicacion.ToString();
                            txtSitioDestDesc.Text = item.descripcion;
                            break;
                        case "Destinatario Ext":
                            txtDestinatarioAlt.Text = item.id_cliente.ToString() + " - " + item.nombre_cliente;
                            //txtTipoSitioDestAlt.Text = item.tipositio.ToString();
                            txtSiteIDDestAlt.Text = item.siteID == null ? "" : item.siteID.ToString();
                            txtNombreSitioDestAlt.Text = item.ubicacion == null ? "" : item.ubicacion.ToString();
                            txtSitioDestAltDesc.Text = item.descripcion;
                            break;
                    }
                }

                if (pedidoRelacionado.no_viaje != null && pedidoRelacionado.no_viaje != 0)
                {
                    // Obtener id_unidad y satelite
                    unidad_Viaje cUnidad = GetUnidadSatelite(Convert.ToInt32(pedidoRelacionado.no_viaje), sqldb);
                    txtUnidad.Text = cUnidad.id_unidad;
                    txtSatelite.Text = cUnidad.mctNumber != null ? cUnidad.mctNumber : "";
                    txtFechaInicioViaje.Text = cUnidad.fecha_real_viaje.ToString("dd/MM/yyyy HH:mm:ss");
                    txtFechaFinViaje.Text = cUnidad.fecha_real_fin_viaje.ToString("dd/MM/yyyy HH:mm:ss");
                    txtEstatusViaje.Text = cUnidad.status_viaje;
                }
                else
                {
                    txtUnidad.Text = " Revisar estatus del viaje ";
                    txtSatelite.Text = " Revisar estatus del viaje ";
                }

                if (pedidoRelacionado.no_viaje > 0)
                {
                    //Llenado en DataGridView
                    List<posicion_unidad> posicion = GetPosicionUnidad(Convert.ToInt32(pedidoRelacionado.no_viaje), sqldb);

                    if (posicion != null && posicion.Any())
                    {
                        //dgvPosicionUnidad.DataSource = posicion;
                        kryptonDataGridView1.DataSource = posicion.Select(vl => new
                        {
                            Ubicacion = vl.ubicacion,
                            Evento = vl.EventTypeDescription,
                            Posdate = vl.posdate.ToString("dd/MM/yyyy HH:mm:ss"),
                            Origen = vl.Sistema_origen,
                            Posdate_Inserto = vl.posdate_inserto.ToString("dd/MM/yyyy HH:mm:ss")
                        }).ToList();

                        // Organizar el espacio de las celdas y columnas del grid de las posiciones de la unidad con el viaje

                        // Sistema_origen
                        kryptonDataGridView1.AutoResizeColumn(3, DataGridViewAutoSizeColumnMode.ColumnHeader);
                        // posdate_inserto
                        kryptonDataGridView1.AutoResizeColumn(4, DataGridViewAutoSizeColumnMode.ColumnHeader);
                        //ubicacion
                        kryptonDataGridView1.AutoResizeColumn(0, DataGridViewAutoSizeColumnMode.ColumnHeader);
                        //EventTypeDescription
                        kryptonDataGridView1.AutoResizeColumn(1, DataGridViewAutoSizeColumnMode.AllCellsExceptHeader);
                        //posdate
                        kryptonDataGridView1.AutoResizeColumn(2, DataGridViewAutoSizeColumnMode.AllCellsExceptHeader);
                    }
                    //else
                    //{
                    //    txtUnidad.Text = " Revisar estatus del viaje ";
                    //    txtSatelite.Text = " Revisar estatus del viaje ";
                    //}
                }
            }
        }

        public void SetClienteEdiPedidoDireccion(int ClienteEdiPedidoId, string empresa)
        {
            List<ClienteEdiPedidoDireccion> list_PedidoDireccion = GetClienteEdiPedidoDireccion(ClienteEdiPedidoId, empresa);

            if (list_PedidoDireccion.Count > 0)
            {
                //dtGrid_PedidoDireccion.DataSource = list_PedidoDireccion.Select(s => new
                //{

                //    ClienteEdiPedidoDireccionId = s.ClienteEdiPedidoDireccionId,
                //    ClienteEdiTipoDireccion = s.TipoDireccionId + " - " + s.NombreClienteEdiTipoDireccion,
                //    FechaEntrada = s.FechaEntrada.ToString(),
                //    FechaSalida = s.FechaSalida.ToString(),
                //    Nombre = s.Nombre,
                //    Pais = s.Pais,
                //    Estado = s.Estado,
                //    Ciudad = s.Ciudad,
                //    Calle = s.Calle,
                //    CodigoPostal = s.CodigoPostal,
                //    Stop = s.Stop,
                //    Accion = s.Accion

                //}).ToList();

                kdtGrid_PedidoDireccion.DataSource = list_PedidoDireccion.Select(s => new
                {

                    ClienteEdiPedidoDireccionId = s.ClienteEdiPedidoDireccionId,
                    ClienteEdiTipoDireccion = s.TipoDireccionId + " - " + s.NombreClienteEdiTipoDireccion,
                    FechaEntrada = s.FechaEntrada.ToString("dd/MM/yyyy HH:mm:ss"),
                    FechaSalida = s.FechaSalida.ToString("dd/MM/yyyy HH:mm:ss"),
                    Nombre = s.Nombre,
                    Pais = s.Pais,
                    Estado = s.Estado,
                    Ciudad = s.Ciudad,
                    Calle = s.Calle,
                    CodigoPostal = s.CodigoPostal,
                    Stop = s.Stop,
                    Accion = s.Accion

                }).ToList();
            }
        }

        public void SetClienteEdiNotificaEvento(int ClienteEdiPedidoId, string empresa) // Se reportan los eventos en la tabla principal
        {
            List<ClienteEdiNotificaEvento> listado_NotificaEvento = GetClienteEdiNotificaEvento(ClienteEdiPedidoId, empresa);

            // Obtener informacion ClienteEdiNotificaEvento
            if (listado_NotificaEvento.Count > 0)
            {
                kdtGrid_EventosReportados.DataSource = listado_NotificaEvento.Select(s => new
                {
                    ClienteEdiNotificaEventoId = s.ClienteEdiNotificaEventoId,
                    Evento = s.EventoId + " - " + s.Evento,
                    FechaEvento = s.FechaIngreso.ToString(),
                    Caso = s.caso,
                    FechaRegistro = s.fechaRegistro.ToString(),
                    Archivo = s.nombreArchivo,
                    Texto214 = s.Texto214
                }).ToList();

                // Configurar columnas para mostrar la informacion importante

                // ClienteEdiNotificaEventoId
                kdtGrid_EventosReportados.AutoResizeColumn(0, DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader);
                // Evento
                kdtGrid_EventosReportados.AutoResizeColumn(1, DataGridViewAutoSizeColumnMode.DisplayedCells);
                // FechaIngreso
                kdtGrid_EventosReportados.AutoResizeColumn(2, DataGridViewAutoSizeColumnMode.DisplayedCells);
                // Caso
                kdtGrid_EventosReportados.AutoResizeColumn(3, DataGridViewAutoSizeColumnMode.DisplayedCells);
                // FechaRegistro
                kdtGrid_EventosReportados.AutoResizeColumn(4, DataGridViewAutoSizeColumnMode.DisplayedCells);
                // Texto214
                kdtGrid_EventosReportados.AutoResizeColumn(6, DataGridViewAutoSizeColumnMode.ColumnHeader);
            }
        }


        public void SetClienteEdiNotificaEventoAppMobil(int no_viaje, int ClienteEdiPedidoId, string sqldb)
        {
            List<ClienteEdiNotificaEventoApp> listado_NotificaEventoApp = GetClienteEdiNotificaEventoAppMob(no_viaje, ClienteEdiPedidoId, sqldb);

            // Obtener informacion ClienteEdiNotificaEvento
            if (listado_NotificaEventoApp.Count >= 0)
            {
             
                kdgvEventosReportadosAppMobil.DataSource = listado_NotificaEventoApp.Select(s => new
                {
                    mensaje = s.mensaje,
                    fecha_recibido = s.fecha_recibido,
                    sistema_origen = s.sistema_origen,
                    no_viaje = s.no_viaje,
                    id_personal = s.id_personal,
                    nombre = s.nombre,
                    //reason_code = s.reason_code,
                    id_pedido = s.id_pedido,
                    parada = s.parada,
                    clienteEdiPedidoId = s.ClienteEdiPedidoId,
                    //tipo_empleado = s.tipo_empleado

                }).ToList();

                // Configurar columnas para mostrar la informacion importante

                // mensaje
                kdgvEventosReportadosAppMobil.AutoResizeColumn(0, DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader);
                // fecha_recibido
                kdgvEventosReportadosAppMobil.AutoResizeColumn(1, DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader);
                // sistema_origen
                kdgvEventosReportadosAppMobil.AutoResizeColumn(2, DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader);
                // no_viaje
                kdgvEventosReportadosAppMobil.AutoResizeColumn(3, DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader);
                // id_personal
                kdgvEventosReportadosAppMobil.AutoResizeColumn(4, DataGridViewAutoSizeColumnMode.ColumnHeader);
                // nombre
                kdgvEventosReportadosAppMobil.AutoResizeColumn(5, DataGridViewAutoSizeColumnMode.ColumnHeader);
                // id_pedido
                kdgvEventosReportadosAppMobil.AutoResizeColumn(6, DataGridViewAutoSizeColumnMode.ColumnHeader);
                // parada
                kdgvEventosReportadosAppMobil.AutoResizeColumn(7, DataGridViewAutoSizeColumnMode.ColumnHeader);
                // clienteEdiPedidoId
                kdgvEventosReportadosAppMobil.AutoResizeColumn(8, DataGridViewAutoSizeColumnMode.ColumnHeader);
            }
        }

        public void SetClienteEdiEstatusSeguimiento(int ClienteEdiPedidoId, string empresa)
        {
            List<ClienteEdiPedidoEstatusSeguimiento> list_EstatusSeguimiento = GetClienteEdiPedidoEstatusSeguimiento(ClienteEdiPedidoId, empresa);

            if (list_EstatusSeguimiento.Count > 0)
            {
                kdtGrid_EstatusSeguimiento.DataSource = list_EstatusSeguimiento.Select(s => new
                {

                    ClienteEdiPedidoEstatusSeguimientoId = s.ClienteEdiPedidoEstatusSeguimientoId,
                    ClienteEdiEstatus = s.ClienteEdiEstatusId + " - " + s.NombreClienteEdiEstatus,
                    Fecha = s.Fecha.ToString()

                }).ToList();
            }
        }

        public void SetClienteConfiguracion(string db)
        {
            List<ConfiguracionCliente> list_EstatusSeguimiento = GetCLientesConfiguracion(db);

            if (list_EstatusSeguimiento.Count > 0)
            {
                kdtGrid_EstatusSeguimiento.DataSource = list_EstatusSeguimiento.Select(s => new
                {

                    ClienteEdiConfiguracionId = s.ClienteEdiConfiguracionId,
                    Empresa = s.descripcion,
                    DataBase = s.SQL.ToString()

                }).ToList();
            }

        }


        #endregion

        #region Get_Informacion

        public List<ClienteEdiPedido> GetClienteEdiPedidoShipment(Int64 Shipment, string empresa)
        {
            DataAccess_ClienteEdiPedido dataAccess_ClienteEdiPedido = new DataAccess_ClienteEdiPedido();

            return dataAccess_ClienteEdiPedido.GetClienteEdiPedidoShipment(Shipment, empresa);
        }
        public ClienteEdiPedido GetClienteEdiPedido(int ClienteEdiPedidoId, string empresa)
        {
            DataAccess_ClienteEdiPedido dataAccess_ClienteEdiPedido = new DataAccess_ClienteEdiPedido();

            return dataAccess_ClienteEdiPedido.GetClienteEdiPedido(ClienteEdiPedidoId, empresa);
        }

        public PedidoRelacionado GetPedidoRelacionado(int ClienteEdiPedidoId, string sqldb)
        {
            DataAccess_PedidoRelacionado dataAccess_PedidoRelacionado = new DataAccess_PedidoRelacionado();

            return dataAccess_PedidoRelacionado.GetPedidoRelacionado(ClienteEdiPedidoId, sqldb);
        }

        public PedidoRelacionado GetDesp_pedido_edi(int ClienteEdiPedidoId, string db)
        {
            DataAccess_PedidoRelacionado dataAccess_PedidoRelacionado = new DataAccess_PedidoRelacionado();

            return dataAccess_PedidoRelacionado.GetDesp_pedido_edi(ClienteEdiPedidoId, db);
        }

        public PedidoRelacionado GetDesp_pedido_viaje(int ClienteEdiPedidoId, string db)
        {
            DataAccess_PedidoRelacionado dataAccess_PedidoRelacionado = new DataAccess_PedidoRelacionado();

            return dataAccess_PedidoRelacionado.GetDesp_pedido_viaje(ClienteEdiPedidoId, db);
        }

        public List<ClienteLis> GetClienteLis(List<ClienteLis> lista_cliente, string db)
        {
            DataAccess_ClienteLis dataAccess_ClienteLis = new DataAccess_ClienteLis();

            return dataAccess_ClienteLis.GetClienteLis(lista_cliente, db);
        }

        public List<ClienteEdiNotificaEvento> GetClienteEdiNotificaEvento(int ClienteEdiPedidoId, string empresa)
        {
            DataAccess_ClienteEdiPedido clienteEdiPedido = new DataAccess_ClienteEdiPedido();

            return clienteEdiPedido.GetClienteEdiNotificaEvento(ClienteEdiPedidoId, empresa);
        }

        public List<ClienteEdiNotificaEventoApp> GetClienteEdiNotificaEventoAppMob(int no_viaje,int ClienteEdiPedidoId, string sqldb)
        {
            DataAccess_ClienteEdiPedido clienteEdiPedido = new DataAccess_ClienteEdiPedido();

            return clienteEdiPedido.GetClienteEdiNotificaEventoAppMobil(no_viaje, ClienteEdiPedidoId, sqldb);
        }


        public unidad_Viaje GetUnidadSatelite(int no_viaje, string db)
        {
            DataAccess_ClienteLis dataAccess_ClienteLis = new DataAccess_ClienteLis();

            return dataAccess_ClienteLis.GetUnidad( no_viaje, db);
        }

        public List<posicion_unidad> GetPosicionUnidad(int no_viaje, string db)
        {
            DataAccess_ClienteEdiPedido dataAccess_ClienteEdiPedido = new DataAccess_ClienteEdiPedido();

            return dataAccess_ClienteEdiPedido.GetPosicion_Unidad(no_viaje, db);
        }

        public List<ClienteEdiPedidoEstatusSeguimiento> GetClienteEdiPedidoEstatusSeguimiento(int ClienteEdiPedidoId, string empresa)
        {
            DataAccess_ClienteEdiPedido dataAccess_ClienteEdiPedido = new DataAccess_ClienteEdiPedido();

            return dataAccess_ClienteEdiPedido.GetClienteEdiPedidoEstatusSeguimiento(ClienteEdiPedidoId, empresa);
        }

        public List<ClienteEdiPedidoDireccion> GetClienteEdiPedidoDireccion(int ClienteEdiPedidoId, string empresa)
        {
            DataAccess_ClienteEdiPedido dataAccess_ClienteEdiPedido = new DataAccess_ClienteEdiPedido();

            return dataAccess_ClienteEdiPedido.GetClienteEdiPedidoDireccion(ClienteEdiPedidoId, empresa);
        }

        public List<ConfiguracionCliente> GetCLientesConfiguracion(string db)
        {
            DataAccess_ClienteEdiPedido dataAccess_ClienteEdiPedido = new DataAccess_ClienteEdiPedido();

            return dataAccess_ClienteEdiPedido.GetClienteEdiConfiguracion(db);
        }

        public ClienteEdiArchivo GetClienteArchivo(Int64 ClienteEdiPedidoId, string db)
        {
            DataAccess_ClienteEdiArchivo dataAccess_ClienteEdiArchivo = new DataAccess_ClienteEdiArchivo();

            return dataAccess_ClienteEdiArchivo.GetClienteArchivo(ClienteEdiPedidoId, db);
        }

        #endregion

        public void limpiar()
        {
            foreach (Control item in this.Controls)
            {
                if (item.Controls.Count > 0)
                {
                    foreach (Control subitem in item.Controls)
                    {
                        if (subitem.AccessibilityObject.Role == AccessibleRole.Text || subitem.AccessibilityObject.Role == AccessibleRole.Table || subitem.AccessibilityObject.Role == AccessibleRole.List)
                            subitem.AccessibilityObject.Value = null;

                        subitem.BackColor = Color.Empty;
                    }
                }
                else if (item.AccessibilityObject.Role == AccessibleRole.Table || item.AccessibilityObject.Role == AccessibleRole.List)
                {
                    if (item.Name != "txtClienteEdiPedidoId")
                        item.AccessibilityObject.Value = null;

                    item.BackColor = Color.Empty;
                }
            }

            kdtGrid_EstatusSeguimiento.DataSource = null;
            kdtGrid_EventosReportados.DataSource = null;
            kdtGrid_PedidoDireccion.DataSource = null;
            kdgvEventosReportadosAppMobil.DataSource = null;
            kryptonDataGridView1.DataSource = null;
        }

        public void MarcarInformacionInvalida()
        {
            foreach (Control item in this.Controls)
            {
                if (item.Controls.Count > 0)
                {
                    foreach (Control subitem in item.Controls)
                    {
                        if (subitem.AccessibilityObject.Role == AccessibleRole.Text && string.IsNullOrEmpty(subitem.AccessibilityObject.Value))
                            subitem.BackColor = Color.Red;

                        // Validar que el cliente tenga una geocerca relacionada en lugar de un sitio
                        //if (subitem.Name.Contains("txtTipoSitio") && subitem.AccessibilityObject.Value == "1" || subitem.AccessibilityObject.Value == "0")
                        //    subitem.BackColor = Color.Red;

                        // Valida que el campo de descripcion diga CLIENTE o El campo aparece vacio entonces marcara como error
                        if (subitem.Name.Contains("txtSitio") && subitem.AccessibilityObject.Value != "CLIENTE")
                            subitem.BackColor = Color.Red;
                    }
                }

                else if (item.AccessibilityObject.Role == AccessibleRole.Text && item.AccessibilityObject.Value == "" && item.Name != "txtClienteEdiPedidoId")
                {
                    item.BackColor = Color.Red;
                }
            }
        }


        // Evento para reportar los Eventos Reportados
        private void dtGrid_EventosReportados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                kdtGrid_EventosReportados.Enabled = false;
                Thread hilo_leerArchivos = new Thread(new ParameterizedThreadStart(LeerArchivoServidor));
                hilo_leerArchivos.Start(e.RowIndex);
            }
        }

        // Lectura de los datos una vez dado el CLICK
        private void LeerArchivoServidor(Object Parametros)
        {

            int RowIndex = (int)Parametros;
            string nombreArchivo = "";


            if (RowIndex != -1)
            {
                nombreArchivo = kdtGrid_EventosReportados.Rows[RowIndex].Cells[6].Value.ToString();
                TxtFormatoTexto.Text = nombreArchivo;
                btnTexto.PerformClick();
                kdtGrid_EventosReportados.Enabled = true;
            }
        }

        private void lbl824_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtClienteEdiPedidoId.Text))
            {
                var frm = new PopUpInfoEdi(Convert.ToInt32(txtClienteEdiPedidoId.Text), "824", cboEmpresa.SelectedValue.ToString());
                frm.Show();
            }
            else
            {
                MessageBox.Show("No hay pedido EDI ingresado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lblUnidad_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUnidad.Text))
            {
                MessageBox.Show("Unidad pendiente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (string.IsNullOrEmpty(txtSatelite.Text))
            {
                MessageBox.Show("La unidad no cuenta con antena relacionada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var frm = new PosicionUnidad(cboEmpresa.SelectedValue.ToString(), txtUnidad.Text, Convert.ToDateTime(txtFechaInicioViaje.Text));
                frm.Show();
            }
        }

        private void btnArchivo204_Click(object sender, EventArgs e)
        {
            if (rbtnArchivoId.Checked)
            {
                // Obtener archivo y contenido 204
                Int64 ClienteEdiPedidoId;
                string db = cboEmpresa.SelectedValue.ToString();

                if (string.IsNullOrEmpty(txtClienteEdiPedidoId.Text))
                {
                    MessageBox.Show(" El campo ArchivoId es requerido ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var isNumber = Int64.TryParse(txtClienteEdiPedidoId.Text, out ClienteEdiPedidoId);
                if (!isNumber)
                {
                    MessageBox.Show("ArchivoId no valido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtClienteEdiPedidoId.Clear();
                    return;
                }

                var ediArchivo = GetClienteArchivo(ClienteEdiPedidoId, db);

                if ( ediArchivo != null )
                {
                    //Enviar al formulario principal
                    TxtFormatoTexto.Text = ediArchivo.TextoClienteEdiArchivo;
                    btnTexto.PerformClick();
                    lblNombreArchivo.Text = $"{ediArchivo.NomClienteEdiArchivo} + ( {ediArchivo.FechaIngreso.ToString("dd/MM/yyyy HH:mm")} )";
                }
                else
                {
                    MessageBox.Show(" No se encontro informacion del archivo ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show(" Debe seleccionar la opcion de: ArchivoId ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
