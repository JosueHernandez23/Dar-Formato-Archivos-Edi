using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dar_Formato_Archivos_Edi.Clases.ClienteEdiPedido;
using Dar_Formato_Archivos_Edi.Clases.PedidoRelacionado;
using Dar_Formato_Archivos_Edi.Clases.ClienteLis;
using Dar_Formato_Archivos_Edi.Clases.ClienteEdiPedidoDireccion;
using Dar_Formato_Archivos_Edi.Clases.ClienteEdiNotificaEvento;
using Dar_Formato_Archivos_Edi.Clases.ClienteEdiEstatusSeguimiento;
using Dar_Formato_Archivos_Edi.DataAccess.DataAccess_ClienteEdiPedido;
using Dar_Formato_Archivos_Edi.DataAccess.DataAccess_PedidoRelacionado;
using Dar_Formato_Archivos_Edi.DataAccess.DataAccess_ClienteLis;
using System.Drawing.Text;
using System.Diagnostics;

namespace Dar_Formato_Archivos_Edi.Forms_secundarios
{
    public partial class ReporteDeEventos : Form
    {


        public ReporteDeEventos()
        {
            InitializeComponent();

        }

        public List<ReporteEventos> GetReporte(string db)
        {
            DataAccess_ClienteLis dataAccess_ClienteEdiPedido = new DataAccess_ClienteLis();

            return dataAccess_ClienteEdiPedido.GetReporte(db);
        }
         



        public void cBoxSQL_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (cBoxSQL.SelectedIndex.ToString() != "")
            {
                MessageBox.Show("Favor de esperar a que termine de procesar los datos...");
                dgvEventos.DataSource = GetReporte(cBoxSQL.Text);
                MessageBox.Show("Se Completo Correctamente");
            }
        }
        public void proceso(DataGridViewBindingCompleteEventHandler e,object sender)
        { 
        
        
        }
    }
}
