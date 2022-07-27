using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dar_Formato_Archivos_Edi.Clases.ClienteEdiEvento;
using Dar_Formato_Archivos_Edi.Conexion;

namespace Dar_Formato_Archivos_Edi.DataAccess
{
    public class DataAccess_ClienteEdiEvento
    {
        public List<ClienteEdiEvento> Listado_Eventos()
        {
            SqlCnx con = new SqlCnx();
            using (var connection = new SqlConnection(con.connectionString))
            {
                connection.Open();
                string query = "Select ClienteEdiEventoId, NombreEvento From ClienteEdiEvento";

                List<ClienteEdiEvento> EdiEventos = connection.Query<ClienteEdiEvento>(query).ToList();

                return EdiEventos;
            }
        }
    }
}
