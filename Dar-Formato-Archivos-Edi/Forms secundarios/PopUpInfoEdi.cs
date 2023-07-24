using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dar_Formato_Archivos_Edi.Clases.Edi;
using Dar_Formato_Archivos_Edi.DataAccess.DataAccess_ClienteEdiPedido;

using System.Windows.Forms;

namespace Dar_Formato_Archivos_Edi.Forms_secundarios
{
    public partial class PopUpInfoEdi : Form
    {
        public string TipoEdi = "";
        public string empresa = "";
        public int ClienteEdiPedidoId;

        public PopUpInfoEdi(int clienteEdiPedidoId, string tipoEdi, string empresa)
        {
            InitializeComponent();
        
            this.ClienteEdiPedidoId = clienteEdiPedidoId;
            this.TipoEdi = tipoEdi;
            this.empresa = empresa;

            obtenerInformacionEdi();
        }

        public void obtenerInformacionEdi()
        {
            if (TipoEdi == "997")
            {

            }
            else if (TipoEdi == "824")
            {
                var edi824 = getEdi824(ClienteEdiPedidoId);
                dtgEdiResult.DataSource = edi824;

                //scacSender
                dtgEdiResult.AutoResizeColumn(0, DataGridViewAutoSizeColumnMode.ColumnHeader);
                //scacReceiver
                dtgEdiResult.AutoResizeColumn(1, DataGridViewAutoSizeColumnMode.ColumnHeader);
                //application_ErrorCode
                dtgEdiResult.AutoResizeColumn(2, DataGridViewAutoSizeColumnMode.AllCellsExceptHeader);
                //message_Error
                dtgEdiResult.AutoResizeColumn(3, DataGridViewAutoSizeColumnMode.AllCellsExceptHeader);
                //dateIssue
                dtgEdiResult.AutoResizeColumn(4, DataGridViewAutoSizeColumnMode.AllCellsExceptHeader);
                //reference_Code
                dtgEdiResult.AutoResizeColumn(5, DataGridViewAutoSizeColumnMode.AllCellsExceptHeader);
                //reference_Description
                dtgEdiResult.AutoResizeColumn(6, DataGridViewAutoSizeColumnMode.AllCellsExceptHeader);
                //interchangeDate
                dtgEdiResult.AutoResizeColumn(7, DataGridViewAutoSizeColumnMode.AllCellsExceptHeader);
                //entryDate
                dtgEdiResult.AutoResizeColumn(8, DataGridViewAutoSizeColumnMode.AllCellsExceptHeader);
                //filesContent
                dtgEdiResult.AutoResizeColumn(9, DataGridViewAutoSizeColumnMode.ColumnHeader);
            
            }
        }


        public List<Edi824> getEdi824(int ClienteEdiPedidoId)
        {
            return DataAccess_ClienteEdiPedido.getEdi824(ClienteEdiPedidoId, empresa);
        }
    }
}
