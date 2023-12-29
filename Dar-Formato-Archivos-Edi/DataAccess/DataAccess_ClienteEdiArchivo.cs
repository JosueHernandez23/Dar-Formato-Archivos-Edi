using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using Dar_Formato_Archivos_Edi.Clases.ClienteEdiPedido;
using Dar_Formato_Archivos_Edi.Conexion;
using Dar_Formato_Archivos_Edi.Clases.ClienteEdiArchivo;

namespace Dar_Formato_Archivos_Edi.DataAccess
{
    public class DataAccess_ClienteEdiArchivo
    {
        public ClienteEdiArchivo GetClienteArchivo(Int64 ClienteEdiPedidoId, string empresa)
        {
            SqlCnx con = new SqlCnx();
            string conexion = empresa == "hgdb_lis" ? con.connectionString_Edi_Cloud : con.connectionString;

            using (var connection = new SqlConnection(conexion))
            {
                connection.Open();

                string query = $@"
                    SELECT cea.ClienteEdiArchivoId,
                            cea.NomClienteEdiArchivo,
                            cea.NomClienteEdiArchivoCompleto,
                            cea.FechaUltimaEscritura,
                            cea.FechaIngreso,
                            cea.TextoClienteEdiArchivo,
                            cea.ClienteEdiConfiguracionId
                    FROM ClienteEdiPedido cep WITH ( NOLOCK )
	                     INNER JOIN ClienteEdiArchivo cea WITH ( NOLOCK )
		                    ON ( cep.NombreArchivo = cea.NomClienteEdiArchivo )
                    WHERE cep.ClienteEdiPedidoId = {ClienteEdiPedidoId}
                ";

                ClienteEdiArchivo EdiArchivo = connection.QuerySingle<ClienteEdiArchivo>(query);

                connection.Close();

                return EdiArchivo;
            }
        }
    }
}
