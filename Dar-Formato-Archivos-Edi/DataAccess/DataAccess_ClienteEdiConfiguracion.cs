using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dar_Formato_Archivos_Edi.Conexion;
using Dar_Formato_Archivos_Edi.Clases.ClienteEdiConfiguracion;

namespace Dar_Formato_Archivos_Edi.Controllers
{
    public class DataAccess_ClienteEdiConfiguracion
    {
        //string connectionString = "Password=SitioM1; Persist Security Info=True; User ID=sa; Initial Catalog=edidb; Data Source=192.168.40.1; app=Edis; Connection Timeout=180";
        public List<ClienteEdiConfiguracion> ListadoClienteEdiConfiguracion()
        {
            SqlCnx con = new SqlCnx();
            using (var connection = new SqlConnection(con.connectionString))
            {
                connection.Open();
                string query = "Select ClienteEdiConfiguracionId, descripcion + ' - ' + CONVERT(VARCHAR(4), ClienteEdiConfiguracionId) as descripcion, SFTPServerPRD, SFTPUsuarioPRD, SFTPPasswordPRD, SFTPFolderTo214PRD as FolderDestino From ClienteEdiConfiguracion";

                List<ClienteEdiConfiguracion> EdiConfiguracionClientes = connection.Query<ClienteEdiConfiguracion>(query).ToList();

                return EdiConfiguracionClientes;
            }
        }

        public List<ClienteEdiConfiguracion> ListadoClienteEdiConfiguracionFrom()
        {
            SqlCnx con = new SqlCnx();
            using (var connection = new SqlConnection(con.connectionString))
            {
                connection.Open();
                string query = "Select ClienteEdiConfiguracionId, descripcion + ' - ' + CONVERT(VARCHAR(4), ClienteEdiConfiguracionId) as descripcion, SFTPServerPRD, SFTPUsuarioPRD, SFTPPasswordPRD, SFTPFolderFromPRD as FolderDestino From ClienteEdiConfiguracion";

                List<ClienteEdiConfiguracion> EdiConfiguracionClientes = connection.Query<ClienteEdiConfiguracion>(query).ToList();

                return EdiConfiguracionClientes;
            }
        }
    }
}
