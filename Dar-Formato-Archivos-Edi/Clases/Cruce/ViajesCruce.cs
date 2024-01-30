using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dar_Formato_Archivos_Edi.Clases.Cruce
{
    public class ViajesCruce
    {
        public Guid Id { get; set; }
        public string NoShipment { get; set; }
        public int IdArchivo { get; set; }
        public string NoUnidad { get; set; }
        public int NoViaje { get; set; }
        public string TipoMovimiento { get; set; }
        public DateTime FechaInicioViaje { get; set; }
        public DateTime? FechaFinViaje { get; set; }
        public DateTime FechaInsert { get; set; }
    }
}
