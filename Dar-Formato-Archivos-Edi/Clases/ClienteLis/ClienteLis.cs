using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dar_Formato_Archivos_Edi.Clases.ClienteLis
{
    public class ClienteLis
    {
        public string tipo_cliente { get; set; }
        public int? id_cliente { get; set; }
        public string nombre_cliente { get; set; }
        public int tipositio { get; set; }
        public string siteID { get; set; }
        public string ubicacion { get; set; }
        public string descripcion { get; set; }
    }

    public class unidad_Viaje
    {
        public string id_unidad { get; set; }
        public string mctNumber { get; set; }
        public DateTime fecha_real_viaje { get; set; }
        public DateTime fecha_real_fin_viaje { get; set; }
        public string status_viaje { get; set; }
    }

    public class posicion_unidad
    {
        public string ubicacion { get; set; }
        public string EventTypeDescription { get; set; } 
        public DateTime posdate { get; set; }
        //public string id_unidad { get; set; }

    }


    public class ConfiguracionCliente
    {
        public int ClienteEdiConfiguracionId { get; set; }
        public string descripcion { get; set; }
        public string SQL { get; set; }

    }


    public class ReporteEventos
    {
        public int ClienteEdiPedidoId { get; set; }
        public int ClienteId { get; set; }
        public string CodeSCAC { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public string descripcion { get; set; }
        public string Estatus_EDI { get; set; }
        public string Shipment { get; set; }
        public string Equipo { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public DateTime? FechaAceptacion { get; set; }
        public DateTime? fechaRelacionPedido { get; set; }
        public DateTime? FechaExpiracion { get; set; }
        public DateTime? fecha_real_viaje { get; set; }
        public DateTime? fecha_real_fin_viaje { get; set; }
        public string Tipo_Mov { get; set; }
        public string Seg_TRucks { get; set; }
        public int? id_pedido { get; set; }
        public int id_viaje { get; set; }
        public string mctnumber { get; set; }
        public string Estatus_204 { get; set; }
        public int? Cant { get; set; }
        public string AA { get; set; }
        public string X3 { get; set; }
        public string AF { get; set; }
        public string AB { get; set; }
        public string X6 { get; set; }
        public string X1 { get; set; }
        public string D1 { get; set; }
        public string porcentaje { get; set; }
        public string CantX6 { get; set; }
        public string UsuarioRelacion { get; set; }
    }

    public class GetEstadisticas
    {
        public int ClienteEdiConfiguracionId { get; set; }
        public string CodeSCAC { get; set; }
        public int RecibidosEdi { get; set; }
        public int RelacionadosTrucks { get; set; }
        public float PorcentajeRelacionados { get; set; }
        public string FormatoPorcentaje { get; set; }
        public int ViajesReales { get; set; }
        public int Importacion { get; set; }
        public int Exportacion { get; set; }
        public int Domestico { get; set; }
        public int Cruce { get; set; }
    }

}
