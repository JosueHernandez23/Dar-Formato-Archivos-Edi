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
using NuGet.Protocol.Plugins;
using DocumentFormat.OpenXml.Bibliography;
using System.Data;
using Dar_Formato_Archivos_Edi.DataAccess.DataAccess_ClienteEdiPedido;
using Org.BouncyCastle.Asn1.X509;

namespace Dar_Formato_Archivos_Edi.Forms_secundarios
{
    
    public partial class ReporteDeEventos : Form
    {
        //Inicio del Form
        public ReporteDeEventos() 
        {
            InitializeComponent();
            pbCargandoDatos.Hide();

            if (cBoxSQL.SelectedIndex.ToString() == "" || dgvEventos.DataSource == null)
                dgvEventos.ClearSelection();
            btnExportExcel.Hide();
        }


        //Lista de obtencion de datos por configuracion por configuracion y reporte de eventos
        public List<ConfiguracionCliente> GetCLientesConfiguracion(string db)
        {
            DataAccess_ClienteEdiPedido dataAccess_ClienteEdiPedido = new DataAccess_ClienteEdiPedido();
            return dataAccess_ClienteEdiPedido.GetClienteEdiConfiguracion(db);
        }
        public List<ReporteEventos> GetReporte(string db, int config)
        {
            DataAccess_ClienteLis dataAccess_ClienteEdiPedido = new DataAccess_ClienteLis();
            return dataAccess_ClienteEdiPedido.GetReporte(db, config);
        }

       

        //Proceso donde se ejecuta la obtencion y Seteos de informacion
        private void cBoxSQL_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetClienteConfiguracion(cBoxSQL.SelectedItem.ToString());
            cBoxClienteId.Text = " ";
        }

        private void cBoxClienteId_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            CargaDataGrid();
        }

        /* SETEO DE INFORMACION ALMACENADAS POR LA BUSQUEDA EN LA BASE DE DATOS DE CADA OPCION */
        //Seteo de informacion en el combo box obtenido de la base de datos por el cBoxCLienteId de configuracion de base de datos
        public void SetClienteConfiguracion(string db)
        {
            List<ConfiguracionCliente> lista = GetCLientesConfiguracion(db);
            cBoxClienteId.Visible = true;
            if (lista.Count > 0)
            {
                cBoxClienteId.DisplayMember = "descripcion";
                cBoxClienteId.ValueMember = "ClienteEdiConfiguracionId";
                cBoxClienteId.DataSource = lista;
                cBoxClienteId.Text = "";
            }
        }

        //Se llena el DataGrid de los pedidos encontrados que se obtuvo los eventos reportados por cada uno
        public void CargaDataGrid()
        {
            string db = cBoxSQL.Text;
            object config = cBoxClienteId.SelectedValue;

            if (cBoxSQL.SelectedIndex.ToString() != "" || dgvEventos.DataSource != null)
            {
                pbCargandoDatos.Image = Resources.loading;
                dgvEventos.ForeColor = System.Drawing.Color.Black;

                if (config != null || dgvEventos.DataSource != null)
                {
                    MessageBox.Show("Favor de esperar a que termine de procesar los datos...");
                    lblEspera.Text = "Cargando Datos";
                    pbCargandoDatos.Visible = true;
                    pbCargandoDatos.Image = Resources.loading;

                    dgvEventos.DataSource = GetReporte(db, (int)config);
                    MessageBox.Show("Se Cargaron Completamente los datos");
                    lblComplete.Text = "Se Completo la carga de datos";
                    pbCargandoDatos.Image = Resources.Complete;
                    pbCargandoDatos.Visible = true;
                    btnExportExcel.Show();
                }
            }
        }

        //Parte donde se reporta los eventos encontrados en un Reporte de Excel.
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
        }

        public void GuardarExcel(XLWorkbook wb)
        {
            List<ConfiguracionCliente> lista = GetCLientesConfiguracion(cBoxSQL.Text);
            cBoxClienteId.DisplayMember = "descripcion";
            cBoxClienteId.ValueMember = "ClienteEdiConfiguracionId";
            cBoxClienteId.DataSource = lista;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xlsx)|*.xlsx";
            if (lista.Count > 0)
            {
                cBoxClienteId.DisplayMember = "descripcion";
                cBoxClienteId.ValueMember = "ClienteEdiConfiguracionId";
                cBoxClienteId.DataSource = lista;
                //cBoxClienteId.Text = "";
            }

            object value = wb.Worksheet("ReporteEdi").Cell(2, 3).Value;
            string valor = lista.Select(s => s.descripcion).FirstOrDefault().ToString();
            
            
            sfd.FileName = "Reporte de Eventos_" + value + "_" + valor + DateTime.Today.Day + " -" +
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
