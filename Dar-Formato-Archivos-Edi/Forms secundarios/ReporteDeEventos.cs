using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Dar_Formato_Archivos_Edi.Clases.ClienteLis;
using Dar_Formato_Archivos_Edi.DataAccess.DataAccess_ClienteLis;
using DataTable = System.Data.DataTable;
using ClosedXML.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using System.IO;

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
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Exportación_de_ajuste_de_inventario.xls";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // Copiar resultados de DataGridView al portapapeles
                procesoExcel();

                object misValue = System.Reflection.Missing.Value;
                Excel.Application xlexcel = new Excel.Application();

                xlexcel.DisplayAlerts = false; // Sin esto obtendrá dos mensajes de confirmación de sobrescritura
                Excel.Workbook xlWorkBook = xlexcel.Workbooks.Add(misValue);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                // Formatear la columna D como texto antes de pegar los resultados, esto era necesario para mis datos
                Excel.Range rng = xlWorkSheet.get_Range("D:D").Cells;
                rng.NumberFormat = "@";

                // Pegar los resultados del portapapeles en el rango de la hoja de cálculo
                Excel.Range CR = (Excel.Range)xlWorkSheet.Cells[1, 1];
                CR.Select();
                xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

                // Por alguna razón la columna A está siempre en blanco en la hoja de trabajo. 
                // Elimina la columna A en blanco y selecciona la celda A1
                Excel.Range delRng = xlWorkSheet.get_Range("A:A").Cells;
                delRng.Delete(Type.Missing);
                xlWorkSheet.get_Range("A1").Select();

                // Guarda el archivo excel en la ubicación capturada desde el SaveFileDialog
                xlWorkBook.SaveAs(sfd.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlexcel.DisplayAlerts = true;
                xlWorkBook.Close(true, misValue, misValue);
                xlexcel.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlexcel);

                // Borrar la selección del Portapapeles y del DataGridView
                Clipboard.Clear();
                dgvEventos.ClearSelection();

                // Abrir el archivo excel recién guardado
                if (File.Exists(sfd.FileName))
                    System.Diagnostics.Process.Start(sfd.FileName);
            }

        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Se ha producido una excepción al liberar el objeto " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
