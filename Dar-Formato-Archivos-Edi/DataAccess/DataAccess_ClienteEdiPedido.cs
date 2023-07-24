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
using Dar_Formato_Archivos_Edi.Clases.Edi;
using System.Data.SqlClient;
using Dapper;
using Dar_Formato_Archivos_Edi.Clases.ClienteLis;

namespace Dar_Formato_Archivos_Edi.DataAccess.DataAccess_ClienteEdiPedido
{
    public class DataAccess_ClienteEdiPedido
    {
        public ClienteEdiPedido GetClienteEdiPedido(int ClienteEdiPedidoId, string empresa) 
        {
            SqlCnx con = new SqlCnx();
            string conexion = empresa == "hgdb_lis" ? con.connectionString_Edi_Cloud : con.connectionString;

            using (var connection = new SqlConnection(conexion))
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
                            '{conexion}' SQL_DB
                    from	ClienteEdiPedido cep With(NoLock)
	                        INNER JOIN ClienteEdiEstatus cee With(NoLock) ON cep.ClienteEdiEstatusId = cee.ClienteEdiEstatusId
		                    INNER JOIN ClienteEdiConfiguracion cec With(NoLock) ON cep.ClienteEdiConfiguracionId = cec.ClienteEdiConfiguracionId
                    where	cep.ClienteEdiPedidoId = {ClienteEdiPedidoId} and cep.ClienteEdiEstatusId in (2,3,4,5,7)
                ";

                ClienteEdiPedido EdiPedidoId = connection.QuerySingle<ClienteEdiPedido>(query);

                ClienteEdiPedidoId = EdiPedidoId.ClienteEdiPedidoId;

                connection.Close();

                return EdiPedidoId;
            }
        }

        public List<ClienteEdiNotificaEventoApp> GetClienteEdiNotificaEventoAppMobil(int no_viaje, int ClienteEdiPedidoId, string sqldb)
        {
            SqlCnx con = new SqlCnx();
            string conexion = sqldb == "hgdb_lis" ? con.connectionString_Hg_Cloud : con.connectionString_Lis.Replace("@DB@", sqldb);
            using (var connection = new SqlConnection(conexion))
            {
              
                connection.Open();
                
                    string query = $@"
						DECLARE @li_ClienteEdiPedido int = {ClienteEdiPedidoId},
		                        @li_NoViaje int = {no_viaje}
						
						IF(@li_NoViaje > 0)
						BEGIN
							Select		dpum.mensaje,			dpum.fecha_recibido,			dpum.id_pedido,
										dpum.parada,			dpum.sistema_origen,			dpum.no_viaje,
										dpum.ClienteEdiPedidoId,pp.id_personal,					pp.tipo_empleado, 
										CASE WHEN ( nombapm IS NOT NULL ) AND ( appat IS NOT NULL ) AND ( apmat IS NOT NULL ) THEN nombapm + ' ' + appat + ' ' + apmat ELSE nombre END AS nombre 
							from 
										desp_posicion_unidad_mensaje dpum		With( Nolock ) , 
										personal_personal pp					With( Nolock ),
										trafico_viaje tv						With( Nolock ),
										mtto_unidades mu						With( Nolock )
							Where 
										tv.no_viaje = dpum.no_viaje and
										dpum.mctnumber = mu.mctnumber And
										tv.id_personal = pp.id_personal and
										dpum.id_Area = 1 And 
										dpum.no_viaje = @li_NoViaje
							ORDER BY dpum.fecha_recibido ASC
						END
                        
						IF(@li_ClienteEdiPedido > 0)
						BEGIN
							Select		DISTINCT(dpum.mensaje),			dpum.fecha_recibido,			dpum.id_pedido,
										dpum.parada,			dpum.sistema_origen,			dpum.no_viaje,
										dpum.ClienteEdiPedidoId,pp.id_personal,					pp.tipo_empleado, 
										CASE WHEN ( nombapm IS NOT NULL ) AND ( appat IS NOT NULL ) AND ( apmat IS NOT NULL ) THEN nombapm + ' ' + appat + ' ' + apmat ELSE nombre END AS nombre 
							from 
										desp_posicion_unidad_mensaje dpum		With( Nolock ) , 
										personal_personal pp					With( Nolock ),
										trafico_viaje tv						With( Nolock ),
										mtto_unidades mu						With( Nolock )
							Where 
										tv.no_viaje = dpum.no_viaje and
										dpum.mctnumber = mu.mctnumber And
										tv.id_personal = pp.id_personal and
										dpum.id_Area = 1 And 
										(dpum.ClienteEdiPedidoId = @li_ClienteEdiPedido )
							ORDER BY dpum.fecha_recibido ASC
						END
                ";
               
                List<ClienteEdiNotificaEventoApp> ClienteEdiNotificaEventoApp = connection.Query<ClienteEdiNotificaEventoApp>(query).ToList();
                connection.Close();

                return ClienteEdiNotificaEventoApp;
            }
        }

