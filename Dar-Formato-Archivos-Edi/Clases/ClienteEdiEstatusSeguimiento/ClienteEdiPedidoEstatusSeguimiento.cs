using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dar_Formato_Archivos_Edi.Clases.ClienteEdiEstatusSeguimiento
{
    public class ClienteEdiPedidoEstatusSeguimiento
    {
        public int ClienteEdiPedidoEstatusSeguimientoId { get; set; }
        public int ClienteEdiEstatusId { get; set; }
        public string NombreClienteEdiEstatus { get; set; }
        public DateTime Fecha { get; set; }
    }
}
