using Dar_Formato_Archivos_Edi.Clases.ClienteEdiPedido;
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

namespace Dar_Formato_Archivos_Edi.PopUp
{
    public partial class EdiShipmentDuplicado : Form
    {
        private List<ClienteEdiPedido> _EdiPedidos;
        public int ClienteEdiPedido { get; set; }
        public EdiShipmentDuplicado(List<ClienteEdiPedido> EdiPedidos)
        {
            InitializeComponent();

            DtgShipment.DataSource = EdiPedidos.Select(vl => new
            {
                Shipment = vl.Shipment,
                Archivo = vl.ClienteEdiPedidoId,
                Cruce = vl.Cruce == 1 ? "Si" : "No"
            }).ToList();

            // Shipment
            DtgShipment.AutoResizeColumn(0, DataGridViewAutoSizeColumnMode.ColumnHeader);
            // ClienteEdiPedidoId
            DtgShipment.AutoResizeColumn(1, DataGridViewAutoSizeColumnMode.AllCells);
        }

        private void DtgShipment_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                ClienteEdiPedido =  Convert.ToInt32(DtgShipment.Rows[e.RowIndex].Cells[1].Value);
                DtgShipment.Enabled = false;
                
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
