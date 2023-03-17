using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dar_Formato_Archivos_Edi.Clases.ClienteEdiConfiguracionEvento
{
    public class ClienteEdiConfiguracionEvento
    {
        public int ClienteEdiConfiguracionEventoId { get; set; }
        public int ClienteEdiConfiguracionId { get; set; }
        public int ClienteEdiEventoId { get; set; }
        public string NombreEvento { get; set; }
        public int Orden { get; set; }
        public int ClienteEdiConsideraServ { get; set; }
        public string ClienteEdiTipoServ { get; set; }
    }
}
