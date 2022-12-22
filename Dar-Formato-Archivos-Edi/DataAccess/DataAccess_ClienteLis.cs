using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using Dar_Formato_Archivos_Edi.Clases.ClienteLis;
using Dar_Formato_Archivos_Edi.Conexion;
using Org.BouncyCastle.Utilities;

namespace Dar_Formato_Archivos_Edi.DataAccess.DataAccess_ClienteLis
{
    public class DataAccess_ClienteLis
    {
        public List<ClienteLis> GetClienteLis(List<ClienteLis> lista_cliente, string db)
        {
            SqlCnx con = new SqlCnx();
            using (var connection = new SqlConnection(con.connectionString_Lis.Replace("@DB@", db)))
            {
                connection.Open();

                var query = "";
                int valor = 0,
                    ultimo_valor = 0;

                foreach (ClienteLis item in lista_cliente)
                {
                    if (valor > ultimo_valor)
                    {
                        query += " UNION ALL ";
                        ultimo_valor = valor;
                    }

                    switch (item.tipo_cliente)
                    {
                        case "Remitente":
                            query += $@"
                                select	
		                                'Remitente' tipo_cliente,
		                                tc.id_cliente id_cliente,
		                                tc.nombre nombre_cliente,
		                                ts.tipoSitio tipositio,
		                                CONVERT(VARCHAR(80), tc.siteid )  siteID,
		                                ts.nombre ubicacion,
                                        ts.descripcion
                                from	trafico_cliente tc With(NoLock)
		                                LEFT JOIN trafico_sitios ts With(NoLock) on tc.siteid = ts.siteID
                                where	tc.id_cliente = {item.id_cliente}
                            ";
                            valor++;
                            break;

                        case "Remitente Ext":
                            query += $@"
                                select	
		                                'Remitente Ext' tipo_cliente,
		                                tc.id_cliente id_cliente,
		                                tc.nombre nombre_cliente,
		                                ts.tipoSitio tipositio,
		                                CONVERT(VARCHAR(80), tc.siteid )  siteID,
		                                ts.nombre ubicacion,
                                        ts.descripcion
                                from	trafico_cliente tc With(NoLock)
		                                LEFT JOIN trafico_sitios ts With(NoLock) on tc.siteid = ts.siteID
                                where	tc.id_cliente = {item.id_cliente}
                            ";
                            valor++;
                            break;

                        case "Destinatario":
                            query += $@"
                                select	
		                                'Destinatario' tipo_cliente,
		                                tc.id_cliente id_cliente,
		                                tc.nombre nombre_cliente,
		                                ts.tipoSitio tipositio,
		                                CONVERT(VARCHAR(80), tc.siteid )  siteID,
		                                ts.nombre ubicacion,
                                        ts.descripcion
                                from	trafico_cliente tc With(NoLock)
		                                LEFT JOIN trafico_sitios ts With(NoLock) on tc.siteid = ts.siteID
                                where	tc.id_cliente = {item.id_cliente}
                            ";
                            valor++;
                            break;

                        case "Destinatario Ext":
                            query += $@"
                                select	
		                                'Destinatario Ext' tipo_cliente,
		                                tc.id_cliente id_cliente,
		                                tc.nombre nombre_cliente,
		                                ts.tipoSitio tipositio,
		                                CONVERT(VARCHAR(80), tc.siteid )  siteID,
		                                ts.nombre ubicacion,
                                        ts.descripcion
                                from	trafico_cliente tc With(NoLock)
		                                LEFT JOIN trafico_sitios ts With(NoLock) on tc.siteid = ts.siteID
                                where	tc.id_cliente = {item.id_cliente}
                            ";
                            valor++;
                            break;
                    }
                }

                List<ClienteLis> listado_cliente = connection.Query<ClienteLis>(query).ToList();

                return listado_cliente;
            }
        }

