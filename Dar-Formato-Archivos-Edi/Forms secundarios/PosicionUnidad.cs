using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dar_Formato_Archivos_Edi.Clases.ClienteLis;
using Dar_Formato_Archivos_Edi.DataAccess.DataAccess_ClienteLis;
using Dar_Formato_Archivos_Edi.Properties;

namespace Dar_Formato_Archivos_Edi.Forms_secundarios
{
    public partial class PosicionUnidad : Form
    {
        public string IdUnidad = "";
        public string bd = "";
        public DateTime FechaInicio;

        public PosicionUnidad(string bd, string idUnidad, DateTime fechaInicio)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.bd = bd;
            this.IdUnidad = idUnidad;
            this.FechaInicio = fechaInicio;
            InicializarPantalla();
        }

        public void InicializarPantalla()
        {
            this.Text = "Unidad: " + IdUnidad;
            this.ResizeRedraw = true;
            btnBuscar.MouseEnter += HoverEnter;
            btnBuscar.MouseLeave += HoverLeave;
            pbEstatus.Visible = false;
            dtDatos.ForeColor = Color.Black;

            Dictionary<string, string> origenDatos = new Dictionary<string, string> 
            {
                {"REPOSITORIO", "Repositorio" },
                {"TRUCKS", "Trucks" }
            };

            cboOrigenDatos.DataSource = new BindingSource(origenDatos, null); 
            cboOrigenDatos.ValueMember = "Key";
            cboOrigenDatos.DisplayMember = "Value";

            dtFechaInicio.MinDate = FechaInicio.AddDays(-1);
            dtFechaInicio.MaxDate = FechaInicio;

            dtFechaFin.MinDate = FechaInicio;
            dtFechaFin.MaxDate = FechaInicio.AddDays(3);
        }

        public static void HoverEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.White;
            btn.ForeColor = Color.Black;
            btn.Cursor = Cursors.Hand;
        }

        public static void HoverLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.FromArgb(46, 51, 73);
            btn.ForeColor = Color.White;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                btnBuscar.Enabled = false;

                pbEstatus.Enabled = true;
                pbEstatus.Visible = true;
                pbEstatus.Image = Resources.loading;

                new Thread(() =>
                {
                    var posiciones = GetPosicionUnidad(cboOrigenDatos.SelectedValue.ToString(), Convert.ToDateTime(dtFechaInicio.Text), Convert.ToDateTime(dtFechaFin.Text).AddHours(23).AddMinutes(59).AddSeconds(59));

                    if (posiciones.Any())
                    {
                        dtDatos.DataSource = posiciones.Select(s => new
                        {
                            NoViaje = s.NoViaje,
                            Unidad = s.IdUnidad,
                            Posdate = s.posdate.ToString("dd/MM/yyyy HH:mm:ss"),
                            Ubicacion = s.ubicacion,
                            Evento = s.EventTypeDescription,
                            Posicion = s.Posicion,
                            SiteId = s.SiteId,
                            EventSubType = s.EventSubType,
                            Latitud = s.Latitud,
                            Longitud = s.Longitud,
                            Velocidad = s.Velocidad,
                            posdate_inserto = s.posdate_inserto,
                            Sistema_Origen = s.Sistema_origen
                        }).ToList();

                        // Configurar columnas para mostrar la informacion importante

                        // NoViaje
                        dtDatos.AutoResizeColumn(0, DataGridViewAutoSizeColumnMode.AllCellsExceptHeader);
                        // Unidad
                        dtDatos.AutoResizeColumn(1, DataGridViewAutoSizeColumnMode.AllCellsExceptHeader);
                        // Posdate
                        dtDatos.AutoResizeColumn(2, DataGridViewAutoSizeColumnMode.AllCellsExceptHeader);
                        // Ubicacion
                        dtDatos.AutoResizeColumn(3, DataGridViewAutoSizeColumnMode.AllCellsExceptHeader);
                        // Evento
                        dtDatos.AutoResizeColumn(4, DataGridViewAutoSizeColumnMode.AllCellsExceptHeader);
                        // Posicion
                        dtDatos.AutoResizeColumn(5, DataGridViewAutoSizeColumnMode.ColumnHeader);
                        // SiteId
                        dtDatos.AutoResizeColumn(6, DataGridViewAutoSizeColumnMode.ColumnHeader);
                        // EventSubType
                        dtDatos.AutoResizeColumn(7, DataGridViewAutoSizeColumnMode.ColumnHeader);
                        // Latitud
                        dtDatos.AutoResizeColumn(8, DataGridViewAutoSizeColumnMode.AllCellsExceptHeader);
                        // Longitud
                        dtDatos.AutoResizeColumn(9, DataGridViewAutoSizeColumnMode.AllCellsExceptHeader);
                        // Velocidad
                        dtDatos.AutoResizeColumn(10, DataGridViewAutoSizeColumnMode.ColumnHeader);
                        // posdate_inserto
                        dtDatos.AutoResizeColumn(11, DataGridViewAutoSizeColumnMode.AllCellsExceptHeader);
                        // Sistema_Origen
                        dtDatos.AutoResizeColumn(12, DataGridViewAutoSizeColumnMode.AllCellsExceptHeader);
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron resultados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    btnBuscar.Enabled = true;
                    pbEstatus.Visible = true;
                    pbEstatus.Image = Resources.Complete;

                }).Start();
            }
            catch (Exception ex)
            {

            }
        }

        public List<posicion_unidad> GetPosicionUnidad(string origenDatos, DateTime fechaInicio, DateTime fechaFin)
        {
            DataAccess_ClienteLis dataAccess_ClienteLis = new DataAccess_ClienteLis();

            return dataAccess_ClienteLis.GetPosicionUnidad(bd, IdUnidad, origenDatos, fechaInicio, fechaFin);
        }
    }
}
