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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEnviarArchivo = new System.Windows.Forms.Button();
            this.lblNombreArchivo = new System.Windows.Forms.Label();
            this.btnSelecArchivo = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.CboClienteEdiConfiguracionId_EnviarArchivo = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFolderDestino = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtLongitud
            // 
            this.TxtLongitud.Location = new System.Drawing.Point(176, 159);
            this.TxtLongitud.Name = "TxtLongitud";
            this.TxtLongitud.Size = new System.Drawing.Size(100, 20);
            this.TxtLongitud.TabIndex = 1;
            // 
            // TxtLatitud
            // 
            this.TxtLatitud.Location = new System.Drawing.Point(39, 159);
            this.TxtLatitud.Name = "TxtLatitud";
            this.TxtLatitud.Size = new System.Drawing.Size(100, 20);
            this.TxtLatitud.TabIndex = 2;
            // 
            // TxtClienteEdiPedidoId
            // 
            this.TxtClienteEdiPedidoId.Location = new System.Drawing.Point(323, 91);
            this.TxtClienteEdiPedidoId.Name = "TxtClienteEdiPedidoId";
            this.TxtClienteEdiPedidoId.Size = new System.Drawing.Size(100, 20);
            this.TxtClienteEdiPedidoId.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Evento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(161, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "ClienteEdiConfiguracionId";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(327, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "ClienteEdiPedidoId";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Latitud";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(205, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Longitud";
            // 
            // DtpFechaEvento
            // 
            this.DtpFechaEvento.Location = new System.Drawing.Point(323, 156);
            this.DtpFechaEvento.MinDate = new System.DateTime(2022, 1, 1, 0, 0, 0, 0);
            this.DtpFechaEvento.Name = "DtpFechaEvento";
            this.DtpFechaEvento.Size = new System.Drawing.Size(200, 20);
            this.DtpFechaEvento.TabIndex = 10;
            this.DtpFechaEvento.Value = new System.DateTime(2022, 7, 19, 0, 0, 0, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(345, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Fecha Evento";
            // 
            // BtnGenerarArchivoEdi
            // 
            this.BtnGenerarArchivoEdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGenerarArchivoEdi.Location = new System.Drawing.Point(221, 224);
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
            this.CboTipoArchivo.Location = new System.Drawing.Point(455, 91);
            this.CboTipoArchivo.Name = "CboTipoArchivo";
            this.CboTipoArchivo.Size = new System.Drawing.Size(121, 24);
            this.CboTipoArchivo.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(483, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Tipo Archivo";
            // 
            // CboEvento
            // 
            this.CboEvento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboEvento.FormattingEnabled = true;
            this.CboEvento.Location = new System.Drawing.Point(28, 89);
            this.CboEvento.Name = "CboEvento";
            this.CboEvento.Size = new System.Drawing.Size(121, 24);
            this.CboEvento.TabIndex = 15;
            // 
            // CboClienteEdiConfiguracionId
            // 
            this.CboClienteEdiConfiguracionId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboClienteEdiConfiguracionId.FormattingEnabled = true;
            this.CboClienteEdiConfiguracionId.Location = new System.Drawing.Point(168, 89);
            this.CboClienteEdiConfiguracionId.Name = "CboClienteEdiConfiguracionId";
            this.CboClienteEdiConfiguracionId.Size = new System.Drawing.Size(121, 24);
            this.CboClienteEdiConfiguracionId.TabIndex = 16;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnGenerarArchivoEdi);
            this.groupBox1.Controls.Add(this.CboClienteEdiConfiguracionId);
            this.groupBox1.Controls.Add(this.TxtLongitud);
            this.groupBox1.Controls.Add(this.CboEvento);
            this.groupBox1.Controls.Add(this.TxtLatitud);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.TxtClienteEdiPedidoId);
            this.groupBox1.Controls.Add(this.CboTipoArchivo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.DtpFechaEvento);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(94, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(595, 308);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generar Archivo Edi";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtFolderDestino);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.btnEnviarArchivo);
            this.groupBox2.Controls.Add(this.lblNombreArchivo);
            this.groupBox2.Controls.Add(this.btnSelecArchivo);
            this.groupBox2.Controls.Add(this.txtPassword);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtUser);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtServer);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.CboClienteEdiConfiguracionId_EnviarArchivo);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(41, 391);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(836, 261);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Enviar Archivo";
            // 
            // btnEnviarArchivo
            // 
            this.btnEnviarArchivo.Location = new System.Drawing.Point(241, 211);
            this.btnEnviarArchivo.Name = "btnEnviarArchivo";
            this.btnEnviarArchivo.Size = new System.Drawing.Size(112, 34);
            this.btnEnviarArchivo.TabIndex = 27;
            this.btnEnviarArchivo.Text = "Enviar archivo";
            this.btnEnviarArchivo.UseVisualStyleBackColor = true;
            this.btnEnviarArchivo.Click += new System.EventHandler(this.btnEnviarArchivo_Click);
            // 
            // lblNombreArchivo
            // 
            this.lblNombreArchivo.AutoSize = true;
            this.lblNombreArchivo.Location = new System.Drawing.Point(204, 141);
            this.lblNombreArchivo.Name = "lblNombreArchivo";
            this.lblNombreArchivo.Size = new System.Drawing.Size(49, 13);
            this.lblNombreArchivo.TabIndex = 26;
            this.lblNombreArchivo.Text = "Archivo: ";
            // 
            // btnSelecArchivo
            // 
            this.btnSelecArchivo.Location = new System.Drawing.Point(28, 131);
            this.btnSelecArchivo.Name = "btnSelecArchivo";
            this.btnSelecArchivo.Size = new System.Drawing.Size(129, 33);
            this.btnSelecArchivo.TabIndex = 25;
            this.btnSelecArchivo.Text = "Seleccionar archivo";
            this.btnSelecArchivo.UseVisualStyleBackColor = true;
            this.btnSelecArchivo.Click += new System.EventHandler(this.btnSelecArchivo_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(496, 82);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(152, 20);
            this.txtPassword.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(536, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Password";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(330, 82);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(146, 20);
            this.txtUser.TabIndex = 23;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(398, 51);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "User";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(176, 82);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(132, 20);
            this.txtServer.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(218, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Server";
            // 
            // CboClienteEdiConfiguracionId_EnviarArchivo
            // 
            this.CboClienteEdiConfiguracionId_EnviarArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboClienteEdiConfiguracionId_EnviarArchivo.FormattingEnabled = true;
            this.CboClienteEdiConfiguracionId_EnviarArchivo.Location = new System.Drawing.Point(28, 78);
            this.CboClienteEdiConfiguracionId_EnviarArchivo.Name = "CboClienteEdiConfiguracionId_EnviarArchivo";
            this.CboClienteEdiConfiguracionId_EnviarArchivo.Size = new System.Drawing.Size(121, 24);
            this.CboClienteEdiConfiguracionId_EnviarArchivo.TabIndex = 20;
            this.CboClienteEdiConfiguracionId_EnviarArchivo.SelectionChangeCommitted += new System.EventHandler(this.CboClienteEdiConfiguracionId_EnviarArchivo_SelectionChangeCommitted);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "ClienteEdiConfiguracionId";
            // 
            // txtFolderDestino
            // 
            this.txtFolderDestino.Location = new System.Drawing.Point(672, 82);
            this.txtFolderDestino.Name = "txtFolderDestino";
            this.txtFolderDestino.Size = new System.Drawing.Size(146, 20);
            this.txtFolderDestino.TabIndex = 25;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(702, 51);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "Folder Destino";
            // 
            // GenerarEdi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 664);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "GenerarEdi";
            this.Text = "GenerarEdi";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSelecArchivo;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox CboClienteEdiConfiguracionId_EnviarArchivo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnEnviarArchivo;
        private System.Windows.Forms.Label lblNombreArchivo;
        private System.Windows.Forms.TextBox txtFolderDestino;
        private System.Windows.Forms.Label label12;
    }
}