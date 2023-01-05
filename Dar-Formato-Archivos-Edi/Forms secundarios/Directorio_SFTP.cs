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
using Dar_Formato_Archivos_Edi.Controllers;
using Dar_Formato_Archivos_Edi.Clases.TipoConexion;
using System.Threading;
using Dar_Formato_Archivos_Edi.Properties;
using Dar_Formato_Archivos_Edi;

namespace Dar_Formato_Archivos_Edi.Forms_secundarios
{
    public partial class Directorio_SFTP : Form
    {
        public List<ClienteEdiConfiguracion> listado_clientes;
        public RichTextBox TxtFormatoTexto;
        public Label txtNombreArchivo;

        public Directorio_SFTP(RichTextBox t, Label NombreArc)
        {
            // Dar formato al archivo
            this.TxtFormatoTexto = t;
            this.txtNombreArchivo = NombreArc;
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            pbEstatus.Visible = false;

            listado_clientes = ObtenerClientesSFTP();

            cboCliente.DataSource = listado_clientes.Select(vl => new { vl.descripcion, vl.ClienteEdiConfiguracionId }).ToList();
            cboCliente.ValueMember = "ClienteEdiConfiguracionId";
            cboCliente.DisplayMember = "descripcion";

            llenarTxtCredenciales();

            cboTipoConexion.DataSource = ObtenerTipoConexion();
            cboTipoConexion.ValueMember = "IdTipoConexion";
            cboTipoConexion.DisplayMember = "Conexion";
        }

        public List<ClienteEdiConfiguracion> ObtenerClientesSFTP()
        {
            List<ClienteEdiConfiguracion> listado_Clientes = new DataAccess_ClienteEdiConfiguracion().ListadoClienteEdiConfiguracionFrom();

            return listado_Clientes;
        }

        public List<TipoConexion> ObtenerTipoConexion()
        {
            List<TipoConexion> listado_conexiones = TipoConexion.Listado_TipoConexion();

            return listado_conexiones;
        }

        public void llenarTxtCredenciales()
        {
            int ClienteEdiConfiguracionId = Convert.ToInt32(cboCliente.SelectedValue);

            txtServidor.Text = listado_clientes.Where(vl => vl.ClienteEdiConfiguracionId == ClienteEdiConfiguracionId).Select(vl => vl.SFTPServerPRD).FirstOrDefault();
            txtUserName.Text = listado_clientes.Where(vl => vl.ClienteEdiConfiguracionId == ClienteEdiConfiguracionId).Select(vl => vl.SFTPUsuarioPRD).FirstOrDefault();
            txtPassword.Text = listado_clientes.Where(vl => vl.ClienteEdiConfiguracionId == ClienteEdiConfiguracionId).Select(vl => vl.SFTPPasswordPRD).FirstOrDefault();
            txtPathOrigen.Text = listado_clientes.Where(vl => vl.ClienteEdiConfiguracionId == ClienteEdiConfiguracionId).Select(vl => vl.FolderDestino).FirstOrDefault();
        }

        // EFECTO HOVER
        private void btnConectar_MouseEnter(object sender, EventArgs e)
        {
            btnConectar.BackColor = Color.White;
            btnConectar.ForeColor = Color.Black;
            btnConectar.Cursor = Cursors.Hand;
        }