        public List<ClienteEdiNotificaEvento> GetClienteEdiNotificaEvento(int ClienteEdiPedidoId, string empresa)
        {
            SqlCnx con = new SqlCnx();
            string conexion = empresa == "hgdb_lis" ? con.connectionString_Edi_Cloud : con.connectionString;
            using (var connection = new SqlConnection(conexion))
            {
                connection.Open();
                string query = $@"
                     select	
		                    cene.ClienteEdiNotificaEventoId,
		                    cene.EventoId,
		                    cee.NombreEvento Evento,
		                    cene.FechaIngreso,
		                    cene.Texto214,
                            cene.ClienteEdiPedidoDireccionId,
                            cene.Caso caso
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

        public List<ClienteEdiPedidoEstatusSeguimiento> GetClienteEdiPedidoEstatusSeguimiento(int ClienteEdiPedidoId, string empresa) 
        {
            SqlCnx con = new SqlCnx();
            string conexion = empresa == "hgdb_lis" ? con.connectionString_Edi_Cloud : con.connectionString;
            using (var connection = new SqlConnection(conexion))
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

        public List<ClienteEdiPedidoDireccion> GetClienteEdiPedidoDireccion(int ClienteEdiPedidoId, string empresa)
        {
            SqlCnx con = new SqlCnx();
            string conexion = empresa == "hgdb_lis" ? con.connectionString_Edi_Cloud : con.connectionString;
            using (var connection = new SqlConnection(conexion))
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

        public List<posicion_unidad>  GetPosicion_Unidad(int no_viaje, string db)
        {
            SqlCnx con = new SqlCnx();
            string conexion = db == "hgdb_lis" ? con.connectionString_Hg_Cloud : con.connectionString_Lis.Replace("@DB@", db);

            using (var connection = new SqlConnection(conexion))
            {
                connection.Open();

                var query = $@"
                    select ubicacion,
		                    EventTypeDescription,
                            posdate,
                            Sistema_origen,
                            posdate_inserto
                     from	desp_posicion_unidad dpu With(NoLock) 
                     where	dpu.id_viaje = {no_viaje}
                            order by dpu.posdate
                ";

                List<posicion_unidad> posicion_Unidads = connection.Query<posicion_unidad>(query).ToList();
                connection.Close();

                return posicion_Unidads;
            }

        }

        public List<ConfiguracionCliente> GetClienteEdiConfiguracion(string db)
        {
            SqlCnx con = new SqlCnx();
            string conexion = db == "hgdb_lis" ? con.connectionString_Edi_Cloud : con.connectionString;
            using (var connection = new SqlConnection(conexion))
            {
                connection.Open();

                var query = $@"
                    Select ClienteEdiConfiguracionId, descripcion,SQL_DB
                    from ClienteEdiConfiguracion
                    where SQL_DB = '{db}'
                ";

                List<ConfiguracionCliente> CLienteConfiguracion = connection.Query<ConfiguracionCliente>(query).ToList();
                connection.Close();


                return CLienteConfiguracion;
            }

        }

        public static List<Edi824> getEdi824(int ClienteEdiPedidoId, string empresa)
        {
            SqlCnx con = new SqlCnx();
            string conexion = empresa == "hgdb_lis" ? con.connectionString_Edi_Cloud : con.connectionString;
            using (var connection = new SqlConnection(conexion))
            {
                connection.Open();

                var query = $@"
                    Select	edi.scacSender, 
		                    edi.scacReceiver, 
		                    edi.application_ErrorCode, 
		                    edi.message_Error, 
		                    edi.dateIssue, 
		                    edi.reference_Code, 
		                    edi.reference_Description, 
		                    edi.interchangeDate, 
		                    edi.entryDate, 
		                    edi.filesContent
                    From edi824 edi With(NoLock) 
	                     inner join ClienteEdiPedido cep With(NoLock) on ( edi.reference_Description = cep.Shipment )
	                     inner join ClienteEdiConfiguracion cec With(NoLock) on ( cep.ClienteEdiConfiguracionId = cec.ClienteEdiConfiguracionId and cec.ISA8 = edi.scacSender )
                    Where cep.ClienteEdiPedidoId = {ClienteEdiPedidoId}
                    Order by edi.dateIssue asc
                ";

                List<Edi824> Edi824 = connection.Query<Edi824>(query).ToList();
                connection.Close();

                return Edi824;
            }
        }

        public List<ClienteEdiPedido> GetClienteEdiPedidoShipment(int Shipment, string empresa)
        {
            SqlCnx con = new SqlCnx();
            string conexion = empresa == "hgdb_lis" ? con.connectionString_Edi_Cloud : con.connectionString;

            using (var connection = new SqlConnection(conexion))
            {
                connection.Open();

                var query = $@"
                    select	
		                    cep.ClienteEdiPedidoId ClienteEdiPedidoId,
                            cep.ClienteEdiEstatusId EstatusId,
		                    cee.NombreClienteEdiEstatus Estatus,
		                    cep.CodeSCAC SCAC,
		                    cep.Shipment Shipment,
		                    cep.FechaIngreso FechaIngreso,
                            '{empresa}' SQL_DB
                    from	ClienteEdiPedido cep With(NoLock)
	                        INNER JOIN ClienteEdiEstatus cee With(NoLock) ON cep.ClienteEdiEstatusId = cee.ClienteEdiEstatusId
		                    INNER JOIN ClienteEdiConfiguracion cec With(NoLock) ON cep.ClienteEdiConfiguracionId = cec.ClienteEdiConfiguracionId
                    where	cep.Shipment = '{Shipment}' and cep.ClienteEdiEstatusId in (2,3,4,7)
                ";

                List<ClienteEdiPedido> ClienteEdiPedido = connection.Query<ClienteEdiPedido>(query).ToList();
                connection.Close();

                return ClienteEdiPedido;
            }
        }

    }
}
