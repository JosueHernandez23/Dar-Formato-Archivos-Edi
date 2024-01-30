using Dar_Formato_Archivos_Edi.Clases.ClienteLis;
using Dar_Formato_Archivos_Edi.Clases.Cruce;
using Dar_Formato_Archivos_Edi.DataAccess;
using Dar_Formato_Archivos_Edi.DataAccess.DataAccess_ClienteEdiPedido;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dar_Formato_Archivos_Edi.Forms_secundarios
{
    public partial class InfoCruce : Form
    {
        public InfoCruce()
        {
            InitializeComponent();
            dtgEnviado.ForeColor = Color.Black;
            dtgRecibido.ForeColor = Color.Black;
        }

        private void btnEnviado_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = dtFechaInicioEnviado.Value;
            DateTime fechaFino = dtFechaFinEnviado.Value;

            var infoEnviada = GetInformacionEnviada(fechaInicio, fechaFino, "hgdb_lis");

            dtgEnviado.DataSource = infoEnviada;
        }

        private void btnRecibido_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = dtFechaInicioRecibido.Value;
            DateTime fechaFino = dtFechaFinRecibido.Value;

            var infoEnviada = GetInformacionRecibida(fechaInicio, fechaFino, "hgdb_lis");

            dtgRecibido.DataSource = infoEnviada;
        }

        public List<SitExpoRepository> GetInformacionEnviada(DateTime fechaInicio, DateTime fechaFin, string db)
        {
            DataAccess_ViajeCruce dataAccess_ViajeCruce = new DataAccess_ViajeCruce();

            return dataAccess_ViajeCruce.GetInformacionEnviada(fechaInicio, fechaFin, db);
        }

        public List<ViajesCruce> GetInformacionRecibida(DateTime fechaInicio, DateTime fechaFin, string db)
        {
            DataAccess_ViajeCruce dataAccess_ViajeCruce = new DataAccess_ViajeCruce();

            return dataAccess_ViajeCruce.GetInformacionRecibida(fechaInicio, fechaFin, db);
        }
    }
}
