using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dar_Formato_Archivos_Edi.Controllers;
using Dar_Formato_Archivos_Edi.Clases.ClienteEdiConfiguracion;
using Dar_Formato_Archivos_Edi.Clases.ClienteEdiTipoArchivo;
using Dar_Formato_Archivos_Edi.Clases.ClienteEdiConfiguracionArchivo_Segmentos;
using Dar_Formato_Archivos_Edi.DataAccess;

namespace Dar_Formato_Archivos_Edi
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
        }

        private void btnSelectClienteSegmento_Click(object sender, EventArgs e)
        {
            dtDatos.DataSource = Listado_ClienteEdiConfiguracionArchivo_Segmentos(Convert.ToInt32(cboClientes.SelectedValue), Convert.ToInt32(cboTipoArchivo.SelectedValue));
            dtDatos.AutoResizeColumns();
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
    }
}
