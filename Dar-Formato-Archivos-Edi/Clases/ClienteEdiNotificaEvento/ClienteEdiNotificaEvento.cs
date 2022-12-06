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
    }
}
