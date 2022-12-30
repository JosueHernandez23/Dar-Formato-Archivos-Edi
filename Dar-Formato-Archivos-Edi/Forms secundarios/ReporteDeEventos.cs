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
using System.Threading;
using System.Windows.Documents;
using Dar_Formato_Archivos_Edi.Properties;

namespace Dar_Formato_Archivos_Edi.Forms_secundarios
{
    public partial class ReporteDeEventos : Form
    {

        public ReporteDeEventos()
        {
            InitializeComponent();
            pbCargandoDatos.Hide();

            if (cBoxSQL.SelectedIndex.ToString() == "" || dgvEventos.DataSource == null)
                dgvEventos.ClearSelection();
                btnExportExcel.Hide();
        }

        public List<ReporteEventos> GetReporte(string db,int config)
        {
            DataAccess_ClienteLis dataAccess_ClienteEdiPedido = new DataAccess_ClienteLis();

            return dataAccess_ClienteEdiPedido.GetReporte(db,config);
        }


        //Combo Box Para filtrar la base de datos siempre y cuando el campo no sea vacio
        public void cBoxSQL_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Thread thread1 = new Thread(new ThreadStart(CargaDataGrid));
            if (cBoxSQL.SelectedIndex.ToString() != "" || dgvEventos.DataSource != null)
                
                lblComplete.Text = "Espera a que termine de cargar los datos";
                pbCargandoDatos.Show();
                thread1.Start();
                btnExportExcel.Show();
        }

        public void CargaDataGrid() {
            string db;
            object config;

            if (cBoxSQL.SelectedIndex.ToString() != "" || dgvEventos.DataSource != null)
            {
                MessageBox.Show("Favor de esperar a que termine de procesar los datos...");
                pbCargandoDatos.Image = Resources.loading;
                dgvEventos.ForeColor = System.Drawing.Color.Black;

                if (cBoxSQL.SelectedIndex.ToString(cBoxSQL.Text) == "CHDB_LIS")
                {
                    db = cBoxSQL.Text;
                    config = 1;
                    dgvEventos.DataSource = GetReporte(db, (int)config);
                    MessageBox.Show("Se Cargaron Completamente los datos");
                }

                if (cBoxSQL.SelectedIndex.ToString(cBoxSQL.Text) == "HGDB_LIS")
                {
                    db = cBoxSQL.Text;
                    config = 2;
                    dgvEventos.DataSource = GetReporte(db, (int)config);
                    MessageBox.Show("Se Cargaron Completamente los datos");
                }

                if (cBoxSQL.SelectedIndex.ToString(cBoxSQL.Text) == "RLDB_LIS")
                {
                    db = cBoxSQL.Text;
                    config = 7;
                    dgvEventos.DataSource = GetReporte(db, (int)config);
                    MessageBox.Show("Se Cargaron Completamente los datos");
                }

                if (cBoxSQL.SelectedIndex.ToString(cBoxSQL.Text) == "LINDADB")
                {
                    db = cBoxSQL.Text;
                    config = 8;
                    dgvEventos.DataSource = GetReporte(db, (int)config);
                    MessageBox.Show("Se Cargaron Completamente los datos");
                }

                lblComplete.Text = "Se Completo la carga de datos";
                pbCargandoDatos.Image = Resources.Complete;
                btnExportExcel.Show();
            }
        }

        public void procesoExcel() //Generar Excel
        {
            dgvEventos.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText; //Se selec
            dgvEventos.SelectAll();
            DataObject dataObj = dgvEventos.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Reporte de Eventos_" + DateTime.Today.Day    + "-" +
                                                   DateTime.Today.Month  + "-" +
                                                   DateTime.Today.Year   + "_" + "_.xls";

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
