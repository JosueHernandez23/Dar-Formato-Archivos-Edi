using ClosedXML.Excel;
using Dar_Formato_Archivos_Edi.Clases.ClienteLis;
using Dar_Formato_Archivos_Edi.DataAccess.DataAccess_ClienteEdiPedido;
using Dar_Formato_Archivos_Edi.DataAccess.DataAccess_ClienteLis;
using Dar_Formato_Archivos_Edi.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition.Primitives;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Dar_Formato_Archivos_Edi.Forms_secundarios
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            pbCargandoDatos.Hide();
            dgvReporteEstadistica.ClearSelection();
            btnExportExcel.Hide();
        }

        public List<GetEstadisticas> GetReportEstadistica()
        {
            string db = "edidb";
            DataAccess_ClienteLis dataAccess_ClienteEdiPedido = new DataAccess_ClienteLis();
            return dataAccess_ClienteEdiPedido.GetReportEstadistica(db);
        }

        private void btnEstadistica_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Thread thread2 = new Thread(new ThreadStart(CargaDataGrid));
            if (dgvReporteEstadistica.DataSource == null)
                thread2.Start();
            pbCargandoDatos.Show();
            btnExportExcel.Show();

        }

        public void CargaDataGrid()
        {
            if (dgvReporteEstadistica.DataSource == null)
            {
                MessageBox.Show("Favor de esperar a que termine de procesar los datos...");
                lblComplete.Text = "Espera a que termine de cargar los datos";
                pbCargandoDatos.Show();
                dgvReporteEstadistica.DataSource = GetReportEstadistica();

                MessageBox.Show("Se Cargaron Completamente los datos");
                lblComplete.Text = "Se Completo la carga de datos";
                pbCargandoDatos.Image = Resources.Complete;
                btnExportExcel.Show();
            }
        }
        

        //Parte de Excel
        private void button1_Click(object sender, EventArgs e)
        {
            // Obtener informacion del DataGridView
            List<GetEstadisticas> lista_eventos = dgvReporteEstadistica.DataSource as List<GetEstadisticas>;
            DataTable dt = new DataTable();

            // Crear columnas para DataTable
            foreach (System.Reflection.PropertyInfo item in typeof(GetEstadisticas).GetProperties())
            {
                dt.Columns.Add(item.Name);
            }

            // Llenar el datable con la informacion obtenida del DataGridView
            foreach (GetEstadisticas item in lista_eventos.OrderByDescending(vl => vl.RelacionadosTrucks))
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
            IXLWorksheet worksheet = wb.Worksheets.Add(dt, "Table_ReporteDiario");

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
            object value = wb.Worksheet("Table_ReporteDiario").Cell(2, 3).Value;

            sfd.FileName = "Estadistica de Eventos_" + value + " " + DateTime.Today.Day + "-" +
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
