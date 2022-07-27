using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dar_Formato_Archivos_Edi.Clases.ClienteEdiConfiguracionArchivo_Segmentos
{
    public class ClienteEdiArchivoConfiguracion_Segmentos
    {
        public int CA_ClienteEdiConfiguracionArchivoId { get; set; }
        public int CA_ClienteEdiTipoArchivoId { get; set; }
        public int CA_Orden { get; set; }
        //public int CA_Estatus_C1 { get; set; }
        //public int CA_Estatus_C2 { get; set; }
        //public int CA_Columas12 { get; set; }
        public int CS_IdSegmento { get; set; }
        public string CS_Nodo { get; set; }
        public string CS_NombreSegmento { get; set; }        
    }
}
