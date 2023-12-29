using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dar_Formato_Archivos_Edi.Clases;

namespace Dar_Formato_Archivos_Edi.Clases.ClienteEdiPedido
{
    public class ClienteEdiPedido
    {
        public int ClienteEdiPedidoId { get; set; }
        public int EstatusId { get; set; }
        public string Estatus { get; set; }
        public string SCAC { get; set; }
        public string Shipment { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string SQL_DB { get; set; }
        public int Cruce { get; set; }
    }
}
