using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dar_Formato_Archivos_Edi.Clases.ClienteEdiConfiguracion
{
    public class ClienteEdiConfiguracion
    {
        public int ClienteEdiConfiguracionId { get; set; }
        public string descripcion { get; set; }
        public string SFTPServerPRD { get; set; }
        public string SFTPUsuarioPRD { get; set; }
        public string SFTPPasswordPRD { get; set; }
        public string FolderDestino { get; set; }
    }
}
