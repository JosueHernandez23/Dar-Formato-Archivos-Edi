using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dar_Formato_Archivos_Edi.Conexion
{
    public class SqlCnx
    {
        public string connectionString { get; } = "Server=hg.sql2008.midireccion.com; Initial Catalog=edidb; UID=hgsupport2008; pwd=hgw700qww!; TrustServerCertificate=false; app=EdiTracker; Encrypt=True; Connection Timeout=3600";

        public string connectionString_Lis { get; } = "Server=hg.sql2008.midireccion.com; Initial Catalog=@DB@; UID=hgsupport2008; pwd=hgw700qww!; TrustServerCertificate=false; app=EdiTracker; Encrypt=True; Connection Timeout=3600";

        public string connectionString_Hg_Cloud { get; } = "Password=hg7w34eg.; Persist Security Info=True; User ID=hguser; Initial Catalog=hgdb_lis; Data Source=hg.sql.midireccion.com; app=EdiTracker; Connection Timeout=180; Application Name=EdiTracker; TrustServerCertificate=false; Encrypt=True;";

        public string connectionString_Edi_Cloud { get; } = "Password=hg7w34eg.; Persist Security Info=True; User ID=hguser; Initial Catalog=edidb; Data Source=hg.sql.midireccion.com; app=EdiTracker; Connection Timeout=180; Application Name=EdiTracker; TrustServerCertificate=false; Encrypt=True;";

    }
}
