using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dar_Formato_Archivos_Edi.Clases.ClienteEdiTipoArchivo
{
    public class ClienteEdiTipoArchivo
    {
        public int ClienteEdiTipoArchivoId { get; set; }
        public string Nombre { get; set; }
    }

    public class ClienteEdiArchivoDatos
    {
        public string NombreArchivo { get; set; }
        public string ContenidoArchivo { get; set; }
        public string TipoEdi { get; set; }
    }
}
