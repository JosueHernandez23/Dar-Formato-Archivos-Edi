using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dar_Formato_Archivos_Edi.Clases.ClienteEdiConfiguracion;
using Dar_Formato_Archivos_Edi.Clases.ClienteEdiTipoArchivo;
using Dar_Formato_Archivos_Edi.Clases.ClienteEdiSegmentos;
using Dar_Formato_Archivos_Edi.Clases.ClienteEdiConfiguracionArchivo_Segmentos;
using Dar_Formato_Archivos_Edi.DataAccess.DataAccess_ClienteEdiConfiguracion;
using Dar_Formato_Archivos_Edi.DataAccess.DataAccess_TipoArchivo;
using Dar_Formato_Archivos_Edi.DataAccess.DataAccess_Form_ListadoSegmentos;
using Dar_Formato_Archivos_Edi.Properties;
using System.Threading;

namespace Dar_Formato_Archivos_Edi.Forms_secundarios
{
    public partial class Configuracion_Segmentos : Form
    {
        List<ClienteEdiArchivoConfiguracion_Segmentos> SegmentosConfig = new List<ClienteEdiArchivoConfiguracion_Segmentos>();
        List<ClienteEdiSegmentos> List_ClienteEdiSegmentos;
        public Configuracion_Segmentos()
        {
            InitializeComponent();
            ConfigButtonEfects();
            CheckForIllegalCrossThreadCalls = false;

            List_ClienteEdiSegmentos = Listado_Segmentos();

            Cbo_Cliente.DataSource = ObtenerClientes();
            Cbo_Cliente.ValueMember = "ClienteEdiConfiguracionId";
            Cbo_Cliente.DisplayMember = "descripcion";

            CboTipoArchivo.DataSource = Listado_ClienteEdiTipoArchivo();
            CboTipoArchivo.ValueMember = "ClienteEdiTipoArchivoId";
            CboTipoArchivo.DisplayMember = "Nombre";

            Cbo_Segmentos.DataSource = List_ClienteEdiSegmentos;
            Cbo_Segmentos.ValueMember = "IdSegmento";
            Cbo_Segmentos.DisplayMember = "DescSegmento";

        }

        #region Obtener Informacion

        public List<ClienteEdiConfiguracion> ObtenerClientes()
        {
            DataAccess_ClienteEdiConfiguracion OCEC = new DataAccess_ClienteEdiConfiguracion();

            return OCEC.ListadoClienteEdiConfiguracion();
        }

        public List<ClienteEdiTipoArchivo> Listado_ClienteEdiTipoArchivo()
        {
            DataAccess_TipoArchivo DTA = new DataAccess_TipoArchivo();

            return DTA.Listado_TipoArchivo();
        }

        public List<ClienteEdiSegmentos> Listado_Segmentos()
        {
            DataAccess_Form_ListadoSegmentos LS = new DataAccess_Form_ListadoSegmentos();

            return LS.Listado_Segmentos();
        }

        public List<ClienteEdiArchivoConfiguracion_Segmentos> Listado_ClienteEdiConfiguracionArchivo_Segmentos(int ClienteEdiConfiguracionId, int ClienteEdiTipoArchivoId)
        {
            DataAccess_Form_ListadoSegmentos AFL = new DataAccess_Form_ListadoSegmentos();

            return AFL.Listado_ClienteEdiArchivoConfiguracion_Segmentos(ClienteEdiConfiguracionId, ClienteEdiTipoArchivoId);
        }

        public void DeleteSegmento(ClienteEdiArchivoConfiguracion_Segmentos cecs)
        {
            DataAccess_Form_ListadoSegmentos AFL = new DataAccess_Form_ListadoSegmentos();
            AFL.DeleteSegmentoCliente(cecs);
        }

        public void InsertSegmento(ClienteEdiArchivoConfiguracion_Segmentos cecs) 
        {
            DataAccess_Form_ListadoSegmentos AFL = new DataAccess_Form_ListadoSegmentos();
            AFL.InsertSegmentoCliente(cecs); 
        }

        public void UpdateSegmento(ClienteEdiArchivoConfiguracion_Segmentos cecs)
        {
            DataAccess_Form_ListadoSegmentos AFL = new DataAccess_Form_ListadoSegmentos();
            AFL.UpdateSegmentoCliente(cecs);
        }

        #endregion

