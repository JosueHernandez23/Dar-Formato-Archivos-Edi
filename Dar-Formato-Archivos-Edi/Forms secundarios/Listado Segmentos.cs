using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dar_Formato_Archivos_Edi.DataAccess.DataAccess_ClienteEdiConfiguracion;
using Dar_Formato_Archivos_Edi.Clases.ClienteEdiConfiguracion;
using Dar_Formato_Archivos_Edi.Clases.ClienteEdiTipoArchivo;
using Dar_Formato_Archivos_Edi.Clases.ClienteEdiConfiguracionArchivo_Segmentos;
using Dar_Formato_Archivos_Edi.DataAccess.DataAccess_TipoArchivo;
using Dar_Formato_Archivos_Edi.DataAccess.DataAccess_Form_ListadoSegmentos;

namespace Dar_Formato_Archivos_Edi.Forms_secundarios
{
    public partial class Listado_Segmentos : Form
    {
        public Listado_Segmentos()
        {
            InitializeComponent();
            cboClientes.DataSource = Listado_ClienteEdiConfiguracion();
            cboClientes.ValueMember = "ClienteEdiConfiguracionId";
            cboClientes.DisplayMember = "descripcion";

            cboTipoArchivo.DataSource = Listado_ClienteEdiTipoArchivo();
            cboTipoArchivo.ValueMember = "ClienteEdiTipoArchivoId";
            cboTipoArchivo.DisplayMember = "Nombre";

            ConfigButtonEfects();
        }

        private void btnSelectClienteSegmento_Click(object sender, EventArgs e)
        {
            dtDatos.DataSource = Listado_ClienteEdiConfiguracionArchivo_Segmentos(Convert.ToInt32(cboClientes.SelectedValue), Convert.ToInt32(cboTipoArchivo.SelectedValue));
            dtDatos.AutoResizeColumns();
        }

        // Efecto Hover
        public void ConfigButtonEfects()
        {
            //var la =  Controls.Cast<Control>().ToList().Where(vl => vl.Text == "");
            //Button[] bb = Controls.OfType<Button>().ToArray();

            //Botones del menu
            List<Button> ArrButtons = tableLayoutPanel2.Controls.OfType<Button>().ToList();
            //Botones para mostrar la informacion del texto
            //ArrButtons.AddRange(tableLayoutPanel3.Controls.OfType<Button>().ToList());


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

        public List<ClienteEdiConfiguracion> Listado_ClienteEdiConfiguracion()
        {
            DataAccess_ClienteEdiConfiguracion OCEC = new DataAccess_ClienteEdiConfiguracion();

            return OCEC.ListadoClienteEdiConfiguracion();
        }

        public List<ClienteEdiTipoArchivo> Listado_ClienteEdiTipoArchivo()
        {
            DataAccess_TipoArchivo DTA = new DataAccess_TipoArchivo();

            return DTA.Listado_TipoArchivo();
        }

        public List<ClienteEdiArchivoConfiguracion_Segmentos> Listado_ClienteEdiConfiguracionArchivo_Segmentos(int ClienteEdiConfiguracionId, int ClienteEdiTipoArchivoId)
        {
            DataAccess_Form_ListadoSegmentos AFL = new DataAccess_Form_ListadoSegmentos();

            return AFL.Listado_ClienteEdiArchivoConfiguracion_Segmentos(ClienteEdiConfiguracionId, ClienteEdiTipoArchivoId);
        }

        private void BtnConfigurarSegmentos_Click(object sender, EventArgs e)
        {
            this.Close();
            
            var f = new Configuracion_Segmentos();
            f.Show();
        }
    }
}
