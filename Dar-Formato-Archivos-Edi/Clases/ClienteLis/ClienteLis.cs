using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dar_Formato_Archivos_Edi.Clases.ClienteLis
{
    public class ClienteLis
    {
        public string tipo_cliente { get; set; }
        public int? id_cliente { get; set; }
        public string nombre_cliente { get; set; }
        public int tipositio { get; set; }
        public string siteID { get; set; }
        public string ubicacion { get; set; }
        public string descripcion { get; set; }
    }

    public class unidad
    { 
        public string id_unidad { get; set; }
        public string mctNumber { get; set; }
    }
}
