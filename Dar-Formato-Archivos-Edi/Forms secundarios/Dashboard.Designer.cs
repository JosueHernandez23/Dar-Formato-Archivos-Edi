namespace Dar_Formato_Archivos_Edi.Forms_secundarios
{
    partial class Dashboard
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvReporteEstadistica = new System.Windows.Forms.DataGridView();
            this.btnEstadistica = new System.Windows.Forms.Button();
            this.gbEstadisticas = new System.Windows.Forms.GroupBox();
            this.gbEstatusDelReporte = new System.Windows.Forms.GroupBox();
            this.pbCargandoDatos = new System.Windows.Forms.PictureBox();
            this.lblEspera = new System.Windows.Forms.Label();
            this.lblComplete = new System.Windows.Forms.Label();
            this.btnExportExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporteEstadistica)).BeginInit();
            this.gbEstadisticas.SuspendLayout();
            this.gbEstatusDelReporte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCargandoDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvReporteEstadistica
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgvReporteEstadistica.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReporteEstadistica.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReporteEstadistica.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvReporteEstadistica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReporteEstadistica.Location = new System.Drawing.Point(6, 32);
            this.dgvReporteEstadistica.Name = "dgvReporteEstadistica";
            this.dgvReporteEstadistica.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReporteEstadistica.Size = new System.Drawing.Size(764, 319);
            this.dgvReporteEstadistica.TabIndex = 0;
            // 
            // btnEstadistica
            // 
            this.btnEstadistica.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEstadistica.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEstadistica.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstadistica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstadistica.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEstadistica.Location = new System.Drawing.Point(6, 365);
            this.btnEstadistica.Name = "btnEstadistica";
            this.btnEstadistica.Size = new System.Drawing.Size(145, 53);
            this.btnEstadistica.TabIndex = 18;
            this.btnEstadistica.Text = "Generar Estadistica";
            this.btnEstadistica.UseVisualStyleBackColor = true;
            this.btnEstadistica.Click += new System.EventHandler(this.btnEstadistica_Click);
            // 
            // gbEstadisticas
            // 
            this.gbEstadisticas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbEstadisticas.Controls.Add(this.gbEstatusDelReporte);
            this.gbEstadisticas.Controls.Add(this.btnExportExcel);
            this.gbEstadisticas.Controls.Add(this.dgvReporteEstadistica);
            this.gbEstadisticas.Controls.Add(this.btnEstadistica);
            this.gbEstadisticas.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbEstadisticas.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gbEstadisticas.Location = new System.Drawing.Point(12, 12);
            this.gbEstadisticas.Name = "gbEstadisticas";
            this.gbEstadisticas.Size = new System.Drawing.Size(776, 426);
            this.gbEstadisticas.TabIndex = 19;
            this.gbEstadisticas.TabStop = false;
            this.gbEstadisticas.Text = "Estadisticas";
            // 
            // gbEstatusDelReporte
            // 
            this.gbEstatusDelReporte.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbEstatusDelReporte.AutoSize = true;
            this.gbEstatusDelReporte.Controls.Add(this.pbCargandoDatos);
            this.gbEstatusDelReporte.Controls.Add(this.lblEspera);
            this.gbEstatusDelReporte.Controls.Add(this.lblComplete);
            this.gbEstatusDelReporte.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gbEstatusDelReporte.Location = new System.Drawing.Point(166, 357);
            this.gbEstatusDelReporte.Name = "gbEstatusDelReporte";
            this.gbEstatusDelReporte.Size = new System.Drawing.Size(443, 63);
            this.gbEstatusDelReporte.TabIndex = 20;
            this.gbEstatusDelReporte.TabStop = false;
            this.gbEstatusDelReporte.Text = "Estatus del Reporte";
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
            // lblEspera
            // 
            this.lblEspera.AutoSize = true;
            this.lblEspera.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEspera.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblEspera.Location = new System.Drawing.Point(36, 20);
            this.lblEspera.Name = "lblEspera";
            this.lblEspera.Size = new System.Drawing.Size(0, 25);
            this.lblEspera.TabIndex = 3;
            // 
            // lblComplete
            // 
            this.lblComplete.AutoSize = true;
            this.lblComplete.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblComplete.Location = new System.Drawing.Point(38, 27);
            this.lblComplete.Name = "lblComplete";
            this.lblComplete.Size = new System.Drawing.Size(0, 16);
            this.lblComplete.TabIndex = 5;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportExcel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnExportExcel.Location = new System.Drawing.Point(625, 365);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(145, 53);
            this.btnExportExcel.TabIndex = 19;
            this.btnExportExcel.Text = "Exportar a Excel";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.button1_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gbEstadisticas);
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporteEstadistica)).EndInit();
            this.gbEstadisticas.ResumeLayout(false);
            this.gbEstadisticas.PerformLayout();
            this.gbEstatusDelReporte.ResumeLayout(false);
            this.gbEstatusDelReporte.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCargandoDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReporteEstadistica;
        private System.Windows.Forms.Button btnEstadistica;
        private System.Windows.Forms.GroupBox gbEstadisticas;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.GroupBox gbEstatusDelReporte;
        private System.Windows.Forms.PictureBox pbCargandoDatos;
        private System.Windows.Forms.Label lblEspera;
        private System.Windows.Forms.Label lblComplete;
    }
}