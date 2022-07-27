using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dar_Formato_Archivos_Edi.Forms_secundarios;
using Dar_Formato_Archivos_Edi.Clases.ClienteEdiTipoArchivo.EdiTipoArchivoFormatos;
using Dar_Formato_Archivos_Edi.DataAccess;
using System.Windows.Forms;
using Dar_Formato_Archivos_Edi.Controllers;

namespace Dar_Formato_Archivos_Edi.Forms_secundarios
{
    public partial class GenerarEdi : Form
    {
        public GenerarEdi()
        {
            InitializeComponent();            

            CboTipoArchivo.DataSource = new DataAccess_TipoArchivo().Listado_TipoArchivo();
            CboTipoArchivo.ValueMember = "ClienteEdiTipoArchivoId";
            CboTipoArchivo.DisplayMember = "Nombre";

            CboEvento.DataSource = new DataAccess_ClienteEdiEvento().Listado_Eventos();
            CboEvento.ValueMember = "ClienteEdiEventoId";
            CboEvento.DisplayMember = "NombreEvento";

            CboClienteEdiConfiguracionId.DataSource = new DataAccess_ClienteEdiConfiguracion().ListadoClienteEdiConfiguracion();
            CboClienteEdiConfiguracionId.ValueMember = "ClienteEdiConfiguracionId";
            CboClienteEdiConfiguracionId.DisplayMember = "descripcion";

        }

        private void BtnGenerarArchivoEdi_Click(object sender, EventArgs e)
        {
            try
            {
                string Evento = CboEvento.Text,
                   TipoArchivo = CboTipoArchivo.Text;

                int ClienteEdiConfiguracionId = Convert.ToInt32(CboClienteEdiConfiguracionId.SelectedValue),
                    ClienteEdiPedidoId = Convert.ToInt32(TxtClienteEdiPedidoId.Text);

                decimal Longitud = Convert.ToDecimal(TxtLatitud.Text),
                        Latitud = Convert.ToDecimal(TxtLongitud.Text);

                DateTime FechaEvento = DtpFechaEvento.Value;

                // using Dar_Formato_Archivos_Edi.Clases.ClienteEdiTipoArchivo.EdiTipoArchivoFormatos;           
                bool resultado = EdiTipoArchivoFormatos.EdiProcesoFormatoArchivo(Evento, TipoArchivo, ClienteEdiConfiguracionId, ClienteEdiPedidoId, Latitud, Longitud, FechaEvento);

                if (!resultado)
                {
                    MessageBox.Show("Ocurrio un error al generar el archivo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
