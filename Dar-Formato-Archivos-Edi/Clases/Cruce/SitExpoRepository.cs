using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dar_Formato_Archivos_Edi.Clases.Cruce
{
    public class SitExpoRepository
    {
        public int Id { get; set; }
        public string NoShipment { get; set; }
        public int? NoPedido { get; set; }
        public int? NoViaje { get; set; }
        public int? NoCliente { get; set; }
        public string NoUnidad { get; set; }
        public string NoCaja { get; set; }
        public int IdArchivo { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaETA { get; set; }
        public string Cliente { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public string EstatusEnvio { get; set; }
        public string TipoMovimiento { get; set; }
    }
}
