using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using System.Threading.Tasks;
using Dar_Formato_Archivos_Edi.Conexion;
using Dar_Formato_Archivos_Edi.Clases.ClienteEdiTipoArchivo;

namespace Dar_Formato_Archivos_Edi.DataAccess
{
    public class DataAccess_TipoArchivo
    {
        public List<ClienteEdiTipoArchivo> Listado_TipoArchivo()
        {
            SqlCnx con = new SqlCnx();

            using (var connection = new SqlConnection(con.connectionString))
            {
                connection.Open();
                string query = "Select ClienteEdiTipoArchivoId, Nombre From ClienteEdiTipoArchivo";

                List<ClienteEdiTipoArchivo> EdiConfiguracionArchivo = connection.Query<ClienteEdiTipoArchivo>(query).ToList();

                return EdiConfiguracionArchivo;
            }
        }

        public static ClienteEdiArchivoDatos TextoEdi(string QueryEdi, string EstatusEdi, string TipoEdi, int ClienteEdiConfiguracionId, int ClienteEdiPedidoId, DateTime fechaEvento)
        {
            SqlCnx con = new SqlCnx();

            using (var connection = new SqlConnection(con.connectionString))
            {
                connection.Open();
                string query_ContenidoEdi = QueryEdi;
                ClienteEdiArchivoDatos EdiTextoFormato = new ClienteEdiArchivoDatos();
                
                DynamicParameters parametro = new DynamicParameters();
                parametro.Add("@li_ClienteEdiConfiguracionId", ClienteEdiConfiguracionId, DbType.Int64);
                parametro.Add("@li_ClienteEdiPedidoId", ClienteEdiPedidoId, DbType.Int64);
                parametro.Add("@ls_TipoArchivoEdi", TipoEdi, DbType.String);
                parametro.Add("@ls_Evento", EstatusEdi, DbType.String);

                EdiTextoFormato.NombreArchivo = connection.Query("Get_ClienteEdiConfiguracion_NombreArchivo", parametro, commandType: CommandType.StoredProcedure).ToArray()[0].NombreArchivo;
                EdiTextoFormato.ContenidoArchivo = connection.Query(query_ContenidoEdi).ToArray()[0].edi;
                EdiTextoFormato.TipoEdi = TipoEdi;

                return EdiTextoFormato;
            }
        }
    }
}
