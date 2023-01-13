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
using System.ComponentModel;
using System.Linq;
using ClosedXML;

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
                    config = 5;
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

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            // Obtener informacion del DataGridView
            List<ReporteEventos> lista_eventos = dgvEventos.DataSource as List<ReporteEventos>;
            DataTable dt = new DataTable();

            // Crear columnas para DataTable
            foreach (System.Reflection.PropertyInfo item in typeof(ReporteEventos).GetProperties())
            {
                dt.Columns.Add(item.Name);
            }

            // Llenar el datable con la informacion obtenida del DataGridView
            foreach (ReporteEventos item in lista_eventos.OrderByDescending(vl => vl.FechaIngreso))
            {
                System.Data.DataRow dr = dt.NewRow();

                foreach (PropertyDescriptor subitem in TypeDescriptor.GetProperties(item))
                {
                    object valor = subitem.GetValue(item);
                    dr[subitem.Name] = valor;
                }

                dt.Rows.Add(dr);
            }

            // Funcion para generar excel
            GenerarExcel(dt);
        }

        public void GenerarExcel(DataTable dt)
        {
            XLWorkbook wb = new XLWorkbook();
            IXLWorksheet worksheet = wb.Worksheets.Add(dt, "ReporteEdi");

            // Cabecera de los datos
            IXLRow firstRow = worksheet.FirstRow();
            firstRow.Style.Font.Bold = true;

            //Contenido
            worksheet.Rows().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Rows().Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.ExpandColumns();
            worksheet.Columns().AdjustToContents();

            GuardarExcel(wb);
            //wb.SaveAs(@"C:\Interfaces_HG\prueba.xlsx");
        }

        public void GuardarExcel(XLWorkbook wb)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xlsx)|*.xlsx";
            object value = wb.Worksheet("ReporteEdi").Cell(2, 3).Value;

            sfd.FileName = "Reporte de Eventos_" + value + " " + DateTime.Today.Day + "-" +
                                                   DateTime.Today.Month + "-" +
                                                   DateTime.Today.Year + "_.xlsx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                wb.SaveAs(sfd.FileName);

                // Abrir el excel que acabamos de crear
                if (File.Exists(sfd.FileName))
                    System.Diagnostics.Process.Start(sfd.FileName);
            }
            
        }
    }
}
