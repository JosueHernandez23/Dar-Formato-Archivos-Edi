using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dar_Formato_Archivos_Edi.Clases.ClienteEdiConfiguracionEvento;
using Dar_Formato_Archivos_Edi.Conexion;

namespace Dar_Formato_Archivos_Edi.DataAccess.DataAccess_ClienteEdiConfiguracionEvento
{
    public class DataAccess_ClienteEdiConfiguracionEvento
    {
        public List<ClienteEdiConfiguracionEvento> Listado_Configuraciones(int cliente)
        {
            SqlCnx con = new SqlCnx();
            using (var connection = new SqlConnection(con.connectionString))
            {
                connection.Open();
                string query = $@"	Select	cece.ClienteEdiConfiguracionEventoId,
                                            cece.ClienteEdiEventoId,
			                                cee.NombreEvento,
			                                cece.Orden,
			                                cece.ClienteEdiConsideraServ,
			                                cece.ClienteEdiTipoServ
                                    From    ClienteEdiConfiguracionEvento cece With(NoLock)
                                            INNER JOIN ClienteEdiEvento cee With(NoLock) ON cece.ClienteEdiEventoId = cee.ClienteEdiEventoId
                                    Where cece.ClienteEdiConfiguracionId = {cliente}
                                    Order by cece.Orden";

                List<ClienteEdiConfiguracionEvento> ConfiguracionEventos = connection.Query<ClienteEdiConfiguracionEvento>(query).ToList();

                return ConfiguracionEventos;
            }
        }

        public void InsertEvento(ClienteEdiConfiguracionEvento evento) 
        {
            SqlCnx con = new SqlCnx();
            using (var connection = new SqlConnection(con.connectionString))
            {
                connection.Open();
                string query = $@"
                    Insert into ClienteEdiConfiguracionEvento (ClienteEdiConfiguracionId, ClienteEdiEventoId, ClienteEdiConsideraServ, ClienteEdiTipoServ, Orden)
                    Values ({evento.ClienteEdiConfiguracionId}, {evento.ClienteEdiEventoId}, {evento.ClienteEdiConsideraServ}, '{evento.ClienteEdiTipoServ}', {evento.Orden} )
                ";

                connection.Execute(query, CommandType.Text);
            }
        }

        public void UpdateEvento(ClienteEdiConfiguracionEvento evento)
        {
            SqlCnx con = new SqlCnx();
            using (var connection = new SqlConnection(con.connectionString))
            {
                connection.Open();
                string query = $@"
                    Update	ClienteEdiConfiguracionEvento
                    Set		ClienteEdiEventoId = {evento.ClienteEdiEventoId},
		                    Orden = {evento.Orden},
		                    ClienteEdiConsideraServ = {evento.ClienteEdiConsideraServ},
		                    ClienteEdiTipoServ = '{evento.ClienteEdiTipoServ}'
                    Where	ClienteEdiConfiguracionEventoId = {evento.ClienteEdiConfiguracionEventoId}
                ";

                connection.Execute(query, CommandType.Text);
            }
        }
    }
}
