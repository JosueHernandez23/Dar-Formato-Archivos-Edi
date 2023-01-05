using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FluentFTP;
using System.Text;
using System.Threading.Tasks;

namespace Dar_Formato_Archivos_Edi.Clases.TipoConexion
{
    public class TipoConexion
    {
        public int IdTipoConexion { get; set; }
        public string Conexion { get; set; }

        public static List<TipoConexion> Listado_TipoConexion()
        {

            List<TipoConexion> Listado_TipoConexion = new List<TipoConexion>();

            Listado_TipoConexion.Add(new TipoConexion() { IdTipoConexion = 1, Conexion = "SFTP" });
            Listado_TipoConexion.Add(new TipoConexion() { IdTipoConexion = 2, Conexion = "FTP" });

            return Listado_TipoConexion;
        }

        public static string CargarArchivo_SFTP(string server, string user, string password, string FolderDestino, string PathArchivo, string NombreArchivo)
        {

            using (SftpClient sftp = new SftpClient(server, user, password))
            {
                try
                {
                    sftp.Connect();

                    //Crear archivo en SFTP
                    FileStream fs = new FileStream(PathArchivo, FileMode.Open);
                    sftp.BufferSize = 1024;
                    string rutafile = Path.GetFileName(FolderDestino) + "//" + NombreArchivo;

                    //Se carga el archivo al SFTP
                    sftp.UploadFile(fs, rutafile);

                    fs.Dispose();

                    sftp.Disconnect();

                    return "El archivo fue cargado por SFTP con exito";
                }
                catch (Exception ex)
                {
                    return "Error: " + ex.Message;
                }
            }
        }

        public IEnumerable<Renci.SshNet.Sftp.SftpFile> ListarArchivos_SFTP(string server, string user, string password, int port, string FolderOrigen)
        {
            using (SftpClient sftp = new SftpClient(server, port, user, password))
            {
                sftp.Connect();

                IEnumerable<Renci.SshNet.Sftp.SftpFile> lista_archivos = sftp.ListDirectory(FolderOrigen);

                sftp.Disconnect();

                return lista_archivos;
            }
        }

        public IEnumerable<FtpListItem> ListarArchivos_FTP(string server, string user, string password, int port, string FolderOrigen)
        {
            using (FtpClient ftp = new FtpClient(server, user, password))
            {
                ftp.Connect();

                FtpListItem[] lista_archivos = ftp.GetListing(FolderOrigen);

                ftp.Disconnect();

                return lista_archivos;
            }
        }

        public static string RevisarContenidoArchivo_SFTP(string server, string user, string password, int port, string pahtFile)
        {
            using (SftpClient sftp = new SftpClient(server, port, user, password))
            {
                try
                {
                    sftp.Connect();

                    string contenido = "";

                    if (sftp.Exists(pahtFile))
                    {
                        contenido = sftp.ReadAllText(pahtFile);
                    }
                    else 
                    {
                        contenido = "El archivo ya no existe";
                    }

                    sftp.Disconnect();

                    return contenido;
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
        }

        public static string RevisarContenidoArchivo_FTP(string server, string user, string password, int port, string pahtFile)
        {
            using (FtpClient ftp = new FtpClient(server, user, password))
            {
                try
                {
                    ftp.Connect();

                    string contenido = "";

                    if (ftp.FileExists(pahtFile))
                    {
                        Stream st = ftp.OpenRead(pahtFile);
                        StreamReader sr = new StreamReader(st);
                        contenido = sr.ReadToEnd();
                    }
                    else
                    {
                        contenido = "El archivo ya no existe";
                    }

                    ftp.Disconnect();

                    return contenido;
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
        }
    }
}
