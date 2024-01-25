using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dar_Formato_Archivos_Edi.Clases.ClienteEdiNotificaEvento
{
    public class ClienteEdiNotificaEvento
    {
        public int ClienteEdiNotificaEventoId { get; set; }
        public int EventoId { get; set; }
        public string Evento { get; set; }
        public string Texto214 { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int ClienteEdiPedidoDireccionId { get; set; }
        public string caso { get; set; }

        public DateTime fechaRegistro { get; set; }
        public string nombreArchivo { get; set; }
    }


    public class ClienteEdiNotificaEventoApp
    {
        public string id_mensaje { get; set; }
        public string mctnumber { get; set; }
        public string mensaje { get; set; }
        public DateTime fecha_recibido { get; set; }
        public int id_area { get; set; }
        public int id_pedido { get; set; }
        public double posicion { get; set; }
        public int parada { get; set; }
        public string sistema_origen { get; set; }
        public int no_viaje { get; set; }
        public string reason_code { get; set; }
        public int ClienteEdiPedidoId { get; set; }
        public int id_personal { get; set; }
        public string tipo_empleado { get; set; }
        public string nombre { get; set; }

    }

}
