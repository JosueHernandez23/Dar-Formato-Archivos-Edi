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
                            CASE WHEN status_viaje = 'A' THEN '(' + status_viaje + ') - Pendiente'
			                     WHEN status_viaje = 'C' THEN '(' + status_viaje + ') - Liquidado'
			                     WHEN status_viaje = 'R' THEN '(' + status_viaje + ') - Realizado'
			                     WHEN status_viaje = 'B' THEN '(' + status_viaje + ') - Cancelado'
			                     WHEN status_viaje = 'T' THEN '(' + status_viaje + ') - Transito'
		                    ELSE status_viaje END AS status_viaje
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

                    Declare @li_ClienteEdiConfiguracionId int = " + config + @"


CREATE TABLE #tt_edi_nuevo(   ClienteEdiPedidoId Integer Null, ClienteId Integer Null, CodeSCAC Varchar(10) Null, Obs Varchar(1000) Null, Origen Varchar(500) Null, 
    Destino Varchar(500) Null, descripcion Varchar(500) Null, Estatus_EDI Varchar(500) Null, Archivo Varchar(500) Null, Shipment Varchar(500) Null, Equipo Varchar(500) Null, 
    ISA6 Varchar(500) Null, FechaExpiracion datetime NULL, FechaIngreso datetime NULL, Tipo_Mov Varchar(50) Null, Seg_TRucks Varchar(50) Null, id_pedido Integer Null,
    Estatus_204 Varchar(50) Null, Cant Integer Null, AA Varchar(4) Null, X3 Varchar(4) Null, AF Varchar(4) Null, AB Varchar(4) Null, X1 Varchar(4) Null, X6 Varchar(4) Null, 
    CD Varchar(4) Null, AG Varchar(4) Null, D1 Varchar(4) Null,id_estatus int,hr_ing_acep int,hr_creacion_pedido int,hr_StopIni_Viaje int,UsuarioAceptacion varchar(10),fechaAceptacion datetime,fecha_real_viaje datetime,fecha_real_fin_viaje datetime,fechaRelacionPedido datetime,fechaRelacionPedidoMin int,UsuarioRelacion varchar(10),id_viaje int,mctnumber varchar(255),CantX6 VARCHAR(MAX),porcentaje varchar(MAX),ClienteEdiConfiguracionId int )


Insert Into #tt_edi_nuevo( ClienteEdiPedidoId, ClienteId, CodeSCAC, Obs, Origen, Destino, descripcion, Estatus_EDI, Archivo, Shipment, Equipo, ISA6, FechaExpiracion, FechaIngreso, Tipo_Mov, Seg_TRucks, id_pedido, Estatus_204, Cant, AA, X3, AF, AB, X1, X6, CD, AG, D1,id_estatus,hr_ing_acep ,hr_creacion_pedido ,hr_StopIni_Viaje,UsuarioAceptacion,FechaAceptacion,fecha_real_viaje,fecha_real_fin_viaje,fechaRelacionPedido,fechaRelacionPedidoMin,UsuarioRelacion,id_viaje,mctnumber,CantX6,porcentaje,ClienteEdiConfiguracionId  )
Select cep.ClienteEdiPedidoId, cep.ClienteId, cec.CodeSCAC, IsNull( cep.estatus_obs, '' ) Obs, cep.Origen, cep.Destino,
    cec.descripcion, cee.NombreClienteEdiEstatus Estatus_EDI, cep.NombreArchivo, cep.Shipment, cep.Equipo, cep.ISA6, cep.FechaExpiracion,
	cep.FechaIngreso, 
    Case When cep.cruce = 1 Then 'Cruce' Else 'Viaje' End Tipo_Mov, 
    Case When IsNull( cephg.ClienteEdiPedidoHGId, 0 ) > 0 Then 'Relacionado' Else 'Pendiente' End Seg_TRucks, cephg.id_pedido,
    Case When cephg.fecha_real_fin_viaje is null Then 'Sin Viaje' Else Case When DATEDIFF ( hh, cephg.fecha_real_fin_viaje, cep.FechaIngreso ) > 0 Then '204 Desfazado' Else '204 En tiempo' End End Estatus_204, 
    1 Cant, '','','','','','','','',''
	,cephg.id_estatus_bi
	,DATEDIFF(Hour, cep.FechaIngreso, cep.fechaaceptacion ) AS hrs_ing_acep
	,DATEDIFF(Hour, cep.fechaaceptacion, cephg.f_pedido )	AS hr_creacion_pedido
	,DATEDIFF(Hour, cep.Fecha_parada_ini, cephg.f_pedido )	AS hr_StopIni_Viaje
	,UsuarioAceptacion,cep.FechaAceptacion,cephg.fecha_real_viaje,cephg.fecha_real_fin_viaje,cephg.fecha_ingreso
	,DATEDIFF(MINUTE, cep.Fecha_parada_ini, cephg.f_pedido ) AS min_ing_relacinado
	,cephg.id_ingreso
	,cephg.no_viaje
	,cephg.mctnumber
	,'','',cep.ClienteEdiConfiguracionId
