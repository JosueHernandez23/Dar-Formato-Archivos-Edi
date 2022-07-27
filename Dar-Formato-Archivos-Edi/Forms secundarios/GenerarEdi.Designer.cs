namespace Dar_Formato_Archivos_Edi.Forms_secundarios
{
    partial class GenerarEdi
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
            this.TxtLongitud = new System.Windows.Forms.TextBox();
            this.TxtLatitud = new System.Windows.Forms.TextBox();
            this.TxtClienteEdiPedidoId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DtpFechaEvento = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnGenerarArchivoEdi = new System.Windows.Forms.Button();
            this.CboTipoArchivo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CboEvento = new System.Windows.Forms.ComboBox();
            this.CboClienteEdiConfiguracionId = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // TxtLongitud
            // 
            this.TxtLongitud.Location = new System.Drawing.Point(248, 181);
            this.TxtLongitud.Name = "TxtLongitud";
            this.TxtLongitud.Size = new System.Drawing.Size(100, 20);
            this.TxtLongitud.TabIndex = 1;
            // 
            // TxtLatitud
            // 
            this.TxtLatitud.Location = new System.Drawing.Point(111, 181);
            this.TxtLatitud.Name = "TxtLatitud";
            this.TxtLatitud.Size = new System.Drawing.Size(100, 20);
            this.TxtLatitud.TabIndex = 2;
            // 
            // TxtClienteEdiPedidoId
            // 
            this.TxtClienteEdiPedidoId.Location = new System.Drawing.Point(395, 113);
            this.TxtClienteEdiPedidoId.Name = "TxtClienteEdiPedidoId";
            this.TxtClienteEdiPedidoId.Size = new System.Drawing.Size(100, 20);
            this.TxtClienteEdiPedidoId.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(141, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Evento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "ClienteEdiConfiguracionId";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(399, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "ClienteEdiPedidoId";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(134, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Latitud";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(277, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Longitud";
            // 
            // DtpFechaEvento
            // 
            this.DtpFechaEvento.Location = new System.Drawing.Point(395, 178);
            this.DtpFechaEvento.MinDate = new System.DateTime(2022, 1, 1, 0, 0, 0, 0);
            this.DtpFechaEvento.Name = "DtpFechaEvento";
            this.DtpFechaEvento.Size = new System.Drawing.Size(200, 20);
            this.DtpFechaEvento.TabIndex = 10;
            this.DtpFechaEvento.Value = new System.DateTime(2022, 7, 19, 0, 0, 0, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(417, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Fecha Evento";
            // 
            // BtnGenerarArchivoEdi
            // 
            this.BtnGenerarArchivoEdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGenerarArchivoEdi.Location = new System.Drawing.Point(293, 246);
            this.BtnGenerarArchivoEdi.Name = "BtnGenerarArchivoEdi";
            this.BtnGenerarArchivoEdi.Size = new System.Drawing.Size(155, 40);
            this.BtnGenerarArchivoEdi.TabIndex = 12;
            this.BtnGenerarArchivoEdi.Text = "Generar Archivo Edi";
            this.BtnGenerarArchivoEdi.UseVisualStyleBackColor = true;
            this.BtnGenerarArchivoEdi.Click += new System.EventHandler(this.BtnGenerarArchivoEdi_Click);
            // 
            // CboTipoArchivo
            // 
            this.CboTipoArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboTipoArchivo.FormattingEnabled = true;
            this.CboTipoArchivo.Location = new System.Drawing.Point(527, 113);
            this.CboTipoArchivo.Name = "CboTipoArchivo";
            this.CboTipoArchivo.Size = new System.Drawing.Size(121, 24);
            this.CboTipoArchivo.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(555, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Tipo Archivo";
            // 
            // CboEvento
            // 
            this.CboEvento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboEvento.FormattingEnabled = true;
            this.CboEvento.Location = new System.Drawing.Point(100, 111);
            this.CboEvento.Name = "CboEvento";
            this.CboEvento.Size = new System.Drawing.Size(121, 24);
            this.CboEvento.TabIndex = 15;
            // 
            // CboClienteEdiConfiguracionId
            // 
            this.CboClienteEdiConfiguracionId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboClienteEdiConfiguracionId.FormattingEnabled = true;
            this.CboClienteEdiConfiguracionId.Location = new System.Drawing.Point(240, 111);
            this.CboClienteEdiConfiguracionId.Name = "CboClienteEdiConfiguracionId";
            this.CboClienteEdiConfiguracionId.Size = new System.Drawing.Size(121, 24);
            this.CboClienteEdiConfiguracionId.TabIndex = 16;
            // 
            // GenerarEdi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CboClienteEdiConfiguracionId);
            this.Controls.Add(this.CboEvento);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CboTipoArchivo);
            this.Controls.Add(this.BtnGenerarArchivoEdi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DtpFechaEvento);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtClienteEdiPedidoId);
            this.Controls.Add(this.TxtLatitud);
            this.Controls.Add(this.TxtLongitud);
            this.Name = "GenerarEdi";
            this.Text = "GenerarEdi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TxtLongitud;
        private System.Windows.Forms.TextBox TxtLatitud;
        private System.Windows.Forms.TextBox TxtClienteEdiPedidoId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker DtpFechaEvento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnGenerarArchivoEdi;
        private System.Windows.Forms.ComboBox CboTipoArchivo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CboEvento;
        private System.Windows.Forms.ComboBox CboClienteEdiConfiguracionId;
    }
}