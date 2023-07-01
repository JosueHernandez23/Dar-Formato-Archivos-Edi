using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dar_Formato_Archivos_Edi.Clases.Edi
{
    public class Edi824
    {
        public string scacSender { get; set; }
        public string scacReceiver { get; set; }
        public string application_ErrorCode { get; set; }
        public string message_Error { get; set; }
        public DateTime dateIssue { get; set; }
        public string reference_Code { get; set; }
        public string reference_Description { get; set; }
        public DateTime interchangeDate { get; set; }
        public DateTime entryDate { get; set; }
        public string filesContent { get; set; }
    }
}
