using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using Dar_Formato_Archivos_Edi.Conexion;
using Dar_Formato_Archivos_Edi.Clases.ClienteEdiArchivo;
using Dar_Formato_Archivos_Edi.Clases.Cruce;

namespace Dar_Formato_Archivos_Edi.DataAccess
{
    public class DataAccess_ViajeCruce
    {
        public List<SitExpoRepository> GetInformacionEnviada(DateTime fechaInicio, DateTime fechaFin, string empresa)
        {
            SqlCnx con = new SqlCnx();
            string conexion = empresa == "hgdb_lis" ? con.connectionString_Edi_Cloud : con.connectionString;

            using (var connection = new SqlConnection(conexion))
            {
                connection.Open();

                string query = $@"
                    SELECT [Id]
                      ,[NoShipment]
                      ,[NoPedido]
                      ,[NoViaje]
                      ,[NoCliente]
                      ,[NoUnidad]
                      ,[NoCaja]
                      ,[IdArchivo]
                      ,[FechaSalida]
                      ,[FechaETA]
                      ,[Cliente]
                      ,[Origen]
                      ,[Destino]
                      ,[FechaIngreso]
                      , CASE WHEN ISNULL([EstatusEnvio], 0) = 0 THEN 'Por Enviar' ELSE 'Enviado' END AS EstatusEnvio
                      ,[TipoServicio]
                  FROM [dbo].[SitExpoRepository]
                  WHERE FechaIngreso >= '{fechaInicio.Date.ToString("yyyy-MM-dd HH:mm:ss")}'
                        AND FechaIngreso <= '{fechaFin.Date.ToString("yyyy-MM-dd 23:59:59")}'
                  ORDER BY FechaIngreso ASC
                ";

                var infoEnviada = connection.Query<SitExpoRepository>(query).ToList();

                connection.Close();

                return infoEnviada;
            }
        }

        public List<ViajesCruce> GetInformacionRecibida(DateTime fechaInicio, DateTime fechaFin, string empresa)
        {
            SqlCnx con = new SqlCnx();
            string conexion = empresa == "hgdb_lis" ? con.connectionString_Edi_Cloud : con.connectionString;

            using (var connection = new SqlConnection(conexion))
            {
                connection.Open();

                string query = $@"
                    SELECT [id]
                      ,[NoShipment]
                      ,[IdArchivo]
                      ,[NoUnidad]
                      ,[NoViaje]
                      ,[TipoMovimiento]
                      ,[FechaInicioViaje]
                      ,[FechaFinViaje]
                      ,[FechaInsert]
                  FROM [dbo].[viajesCruce]
                  WHERE FechaInsert >= '{fechaInicio.Date.ToString("yyyy-MM-dd HH:mm:ss")}'
                        AND FechaInsert <= '{fechaFin.Date.ToString("yyyy-MM-dd 23:59:59")}'
                  ORDER BY FechaInsert ASC
                ";

                var infoRecibida = connection.Query<ViajesCruce>(query).ToList();

                connection.Close();

                return infoRecibida;
            }
        }
    }
}
