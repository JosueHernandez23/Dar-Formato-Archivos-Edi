using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public static void CargarArchivo_SFTP(string server, string user, string password, string FolderDestino, string PathArchivo, string NombreArchivo)
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
                }
                catch (Exception ex)
                {

                }
            }
        }

    }
}
