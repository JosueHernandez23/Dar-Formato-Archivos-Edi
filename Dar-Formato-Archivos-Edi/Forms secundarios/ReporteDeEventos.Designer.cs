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
            this.dgvEventos.Location = new System.Drawing.Point(10, 44);
            this.dgvEventos.Name = "dgvEventos";
            this.dgvEventos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgvEventos.Size = new System.Drawing.Size(1147, 608);
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
            this.cBoxSQL.Location = new System.Drawing.Point(165, 17);
            this.cBoxSQL.Name = "cBoxSQL";
            this.cBoxSQL.Size = new System.Drawing.Size(121, 21);
            this.cBoxSQL.TabIndex = 1;
            this.cBoxSQL.SelectedIndexChanged += new System.EventHandler(this.cBoxSQL_SelectedIndexChanged);
            // 
            // lblWaiting
            // 
            this.lblWaiting.AutoSize = true;
            this.lblWaiting.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaiting.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblWaiting.Location = new System.Drawing.Point(6, 17);
            this.lblWaiting.Name = "lblWaiting";
            this.lblWaiting.Size = new System.Drawing.Size(155, 21);
            this.lblWaiting.TabIndex = 2;
            this.lblWaiting.Text = "Seleccionar Reporte: ";
            // 
            // lblEspera
            // 
            this.lblEspera.AutoSize = true;
            this.lblEspera.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEspera.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblEspera.Location = new System.Drawing.Point(36, 18);
            this.lblEspera.Name = "lblEspera";
            this.lblEspera.Size = new System.Drawing.Size(0, 25);
            this.lblEspera.TabIndex = 3;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportExcel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnExportExcel.Location = new System.Drawing.Point(1082, 15);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(75, 23);
            this.btnExportExcel.TabIndex = 4;
            this.btnExportExcel.Text = "Excel";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // lblComplete
            // 
            this.lblComplete.AutoSize = true;
            this.lblComplete.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblComplete.Location = new System.Drawing.Point(38, 25);
            this.lblComplete.Name = "lblComplete";
            this.lblComplete.Size = new System.Drawing.Size(0, 13);
            this.lblComplete.TabIndex = 5;
            // 
            // pbCargandoDatos
            // 
            this.pbCargandoDatos.Image = global::Dar_Formato_Archivos_Edi.Properties.Resources.loading;
            this.pbCargandoDatos.Location = new System.Drawing.Point(6, 19);
            this.pbCargandoDatos.Name = "pbCargandoDatos";
            this.pbCargandoDatos.Size = new System.Drawing.Size(26, 21);
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
            this.gbReporteEventosExcel.Controls.Add(this.dgvEventos);
            this.gbReporteEventosExcel.Controls.Add(this.cBoxSQL);
            this.gbReporteEventosExcel.Controls.Add(this.lblWaiting);
            this.gbReporteEventosExcel.Controls.Add(this.btnExportExcel);
            this.gbReporteEventosExcel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gbReporteEventosExcel.Location = new System.Drawing.Point(12, 12);
            this.gbReporteEventosExcel.Name = "gbReporteEventosExcel";
            this.gbReporteEventosExcel.Size = new System.Drawing.Size(1163, 658);
            this.gbReporteEventosExcel.TabIndex = 7;
            this.gbReporteEventosExcel.TabStop = false;
            this.gbReporteEventosExcel.Text = "Eventos Reportados";
            // 
            // gbEstatusDelReporte
            // 
            this.gbEstatusDelReporte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbEstatusDelReporte.AutoSize = true;
            this.gbEstatusDelReporte.Controls.Add(this.pbCargandoDatos);
            this.gbEstatusDelReporte.Controls.Add(this.lblEspera);
            this.gbEstatusDelReporte.Controls.Add(this.lblComplete);
            this.gbEstatusDelReporte.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gbEstatusDelReporte.Location = new System.Drawing.Point(12, 673);
            this.gbEstatusDelReporte.Name = "gbEstatusDelReporte";
            this.gbEstatusDelReporte.Size = new System.Drawing.Size(1159, 59);
            this.gbEstatusDelReporte.TabIndex = 8;
            this.gbEstatusDelReporte.TabStop = false;
            this.gbEstatusDelReporte.Text = "Estatus del Reporte";
            // 
            // ReporteDeEventos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1181, 744);
            this.Controls.Add(this.gbEstatusDelReporte);
            this.Controls.Add(this.gbReporteEventosExcel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
    }
}