From edidb.dbo.ClienteEdiPedido cep With( Nolock ) 
     LEFT OUTER JOIN edidb.dbo.ClienteEdiPedidohg cephg With( Nolock ) On ( cep.ClienteEdiPedidoId = cephg.ClienteEdiPedidoId )
	 INNER JOIN edidb.dbo.ClienteEdiConfiguracion cec With( Nolock ) ON cep.ClienteEdiConfiguracionId = cec.ClienteEdiConfiguracionId
	 INNER JOIN edidb.dbo.ClienteEdiEstatus cee With( Nolock ) ON cep.ClienteEdiEstatusId = cee.ClienteEdiEstatusId 
Where cec.SQL_DB In ( Select valor from general_parametros With( NoLock ) Where  nombre = 'edihgnuevodbname' ) And
	  cep.ClienteediconfiguracionId in( @li_ClienteEdiConfiguracionId ) and
	  cep.FechaIngreso > DATEADD(MONTH,-1,getdate())
Order by cep.Shipment asc

UPDATE #tt_edi_nuevo
SET AA = 1
WHERE (SELECT COUNT(cene.ClienteEdiPedidoId) 
			FROM edidb.dbo.ClienteEdiNotificaEvento cene With( Nolock )
				INNER JOIN edidb.dbo.ClienteEdiEvento cee With( Nolock )
					ON cene.EventoId =  cee.ClienteEdiEventoId
		WHERE cene.ClienteEdiPedidoId = #tt_edi_nuevo.ClienteEdiPedidoId 
			AND cee.ClienteEdiEventoId = 1)  > 0;

UPDATE #tt_edi_nuevo
SET X3 = 1
WHERE (SELECT COUNT(cene.ClienteEdiPedidoId) 
			FROM edidb.dbo.ClienteEdiNotificaEvento cene With( Nolock )
				INNER JOIN edidb.dbo.ClienteEdiEvento cee With( Nolock )
					ON cene.EventoId =  cee.ClienteEdiEventoId
		WHERE cene.ClienteEdiPedidoId = #tt_edi_nuevo.ClienteEdiPedidoId 
			AND cee.ClienteEdiEventoId = 2)  > 0;

UPDATE #tt_edi_nuevo
SET AF = 1
WHERE (SELECT COUNT(cene.ClienteEdiPedidoId) 
			FROM edidb.dbo.ClienteEdiNotificaEvento cene With( Nolock )
				INNER JOIN edidb.dbo.ClienteEdiEvento cee With( Nolock )
					ON cene.EventoId =  cee.ClienteEdiEventoId
		WHERE cene.ClienteEdiPedidoId = #tt_edi_nuevo.ClienteEdiPedidoId 
			AND cee.ClienteEdiEventoId = 3)  > 0;
   
UPDATE #tt_edi_nuevo
SET AB = 1
WHERE (SELECT COUNT(cene.ClienteEdiPedidoId) 
			FROM edidb.dbo.ClienteEdiNotificaEvento cene With( Nolock )
				INNER JOIN edidb.dbo.ClienteEdiEvento cee With( Nolock )
					ON cene.EventoId =  cee.ClienteEdiEventoId
		WHERE cene.ClienteEdiPedidoId = #tt_edi_nuevo.ClienteEdiPedidoId 
			AND cee.ClienteEdiEventoId = 4)  > 0;

UPDATE #tt_edi_nuevo
SET X1 = 1
WHERE (SELECT COUNT(cene.ClienteEdiPedidoId) 
			FROM edidb.dbo.ClienteEdiNotificaEvento cene With( Nolock )
				INNER JOIN edidb.dbo.ClienteEdiEvento cee With( Nolock )
					ON cene.EventoId =  cee.ClienteEdiEventoId
		WHERE cene.ClienteEdiPedidoId = #tt_edi_nuevo.ClienteEdiPedidoId 
			AND cee.ClienteEdiEventoId = 5)  > 0;