        public unidad_Viaje GetUnidad(int no_viaje, string db)
        {
            SqlCnx con = new SqlCnx();
            using (var connection = new SqlConnection(con.connectionString_Lis.Replace("@DB@", db)))
            {
                connection.Open();

                var query = $@"
                    select tv.id_unidad,
		                    mu.mctNumber,
                            fecha_real_viaje,
                            fecha_real_fin_viaje,
                            status_viaje
                     from	trafico_viaje tv With(NoLock) 
		                    INNER JOIN mtto_unidades mu With(NoLock) ON tv.id_unidad = mu.id_unidad
                     where	tv.no_viaje = {no_viaje}
                ";

                unidad_Viaje csunidad = connection.QuerySingleOrDefault<unidad_Viaje>(query);

                return csunidad;
            }
        }

        public List<ReporteEventos> GetReporte(string db)
        {
            SqlCnx con = new SqlCnx();

            using (var connection = new SqlConnection(con.connectionString_Lis.Replace("@DB@", db)))
            {
                connection.Open();

                var query = $@"
                    Declare @ll_ClienteEdiPedidoId integer,
		                    @ll_evento int
		

                    --Select * from edidb.dbo.ClienteEdiEstatus
                    CREATE TABLE #tt_edi_nuevo(   ClienteEdiPedidoId Integer Null, ClienteId Integer Null, CodeSCAC Varchar(10) Null, Obs Varchar(1000) Null, Origen Varchar(500) Null, 
                        Destino Varchar(500) Null, descripcion Varchar(500) Null, Estatus_EDI Varchar(500) Null, Archivo Varchar(500) Null, Shipment Varchar(500) Null, Equipo Varchar(500) Null, 
                        ISA6 Varchar(500) Null, FechaExpiracion datetime NULL, FechaIngreso datetime NULL, Tipo_Mov Varchar(50) Null, Seg_TRucks Varchar(50) Null, id_pedido Integer Null,
                        Estatus_204 Varchar(50) Null, Cant Integer Null, AA Varchar(4) Null, X3 Varchar(4) Null, AF Varchar(4) Null, AB Varchar(4) Null, X1 Varchar(4) Null, X6 Varchar(4) Null, 
                        CD Varchar(4) Null, AG Varchar(4) Null, D1 Varchar(4) Null )

                    Insert Into #tt_edi_nuevo( ClienteEdiPedidoId, ClienteId, CodeSCAC, Obs, Origen, Destino, descripcion, Estatus_EDI, Archivo, Shipment, Equipo, ISA6, FechaExpiracion, FechaIngreso, Tipo_Mov, Seg_TRucks, id_pedido, Estatus_204, Cant, AA, X3, AF, AB, X1, X6, CD, AG, D1 )

                    Select cep.ClienteEdiPedidoId, cep.ClienteId, cec.CodeSCAC, IsNull( cep.estatus_obs, '' ) Obs, cep.Origen, cep.Destino,
                        cec.descripcion, cee.NombreClienteEdiEstatus Estatus_EDI, cep.NombreArchivo, cep.Shipment, cep.Equipo, cep.ISA6, cep.FechaExpiracion, cep.FechaIngreso, 
                        Case When cep.cruce = 1 Then 'Cruce' Else 'Viaje' End Tipo_Mov, 
                        Case When IsNull( cephg.ClienteEdiPedidoHGId, 0 ) > 0 Then 'Relacionado' Else 'Pendiente' End Seg_TRucks, cephg.id_pedido,
                        Case When cephg.fecha_real_fin_viaje is null Then 'Sin Viaje' Else Case When DATEDIFF ( hh, cephg.fecha_real_fin_viaje, cep.FechaIngreso ) > 0 Then '204 Desfazado' Else '204 En tiempo' End End Estatus_204, 
                        --cephg.f_pedido, cephg.fecha_ingreso, cephg.fecha_real_viaje, cephg.fecha_real_fin_viaje
                        1 Cant, '','','','','','','','',''
                    From edidb.dbo.ClienteEdiPedido cep With( Nolock ) 
                         Left Outer Join edidb.dbo.ClienteEdiPedidohg cephg With( Nolock ) On ( cep.ClienteEdiPedidoId = cephg.ClienteEdiPedidoId ), 
                         edidb.dbo.ClienteEdiConfiguracion cec With( Nolock ), 
                         edidb.dbo.ClienteEdiEstatus cee With( Nolock ) 

                    Where cep.ClienteEdiConfiguracionId = cec.ClienteEdiConfiguracionId And 
                          cep.ClienteEdiEstatusId = cee.ClienteEdiEstatusId And --cep.ClienteediconfiguracionId = @ll_configuracionId and
                          cec.SQL_DB In ( Select valor from general_parametros With( NoLock ) Where  nombre = 'edihgnuevodbname' ) And
                          cep.Fecha_parada_ini >= DATEADD(DAY, -5,GETDATE())

                    Order by cep.Shipment asc 

                    -- Se cargan los registros del EDI en el cursos 
                    Declare c_edi Cursor For
                    SElect ClienteEdiPedidoId From #tt_edi_nuevo

                    -- Se abre el cursor de unidades y se coloca en la 1er. posicion 
                    Open c_edi
                    Fetch Next From c_edi Into @ll_ClienteEdiPedidoId

                    -- Se actualizan las unidades con los datos de las posiciones
                    While ( @@fetch_status <> -1 ) 
                    Begin 

                       Select @ll_evento = Case When COUNT( cee.NombreEvento ) > 0 Then 1 Else 0 End
                       From edidb.dbo.ClienteEdiNotificaEvento cene With( Nolock ), edidb.dbo.ClienteEdiEvento cee With( Nolock ) 
                       Where cene.EventoId =  cee.ClienteEdiEventoId And cee.NombreEvento = 'AA' And cene.ClienteEdiPedidoId = @ll_ClienteEdiPedidoId 
   
                       If @ll_evento = 1
                       Begin
                          Update #tt_edi_nuevo
                          Set AA = @ll_evento
                          Where ClienteEdiPedidoId = @ll_ClienteEdiPedidoId 
                       End
   
                       Select @ll_evento = Case When COUNT( cee.NombreEvento ) > 0 Then 1 Else 0 End
                       From edidb.dbo.ClienteEdiNotificaEvento cene With( Nolock ), edidb.dbo.ClienteEdiEvento cee With( Nolock ) 
                       Where cene.EventoId =  cee.ClienteEdiEventoId And cee.NombreEvento = 'X3' And cene.ClienteEdiPedidoId = @ll_ClienteEdiPedidoId 
   
                       If @ll_evento = 1
                       Begin
                          Update #tt_edi_nuevo
                          Set X3 = @ll_evento
                          Where ClienteEdiPedidoId = @ll_ClienteEdiPedidoId 
                       End
   
                       Select @ll_evento = Case When COUNT( cee.NombreEvento ) > 0 Then 1 Else 0 End
                       From edidb.dbo.ClienteEdiNotificaEvento cene With( Nolock ), edidb.dbo.ClienteEdiEvento cee With( Nolock ) 
                       Where cene.EventoId =  cee.ClienteEdiEventoId And cee.NombreEvento = 'AF' And cene.ClienteEdiPedidoId = @ll_ClienteEdiPedidoId 
   
                       If @ll_evento = 1
                       Begin
                          Update #tt_edi_nuevo
                          Set AF = @ll_evento
                          Where ClienteEdiPedidoId = @ll_ClienteEdiPedidoId 
                       End
   
                          Select @ll_evento = Case When COUNT( cee.NombreEvento ) > 0 Then 1 Else 0 End
                       From edidb.dbo.ClienteEdiNotificaEvento cene With( Nolock ), edidb.dbo.ClienteEdiEvento cee With( Nolock ) 
                       Where cene.EventoId =  cee.ClienteEdiEventoId And cee.NombreEvento = 'AB' And cene.ClienteEdiPedidoId = @ll_ClienteEdiPedidoId 
   
                       If @ll_evento = 1
                       Begin
                          Update #tt_edi_nuevo
                          Set AB = @ll_evento
                          Where ClienteEdiPedidoId = @ll_ClienteEdiPedidoId 
                       End
   
                       Select @ll_evento = Case When COUNT( cee.NombreEvento ) > 0 Then 1 Else 0 End
                       From edidb.dbo.ClienteEdiNotificaEvento cene With( Nolock ), edidb.dbo.ClienteEdiEvento cee With( Nolock ) 
                       Where cene.EventoId =  cee.ClienteEdiEventoId And cee.NombreEvento = 'X1' And cene.ClienteEdiPedidoId = @ll_ClienteEdiPedidoId 
   
                       If @ll_evento = 1
                       Begin
                          Update #tt_edi_nuevo
                          Set X1 = @ll_evento
                          Where ClienteEdiPedidoId = @ll_ClienteEdiPedidoId 
                       End
   
                          Select @ll_evento = Case When COUNT( cee.NombreEvento ) > 0 Then 1 Else 0 End
                       From edidb.dbo.ClienteEdiNotificaEvento cene With( Nolock ), edidb.dbo.ClienteEdiEvento cee With( Nolock ) 
                       Where cene.EventoId =  cee.ClienteEdiEventoId And cee.NombreEvento = 'X6' And cene.ClienteEdiPedidoId = @ll_ClienteEdiPedidoId 
   
                       If @ll_evento = 1
                       Begin
                          Update #tt_edi_nuevo
                          Set X6 = @ll_evento
                          Where ClienteEdiPedidoId = @ll_ClienteEdiPedidoId 
                       End
   
                          Select @ll_evento = Case When COUNT( cee.NombreEvento ) > 0 Then 1 Else 0 End
                       From edidb.dbo.ClienteEdiNotificaEvento cene With( Nolock ), edidb.dbo.ClienteEdiEvento cee With( Nolock ) 
                       Where cene.EventoId =  cee.ClienteEdiEventoId And cee.NombreEvento = 'CD' And cene.ClienteEdiPedidoId = @ll_ClienteEdiPedidoId 
   
                       If @ll_evento = 1
                       Begin
                          Update #tt_edi_nuevo
                          Set CD = @ll_evento
                          Where ClienteEdiPedidoId = @ll_ClienteEdiPedidoId 
                       End
   
                          Select @ll_evento = Case When COUNT( cee.NombreEvento ) > 0 Then 1 Else 0 End
                       From edidb.dbo.ClienteEdiNotificaEvento cene With( Nolock ), edidb.dbo.ClienteEdiEvento cee With( Nolock ) 
                       Where cene.EventoId =  cee.ClienteEdiEventoId And cee.NombreEvento = 'AG' And cene.ClienteEdiPedidoId = @ll_ClienteEdiPedidoId 
   
                       If @ll_evento = 1
                       Begin
                          Update #tt_edi_nuevo
                          Set AG = @ll_evento
                          Where ClienteEdiPedidoId = @ll_ClienteEdiPedidoId 
                       End
   
                          Select @ll_evento = Case When COUNT( cee.NombreEvento ) > 0 Then 1 Else 0 End
                       From edidb.dbo.ClienteEdiNotificaEvento cene With( Nolock ), edidb.dbo.ClienteEdiEvento cee With( Nolock ) 
                       Where cene.EventoId =  cee.ClienteEdiEventoId And cee.NombreEvento = 'D1' And cene.ClienteEdiPedidoId = @ll_ClienteEdiPedidoId 
   
                       If @ll_evento = 1
                       Begin
                          Update #tt_edi_nuevo
                          Set D1 = @ll_evento
                          Where ClienteEdiPedidoId = @ll_ClienteEdiPedidoId 
                       End
   
                       Fetch Next From c_edi Into @ll_ClienteEdiPedidoId
                    End 


                    Select ClienteEdiPedidoId, ClienteId, CodeSCAC,  --Obs, Origen, Destino, 
                           descripcion, Estatus_EDI, --Archivo, 
                           Shipment, Equipo, ISA6,  FechaIngreso,FechaExpiracion,
                           Tipo_Mov ,Seg_TRucks ,id_pedido ,Estatus_204, Cant, AA, X3, AF, AB, X6, X1--, CD, AG
	                       , D1 
                    From #tt_edi_nuevo
                    --where Estatus_204 = '204 En tiempo'
                     Order by ClienteEdiPedidoId DESC
                 ";

                List<ReporteEventos> reporteEventos = connection.Query<ReporteEventos>(query).ToList();
                return reporteEventos;
            }


        }



    }
}
