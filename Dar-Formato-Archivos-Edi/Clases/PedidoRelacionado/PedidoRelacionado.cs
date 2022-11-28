using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dar_Formato_Archivos_Edi.Clases.PedidoRelacionado
{
    public class PedidoRelacionado
    {
        public int? id_pedido { get; set; }
        public int? no_viaje { get; set; }
        public int? id_remitente { get; set; }
        public int? id_remitente_ext { get; set; }
        public int? id_destinatario { get; set; }
        public int? id_destinatario_ext { get; set; }
    }
}