UPDATE #tt_edi_nuevo
SET X6 = 1
WHERE (SELECT COUNT(cene.ClienteEdiPedidoId) 
			FROM edidb.dbo.ClienteEdiNotificaEvento cene With( Nolock )
				INNER JOIN edidb.dbo.ClienteEdiEvento cee With( Nolock )
					ON cene.EventoId =  cee.ClienteEdiEventoId
		WHERE cene.ClienteEdiPedidoId = #tt_edi_nuevo.ClienteEdiPedidoId 
			AND cee.ClienteEdiEventoId = 6)  > 0;

UPDATE #tt_edi_nuevo
SET CD = 1
WHERE (SELECT COUNT(cene.ClienteEdiPedidoId) 
			FROM edidb.dbo.ClienteEdiNotificaEvento cene With( Nolock )
				INNER JOIN edidb.dbo.ClienteEdiEvento cee With( Nolock )
					ON cene.EventoId =  cee.ClienteEdiEventoId
		WHERE cene.ClienteEdiPedidoId = #tt_edi_nuevo.ClienteEdiPedidoId 
			AND cee.ClienteEdiEventoId = 7)  > 0;

UPDATE #tt_edi_nuevo
SET AG = 1
WHERE (SELECT COUNT(cene.ClienteEdiPedidoId) 
			FROM edidb.dbo.ClienteEdiNotificaEvento cene With( Nolock )
				INNER JOIN edidb.dbo.ClienteEdiEvento cee With( Nolock )
					ON cene.EventoId =  cee.ClienteEdiEventoId
		WHERE cene.ClienteEdiPedidoId = #tt_edi_nuevo.ClienteEdiPedidoId 
			AND cee.ClienteEdiEventoId = 8)  > 0;

UPDATE #tt_edi_nuevo
SET D1 = 1
WHERE (SELECT COUNT(cene.ClienteEdiPedidoId) 
			FROM edidb.dbo.ClienteEdiNotificaEvento cene With( Nolock )
				INNER JOIN edidb.dbo.ClienteEdiEvento cee With( Nolock )
					ON cene.EventoId =  cee.ClienteEdiEventoId
		WHERE cene.ClienteEdiPedidoId = #tt_edi_nuevo.ClienteEdiPedidoId 
			AND cee.ClienteEdiEventoId = 9)  > 0;


