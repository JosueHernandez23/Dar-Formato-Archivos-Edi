using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using Dar_Formato_Archivos_Edi.Conexion;
using Dar_Formato_Archivos_Edi.Clases.ClienteEdiConfiguracionArchivo_Segmentos;
using Dar_Formato_Archivos_Edi.Clases.ClienteEdiSegmentos;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Dar_Formato_Archivos_Edi.DataAccess.DataAccess_Form_ListadoSegmentos
{
    public class DataAccess_Form_ListadoSegmentos
    {
        public List<ClienteEdiArchivoConfiguracion_Segmentos> Listado_ClienteEdiArchivoConfiguracion_Segmentos(int ClienteEdiConfiguracionId, int ClienteEdiTipoArchivoId)
        {
            SqlCnx con = new SqlCnx();

            using (var connection = new SqlConnection(con.connectionString))
            {
                connection.Open();
                string query = "Select	CS.IdSegmento CS_IdSegmento, CS.Nodo CS_Nodo, CS.NombreSegmento CS_NombreSegmento, CA.Orden CA_Orden, CA.ClienteEdiConfiguracionArchivoId CA_ClienteEdiConfiguracionArchivoId, CA.ClienteEdiTipoArchivoId CA_ClienteEdiTipoArchivoId, CA.Estatus_C1 CA_Estatus_C1, CA.Estatus_C2 CA_Estatus_C2, CA.Columnas12 CA_Columnas12, CA.FinSegAd CA_FinSegAd, CA.ClienteEdiConfiguracionId CA_ClienteEdiConfiguracionId From	ClienteEdiConfiguracionArchivo CA, ClienteEdiSegmentos CS Where	CA.ClienteEdiSegmentoId = CS.IdSegmento AND CA.ClienteEdiConfiguracionId = " + ClienteEdiConfiguracionId.ToString() + " AND CA.ClienteEdiTipoArchivoId = " + ClienteEdiTipoArchivoId.ToString() + " Order by Orden ";
                //string query = "Select	CS.IdSegmento CS_IdSegmento, CS.Nodo CS_Nodo, CS.NombreSegmento CS_NombreSegmento, CA.Orden CA_Orden, CA.Estatus_C1 CA_Estatus_C1, CA.Estatus_C2 CA_Estatus_C2, CA.Columnas12 CA_Columnas12  From	ClienteEdiConfiguracionArchivo CA, ClienteEdiSegmentos CS Where	CA.ClienteEdiSegmentoId = CS.IdSegmento AND CA.ClienteEdiConfiguracionId = " + ClienteEdiConfiguracionId.ToString() + " AND CA.ClienteEdiTipoArchivoId = " + ClienteEdiTipoArchivoId.ToString() + " Order by Orden ";

                List<ClienteEdiArchivoConfiguracion_Segmentos> ArchivoConfiguracion_Segmentos = connection.Query<ClienteEdiArchivoConfiguracion_Segmentos>(query).ToList();

                return ArchivoConfiguracion_Segmentos;
            }
        }

        public List<ClienteEdiSegmentos> Listado_Segmentos()
        {
            SqlCnx con = new SqlCnx();

            using (var connection = new SqlConnection(con.connectionString))
            {
                connection.Open();
                string query = " Select IdSegmento, Nodo, NombreSegmento, CONVERT(VARCHAR(40), Nodo) + ' - ' + NombreSegmento as DescSegmento From ClienteEdiSegmentos ";

                List<ClienteEdiSegmentos> Segmentos = connection.Query<ClienteEdiSegmentos>(query).ToList();

                return Segmentos;
            }

        }

        public void DeleteSegmentoCliente(ClienteEdiArchivoConfiguracion_Segmentos cs)
        {
            SqlCnx con = new SqlCnx();

            using (var connection = new SqlConnection(con.connectionString))
            {
                connection.Open();
                string query = $@" 
                    Delete From ClienteEdiConfiguracionArchivo  Where	ClienteEdiConfiguracionArchivoId = {cs.CA_ClienteEdiConfiguracionArchivoId}
		                                                                And ClienteEdiConfiguracionId = {cs.CA_ClienteEdiConfiguracionId}
		                                                                And ClienteEdiTipoArchivoId = {cs.CA_ClienteEdiTipoArchivoId}
                ";

                connection.Execute(query, CommandType.Text);
            }
        }

        public void InsertSegmentoCliente(ClienteEdiArchivoConfiguracion_Segmentos cs)
        {
            SqlCnx con = new SqlCnx();

            using (var connection = new SqlConnection(con.connectionString))
            {
                connection.Open();
                string query = $@" 
                    Insert into ClienteEdiConfiguracionArchivo (ClienteEdiConfiguracionId, ClienteEdiSegmentoId, Estatus_C1, Estatus_C2, Columnas12, Orden, ClienteEdiTipoArchivoId, FinSegAd)
                    Values( {cs.CA_ClienteEdiConfiguracionId}, {cs.CS_IdSegmento}, {cs.CA_Estatus_C1}, {cs.CA_Estatus_C2}, {cs.CA_Columnas12}, {cs.CA_Orden}, {cs.CA_ClienteEdiTipoArchivoId}, '{cs.CA_FinSegAd}' )
                ";

                connection.Execute(query, CommandType.Text);
            }
        }

        public void UpdateSegmentoCliente(ClienteEdiArchivoConfiguracion_Segmentos cs) 
        {
            SqlCnx con = new SqlCnx();

            using (var connection = new SqlConnection(con.connectionString))
            {
                connection.Open();
                string query = $@" 
                                Update  ClienteEdiConfiguracionArchivo
                                Set		Orden = {cs.CA_Orden},
		                                Estatus_C1 = {cs.CA_Estatus_C1},
		                                Estatus_C2 = {cs.CA_Estatus_C2},
		                                Columnas12 = {cs.CA_Columnas12},
		                                FinSegAd = '{cs.CA_FinSegAd}'
                                Where	ClienteEdiConfiguracionArchivoId = {cs.CA_ClienteEdiConfiguracionArchivoId}
		                                And ClienteEdiConfiguracionId = {cs.CA_ClienteEdiConfiguracionId}
		                                And ClienteEdiTipoArchivoId = {cs.CA_ClienteEdiTipoArchivoId}
                ";

                connection.Execute(query, CommandType.Text);
            }
        }
    }
}
