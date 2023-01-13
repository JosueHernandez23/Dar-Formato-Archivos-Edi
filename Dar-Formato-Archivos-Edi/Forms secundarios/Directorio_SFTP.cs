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
using Dar_Formato_Archivos_Edi.DataAccess.DataAccess_ClienteEdiConfiguracion;
using Dar_Formato_Archivos_Edi.Clases.TipoConexion;
using System.Threading;
using Dar_Formato_Archivos_Edi.Properties;

namespace Dar_Formato_Archivos_Edi.Forms_secundarios
{
    public partial class Directorio_SFTP : Form
    {
        public List<ClienteEdiConfiguracion> listado_clientes;
        public RichTextBox TxtFormatoTexto;
        public Label txtNombreArchivo;
        public IEnumerable<Renci.SshNet.Sftp.SftpFile> DataList_SFTP;
        public IEnumerable<FluentFTP.FtpListItem> DataList_FTP;

        public Directorio_SFTP(RichTextBox t, Label NombreArc)
        {
            // Dar formato al archivo
            this.TxtFormatoTexto = t;
            this.txtNombreArchivo = NombreArc;
            InitializeComponent();
            ConfigButtonEfects();

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
        public void ConfigButtonEfects()
        {
            //Botones para conectar y filtrar archivos sftp
            List<Button> ArrButtons = new List<Button>() { btnConectar, BtnFiltrar };

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
                DataList_SFTP = null;
                DataList_FTP = null;

                string server = txtServidor.Text;
                string user = txtUserName.Text;
                string password = txtPassword.Text;
                string path = txtPathOrigen.Text;
                int port = ConvertToInt(txtPort.Text, 22);

                // SFTP
                if (Convert.ToInt32(cboTipoConexion.SelectedValue) == 1)
                {
                    DataList_SFTP = new TipoConexion().ListarArchivos_SFTP(server, user, password, port, path);
                    dtgServerFiles.DataSource = DataList_SFTP;
                    dtgServerFiles.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                // FTP
                if (Convert.ToInt32(cboTipoConexion.SelectedValue) == 2)
                {
                    DataList_FTP = new TipoConexion().ListarArchivos_FTP(server, user, password, port, path);
                    dtgServerFiles.DataSource = DataList_FTP;
                    dtgServerFiles.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;;
                }

                //lblContArchivos.Text = DataList_FTP.LongCount().ToString();
                lblContArchivos.Text = dtgServerFiles.RowCount.ToString();
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

        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            BtnFiltrar.Enabled = false;
            pbEstatus.Visible = true;
            pbEstatus.Image = Resources.loading;

            Thread hilo_filtrarArchivos = new Thread(Filtrar_Archivos);
            hilo_filtrarArchivos.Start();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        public void Filtrar_Archivos()
        {
            try
            {
                dtgServerFiles.DataSource = null;
                if (TxtFiltroArchivo.Text != "")
                {
                    // SFTP
                    if (Convert.ToInt32(cboTipoConexion.SelectedValue) == 1)
                    {
                        dtgServerFiles.DataSource = DataList_SFTP.Where(vl => vl.Name == TxtFiltroArchivo.Text).ToList();
                        dtgServerFiles.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                    // FTP
                    if (Convert.ToInt32(cboTipoConexion.SelectedValue) == 2)
                    {
                        dtgServerFiles.DataSource = DataList_FTP.Where(vl => vl.Name == TxtFiltroArchivo.Text).ToList();
                        dtgServerFiles.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                }
                else
                {
                    // SFTP
                    if (Convert.ToInt32(cboTipoConexion.SelectedValue) == 1)
                    {
                        dtgServerFiles.DataSource = DataList_SFTP;
                        dtgServerFiles.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                    // FTP
                    if (Convert.ToInt32(cboTipoConexion.SelectedValue) == 2)
                    {
                        dtgServerFiles.DataSource = DataList_FTP;
                        dtgServerFiles.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                }
                lblContArchivos.Text = dtgServerFiles.RowCount.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error: " + ex.Message);
            }
            finally
            {
                BtnFiltrar.Enabled = true;
                pbEstatus.Visible = true;
                pbEstatus.Image = Resources.Complete;
            }
        }
    }
}