-- Actualizar la columna '@MostrarPorcentaje' con los valores correspondientes
UPDATE #tt_edi_nuevo
SET CantX6 = (
    SELECT TOP 1
        (SELECT COUNT(1) FROM edidb.dbo.ClienteEdiNotificaEvento WHERE ClienteEdiPedidoId = #tt_edi_nuevo.ClienteEdiPedidoId AND EventoId = 6) as Porcentaje
    FROM
        edidb.dbo.ClienteEdiPedidoHG ceph
        INNER JOIN edidb.dbo.ClienteEdiNotificaEvento cene ON (cene.ClienteEdiPedidoId = ceph.ClienteEdiPedidoId) AND EventoId IN (3, 5, 6)
        INNER JOIN edidb.dbo.ClienteEdiPedido cep ON (cep.ClienteEdiPedidoId = cene.ClienteEdiPedidoId)
        INNER JOIN edidb.dbo.ClienteEdiConfiguracion cee ON (cee.ClienteEdiConfiguracionId = cep.ClienteEdiConfiguracionId)
    WHERE ceph.ClienteEdiPedidoId = #tt_edi_nuevo.ClienteEdiPedidoId
)



UPDATE #tt_edi_nuevo
SET porcentaje = 
    CASE 
        WHEN ClienteEdiConfiguracionId IN (1, 2, 4, 7, 8) THEN
            (
                SELECT ROUND((SUM(
                    CASE WHEN CONVERT(INT, AA) = 1 THEN 1 ELSE 0 END +
                    CASE WHEN CONVERT(INT, X3) = 1 THEN 1 ELSE 0 END +
                    CASE WHEN CONVERT(INT, AF) = 1 THEN 1 ELSE 0 END +
                    CASE WHEN CONVERT(INT, AB) = 1 THEN 1 ELSE 0 END +
                    CASE WHEN CONVERT(INT, X6) = 1 THEN 1 ELSE 0 END +
                    CASE WHEN CONVERT(INT, X1) = 1 THEN 1 ELSE 0 END +
                    CASE WHEN CONVERT(INT, D1) = 1 THEN 1 ELSE 0 END
                    ) * 100.0) / (COUNT(*) * 7), 3) AS porcentaje
                FROM #tt_edi_nuevo AS sub
                WHERE sub.ClienteEdiPedidoId = #tt_edi_nuevo.ClienteEdiPedidoId
                GROUP BY ClienteEdiPedidoId
            )
        WHEN ClienteEdiConfiguracionId = 5 AND Tipo_Mov = 'Viaje' THEN
            (
                SELECT ROUND((SUM(
                    CASE WHEN CONVERT(INT, X3) = 1 THEN 1 ELSE 0 END +
                    CASE WHEN CONVERT(INT, AF) = 1 THEN 1 ELSE 0 END +
                    CASE WHEN CONVERT(INT, AG) = 1 THEN 1 ELSE 0 END +
                    CASE WHEN CONVERT(INT, X6) = 1 THEN 1 ELSE 0 END +
                    CASE WHEN CONVERT(INT, X1) = 1 THEN 1 ELSE 0 END +
                    CASE WHEN CONVERT(INT, AB) = 1 THEN 1 ELSE 0 END
                    ) * 100.0) / (COUNT(*) * 7), 3) AS porcentaje
                FROM #tt_edi_nuevo AS sub
                WHERE sub.ClienteEdiPedidoId = #tt_edi_nuevo.ClienteEdiPedidoId
                GROUP BY ClienteEdiPedidoId
            )
        WHEN ClienteEdiConfiguracionId = 5 AND Tipo_Mov = 'Cruce' THEN
            (
                SELECT ROUND((SUM(
                    CASE WHEN CONVERT(INT, D1) = 1 THEN 1 ELSE 0 END +
                    CASE WHEN CONVERT(INT, X1) = 1 THEN 1 ELSE 0 END
                    ) * 100.0) / (COUNT(*) * 2), 3) AS porcentaje
                FROM #tt_edi_nuevo AS sub
                WHERE sub.ClienteEdiPedidoId = #tt_edi_nuevo.ClienteEdiPedidoId
                GROUP BY ClienteEdiPedidoId
            )
        WHEN ClienteEdiConfiguracionId = 3 THEN
            (
                SELECT ROUND((SUM(
                    CASE WHEN CONVERT(INT, X3) = 1 THEN 1 ELSE 0 END +
                    CASE WHEN CONVERT(INT, AF) = 1 THEN 1 ELSE 0 END +
                    CASE WHEN CONVERT(INT, X1) = 1 THEN 1 ELSE 0 END
                    ) * 100.0) / (COUNT(*) * 3), 3) AS porcentaje
                FROM #tt_edi_nuevo AS sub
                WHERE sub.ClienteEdiPedidoId = #tt_edi_nuevo.ClienteEdiPedidoId
                GROUP BY ClienteEdiPedidoId
            )
        ELSE 0 -- Valor por defecto si no se cumple ninguna condición
    END



SELECT 
    ClienteEdiPedidoId, ClienteId, CodeSCAC, Origen, Destino, descripcion, Estatus_EDI, Shipment, Equipo, FechaIngreso, FechaAceptacion, fechaRelacionPedido,
    FechaExpiracion, fecha_real_viaje, fecha_real_fin_viaje, Tipo_Mov, Seg_TRucks, id_pedido, id_viaje, mctnumber, Estatus_204, Cant, AA, X3, AF, AG, X6,
    X1, AB, D1, porcentaje, CantX6, UsuarioRelacion
FROM #tt_edi_nuevo

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
                            Where    ClienteEdiConfiguracionId IN (Select ClienteEdiConfiguracionId from ClienteEdiConfiguracion)


                            -- Obtener Recibidos Edi --
                            UPDATE    @Table_ReporteDiario
                                SET        RecibidosEdi = TR.CountPedido
                                FROM    (Select    Count(DISTINCT(ClienteEdiPedidoId)) as CountPedido, ClienteEdiConfiguracionId as ClienteEdiConf
                                        From    ClienteEdiPedido With(NoLock)
                                        Where    CAST(FechaIngreso AS DATE) = CAST(@Fecha as DATE) And
                                                --ClienteEdiConfiguracionId IN (Select ClienteEdiConfiguracionId from ClienteEdiConfiguracion) And
					                            ClienteEdiPedidoId in (Select ClienteEdiPedidoId
											                            from ClienteEdiPedido With(NoLock)
											                            Where CAST(FechaIngreso AS DATE) = CAST(@Fecha as DATE)
											                            and Shipment in	(Select DISTINCT(Shipment) 
																                            from ClienteEdiPedido With(NoLock)
															                             where ClienteEdiConfiguracionId IN (Select ClienteEdiConfiguracionId from ClienteEdiConfiguracion))) and
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
                                                    CEP.ClienteEdiConfiguracionId IN (Select ClienteEdiConfiguracionId from ClienteEdiConfiguracion)
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
                                                And CEP.ClienteEdiConfiguracionId IN (Select ClienteEdiConfiguracionId from ClienteEdiConfiguracion)
					                            and CEP.ClienteEdiPedidoId IN (
													                            Select ClienteEdiPedidoId
															                             from ClienteEdiPedido WITH (NOLOCK)
															                             Where CAST(FechaIngreso AS DATE) = CAST(@Fecha as DATE)
																		                            and Shipment in (
																						                             Select DISTINCT(Shipment) 
																						                             from ClienteEdiPedido WITH (NOLOCK)
																						                             where ClienteEdiConfiguracionId IN (Select ClienteEdiConfiguracionId from ClienteEdiConfiguracion))
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
                                                And CEP.ClienteEdiConfiguracionId IN (Select ClienteEdiConfiguracionId from ClienteEdiConfiguracion)
					                            and CEP.ClienteEdiPedidoId IN (
													                            Select ClienteEdiPedidoId
															                             from ClienteEdiPedido WITH (NOLOCK)
															                             Where CAST(FechaIngreso AS DATE) = CAST(@Fecha as DATE)
																		                            and Shipment in (
																						                             Select DISTINCT(Shipment) 
																						                             from ClienteEdiPedido WITH (NOLOCK)
																						                             where ClienteEdiConfiguracionId IN (Select ClienteEdiConfiguracionId from ClienteEdiConfiguracion))
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
                                                And CEP.ClienteEdiConfiguracionId IN (Select ClienteEdiConfiguracionId from ClienteEdiConfiguracion)
					                            and CEP.ClienteEdiPedidoId IN (
													                            Select ClienteEdiPedidoId
															                             from ClienteEdiPedido WITH (NOLOCK)
															                             Where CAST(FechaIngreso AS DATE) = CAST(@Fecha as DATE)
																		                            and Shipment in (
																						                             Select DISTINCT(Shipment) 
																						                             from ClienteEdiPedido WITH (NOLOCK)
																						                             where ClienteEdiConfiguracionId IN (Select ClienteEdiConfiguracionId from ClienteEdiConfiguracion))
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
                                                And CEP.ClienteEdiConfiguracionId IN (Select ClienteEdiConfiguracionId from ClienteEdiConfiguracion)
					                            and CEP.ClienteEdiPedidoId IN (
													                            Select ClienteEdiPedidoId
															                             from ClienteEdiPedido WITH (NOLOCK)
															                             Where CAST(FechaIngreso AS DATE) = CAST(@Fecha as DATE)
																		                            and Shipment in (
																						                             Select DISTINCT(Shipment) 
																						                             from ClienteEdiPedido WITH (NOLOCK)
																						                             where ClienteEdiConfiguracionId IN (Select ClienteEdiConfiguracionId from ClienteEdiConfiguracion))
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
                                                And CEP.ClienteEdiConfiguracionId IN (Select ClienteEdiConfiguracionId from ClienteEdiConfiguracion)
					                            and CEP.ClienteEdiPedidoId IN (
													                            Select ClienteEdiPedidoId
															                             from ClienteEdiPedido WITH (NOLOCK)
															                             Where CAST(FechaIngreso AS DATE) = CAST(@Fecha as DATE)
																		                            and Shipment in (
																						                             Select DISTINCT(Shipment) 
																						                             from ClienteEdiPedido WITH (NOLOCK)
																						                             where ClienteEdiConfiguracionId IN (Select ClienteEdiConfiguracionId from ClienteEdiConfiguracion))
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
