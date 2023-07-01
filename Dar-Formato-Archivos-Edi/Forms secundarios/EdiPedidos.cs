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

namespace Dar_Formato_Archivos_Edi.Forms_secundarios
{
    public partial class EdiPedidos : Form
    {

        public RichTextBox TxtFormatoTexto;
        public EdiPedidos(RichTextBox e)
        {
            this.TxtFormatoTexto = e;

            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            groupBox1.ForeColor = Color.White;
            groupBox2.ForeColor = Color.White;
            groupBox3.ForeColor = Color.White;

            kdgvEventosReportadosAppMobil.ForeColor = Color.Black;

            new List<Label>() { lbl824, lbl997 }.ForEach(lbls =>
            {
                lbls.MouseHover += HoverEnter;
            });
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
                int ClienteEdiPedidoId = Convert.ToInt32(txtClienteEdiPedidoId.Text);
                //int Viaje = Convert.ToInt32(txtViaje);
                ClienteEdiPedido cep = SetClienteEdiEstatus(ClienteEdiPedidoId);

                // Llenar textbox con Informacion de la relacion
                SetInformacionRelacion(ClienteEdiPedidoId, cep.SQL_DB);

                // Llenar DataGrid con informacion ClienteEdiPedidoDireccion
                SetClienteEdiPedidoDireccion(ClienteEdiPedidoId);

                // Llenar DataGrid con informacion ClienteEdiNotificaEvento
                SetClienteEdiNotificaEvento(ClienteEdiPedidoId);

                // Llenar DataGrid con informacion ClienteEdiNotificaEvento
                SetClienteEdiEstatusSeguimiento(ClienteEdiPedidoId);

                //Marcar textbox en rojo para la informacion pendiente
                MarcarInformacionInvalida();
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Ocurrio un error: " + ex.Message);
            }
        }

        #region Set_Informacion
        public ClienteEdiPedido SetClienteEdiEstatus(int ClienteEdiPedidoId)
        {

            // Obtener Estatus Edi
            ClienteEdiPedido clienteEdiPedido = GetClienteEdiPedido(ClienteEdiPedidoId);

            txtEstatus.Text = clienteEdiPedido.EstatusId.ToString() + " - " + clienteEdiPedido.Estatus;
            txtSCAC.Text = clienteEdiPedido.SCAC;
            txtFechaIngreso.Text = clienteEdiPedido.FechaIngreso.ToString();
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
                pedidoRelacionado = GetPedidoRelacionado(ClienteEdiPedidoId);
            }

