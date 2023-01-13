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
using System.Data;
using System.Data.Common;
using System.Threading;
using iTextSharp.text;
using static Org.BouncyCastle.Math.EC.ECCurve;
using Dar_Formato_Archivos_Edi.Forms_secundarios;

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

        public List<ReporteEventos> GetReporte(string db,int config)
        {
            SqlCnx con = new SqlCnx();
            

            using (var connection = new SqlConnection(con.connectionString_Lis.Replace("@DB@", db)))
            {
                connection.Open();
                var query = $@"

                    Declare @ll_ClienteEdiPedidoId integer,
		                    @ll_evento int,
                            @ll_configuracionId int = "+ config +@"

		
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
                          cep.ClienteEdiEstatusId = cee.ClienteEdiEstatusId And 
                          cec.SQL_DB In ( Select valor from general_parametros With( NoLock ) Where  nombre = 'edihgnuevodbname' ) And
                          cep.ClienteediconfiguracionId = @ll_configuracionId and
                          cep.FechaIngreso >= DATEADD(DAY, -5,GETDATE())
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
                    Order by ClienteEdiPedidoId DESC
                 ";

                List<ReporteEventos> reporteEventos = connection.Query<ReporteEventos>(query,commandTimeout: 3600).ToList();
                var conec = new SqlConnection(con.connectionString_Lis.Replace("@DB@", db));


                DataTable dt = new DataTable();
                dt.TableName = "#tt_edi_nuevo";
                conec.Open();
                SqlDataAdapter da = new SqlDataAdapter(query, conec);
                da.SelectCommand.CommandTimeout = 3600;
                da.Fill(dt);
                conec.Close();

                return reporteEventos;
            }
        }

        public List<GetEstadisticas> GetReportEstadistica(string db) {
            SqlCnx con = new SqlCnx();

            using (var connection = new SqlConnection(con.connectionString_Lis.Replace("@DB@", db)))
            {
                connection.Open();
                var query = $@"
                            DECLARE @Table_ReporteDiario Table (
                            ClienteEdiConfiguracionId INT,
                            CodeSCAC varchar(6),
                            RecibidosEdi INT,
                            RelacionadosTrucks INT,
                            PorcentajeRelacionados DECIMAL(18,8),
                            ViajesReales INT,
                            Importacion INT,
                            Exportacion INT,
                            ViajeLocal INT,
                            Cruce INT,
                            cepid INT,
                            REPORTE_DIA DATETIME
                            )
                            DECLARE @Fecha DATETIME = DATEADD(DAY, -1, CAST( GETDATE() as DATE))

                            -- Insertar clientes HG --
                            INSERT INTO @Table_ReporteDiario (ClienteEdiConfiguracionId, CodeSCAC)
                            Select    ClienteEdiConfiguracionId, CodeSCAC
                            From    ClienteEdiConfiguracion With(NoLock)
                            Where    ClienteEdiConfiguracionId IN (1,2,5,7,8)


                            -- Obtener Recibidos Edi --
                            UPDATE    @Table_ReporteDiario
                                SET        RecibidosEdi = TR.CountPedido
                                FROM    (Select    Count(DISTINCT(ClienteEdiPedidoId)) as CountPedido, ClienteEdiConfiguracionId as ClienteEdiConf
                                        From    ClienteEdiPedido With(NoLock)
                                        Where    CAST(FechaIngreso AS DATE) = CAST(@Fecha as DATE) And
                                                --ClienteEdiConfiguracionId IN (1,2,5,7,8) And
					                            ClienteEdiPedidoId in (Select ClienteEdiPedidoId
											                            from ClienteEdiPedido With(NoLock)
											                            Where CAST(FechaIngreso AS DATE) = CAST(@Fecha as DATE)
											                            and Shipment in	(Select DISTINCT(Shipment) 
																                            from ClienteEdiPedido With(NoLock)
															                             where ClienteEdiConfiguracionId IN (1,2,5,7,8))) and
                                                ClienteEdiEstatusId <> 5
                                                Group by ClienteEdiConfiguracionId) TR
                                Where ClienteEdiConfiguracionId = TR.ClienteEdiConf


                            -- Obtener Relacionados Trucks --
                            UPDATE    @Table_ReporteDiario
                                SET        RelacionadosTrucks = TR.CountPedido
                                FROM    (Select    COUNT(CEPHG.ClienteEdiPedidoId) as CountPedido, CEP.ClienteEdiConfiguracionId as ClienteEdiConf
                                            From    --ClienteEdiPedidoEstatusSeguimiento CEPES With(NoLock),
                                                    ClienteEdiPedidoHG CEPHG With(NoLock),
                                                    ClienteEdiPedido CEP With(NoLock)
                                            Where    CEPHG.ClienteEdiPedidoId = CEP.ClienteEdiPedidoId And
                                                    CAST(CEP.FechaIngreso AS DATE) = CAST(@Fecha as DATE) And
                                                    --CEP.ClienteEdiEstatusId <> 5 And
                                                    CEP.ClienteEdiConfiguracionId IN (1,2,5,7,8)
                                                    Group by CEP.ClienteEdiConfiguracionId) TR
                                Where ClienteEdiConfiguracionId = TR.ClienteEdiConf

                            -- Porcentaje Relacionados --
                            UPDATE    @Table_ReporteDiario
                                SET PorcentajeRelacionados = CONVERT(DECIMAL(18,2), ISNULL(RelacionadosTrucks,0) )/CONVERT(DECIMAL(18,2), ISNULL(RecibidosEdi, 0) ) * 100
	                            where RecibidosEdi > 0
	

                            UPDATE    @Table_ReporteDiario
                                SET ViajesReales = (SELECT TR.CountPedido)
                                FROM (Select    COUNT(CEP.ClienteEdiPedidoId) as CountPedido,  
                                                CEP.ClienteEdiConfiguracionId as ClienteEdiConf,
                                                CEPHG.tipo_serv as tipo_serv
                                        From    ClienteEdiPedidoHG CEPHG With(NoLock),
                                                ClienteEdiPedido CEP With(NoLock)
                                        Where    CEP.ClienteEdiPedidoId = CEPHG.ClienteEdiPedidoId And
                                                CAST(CEP.FechaIngreso AS DATE) = CAST(@Fecha as DATE)
                                                --And CEPHG.tipo_serv = 'T'
                                                --And CEP.ClienteEdiEstatusId IN (3,4,7)
                                                And CEP.ClienteEdiConfiguracionId IN (1,2,5,7,8)
					                            and CEP.ClienteEdiPedidoId IN (
													                            Select ClienteEdiPedidoId
															                             from ClienteEdiPedido WITH (NOLOCK)
															                             Where CAST(FechaIngreso AS DATE) = CAST(@Fecha as DATE)
																		                            and Shipment in (
																						                             Select DISTINCT(Shipment) 
																						                             from ClienteEdiPedido WITH (NOLOCK)
																						                             where ClienteEdiConfiguracionId IN (1,2,5,7,8))
																						                             and tipo_serv = 'T'
					                            )
                                                Group by CEP.ClienteEdiConfiguracionId, CEPHG.tipo_serv) TR
                                WHERE    ClienteEdiConfiguracionId = TR.ClienteEdiConf


                            -- TIPO VIAJES: IMPORTACION --
                            UPDATE    @Table_ReporteDiario
                                SET Importacion = (SELECT TR.CountPedido)
                                FROM (Select    COUNT(CEP.ClienteEdiPedidoId) as CountPedido,  
                                                CEP.ClienteEdiConfiguracionId as ClienteEdiConf,
                                                CEPHG.tipo_serv as tipo_serv
                                        From    ClienteEdiPedidoHG CEPHG With(NoLock),
                                                ClienteEdiPedido CEP With(NoLock)
                                        Where    CEP.ClienteEdiPedidoId = CEPHG.ClienteEdiPedidoId And
                                                CAST(CEP.FechaIngreso AS DATE) = CAST(@Fecha as DATE)
                                                --And CEPHG.tipo_serv = 'I'
                                                --And CEP.ClienteEdiEstatusId IN (3,4,7)
                                                And CEP.ClienteEdiConfiguracionId IN (1,2,5,7,8)
					                            and CEP.ClienteEdiPedidoId IN (
													                            Select ClienteEdiPedidoId
															                             from ClienteEdiPedido WITH (NOLOCK)
															                             Where CAST(FechaIngreso AS DATE) = CAST(@Fecha as DATE)
																		                            and Shipment in (
																						                             Select DISTINCT(Shipment) 
																						                             from ClienteEdiPedido WITH (NOLOCK)
																						                             where ClienteEdiConfiguracionId IN (1,2,5,7,8))
																						                             and tipo_serv = 'I'
					                            )
                                                Group by CEP.ClienteEdiConfiguracionId, CEPHG.tipo_serv) TR
                                WHERE    ClienteEdiConfiguracionId = TR.ClienteEdiConf

                            -- TIPO VIAJES: EXPORTACION --
                            UPDATE    @Table_ReporteDiario
                                SET Exportacion = (SELECT TR.CountPedido)
                                FROM (Select    COUNT(CEP.ClienteEdiPedidoId) as CountPedido,  
                                                CEP.ClienteEdiConfiguracionId as ClienteEdiConf,
                                                CEPHG.tipo_serv as tipo_serv
                                        From    ClienteEdiPedidoHG CEPHG With(NoLock),
                                                ClienteEdiPedido CEP With(NoLock)
                                        Where    CEP.ClienteEdiPedidoId = CEPHG.ClienteEdiPedidoId And
                                                CAST(CEP.FechaIngreso AS DATE) = CAST(@Fecha as DATE)
                                                --And CEPHG.tipo_serv = 'E'
                                                --And CEP.ClienteEdiEstatusId IN (3,4,7)
                                                And CEP.ClienteEdiConfiguracionId IN (1,2,5,7,8)
					                            and CEP.ClienteEdiPedidoId IN (
													                            Select ClienteEdiPedidoId
															                             from ClienteEdiPedido WITH (NOLOCK)
															                             Where CAST(FechaIngreso AS DATE) = CAST(@Fecha as DATE)
																		                            and Shipment in (
																						                             Select DISTINCT(Shipment) 
																						                             from ClienteEdiPedido WITH (NOLOCK)
																						                             where ClienteEdiConfiguracionId IN (1,2,5,7,8))
																						                             and tipo_serv = 'E'
					                            )
                                                Group by CEP.ClienteEdiConfiguracionId, CEPHG.tipo_serv) TR
                                WHERE    ClienteEdiConfiguracionId = TR.ClienteEdiConf

                            -- TIPO VIAJES: DOMESTICO --
                            UPDATE    @Table_ReporteDiario
                                SET ViajeLocal = (SELECT TR.CountPedido)
                                FROM (Select    COUNT(CEP.ClienteEdiPedidoId) as CountPedido,  
                                                CEP.ClienteEdiConfiguracionId as ClienteEdiConf,
                                                CEPHG.tipo_serv as tipo_serv
                                        From    ClienteEdiPedidoHG CEPHG With(NoLock),
                                                ClienteEdiPedido CEP With(NoLock)
                                        Where    CEP.ClienteEdiPedidoId = CEPHG.ClienteEdiPedidoId And
                                                CAST(CEP.FechaIngreso AS DATE) = CAST(@Fecha as DATE)
                                                --And CEPHG.tipo_serv = 'D'
                                                --And CEP.ClienteEdiEstatusId IN (3,4,7)
                                                And CEP.ClienteEdiConfiguracionId IN (1,2,5,7,8)
					                            and CEP.ClienteEdiPedidoId IN (
													                            Select ClienteEdiPedidoId
															                             from ClienteEdiPedido WITH (NOLOCK)
															                             Where CAST(FechaIngreso AS DATE) = CAST(@Fecha as DATE)
																		                            and Shipment in (
																						                             Select DISTINCT(Shipment) 
																						                             from ClienteEdiPedido WITH (NOLOCK)
																						                             where ClienteEdiConfiguracionId IN (1,2,5,7,8))
																						                             and tipo_serv = 'D'
					                            )
                                                Group by CEP.ClienteEdiConfiguracionId, CEPHG.tipo_serv) TR
                                WHERE    ClienteEdiConfiguracionId = TR.ClienteEdiConf
                            --Select @Fecha Fecha_ReporteDiario

                            -- TIPO VIAJES: CRUCE --
                            UPDATE    @Table_ReporteDiario
                                SET Cruce = (SELECT TR.CountPedido)
                                FROM (Select    COUNT(CEP.ClienteEdiPedidoId) as CountPedido,  
                                                CEP.ClienteEdiConfiguracionId as ClienteEdiConf,
                                                CEPHG.tipo_serv as tipo_serv
                                        From    ClienteEdiPedidoHG CEPHG With(NoLock),
                                                ClienteEdiPedido CEP With(NoLock)
                                        Where    CEP.ClienteEdiPedidoId = CEPHG.ClienteEdiPedidoId And
                                                CAST(CEP.FechaIngreso AS DATE) = CAST(@Fecha as DATE)
                                                --And CEPHG.tipo_serv = 'C'
                                                --And CEP.ClienteEdiEstatusId IN (3,4,7)
                                                And CEP.ClienteEdiConfiguracionId IN (1,2,5,7,8)
					                            and CEP.ClienteEdiPedidoId IN (
													                            Select ClienteEdiPedidoId
															                             from ClienteEdiPedido WITH (NOLOCK)
															                             Where CAST(FechaIngreso AS DATE) = CAST(@Fecha as DATE)
																		                            and Shipment in (
																						                             Select DISTINCT(Shipment) 
																						                             from ClienteEdiPedido WITH (NOLOCK)
																						                             where ClienteEdiConfiguracionId IN (1,2,5,7,8))
																						                             and tipo_serv = 'C'
					                            )
                                                Group by CEP.ClienteEdiConfiguracionId, CEPHG.tipo_serv) TR
                                WHERE    ClienteEdiConfiguracionId = TR.ClienteEdiConf


                            Select    ClienteEdiConfiguracionId,
                                    CodeSCAC,
                                    ISNULL(RecibidosEdi, 0) as RecibidosEdi,
                                    ISNULL(RelacionadosTrucks, 0) as RelacionadosTrucks,
                                    ISNULL(PorcentajeRelacionados, 0) as PorcentajeRelacionados,
                                    SUBSTRING( CONVERT(VARCHAR(27), ISNULL(PorcentajeRelacionados, 0) ), 0, CHARINDEX('.', CONVERT(VARCHAR(27), ISNULL(PorcentajeRelacionados, 0) ) ) ) + '%' as FormatoPorcentaje,
                                    ISNULL(ViajesReales, 0) as ViajesReales,
                                    ISNULL(Importacion, 0) as Importacion,
                                    ISNULL(Exportacion, 0) as Exportacion,
                                    ISNULL(ViajeLocal, 0) as Domestico,
		                            ISNULL(Cruce, 0) as Cruce
                            From    @Table_ReporteDiario
                 ";

                List<GetEstadisticas> ReporteEstadistica = connection.Query<GetEstadisticas>(query, commandTimeout: 3600).ToList();
                var conec = new SqlConnection(con.connectionString_Lis.Replace("@DB@", db));


                DataTable dt = new DataTable();
                dt.TableName = "@Table_ReporteDiario";
                conec.Open();
                SqlDataAdapter da = new SqlDataAdapter(query, conec);
                da.SelectCommand.CommandTimeout = 3600;
                da.Fill(dt);
                conec.Close();

                return ReporteEstadistica;
            }
        }

    }
}
