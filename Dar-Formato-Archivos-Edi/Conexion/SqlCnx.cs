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
        public string connectionString { get; } = "Password=SitioM1; Persist Security Info=True; User ID=sa; Initial Catalog=edidb; Data Source=192.168.40.1; app=Edis; Connection Timeout=3600";

        public string connectionString_Lis { get; } = "Password=Dbs4Hgsqy2!; Persist Security Info=True; User ID=hgUser2008; Initial Catalog=@DB@; Data Source=hg.sql2008.midireccion.com; app=Edis; Connection Timeout=3600; TrustServerCertificate=false; Encrypt=True;";

        public string connectionString_Hg_Cloud { get; } = "Password=hg7w34eg.; Persist Security Info=True; User ID=hguser; Initial Catalog=hgdb_lis; Data Source=hg.sql.midireccion.com; app=EdiTracker; Connection Timeout=180; Application Name=EdiTracker; TrustServerCertificate=false; Encrypt=True;";

        public string connectionString_Edi_Cloud { get; } = "Password=hg7w34eg.; Persist Security Info=True; User ID=hguser; Initial Catalog=edidb; Data Source=hg.sql.midireccion.com; app=EdiTracker; Connection Timeout=180; Application Name=EdiTracker; TrustServerCertificate=false; Encrypt=True;";

    }
}
