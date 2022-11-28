namespace Dar_Formato_Archivos_Edi.Forms_secundarios
{
    partial class Listado_Segmentos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cboClientes = new System.Windows.Forms.ComboBox();
            this.LblCliente = new System.Windows.Forms.Label();
            this.lblTipoArchivo = new System.Windows.Forms.Label();
            this.cboTipoArchivo = new System.Windows.Forms.ComboBox();
            this.dtDatos = new System.Windows.Forms.DataGridView();
            this.btnSelectClienteSegmento = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // cboClientes
            // 
            this.cboClientes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboClientes.FormattingEnabled = true;
            this.cboClientes.Location = new System.Drawing.Point(371, 30);
            this.cboClientes.Name = "cboClientes";
            this.cboClientes.Size = new System.Drawing.Size(158, 24);
            this.cboClientes.TabIndex = 0;
            // 
            // LblCliente
            // 
            this.LblCliente.AutoSize = true;
            this.LblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCliente.Location = new System.Drawing.Point(306, 33);
            this.LblCliente.Name = "LblCliente";
            this.LblCliente.Size = new System.Drawing.Size(59, 17);
            this.LblCliente.TabIndex = 1;
            this.LblCliente.Text = "Cliente: ";
            // 
            // lblTipoArchivo
            // 
            this.lblTipoArchivo.AutoSize = true;
            this.lblTipoArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoArchivo.Location = new System.Drawing.Point(646, 33);
            this.lblTipoArchivo.Name = "lblTipoArchivo";
            this.lblTipoArchivo.Size = new System.Drawing.Size(95, 17);
            this.lblTipoArchivo.TabIndex = 2;
            this.lblTipoArchivo.Text = "Tipo Archivo: ";
            // 
            // cboTipoArchivo
            // 
            this.cboTipoArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoArchivo.FormattingEnabled = true;
            this.cboTipoArchivo.Location = new System.Drawing.Point(739, 30);
            this.cboTipoArchivo.Name = "cboTipoArchivo";
            this.cboTipoArchivo.Size = new System.Drawing.Size(121, 24);
            this.cboTipoArchivo.TabIndex = 3;
            // 
            // dtDatos
            // 
            this.dtDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtDatos.Location = new System.Drawing.Point(12, 122);
            this.dtDatos.Name = "dtDatos";
            this.dtDatos.Size = new System.Drawing.Size(889, 352);
            this.dtDatos.TabIndex = 4;
            // 
            // btnSelectClienteSegmento
            // 
            this.btnSelectClienteSegmento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectClienteSegmento.Location = new System.Drawing.Point(12, 62);
            this.btnSelectClienteSegmento.Name = "btnSelectClienteSegmento";
            this.btnSelectClienteSegmento.Size = new System.Drawing.Size(137, 36);
            this.btnSelectClienteSegmento.TabIndex = 9;
            this.btnSelectClienteSegmento.Text = "Consultar";
            this.btnSelectClienteSegmento.UseVisualStyleBackColor = true;
            this.btnSelectClienteSegmento.Click += new System.EventHandler(this.btnSelectClienteSegmento_Click);
            // 
            // Listado_Segmentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 487);
            this.Controls.Add(this.btnSelectClienteSegmento);
            this.Controls.Add(this.dtDatos);
            this.Controls.Add(this.cboTipoArchivo);
            this.Controls.Add(this.lblTipoArchivo);
            this.Controls.Add(this.LblCliente);
            this.Controls.Add(this.cboClientes);
            this.Name = "Listado_Segmentos";
            this.Text = "Listado_Segmentos";
            ((System.ComponentModel.ISupportInitialize)(this.dtDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboClientes;
        private System.Windows.Forms.Label LblCliente;
        private System.Windows.Forms.Label lblTipoArchivo;
        private System.Windows.Forms.ComboBox cboTipoArchivo;
        private System.Windows.Forms.DataGridView dtDatos;
        private System.Windows.Forms.Button btnSelectClienteSegmento;
    }
}