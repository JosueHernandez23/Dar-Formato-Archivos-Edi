using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dar_Formato_Archivos_Edi.Clases.ClienteEdiPedidoDireccion
{
    public class ClienteEdiPedidoDireccion
    {
		public int ClienteEdiPedidoDireccionId { get; set; }
		public int TipoDireccionId { get; set; }
		public string NombreClienteEdiTipoDireccion { get; set; }
		public DateTime FechaEntrada { get; set; }
		public DateTime FechaSalida { get; set; }
		public string Nombre { get; set; }
		public string Pais { get; set; }
		public string Estado { get; set; }
		public string Ciudad { get; set; }
		public string Calle { get; set; }
		public string CodigoPostal { get; set; }
		public string Stop { get; set; }
		public string Accion { get; set; }
	}
}
