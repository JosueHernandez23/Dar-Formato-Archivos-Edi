using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Renci.SshNet;
using Dar_Formato_Archivos_Edi.Clases.ClienteEdiTipoArchivo.EdiTipoArchivoFormatos;
using Dar_Formato_Archivos_Edi.Clases.ClienteEdiConfiguracion;
using Dar_Formato_Archivos_Edi.Clases.ClienteEdiEvento;
using Dar_Formato_Archivos_Edi.Clases.ClienteEdiTipoArchivo;
using Dar_Formato_Archivos_Edi.Clases.TipoConexion;
using Dar_Formato_Archivos_Edi.DataAccess;
using System.Windows.Forms;
using Dar_Formato_Archivos_Edi.Controllers;
using System.IO;

namespace Dar_Formato_Archivos_Edi.Forms_secundarios
{
    public partial class GenerarEdi : Form
    {
        List<ClienteEdiTipoArchivo> Listado_TipoArchivo = new DataAccess_TipoArchivo().Listado_TipoArchivo();
        List<ClienteEdiEvento> Listado_Eventos = new DataAccess_ClienteEdiEvento().Listado_Eventos();
        List<ClienteEdiConfiguracion> ListadoClienteEdiConfiguracion = new DataAccess_ClienteEdiConfiguracion().ListadoClienteEdiConfiguracion();
        string Path_Archivo = "";
        public GenerarEdi()
        {
            InitializeComponent();

            CboTipoArchivo.DataSource = Listado_TipoArchivo;
            CboTipoArchivo.ValueMember = "ClienteEdiTipoArchivoId";
            CboTipoArchivo.DisplayMember = "Nombre";

            CboEvento.DataSource = Listado_Eventos;
            CboEvento.ValueMember = "ClienteEdiEventoId";
            CboEvento.DisplayMember = "NombreEvento";

            CboClienteEdiConfiguracionId.DataSource = ListadoClienteEdiConfiguracion.Select(vl => new { vl.ClienteEdiConfiguracionId, vl.descripcion }).ToList();
            CboClienteEdiConfiguracionId.ValueMember = "ClienteEdiConfiguracionId";
            CboClienteEdiConfiguracionId.DisplayMember = "descripcion";

            CboClienteEdiConfiguracionId_EnviarArchivo.DataSource = ListadoClienteEdiConfiguracion.Select(vl => new { vl.ClienteEdiConfiguracionId, vl.descripcion }).ToList();
            CboClienteEdiConfiguracionId_EnviarArchivo.ValueMember = "ClienteEdiConfiguracionId";
            CboClienteEdiConfiguracionId_EnviarArchivo.DisplayMember = "descripcion";

            cboTipoConexion.DataSource = TipoConexion.Listado_TipoConexion();
            cboTipoConexion.ValueMember = "IdTipoConexion";
            cboTipoConexion.DisplayMember = "Conexion";

        }

        private void BtnGenerarArchivoEdi_Click(object sender, EventArgs e)
        {
            try
            {
                string Evento = CboEvento.Text,
                   TipoArchivo = CboTipoArchivo.Text;

                int ClienteEdiConfiguracionId = Convert.ToInt32(CboClienteEdiConfiguracionId.SelectedValue),
                    ClienteEdiPedidoId = Convert.ToInt32(TxtClienteEdiPedidoId.Text);

                decimal Longitud = Convert.ToDecimal(TxtLatitud.Text),
                        Latitud = Convert.ToDecimal(TxtLongitud.Text);

                DateTime FechaEvento = DtpFechaEvento.Value;

                // using Dar_Formato_Archivos_Edi.Clases.ClienteEdiTipoArchivo.EdiTipoArchivoFormatos;           
                bool resultado = EdiTipoArchivoFormatos.EdiProcesoFormatoArchivo(Evento, TipoArchivo, ClienteEdiConfiguracionId, ClienteEdiPedidoId, Latitud, Longitud, FechaEvento);

                if (!resultado)
                {
                    MessageBox.Show("Ocurrio un error al generar el archivo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void CboClienteEdiConfiguracionId_EnviarArchivo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int ClienteEdiConfiguracionId = Convert.ToInt32(CboClienteEdiConfiguracionId_EnviarArchivo.SelectedValue);

            txtServer.Text = "";
            txtUser.Text = "";
            txtPassword.Text = "";

            txtServer.Text = ListadoClienteEdiConfiguracion.Where(vl => vl.ClienteEdiConfiguracionId == ClienteEdiConfiguracionId).Select(vl => vl.SFTPServerPRD).FirstOrDefault();
            txtUser.Text = ListadoClienteEdiConfiguracion.Where(vl => vl.ClienteEdiConfiguracionId == ClienteEdiConfiguracionId).Select(vl => vl.SFTPUsuarioPRD).FirstOrDefault();
            txtPassword.Text = ListadoClienteEdiConfiguracion.Where(vl => vl.ClienteEdiConfiguracionId == ClienteEdiConfiguracionId).Select(vl => vl.SFTPPasswordPRD).FirstOrDefault();
            txtFolderDestino.Text = ListadoClienteEdiConfiguracion.Where(vl => vl.ClienteEdiConfiguracionId == ClienteEdiConfiguracionId).Select(vl => vl.FolderDestino).FirstOrDefault();
        }

        private void btnSelecArchivo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog CargarArchivo = new OpenFileDialog())
            {
                CargarArchivo.InitialDirectory = "c:\\Escritorio";
                CargarArchivo.Filter = "Edi File (*.edi)|*.edi";

                if (CargarArchivo.ShowDialog() == DialogResult.OK)
                {
                    lblNombreArchivo.Text = CargarArchivo.SafeFileName;
                    Path_Archivo = CargarArchivo.FileName;
                }
            }
        }

        private void btnEnviarArchivo_Click(object sender, EventArgs e)
        {

            try
            {
                int IdTipoConexion = Convert.ToInt32(cboTipoConexion.SelectedValue);

                if (IdTipoConexion == 1) TipoConexion.CargarArchivo_SFTP(txtServer.Text, txtUser.Text, txtPassword.Text, txtFolderDestino.Text, Path_Archivo, lblNombreArchivo.Text);

                Path_Archivo = "";
                lblNombreArchivo.Text = "";

                //object obj = (
                //    Nombre: "",
                //    Apellido: "",
                //    edad: ""
                //    );

                MessageBox.Show("Archivo enviado por SFTP");
            }
            catch (Exception ex)                                                                                
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