        private void btnConectar_MouseLeave(object sender, EventArgs e)
        {
            btnConectar.BackColor = Color.FromArgb(46, 51, 73);
            btnConectar.ForeColor = Color.White;
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            btnConectar.Enabled = false;
            pbEstatus.Visible = true;
            pbEstatus.Image = Resources.loading;

            Thread hilo_dtgv = new Thread(Obtener_datos_DTGV);
            hilo_dtgv.Start();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private void cboCliente_SelectionChangeCommitted(object sender, EventArgs e)
        {
            pbEstatus.Visible = false;
            llenarTxtCredenciales();
        }

        public static int ConvertToInt(string value, int defValue)
        {
            try
            {
                return Convert.ToInt32(value);
            }
            catch
            {
                return defValue;
            }
        }

        public void Obtener_datos_DTGV()
        {
            try
            {
                dtgServerFiles.DataSource = null;

                string server = txtServidor.Text;
                string user = txtUserName.Text;
                string password = txtPassword.Text;
                string path = txtPathOrigen.Text;
                int port = ConvertToInt(txtPort.Text, 22);

                // SFTP
                if (Convert.ToInt32(cboTipoConexion.SelectedValue) == 1)
                {
                    IEnumerable<Renci.SshNet.Sftp.SftpFile> lista_archivos = new TipoConexion().ListarArchivos_SFTP(server, user, password, port, path);
                    dtgServerFiles.DataSource = lista_archivos;
                    dtgServerFiles.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                // FTP
                if (Convert.ToInt32(cboTipoConexion.SelectedValue) == 2)
                {
                    IEnumerable<FluentFTP.FtpListItem> lista_archivos = new TipoConexion().ListarArchivos_FTP(server, user, password, port, path);
                    dtgServerFiles.DataSource = lista_archivos;
                    dtgServerFiles.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error: " + ex.Message);
            }
            finally
            {
                btnConectar.Enabled = true;
                pbEstatus.Visible = true;
                pbEstatus.Image = Resources.Complete;
            }
        }

        private void dtgServerFiles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                pbEstatus.Image = Resources.loading;
                dtgServerFiles.Enabled = false;
                Thread hilo_leerArchivos = new Thread(new ParameterizedThreadStart(LeerArchivoServidor));
                hilo_leerArchivos.Start(e.RowIndex);
            }
        }

        private void LeerArchivoServidor(Object Parametros) 
        {

            int RowIndex = (int)Parametros;

            if (RowIndex != -1)
            {
                string contenido = "";
                string server = txtServidor.Text;
                string user = txtUserName.Text;
                string password = txtPassword.Text;
                string path = txtPathOrigen.Text;
                string nombreArchivo = "";
                int port = ConvertToInt(txtPort.Text, 22);

                // SFTP
                if (Convert.ToInt32(cboTipoConexion.SelectedValue) == 1)
                {
                    nombreArchivo = dtgServerFiles.Rows[RowIndex].Cells[2].Value.ToString();

                    string FullName = dtgServerFiles.Rows[RowIndex].Cells[1].Value.ToString();

                    contenido = TipoConexion.RevisarContenidoArchivo_SFTP(server, user, password, port, FullName);

                }
                // FTP
                if (Convert.ToInt32(cboTipoConexion.SelectedValue) == 2)
                {
                    nombreArchivo = dtgServerFiles.Rows[RowIndex].Cells[3].Value.ToString();

                    string FullName = dtgServerFiles.Rows[RowIndex].Cells[2].Value.ToString();

                    contenido = TipoConexion.RevisarContenidoArchivo_FTP(server, user, password, port, FullName);
                }

                string segmento = ObtenerSegmento(contenido);

                pbEstatus.Image = Resources.Complete;
                TxtFormatoTexto.Text = DarFormatoTexto(contenido, segmento);
                txtNombreArchivo.Text = nombreArchivo;
                dtgServerFiles.Enabled = true;
            }
        }

        private string ObtenerSegmento(string textoArchivo)
        {
            try
            {
                int lenghtTexto = textoArchivo.Trim().Length;

                string valorSegmento = (textoArchivo.Substring(lenghtTexto - 1, 1)).Trim();

                return valorSegmento;
            }

            catch
            {
                return "";
            }
        }

        private string DarFormatoTexto(string textoArchivo, string segmento)
        {
            string[] SeparadorSegmento = textoArchivo.Split(Convert.ToChar(segmento)).Where(s => s != "\r\n" && s != "").ToArray();
            string[] SeparadorElemento = new string[0];
            string textoFormato = ""; //textoArchivo.Replace(segmento, segmento + "\n");

            foreach (string BloqueSegmento in SeparadorSegmento)
            {
                textoFormato += BloqueSegmento.Replace("\r\n", "").Replace("\n", "") + segmento + "\n";
            }

            return textoFormato.TrimEnd();
        }
    }
}
