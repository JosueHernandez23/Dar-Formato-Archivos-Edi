using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using Dar_Formato_Archivos_Edi.Clases.PedidoRelacionado;
using Dar_Formato_Archivos_Edi.Conexion;

namespace Dar_Formato_Archivos_Edi.DataAccess.DataAccess_PedidoRelacionado
{
    public class DataAccess_PedidoRelacionado
    {
        public PedidoRelacionado GetPedidoRelacionado(int ClienteEdiPedidoId) 
        { 
            SqlCnx con = new SqlCnx();
            using (var connection = new SqlConnection(con.connectionString))
            {
                connection.Open();

                var query = $@"
                   select	
                            cephg.id_pedido,
		                    cephg.no_viaje,
		                    cephg.id_remitente,
		                    cephg.id_remitente_ext,
		                    cephg.id_destinatario,
		                    cephg.id_destinatario_ext
                    from	ClienteEdiPedido cep With(NoLock)
		                    INNER JOIN ClienteEdiPedidoHG cephg With(NoLock) ON cep.ClienteEdiPedidoId = cephg.ClienteEdiPedidoId
                    where	cep.ClienteEdiPedidoId = {ClienteEdiPedidoId}
                ";

                PedidoRelacionado pedidoRelacionado = connection.QuerySingleOrDefault<PedidoRelacionado>(query);

                return pedidoRelacionado;
            }
        }

        public PedidoRelacionado GetDesp_pedido_edi(int ClienteEdiPedidoId, string db)
        {
            SqlCnx con = new SqlCnx();
            using (var connection = new SqlConnection(con.connectionString_Lis.Replace("@DB@", db)))
            {
                connection.Open();

                var query = $@"
                   select	id_pedido,
		                    no_viaje,
		                    id_remitente,
		                    id_remitente_ext,
		                    id_destinatario,
		                    id_destinatario_ext
                    from	chdb_lis.dbo.desp_pedido_edi With(NoLock)
                    where	ClienteEdiPedidoId = {ClienteEdiPedidoId}
                ";

                PedidoRelacionado pedidoRelacionado = connection.QuerySingleOrDefault<PedidoRelacionado>(query);

                return pedidoRelacionado;
            }
        }
    }
}
