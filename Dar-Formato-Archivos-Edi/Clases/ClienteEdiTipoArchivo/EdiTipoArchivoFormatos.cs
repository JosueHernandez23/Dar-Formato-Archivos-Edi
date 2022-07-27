using Dar_Formato_Archivos_Edi.DataAccess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dar_Formato_Archivos_Edi.Clases.ClienteEdiTipoArchivo.EdiTipoArchivoFormatos
{
    public class EdiTipoArchivoFormatos
    {
        public static bool EdiProcesoFormatoArchivo(string EstatusEdi, string TipoEdi, int ClienteEdiConfiguracionId, int ClienteEdiPedidoId, decimal Latitud, decimal longitud, DateTime fechaEvento)
        {
			string FormatoEdi = "";
			string path = "";

			// Contiene el query para generar texto edi
			if (TipoEdi == "214")
            {
				path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\" + "EstructuraEDI\\Estructura_214.txt";
				path = path.Replace("file:\\", "").Replace("\\Debug", "").Replace("\\bin", "");
				
				StreamReader sr = new StreamReader(path);

				FormatoEdi = sr.ReadToEnd();

				// Se ingresan los valores mediante un replace en el query para despues ser ejecutado
				FormatoEdi = FormatoEdi.Replace("@EventoReplace", EstatusEdi)
							.Replace("@ClienteEdiConfiguracionIdReplace", ClienteEdiConfiguracionId.ToString())
							.Replace("@LatitudReplace", Latitud.ToString())
							.Replace("@LongitudReplace", longitud.ToString())
							.Replace("@ClienteEdiPedidoIdReplace", ClienteEdiPedidoId.ToString())
							.Replace("@FechaEventoReplace", fechaEvento.ToString("yyyy/MM/dd hh:mm:ss"));
			}

			if (TipoEdi == "990")
            {
				path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\" + "EstructuraEDI\\Estructura_990.txt";
				path = path.Replace("file:\\", "").Replace("\\Debug", "").Replace("\\bin", "");
		
				StreamReader sr = new StreamReader(path);

				FormatoEdi = sr.ReadToEnd();

				// Se ingresan los valores mediante un replace en el query para despues ser ejecutado
				FormatoEdi = FormatoEdi.Replace("@ClienteEdiConfiguracionIdReplace", ClienteEdiConfiguracionId.ToString())
							.Replace("@ClienteEdiPedidoIdReplace", ClienteEdiPedidoId.ToString());
			}

			if (TipoEdi == "997")
            {
				path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\" + "EstructuraEDI\\Estructura_997.txt";
				path = path.Replace("file:\\", "").Replace("\\Debug", "").Replace("\\bin", "");

				StreamReader sr = new StreamReader(path);

				FormatoEdi = sr.ReadToEnd();

				// Se ingresan los valores mediante un replace en el query para despues ser ejecutado
				FormatoEdi = FormatoEdi.Replace("@ClienteEdiConfiguracionIdReplace", ClienteEdiConfiguracionId.ToString())
							.Replace("@ClienteEdiPedidoIdReplace", ClienteEdiPedidoId.ToString());
			}

			ClienteEdiArchivoDatos CEA = DataAccess_TipoArchivo.TextoEdi(FormatoEdi, EstatusEdi, TipoEdi, ClienteEdiConfiguracionId, ClienteEdiPedidoId, fechaEvento);

			// Se crea el archivo Edi
			bool resultado = CrearArchivoEdi(CEA);

			return resultado;
		}

		public static bool CrearArchivoEdi(ClienteEdiArchivoDatos CEA)
        {
			bool resultado = true;
			string RutaCreacionEdi = @"C:\CreacionArchivosEdi\" + CEA.TipoEdi;

			if (!Directory.Exists(RutaCreacionEdi)) Directory.CreateDirectory(RutaCreacionEdi);

			if (CEA.ContenidoArchivo == "" || CEA.ContenidoArchivo == null)
            {
				resultado = false;

			}
			else
            {
				StreamWriter sw = new StreamWriter(RutaCreacionEdi + "\\" + CEA.NombreArchivo, true);
				sw.WriteLine(CEA.ContenidoArchivo);
				sw.Flush();
				sw.Close();
			}

			return resultado;

		}
    }
}
