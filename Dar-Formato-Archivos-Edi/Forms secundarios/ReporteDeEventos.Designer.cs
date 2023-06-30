namespace Dar_Formato_Archivos_Edi.Forms_secundarios
{
    partial class ReporteDeEventos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteDeEventos));
            this.dgvEventos = new System.Windows.Forms.DataGridView();
            this.cBoxSQL = new System.Windows.Forms.ComboBox();
            this.lblWaiting = new System.Windows.Forms.Label();
            this.lblEspera = new System.Windows.Forms.Label();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.lblComplete = new System.Windows.Forms.Label();
            this.pbCargandoDatos = new System.Windows.Forms.PictureBox();
            this.gbReporteEventosExcel = new System.Windows.Forms.GroupBox();
            this.cBoxClienteId = new System.Windows.Forms.ComboBox();
            this.gbEstatusDelReporte = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCargandoDatos)).BeginInit();
            this.gbReporteEventosExcel.SuspendLayout();
            this.gbEstatusDelReporte.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvEventos
            // 
            this.dgvEventos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEventos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvEventos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvEventos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEventos.Location = new System.Drawing.Point(8, 55);
            this.dgvEventos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvEventos.Name = "dgvEventos";
            this.dgvEventos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgvEventos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvEventos.Size = new System.Drawing.Size(850, 361);
            this.dgvEventos.TabIndex = 0;
            // 
            // cBoxSQL
            // 
            this.cBoxSQL.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cBoxSQL.FormattingEnabled = true;
            this.cBoxSQL.Items.AddRange(new object[] {
            "HGDB_LIS",
            "CHDB_LIS",
            "RLDB_LIS",
            "LINDADB"});
            this.cBoxSQL.Location = new System.Drawing.Point(206, 21);
            this.cBoxSQL.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cBoxSQL.Name = "cBoxSQL";
            this.cBoxSQL.Size = new System.Drawing.Size(150, 24);
            this.cBoxSQL.TabIndex = 1;
            this.cBoxSQL.SelectionChangeCommitted += new System.EventHandler(this.cBoxSQL_SelectionChangeCommitted);
            // 
            // lblWaiting
            // 
            this.lblWaiting.AutoSize = true;
            this.lblWaiting.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaiting.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblWaiting.Location = new System.Drawing.Point(8, 21);
            this.lblWaiting.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWaiting.Name = "lblWaiting";
            this.lblWaiting.Size = new System.Drawing.Size(194, 28);
            this.lblWaiting.TabIndex = 2;
            this.lblWaiting.Text = "Seleccionar Reporte: ";
            // 
            // lblEspera
            // 
            this.lblEspera.AutoSize = true;
            this.lblEspera.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEspera.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblEspera.Location = new System.Drawing.Point(48, 30);
            this.lblEspera.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEspera.Name = "lblEspera";
            this.lblEspera.Size = new System.Drawing.Size(0, 32);
            this.lblEspera.TabIndex = 3;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportExcel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnExportExcel.Location = new System.Drawing.Point(760, 21);
            this.btnExportExcel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(94, 29);
            this.btnExportExcel.TabIndex = 4;
            this.btnExportExcel.Text = "Excel";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // lblComplete
            // 
            this.lblComplete.AutoSize = true;
            this.lblComplete.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblComplete.Location = new System.Drawing.Point(50, 39);
            this.lblComplete.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblComplete.Name = "lblComplete";
            this.lblComplete.Size = new System.Drawing.Size(0, 16);
            this.lblComplete.TabIndex = 5;
            // 
            // pbCargandoDatos
            // 
            this.pbCargandoDatos.Image = global::Dar_Formato_Archivos_Edi.Properties.Resources.loading;
            this.pbCargandoDatos.Location = new System.Drawing.Point(8, 30);
            this.pbCargandoDatos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbCargandoDatos.Name = "pbCargandoDatos";
            this.pbCargandoDatos.Size = new System.Drawing.Size(32, 26);
            this.pbCargandoDatos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCargandoDatos.TabIndex = 6;
            this.pbCargandoDatos.TabStop = false;
            // 
            // gbReporteEventosExcel
            // 
            this.gbReporteEventosExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbReporteEventosExcel.AutoSize = true;
            this.gbReporteEventosExcel.Controls.Add(this.cBoxClienteId);
            this.gbReporteEventosExcel.Controls.Add(this.dgvEventos);
            this.gbReporteEventosExcel.Controls.Add(this.cBoxSQL);
            this.gbReporteEventosExcel.Controls.Add(this.lblWaiting);
            this.gbReporteEventosExcel.Controls.Add(this.btnExportExcel);
            this.gbReporteEventosExcel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gbReporteEventosExcel.Location = new System.Drawing.Point(15, 15);
            this.gbReporteEventosExcel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbReporteEventosExcel.Name = "gbReporteEventosExcel";
            this.gbReporteEventosExcel.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbReporteEventosExcel.Size = new System.Drawing.Size(861, 424);
            this.gbReporteEventosExcel.TabIndex = 7;
            this.gbReporteEventosExcel.TabStop = false;
            this.gbReporteEventosExcel.Text = "Eventos Reportados";
            // 
            // cBoxClienteId
            // 
            this.cBoxClienteId.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cBoxClienteId.FormattingEnabled = true;
            this.cBoxClienteId.Items.AddRange(new object[] {
            "2",
            "3",
            "5"});
            this.cBoxClienteId.Location = new System.Drawing.Point(365, 21);
            this.cBoxClienteId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cBoxClienteId.Name = "cBoxClienteId";
            this.cBoxClienteId.Size = new System.Drawing.Size(160, 24);
            this.cBoxClienteId.TabIndex = 5;
            this.cBoxClienteId.Visible = false;
            this.cBoxClienteId.SelectionChangeCommitted += new System.EventHandler(this.cBoxClienteId_SelectionChangeCommitted_1);
            // 
            // gbEstatusDelReporte
            // 
            this.gbEstatusDelReporte.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbEstatusDelReporte.AutoSize = true;
            this.gbEstatusDelReporte.Controls.Add(this.pbCargandoDatos);
            this.gbEstatusDelReporte.Controls.Add(this.lblEspera);
            this.gbEstatusDelReporte.Controls.Add(this.lblComplete);
            this.gbEstatusDelReporte.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gbEstatusDelReporte.Location = new System.Drawing.Point(15, 455);
            this.gbEstatusDelReporte.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbEstatusDelReporte.Name = "gbEstatusDelReporte";
            this.gbEstatusDelReporte.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbEstatusDelReporte.Size = new System.Drawing.Size(854, 81);
            this.gbEstatusDelReporte.TabIndex = 8;
            this.gbEstatusDelReporte.TabStop = false;
            this.gbEstatusDelReporte.Text = "Estatus del Reporte";
            // 
            // ReporteDeEventos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(878, 541);
            this.Controls.Add(this.gbEstatusDelReporte);
            this.Controls.Add(this.gbReporteEventosExcel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(1280, 720);
            this.MinimumSize = new System.Drawing.Size(396, 588);
            this.Name = "ReporteDeEventos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReporteDeEventos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCargandoDatos)).EndInit();
            this.gbReporteEventosExcel.ResumeLayout(false);
            this.gbReporteEventosExcel.PerformLayout();
            this.gbEstatusDelReporte.ResumeLayout(false);
            this.gbEstatusDelReporte.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEventos;
        private System.Windows.Forms.ComboBox cBoxSQL;
        private System.Windows.Forms.Label lblWaiting;
        private System.Windows.Forms.Label lblEspera;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Label lblComplete;
        private System.Windows.Forms.PictureBox pbCargandoDatos;
        private System.Windows.Forms.GroupBox gbReporteEventosExcel;
        private System.Windows.Forms.GroupBox gbEstatusDelReporte;
        private System.Windows.Forms.ComboBox cBoxClienteId;
    }
}