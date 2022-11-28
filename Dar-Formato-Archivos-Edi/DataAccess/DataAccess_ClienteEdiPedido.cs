using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dar_Formato_Archivos_Edi.Conexion;
using Dar_Formato_Archivos_Edi.Clases.ClienteEdiPedido;
using Dar_Formato_Archivos_Edi.Clases.ClienteEdiNotificaEvento;
using Dar_Formato_Archivos_Edi.Clases.ClienteEdiEstatusSeguimiento;
using Dar_Formato_Archivos_Edi.Clases.ClienteEdiPedidoDireccion;
using System.Data.SqlClient;
using Dapper;

namespace Dar_Formato_Archivos_Edi.DataAccess.DataAccess_ClienteEdiPedido
{
    public class DataAccess_ClienteEdiPedido
    {
        public ClienteEdiPedido GetClienteEdiPedido(int ClienteEdiPedidoId) 
        {
            SqlCnx con = new SqlCnx();
            using (var connection = new SqlConnection(con.connectionString))
            {
                connection.Open();
                string query = $@"
                    select	
		                    cep.ClienteEdiPedidoId ClienteEdiPedidoId,
                            cep.ClienteEdiEstatusId EstatusId,
		                    cee.NombreClienteEdiEstatus Estatus,
		                    cep.CodeSCAC SCAC,
		                    cep.Shipment Shipment,
		                    cep.FechaIngreso FechaIngreso,
                            LOWER(cec.SQL_DB) SQL_DB
                    from	ClienteEdiPedido cep With(NoLock)
	                        INNER JOIN ClienteEdiEstatus cee With(NoLock) ON cep.ClienteEdiEstatusId = cee.ClienteEdiEstatusId
		                    INNER JOIN ClienteEdiConfiguracion cec With(NoLock) ON cep.ClienteEdiConfiguracionId = cec.ClienteEdiConfiguracionId
                    where	cep.ClienteEdiPedidoId = {ClienteEdiPedidoId}
                ";

                ClienteEdiPedido EdiPedidoId = connection.QuerySingle<ClienteEdiPedido>(query);
                
                connection.Close();

                return EdiPedidoId;
            }
        }

        public List<ClienteEdiNotificaEvento> GetClienteEdiNotificaEvento(int ClienteEdiPedidoId)
        {
            SqlCnx con = new SqlCnx();
            using (var connection = new SqlConnection(con.connectionString))
            {
                connection.Open();
                string query = $@"
                     select	
		                    cene.ClienteEdiNotificaEventoId,
		                    cene.EventoId,
		                    cee.NombreEvento Evento,
		                    cene.FechaIngreso,
		                    cene.Texto214
                     from	ClienteEdiNotificaEvento cene With(NoLock)
		                    INNER JOIN ClienteEdiEvento cee With(Nolock) ON cene.EventoId = cee.ClienteEdiEventoId
                     where	cene.ClienteEdiPedidoId = {ClienteEdiPedidoId}
                     Order by cene.ClienteEdiNotificaEventoId
                ";

                List<ClienteEdiNotificaEvento> ClienteEdiNotificaEvento = connection.Query<ClienteEdiNotificaEvento>(query).ToList();

                connection.Close();

                return ClienteEdiNotificaEvento;
            }
        }

        public List<ClienteEdiPedidoEstatusSeguimiento> GetClienteEdiPedidoEstatusSeguimiento(int ClienteEdiPedidoId) 
        {
            SqlCnx con = new SqlCnx();
            using (var connection = new SqlConnection(con.connectionString))
            {
                connection.Open();
                string query = $@"
                     select	cepes.ClienteEdiPedidoEstatusSeguimientoId,
		                    cepes.ClienteEdiEstatusId,
		                    cee.NombreClienteEdiEstatus,
		                    cepes.Fecha
                    from	ClienteEdiPedidoEstatusSeguimiento cepes With(NoLock)
		                    INNER JOIN ClienteEdiEstatus cee With(NoLock) ON cepes.ClienteEdiEstatusId = cee.ClienteEdiEstatusId
                    where	ClienteEdiPedidoId = {ClienteEdiPedidoId}
                    order by ClienteEdiPedidoEstatusSeguimientoId
                ";

                List<ClienteEdiPedidoEstatusSeguimiento> ClienteEdiPedidoEstatusSeguimiento = connection.Query<ClienteEdiPedidoEstatusSeguimiento>(query).ToList();

                connection.Close();

                return ClienteEdiPedidoEstatusSeguimiento;
            }
        }

        public List<ClienteEdiPedidoDireccion> GetClienteEdiPedidoDireccion(int ClienteEdiPedidoId)
        {
            SqlCnx con = new SqlCnx();
            using (var connection = new SqlConnection(con.connectionString))
            {
                connection.Open();
                string query = $@"
                     Select	cepd.ClienteEdiPedidoDireccionId,
		                    cepd.TipoDireccionId,
		                    cetd.NombreClienteEdiTipoDireccion,
		                    cepd.FechaEntrada,
		                    cepd.FechaSalida,
		                    cepd.Nombre,
		                    cepd.Pais,
		                    cepd.Estado,
		                    cepd.Ciudad,
		                    cepd.Calle,
		                    cepd.CodigoPostal,
		                    cepd.Clave_S501 as Stop,
		                    cepd.Clave_S502 as Accion
                    from	ClienteEdiPedidoDireccion cepd With(NoLock)
		                    INNER JOIN ClienteEdiTipoDireccion cetd With(NoLock) ON cepd.TipoDireccionId = cetd.ClienteEdiTipoDireccionId
                    where	ClienteEdiPedidoId = {ClienteEdiPedidoId}
                    order by cepd.ClienteEdiPedidoDireccionId
                ";

                List<ClienteEdiPedidoDireccion> ClienteEdiPedidoDireccion = connection.Query<ClienteEdiPedidoDireccion>(query).ToList();

                connection.Close();

                return ClienteEdiPedidoDireccion;
            }
        }
    }
}
