using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace Dar_Formato_Archivos_Edi.Forms_secundarios
{
    public partial class EdiPedidos : Form
    {
        public EdiPedidos()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                limpiar();
                // Llenar textbox con informacion de Estatus Edi
                int ClienteEdiPedidoId = Convert.ToInt32(txtClienteEdiPedidoId.Text);

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

        #region Setear Informacion
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
            // Obtener Informacion de la relacion
            PedidoRelacionado pedidoRelacionado = GetPedidoRelacionado(ClienteEdiPedidoId);

            if (pedidoRelacionado != null)
            {
                txtPedido.Text = pedidoRelacionado.id_pedido.ToString();
                txtViaje.Text = pedidoRelacionado.no_viaje.ToString();

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

                if (pedidoRelacionado.no_viaje != null)
                {
                    // Obtener id_unidad y satelite
                    unidad cUnidad = GetUnidadSatelite(Convert.ToInt32(pedidoRelacionado.no_viaje), sqldb);
                    txtUnidad.Text = cUnidad.id_unidad;
                    txtSatelite.Text = cUnidad.mctNumber != null ? cUnidad.mctNumber : "";
                }
            }
        }

        public void SetClienteEdiPedidoDireccion(int ClienteEdiPedidoId)
        {
            List<ClienteEdiPedidoDireccion> list_PedidoDireccion = GetClienteEdiPedidoDireccion(ClienteEdiPedidoId);

            if (list_PedidoDireccion.Count > 0)
            {
                dtGrid_PedidoDireccion.DataSource = list_PedidoDireccion.Select(s => new {

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

        public void SetClienteEdiNotificaEvento(int ClienteEdiPedidoId) 
        {
            List<ClienteEdiNotificaEvento> listado_NotificaEvento = GetClienteEdiNotificaEvento(ClienteEdiPedidoId);

            // Obtener informacion ClienteEdiNotificaEvento
            if (listado_NotificaEvento.Count > 0)
            {
                dtGrid_EventosReportados.DataSource = listado_NotificaEvento.Select(s => new
                {

                    ClienteEdiNotificaEventoId = s.ClienteEdiNotificaEventoId,
                    Evento = s.EventoId + " - " + s.Evento,
                    FechaIngreso = s.FechaIngreso.ToString(),
                    Texto214 = s.Texto214

                }).ToList();
            }
        }

        public void SetClienteEdiEstatusSeguimiento(int ClienteEdiPedidoId)
        {
            List<ClienteEdiPedidoEstatusSeguimiento> list_EstatusSeguimiento = GetClienteEdiPedidoEstatusSeguimiento(ClienteEdiPedidoId);

            if (list_EstatusSeguimiento.Count > 0)
            {
                dtGrid_EstatusSeguimiento.DataSource = list_EstatusSeguimiento.Select(s => new { 
                
                    ClienteEdiPedidoEstatusSeguimientoId = s.ClienteEdiPedidoEstatusSeguimientoId,
                    ClienteEdiEstatus = s.ClienteEdiEstatusId + " - " + s.NombreClienteEdiEstatus,
                    Fecha = s.Fecha.ToString()

                }).ToList();
            }
        }

        #endregion

        #region Get Informacion

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

        public unidad GetUnidadSatelite(int no_viaje, string db)
        {
            DataAccess_ClienteLis dataAccess_ClienteLis = new DataAccess_ClienteLis();

            return dataAccess_ClienteLis.GetUnidad(no_viaje, db);
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
        }

        public void MarcarInformacionInvalida() 
        {
            foreach (Control item in this.Controls)
            {
                if (item.Controls.Count > 0)
                {
                    foreach (Control subitem in item.Controls)
                    {
                        if (subitem.AccessibilityObject.Role == AccessibleRole.Text && subitem.AccessibilityObject.Value == "" )
                            subitem.BackColor = Color.Red;
                    }
                }
                else if (item.AccessibilityObject.Role == AccessibleRole.Text && item.AccessibilityObject.Value == "" && item.Name != "txtClienteEdiPedidoId")
                {
                        item.BackColor = Color.Red;
                }
            }
        }
    }
}
