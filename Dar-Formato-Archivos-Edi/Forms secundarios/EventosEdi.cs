using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Dar_Formato_Archivos_Edi.Clases.ClienteEdiConfiguracion;
using Dar_Formato_Archivos_Edi.Clases.ClienteEdiEvento;
using Dar_Formato_Archivos_Edi.Clases.ClienteEdiConfiguracionEvento;
using Dar_Formato_Archivos_Edi.DataAccess.DataAccess_ClienteEdiConfiguracion;
using Dar_Formato_Archivos_Edi.DataAccess.DataAccess_ClienteEdiEvento;
using Dar_Formato_Archivos_Edi.DataAccess.DataAccess_ClienteEdiConfiguracionEvento;

namespace Dar_Formato_Archivos_Edi.Forms_secundarios
{
    public partial class EventosEdi : Form
    {
        List<ClienteEdiConfiguracionEvento> configuracionEvento = new List<ClienteEdiConfiguracionEvento>();
        public EventosEdi()
        {
            InitializeComponent();
            ConfigButtonEfects();
            InicializarPantalla();
            CheckForIllegalCrossThreadCalls = false;

            List<Button> ArrButtons = tableLayoutPanel_Params.Controls.OfType<Button>().ToList();

            foreach (Button btn in ArrButtons)
            {
                btn.BackColor = Color.FromArgb(46, 51, 73);
                btn.ForeColor = Color.White;
            }
        }

        public void InicializarPantalla()
        {
            // Obtener Clientes
            List<ClienteEdiConfiguracion> clientes = ObtenerClientes();
            //Obtener Eventos
            List<ClienteEdiEvento> eventos = ObtenerEventos();

            // Llenar ComboBox para mostrar clientes
            cboClienteEdi.DataSource = clientes;
            cboClienteEdi.ValueMember = "ClienteEdiConfiguracionId";
            cboClienteEdi.DisplayMember = "descripcion";

            // Llenar ComboBox para mostrar eventos
            cboEdiEvento.DataSource = eventos;
            cboEdiEvento.ValueMember = "ClienteEdiEventoId";
            cboEdiEvento.DisplayMember = "Descripcion";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dtGV_Data.DataSource = null;
            int cliente = Convert.ToInt32(cboClienteEdi.SelectedValue);

            new Thread(() =>
            {
                // Deshabilitar boton
                SwitchButtonState(sender);

                configuracionEvento = ObtenerConfiguracionEventos(cliente);

                dtGV_Data.DataSource = configuracionEvento;

                // Cambiar el color de las celdas que se guardaran cambios
                ConfigurarDTGV_Segmentos();

                //Habilitar boton
                SwitchButtonState(sender);
            }).Start();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            dtGV_Data.DataSource = null;
            
            new Thread(() =>
            {
                SwitchButtonState(sender);

                configuracionEvento.Add(
                    new ClienteEdiConfiguracionEvento()
                    {
                        ClienteEdiConfiguracionEventoId = 0,
                        ClienteEdiConfiguracionId = configuracionEvento.Select(vl => vl.ClienteEdiConfiguracionId).FirstOrDefault(),
                        ClienteEdiConsideraServ = 0,
                        ClienteEdiTipoServ = "",
                        ClienteEdiEventoId = Convert.ToInt32(cboEdiEvento.SelectedValue),
                        NombreEvento = cboEdiEvento.Text.Substring(0, cboEdiEvento.Text.IndexOf(" ") ),
                        Orden = 0
                    }
                );

                dtGV_Data.DataSource = configuracionEvento;

                // Cambiar el color de las celdas que se guardaran cambios
                ConfigurarDTGV_Segmentos();

                SwitchButtonState(sender);
            }).Start();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            dtGV_Data.DataSource = null;

            new Thread(() =>
            {
                SwitchButtonState(sender);

                foreach (ClienteEdiConfiguracionEvento item in configuracionEvento)
                {
                    if (item.ClienteEdiConfiguracionEventoId == 0)
                    {
                        // Insertar
                        InsertEvento(item);
                    }
                    else
                    {
                        // Actualizar
                        UpdateEvento(item);
                    }
                }

                configuracionEvento = ObtenerConfiguracionEventos(Convert.ToInt32(cboClienteEdi.SelectedValue));
                dtGV_Data.DataSource = configuracionEvento;

                SwitchButtonState(sender);

                MessageBox.Show(" Se ha guardado con exito ");
            }).Start();
        }

        #region ProcessData
        public List<ClienteEdiConfiguracion> ObtenerClientes()
        {
            DataAccess_ClienteEdiConfiguracion OCEC = new DataAccess_ClienteEdiConfiguracion();

            return OCEC.ListadoClienteEdiConfiguracion();
        }

        public List<ClienteEdiEvento> ObtenerEventos()
        {
            DataAccess_ClienteEdiEvento OCEE = new DataAccess_ClienteEdiEvento();

            return OCEE.Listado_Eventos();
        }

        public List<ClienteEdiConfiguracionEvento> ObtenerConfiguracionEventos(int cliente)
        {
            DataAccess_ClienteEdiConfiguracionEvento OCECE = new DataAccess_ClienteEdiConfiguracionEvento();

            return OCECE.Listado_Configuraciones(cliente);
        }

        public void InsertEvento(ClienteEdiConfiguracionEvento evento) 
        {
            DataAccess_ClienteEdiConfiguracionEvento OCECE = new DataAccess_ClienteEdiConfiguracionEvento();
            OCECE.InsertEvento(evento);
        }

        public void UpdateEvento(ClienteEdiConfiguracionEvento evento)
        {
            DataAccess_ClienteEdiConfiguracionEvento OCECE = new DataAccess_ClienteEdiConfiguracionEvento();
            OCECE.UpdateEvento(evento);
        }

        #endregion

        #region Config (Buttons)
        public void ConfigButtonEfects()
        {
            //Obtener botones
            List<Button> ArrButtons = tableLayoutPanel_Params.Controls.OfType<Button>().ToList();

            foreach (Button btn in ArrButtons)
            {
                btn.MouseEnter += HoverEnter;
                btn.MouseLeave += HoverLeave;
            }
        }

        public static void HoverEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.White;
            btn.ForeColor = Color.Black;
            btn.Cursor = Cursors.Hand;
        }

        public static void HoverLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.FromArgb(46, 51, 73);
            btn.ForeColor = Color.White;
        }

        public static void SwitchButtonState(object sender) 
        {
            Button btn = (Button)sender;

            btn.Enabled = btn.Enabled ? false : true;
        }

        #endregion

        public void ConfigurarDTGV_Segmentos()
        {
            dtGV_Data.AutoResizeColumns();
            dtGV_Data.ScrollBars = ScrollBars.Both;
            DataGridViewColumnCollection Columnas = dtGV_Data.Columns;

            foreach (DataGridViewTextBoxColumn item in Columnas)
            {
                if (item.Name == "ClienteEdiEventoId"
                    || item.Name == "Orden"
                        || item.Name == "ClienteEdiConsideraServ"
                            || item.Name == "ClienteEdiTipoServ")
                {
                    item.DefaultCellStyle = new DataGridViewCellStyle()
                    {
                        BackColor = Color.FromArgb(94, 229, 84),
                        Font = new Font(Font, FontStyle.Bold)
                    };
                }
                else
                {
                    item.ReadOnly = true;
                }

                if (item.Name == "CA_ClienteEdiConfiguracionId" || item.Name == "CA_ClienteEdiTipoArchivoId")
                {
                    item.Visible = false;
                }
            }
        }
    }
}