        #region Efecto Hover
        public void ConfigButtonEfects()
        {
            List<Button> ArrButtons = TLayoutPanel_Botones.Controls.OfType<Button>().ToList();

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

        #endregion

        #region Eventos de Controles

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            PTB_Estatus.Image = Resources.loading;
            BtnConsultar.Enabled = false;
            DTGV_Segmentos.DataSource = null;

            new Thread(() =>
            {

                ConsultarSegmentos();

                BtnConsultar.Enabled = true;
                PTB_Estatus.Image = Resources.Complete;

            }).Start();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private void BtnOrdenar_Click(object sender, EventArgs e)
        {
            PTB_Estatus.Image = Resources.loading;
            BtnOrdenar.Enabled = false;
            DTGV_Segmentos.DataSource = null;

            new Thread(() =>
            {

                SegmentosConfig = SegmentosConfig.OrderBy(vl => vl.CA_Orden).ToList();

                DTGV_Segmentos.DataSource = SegmentosConfig;
                ConfigurarDTGV_Segmentos();

                BtnOrdenar.Enabled = true;
                PTB_Estatus.Image = Resources.Complete;

            }).Start();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private void BtnAddSegmento_Click(object sender, EventArgs e)
        {
            PTB_Estatus.Image = Resources.loading;
            DTGV_Segmentos.DataSource = null;
            BtnAddSegmento.Enabled = false;

            new Thread(() =>
            {

                ClienteEdiSegmentos ces = List_ClienteEdiSegmentos.Where(vl => vl.IdSegmento == Convert.ToInt32(Cbo_Segmentos.SelectedValue)).FirstOrDefault();

                ClienteEdiArchivoConfiguracion_Segmentos registro = new ClienteEdiArchivoConfiguracion_Segmentos()
                {
                    CA_ClienteEdiConfiguracionArchivoId = 0,
                    CA_ClienteEdiTipoArchivoId = Convert.ToInt32(CboTipoArchivo.SelectedValue),
                    CA_ClienteEdiConfiguracionId = Convert.ToInt32(Cbo_Cliente.SelectedValue),
                    CA_Orden = 0,
                    CA_Estatus_C1 = 0,
                    CA_Estatus_C2 = 0,
                    CA_Columnas12 = 0,
                    CS_IdSegmento = ces.IdSegmento,
                    CS_Nodo = ces.Nodo,
                    CS_NombreSegmento = ces.NombreSegmento
                };

                SegmentosConfig.Add(registro);
                DTGV_Segmentos.DataSource = SegmentosConfig;
                ConfigurarDTGV_Segmentos();

                BtnAddSegmento.Enabled = true;
                PTB_Estatus.Image = Resources.Complete;
            }).Start();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private void DTGV_Segmentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                int ClienteEdiConfiguracionArchvioId = SegmentosConfig[e.RowIndex].CA_ClienteEdiConfiguracionArchivoId;
                string elemento = ClienteEdiConfiguracionArchvioId.ToString() + " - " + SegmentosConfig[e.RowIndex].CS_Nodo.ToString();

                DialogResult resp = MessageBox.Show("Deseas eliminar el elemento: " + elemento, "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (resp == DialogResult.Yes)
                {
                    PTB_Estatus.Image = Resources.loading;
                    DTGV_Segmentos.DataSource = null;
                    BtnAddSegmento.Enabled = false;

                    new Thread(() =>
                    {
                        if (ClienteEdiConfiguracionArchvioId > 0)
                        {
                            // Eliminar registros que ya estan registrados en la bd
                            DeleteSegmento(SegmentosConfig[e.RowIndex]);
                        }

                        // Eliminar registros que no se ha procesado
                        SegmentosConfig.RemoveAt(e.RowIndex);

                        DTGV_Segmentos.DataSource = SegmentosConfig;
                        ConfigurarDTGV_Segmentos();

                        BtnAddSegmento.Enabled = true;
                        PTB_Estatus.Image = Resources.Complete;
                    }).Start();

                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                }
            }
            else 
            {
                MessageBox.Show("Elemento no valido");
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            PTB_Estatus.Image = Resources.loading;
            DTGV_Segmentos.DataSource = null;
            DTGV_Segmentos.Enabled = false;
            BtnGuardar.Enabled = false;

            new Thread(() =>
            {
                foreach (ClienteEdiArchivoConfiguracion_Segmentos item in SegmentosConfig)
                {
                    if (item.CA_ClienteEdiConfiguracionArchivoId == 0)
                    {
                        // Insertar
                        InsertSegmento(item);
                    }
                    else
                    {
                        // Actualizar
                        UpdateSegmento(item);
                    }
                }

                ConsultarSegmentos();

                PTB_Estatus.Image = Resources.Complete;
                DTGV_Segmentos.Enabled = true;
                BtnGuardar.Enabled = true;

                MessageBox.Show(" Se ha guardado con exito ");
            }).Start();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private void CboTipoArchivo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SegmentosConfig = new List<ClienteEdiArchivoConfiguracion_Segmentos>();
        }

        private void Cbo_Cliente_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SegmentosConfig = new List<ClienteEdiArchivoConfiguracion_Segmentos>();
        }

        #endregion

        #region Configuraciones de los controles
        public void ConfigurarDTGV_Segmentos()
        {
            DTGV_Segmentos.AutoResizeColumns();
            DTGV_Segmentos.ScrollBars = ScrollBars.Both;
            DataGridViewColumnCollection Columnas = DTGV_Segmentos.Columns;

            foreach (DataGridViewTextBoxColumn item in Columnas)
            {
                if (item.Name == "CA_Orden"
                    || item.Name == "CA_Estatus_C1"
                        || item.Name == "CA_Estatus_C2"
                            || item.Name == "CA_Columnas12"
                                || item.Name == "CA_FinSegAd")
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

        public void ConsultarSegmentos() 
        {
            SegmentosConfig = Listado_ClienteEdiConfiguracionArchivo_Segmentos(Convert.ToInt32(Cbo_Cliente.SelectedValue), Convert.ToInt32(CboTipoArchivo.SelectedValue));

            DTGV_Segmentos.DataSource = SegmentosConfig;
            ConfigurarDTGV_Segmentos();
        }

        #endregion

    }
}
