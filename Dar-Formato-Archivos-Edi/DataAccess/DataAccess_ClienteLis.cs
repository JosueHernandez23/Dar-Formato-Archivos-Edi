using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using Dar_Formato_Archivos_Edi.Clases.ClienteLis;
using Dar_Formato_Archivos_Edi.Conexion;

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

        public unidad GetUnidad(int no_viaje, string db)
        {
            SqlCnx con = new SqlCnx();
            using (var connection = new SqlConnection(con.connectionString_Lis.Replace("@DB@", db)))
            {
                connection.Open();

                var query = $@"
                    select tv.id_unidad,
		                    mu.mctNumber
                     from	trafico_viaje tv With(NoLock) 
		                    INNER JOIN mtto_unidades mu With(NoLock) ON tv.id_unidad = mu.id_unidad
                     where	tv.no_viaje = {no_viaje}
                ";

                unidad csunidad = connection.QuerySingleOrDefault<unidad>(query);

                return csunidad;
            }
        }
    }
}
