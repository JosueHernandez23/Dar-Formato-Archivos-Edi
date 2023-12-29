using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dar_Formato_Archivos_Edi.Clases.ClienteEdiArchivo
{
    public class ClienteEdiArchivo
    {
        public int ClienteEdiArchivoId { get; set; }
        public string NomClienteEdiArchivo { get; set; }
        public string NomClienteEdiArchivoCompleto { get; set; }
        public DateTime FechaUltimaEscritura { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string TextoClienteEdiArchivo { get; set; }
        public int ClienteEdiConfiguracionId { get; set; }
        public string database { get; set; }
    }
}
