using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dar_Formato_Archivos_Edi.Clases.ClienteEdiConfiguracionArchivo
{
    internal class ClienteEdiConfiguracionArchivo
    {
        public int ClienteEdiConfiguracionArchivoId { get; set; }
        public int ClienteEdiConfiguracion { get; set; }
        public int ClienteEdiSegmentoId { get; set; }
        public int Estatus_C1 { get; set; }
        public int Estatuc_C2 { get; set; }
        public int Columnas12 { get; set; }
        public int Orden { get; set; }
        public int ClienteEdiArchivoId { get; set; }
    }
}
