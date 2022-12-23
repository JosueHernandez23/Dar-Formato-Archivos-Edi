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
using Microsoft.Office.Interop.Excel;
using System.Collections;
using DataTable = System.Data.DataTable;
using Dar_Formato_Archivos_Edi.Conexion;
using System.IO;
using ClosedXML.Excel;
using System.Data.SqlClient;
using Azure;
using DocumentFormat.OpenXml.Bibliography;

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

        //public List<ReporteEventos> GetReporteExcel(string db)
        //{
        //    DataAccess_ClienteLis dataAccess_ClienteEdiPedido = new DataAccess_ClienteLis();

        //    var resultado = dgvEventos.DataSource;
        //    return dataAccess_ClienteEdiPedido.GetReporte(db);
        //}



        //Combo Box Para filtrar la base de datos siempre y cuando el campo no sea vacio
        public void cBoxSQL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxSQL.SelectedIndex.ToString() != "")
            {
                MessageBox.Show("Favor de esperar a que termine de procesar los datos...");
                dgvEventos.DataSource = GetReporte(cBoxSQL.Text);
                MessageBox.Show("Se Completo Correctamente");
            }
        }

        public void procesoExcel() //Generar Excel
        {
            dgvEventos.SelectAll();
            DataObject dataObj = dgvEventos.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            XLWorkbook wb = new XLWorkbook();
            string esc = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            SaveFileDialog file = new SaveFileDialog();
            DataTable data = new DataTable(); //(DataTable)(dgvEventos.DataSource);

            dgvEventos.SelectAll();
            DataObject dataObj = dgvEventos.GetClipboardContent();
            DataAccess_ClienteLis da = new DataAccess_ClienteLis();
            data = (DataTable)(dgvEventos.DataSource);

            file.Filter = "Excel Files | *.xlsx";
            //wb.Worksheets.Add((dataObj.ToString()), "Hoja1");
            wb.SaveAs(esc + @"\Prueba.xlms");

            //if (cBoxSQL.SelectedIndex.ToString() != "")
            //{
            //    procesoExcel();
            //    Microsoft.Office.Interop.Excel.Application xlexcel;
            //    Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            //    Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            //    object misValue = System.Reflection.Missing.Value;
            //    xlexcel = new Microsoft.Office.Interop.Excel.Application();
            //    xlexcel.Visible = true;
            //    xlWorkBook = xlexcel.Workbooks.Add(misValue);
            //    xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            //    Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
            //    CR.Select();
            //    xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
            //}
        }
    }
}
