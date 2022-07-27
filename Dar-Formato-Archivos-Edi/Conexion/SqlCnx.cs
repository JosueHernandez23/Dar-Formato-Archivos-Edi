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
        public string connectionString { get; } = "Password=SitioM1; Persist Security Info=True; User ID=sa; Initial Catalog=edidb; Data Source=192.168.40.1; app=Edis; Connection Timeout=180";
    }
}
