using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using Dar_Formato_Archivos_Edi.Conexion;
using Dar_Formato_Archivos_Edi.Clases.ClienteEdiConfiguracionArchivo_Segmentos;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Dar_Formato_Archivos_Edi.DataAccess
{
    public class DataAccess_Form_ListadoSegmentos
    {
        public List<ClienteEdiArchivoConfiguracion_Segmentos> Listado_ClienteEdiArchivoConfiguracion_Segmentos(int ClienteEdiConfiguracionId, int ClienteEdiTipoArchivoId)
        {
            SqlCnx con = new SqlCnx();

            using (var connection = new SqlConnection(con.connectionString))
            {
                connection.Open();
                string query = "Select	CS.IdSegmento CS_IdSegmento, CS.Nodo CS_Nodo, CS.NombreSegmento CS_NombreSegmento, CA.Orden CA_Orden, CA.ClienteEdiConfiguracionArchivoId CA_ClienteEdiConfiguracionArchivoId, CA.ClienteEdiTipoArchivoId CA_ClienteEdiTipoArchivoId From	ClienteEdiConfiguracionArchivo CA, ClienteEdiSegmentos CS Where	CA.ClienteEdiSegmentoId = CS.IdSegmento AND CA.ClienteEdiConfiguracionId = " + ClienteEdiConfiguracionId.ToString() + " AND CA.ClienteEdiTipoArchivoId = " + ClienteEdiTipoArchivoId.ToString() + " Order by Orden ";
                //string query = "Select	CS.IdSegmento CS_IdSegmento, CS.Nodo CS_Nodo, CS.NombreSegmento CS_NombreSegmento, CA.Orden CA_Orden, CA.Estatus_C1 CA_Estatus_C1, CA.Estatus_C2 CA_Estatus_C2, CA.Columnas12 CA_Columnas12  From	ClienteEdiConfiguracionArchivo CA, ClienteEdiSegmentos CS Where	CA.ClienteEdiSegmentoId = CS.IdSegmento AND CA.ClienteEdiConfiguracionId = " + ClienteEdiConfiguracionId.ToString() + " AND CA.ClienteEdiTipoArchivoId = " + ClienteEdiTipoArchivoId.ToString() + " Order by Orden ";

                List<ClienteEdiArchivoConfiguracion_Segmentos> ArchivoConfiguracion_Segmentos = connection.Query<ClienteEdiArchivoConfiguracion_Segmentos>(query).ToList();

                return ArchivoConfiguracion_Segmentos;
            }
        }
    }
}