            if (pedidoRelacionado != null)
            {
                // Obtener viaje de la tabla desp_pedido
                if (pedidoRelacionado.id_pedido > 0 && pedidoRelacionado.no_viaje == 0 && sqldb != "chdb_lis")
                {
                    pedidoRelacionado = GetDesp_pedido_viaje(ClienteEdiPedidoId, sqldb);
                }

                pedidoRelacionado.ClienteEdiPedidoId = ClienteEdiPedidoId;
                txtPedido.Text = pedidoRelacionado.id_pedido.ToString();
                txtViaje.Text = pedidoRelacionado.no_viaje.ToString();
                txtClienteEdiPedidoId.Text = pedidoRelacionado.ClienteEdiPedidoId.ToString();



                // Llenar DataGrid con informacion ClienteEdiNotificaEvento
                SetClienteEdiNotificaEventoAppMobil(Convert.ToInt32(txtViaje.Text),(Convert.ToInt32(txtClienteEdiPedidoId.Text)));

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
                            txtTipoSitioRem.Text = item.tipositio.ToString();
                            txtSiteIDRem.Text = item.siteID == null ? "" : item.siteID.ToString();
                            txtNombreSitioRem.Text = item.ubicacion == null ? "" : item.ubicacion.ToString();
                            txtSitioRemDesc.Text = item.descripcion;
                            break;
                        case "Remitente Ext":
                            txtRemitenteAlt.Text = item.id_cliente.ToString() + " - " + item.nombre_cliente;
                            txtTipoSitioRemAlt.Text = item.tipositio.ToString();
                            txtSiteIDRemAlt.Text = item.siteID == null ? "" : item.siteID.ToString();
                            txtNombreSitioRemAlt.Text = item.ubicacion == null ? "" : item.ubicacion.ToString();
                            txtSitioRemAltDesc.Text = item.descripcion;
                            break;
                        case "Destinatario":
                            txtDestinatario.Text = item.id_cliente.ToString() + " - " + item.nombre_cliente;
                            txtTipoSitioDest.Text = item.tipositio.ToString();
                            txtSiteIDDest.Text = item.siteID == null ? "" : item.siteID.ToString();
                            txtNombreSitioDest.Text = item.ubicacion == null ? "" : item.ubicacion.ToString();
                            txtSitioDestDesc.Text = item.descripcion;
                            break;
                        case "Destinatario Ext":
                            txtDestinatarioAlt.Text = item.id_cliente.ToString() + " - " + item.nombre_cliente;
                            txtTipoSitioDestAlt.Text = item.tipositio.ToString();
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
                    txtFechaInicioViaje.Text = cUnidad.fecha_real_viaje.ToString();
                    txtFechaFinViaje.Text = cUnidad.fecha_real_fin_viaje.ToString();
                    txtEstatusViaje.Text = cUnidad.status_viaje;

                    //Llenado en DataGridView
                    List<posicion_unidad> posicion = GetPosicionUnidad(Convert.ToInt32(pedidoRelacionado.no_viaje), sqldb);
                    //dgvPosicionUnidad.DataSource = posicion;
                    kryptonDataGridView1.DataSource = posicion;

                    // Organizar el espacio de las celdas y columnas del grid de las posiciones de la unidad con el viaje

                    //ubicacion
                    kryptonDataGridView1.AutoResizeColumn(1, DataGridViewAutoSizeColumnMode.AllCellsExceptHeader);
                    //posdate
                    kryptonDataGridView1.AutoResizeColumn(2, DataGridViewAutoSizeColumnMode.AllCellsExceptHeader);
                    // Sistema_origen
                    kryptonDataGridView1.AutoResizeColumn(3, DataGridViewAutoSizeColumnMode.AllCellsExceptHeader);
                    // posdate_inserto
                    kryptonDataGridView1.AutoResizeColumn(4, DataGridViewAutoSizeColumnMode.AllCellsExceptHeader);
                }
                else
                {
                    txtUnidad.Text = " Revisar estatus del viaje ";
                    txtSatelite.Text = " Revisar estatus del viaje ";
                }
            }
        }

        public void SetClienteEdiPedidoDireccion(int ClienteEdiPedidoId)
        {
            List<ClienteEdiPedidoDireccion> list_PedidoDireccion = GetClienteEdiPedidoDireccion(ClienteEdiPedidoId);

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
                    FechaEntrada = s.FechaEntrada.ToString(),
                    FechaSalida = s.FechaSalida.ToString(),
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

        public void SetClienteEdiNotificaEvento(int ClienteEdiPedidoId) // Se reportan los eventos en la tabla principal
        {
            List<ClienteEdiNotificaEvento> listado_NotificaEvento = GetClienteEdiNotificaEvento(ClienteEdiPedidoId);

            // Obtener informacion ClienteEdiNotificaEvento
            if (listado_NotificaEvento.Count > 0)
            {
                kdtGrid_EventosReportados.DataSource = listado_NotificaEvento.Select(s => new
                {
                    ClienteEdiNotificaEventoId = s.ClienteEdiNotificaEventoId,
                    Evento = s.EventoId + " - " + s.Evento,
                    FechaIngreso = s.FechaIngreso.ToString(),
                    //PedidoDireccionId = s.ClienteEdiPedidoDireccionId,
                    Caso = s.caso,
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
                // Texto214
                kdtGrid_EventosReportados.AutoResizeColumn(4, DataGridViewAutoSizeColumnMode.ColumnHeader);
            }
        }


        public void SetClienteEdiNotificaEventoAppMobil(int no_viaje, int ClienteEdiPedidoId)
        {
            List<ClienteEdiNotificaEventoApp> listado_NotificaEventoApp = GetClienteEdiNotificaEventoAppMob(no_viaje, ClienteEdiPedidoId);

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

        public void SetClienteEdiEstatusSeguimiento(int ClienteEdiPedidoId)
        {
            List<ClienteEdiPedidoEstatusSeguimiento> list_EstatusSeguimiento = GetClienteEdiPedidoEstatusSeguimiento(ClienteEdiPedidoId);

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

        public ClienteEdiPedido GetClienteEdiPedido(int ClienteEdiPedidoId)
        {
            DataAccess_ClienteEdiPedido dataAccess_ClienteEdiPedido = new DataAccess_ClienteEdiPedido();

            return dataAccess_ClienteEdiPedido.GetClienteEdiPedido(ClienteEdiPedidoId);
        }

        public PedidoRelacionado GetPedidoRelacionado(int ClienteEdiPedidoId)
        {
            DataAccess_PedidoRelacionado dataAccess_PedidoRelacionado = new DataAccess_PedidoRelacionado();

            return dataAccess_PedidoRelacionado.GetPedidoRelacionado(ClienteEdiPedidoId);
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

        public List<ClienteEdiNotificaEvento> GetClienteEdiNotificaEvento(int ClienteEdiPedidoId)
        {
            DataAccess_ClienteEdiPedido clienteEdiPedido = new DataAccess_ClienteEdiPedido();

            return clienteEdiPedido.GetClienteEdiNotificaEvento(ClienteEdiPedidoId);
        }

        public List<ClienteEdiNotificaEventoApp> GetClienteEdiNotificaEventoAppMob(int no_viaje,int ClienteEdiPedidoId)
        {
            DataAccess_ClienteEdiPedido clienteEdiPedido = new DataAccess_ClienteEdiPedido();

            return clienteEdiPedido.GetClienteEdiNotificaEventoAppMobil(no_viaje, ClienteEdiPedidoId);
        }


        public unidad_Viaje GetUnidadSatelite(int no_viaje, string db)
        {
            DataAccess_ClienteLis dataAccess_ClienteLis = new DataAccess_ClienteLis();

            return dataAccess_ClienteLis.GetUnidad(no_viaje, db);
        }

        public List<posicion_unidad> GetPosicionUnidad(int no_viaje, string db)
        {
            DataAccess_ClienteEdiPedido dataAccess_ClienteEdiPedido = new DataAccess_ClienteEdiPedido();

            return dataAccess_ClienteEdiPedido.GetPosicion_Unidad(no_viaje, db);
        }

        public List<ClienteEdiPedidoEstatusSeguimiento> GetClienteEdiPedidoEstatusSeguimiento(int ClienteEdiPedidoId)
        {
            DataAccess_ClienteEdiPedido dataAccess_ClienteEdiPedido = new DataAccess_ClienteEdiPedido();

            return dataAccess_ClienteEdiPedido.GetClienteEdiPedidoEstatusSeguimiento(ClienteEdiPedidoId);
        }

        public List<ClienteEdiPedidoDireccion> GetClienteEdiPedidoDireccion(int ClienteEdiPedidoId)
        {
            DataAccess_ClienteEdiPedido dataAccess_ClienteEdiPedido = new DataAccess_ClienteEdiPedido();

            return dataAccess_ClienteEdiPedido.GetClienteEdiPedidoDireccion(ClienteEdiPedidoId);
        }

        public List<ConfiguracionCliente> GetCLientesConfiguracion(string db)
        {
            DataAccess_ClienteEdiPedido dataAccess_ClienteEdiPedido = new DataAccess_ClienteEdiPedido();

            return dataAccess_ClienteEdiPedido.GetClienteEdiConfiguracion(db);
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
                        if (subitem.AccessibilityObject.Role == AccessibleRole.Text && subitem.AccessibilityObject.Value == "")
                            subitem.BackColor = Color.Red;

                        // Validar que el cliente tenga una geocerca relacionada en lugar de un sitio
                        if (subitem.Name.Contains("txtTipoSitio") && subitem.AccessibilityObject.Value == "1" || subitem.AccessibilityObject.Value == "0")
                            subitem.BackColor = Color.Red;
                    }
                }

                else if (item.AccessibilityObject.Role == AccessibleRole.Text && item.AccessibilityObject.Value == "" && item.Name != "txtClienteEdiPedidoId")
                {
                    item.BackColor = Color.Red;
                }
            }
        }

        public void WhiteMode()
        {
            // Fondo del form: Blanco
            this.BackColor = Color.White;

            foreach (Control item in this.Controls)
            {
                switch (item.AccessibilityObject.Role)
                {
                    case AccessibleRole.Text:
                        item.ForeColor = Color.Black;
                        break;
                    case AccessibleRole.Table:
                        item.ForeColor = Color.Black;
                        break;

                    default:
                        item.ForeColor = Color.Black;
                        break;
                }
            }
        }

        public void BlackMode()
        {
            // Fondo del form: Blanco
            this.BackColor = Color.Black;

            foreach (Control item in this.Controls)
            {
                switch (item.AccessibilityObject.Role)
                {
                    case AccessibleRole.Text:
                        item.ForeColor = Color.Black;
                        break;
                    case AccessibleRole.Table:
                        item.ForeColor = Color.Black;
                        break;

                    default:
                        item.ForeColor = Color.White;
                        break;
                }
            }
        }

        public void CustomMode(Color Back, Color Fore)
        {
            // Fondo del form: Blanco
            this.BackColor = Back;

            foreach (Control item in this.Controls)
            {
                switch (item.AccessibilityObject.Role)
                {
                    case AccessibleRole.Text:
                        item.ForeColor = Fore;
                        break;
                    case AccessibleRole.Table:
                        item.ForeColor = Fore;
                        break;

                    default:
                        item.ForeColor = Fore;
                        break;
                }
            }
        }

        public void CustomModeARGB(byte[] BackArgb, byte[] BodyForeArgb, byte[] TitleContentArgb)
        {

            List<Control> listado_Controles = new List<Control>();

            foreach (Control item in Controls)
            {
                if (item.Controls.Count > 0)
                {
                    foreach (Control SubItem in item.Controls)
                    {
                        listado_Controles.Add(SubItem);
                    }
                }
                else
                {
                    listado_Controles.Add(item);
                }
            }

            // Fondo del form: Blanco
            this.BackColor = Color.FromArgb(BackArgb[0], BackArgb[1], BackArgb[2], BackArgb[3]);

            foreach (Control item in listado_Controles)
            {
                switch (item.GetType().Name)
                {
                    case "TextBox":
                        item.ForeColor = Color.FromArgb(BodyForeArgb[0], BodyForeArgb[1], BodyForeArgb[2], BodyForeArgb[3]);
                        break;
                    case "DataGridView":
                        item.ForeColor = Color.FromArgb(BodyForeArgb[0], BodyForeArgb[1], BodyForeArgb[2], BodyForeArgb[3]);
                        break;
                    case "Label":
                        item.ForeColor = Color.FromArgb(BodyForeArgb[0], BodyForeArgb[1], BodyForeArgb[2], BodyForeArgb[3]);
                        break;

                    default:
                        item.ForeColor = Color.FromArgb(BodyForeArgb[0], BodyForeArgb[1], BodyForeArgb[2], BodyForeArgb[3]);
                        break;
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
                nombreArchivo = kdtGrid_EventosReportados.Rows[RowIndex].Cells[3].Value.ToString();
                TxtFormatoTexto.Text = nombreArchivo;
                kdtGrid_EventosReportados.Enabled = true;
            }
        }

        private void dtGrid_EventosReportados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lbl824_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtClienteEdiPedidoId.Text))
            {
                var frm = new PopUpInfoEdi(Convert.ToInt32(txtClienteEdiPedidoId.Text), "824");
                frm.Show();
            }
            else
            {
                MessageBox.Show("No hay pedido EDI ingresado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
