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
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCargandoDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEventos
            // 
            this.dgvEventos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvEventos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvEventos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEventos.Location = new System.Drawing.Point(12, 44);
            this.dgvEventos.Name = "dgvEventos";
            this.dgvEventos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgvEventos.Size = new System.Drawing.Size(1292, 519);
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
            this.cBoxSQL.Location = new System.Drawing.Point(171, 12);
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
            this.lblWaiting.Location = new System.Drawing.Point(12, 12);
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
            this.lblEspera.Location = new System.Drawing.Point(42, 568);
            this.lblEspera.Name = "lblEspera";
            this.lblEspera.Size = new System.Drawing.Size(0, 25);
            this.lblEspera.TabIndex = 3;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Location = new System.Drawing.Point(1229, 15);
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
            this.lblComplete.Location = new System.Drawing.Point(44, 575);
            this.lblComplete.Name = "lblComplete";
            this.lblComplete.Size = new System.Drawing.Size(0, 13);
            this.lblComplete.TabIndex = 5;
            // 
            // pbCargandoDatos
            // 
            this.pbCargandoDatos.Image = global::Dar_Formato_Archivos_Edi.Properties.Resources.loading;
            this.pbCargandoDatos.Location = new System.Drawing.Point(12, 569);
            this.pbCargandoDatos.Name = "pbCargandoDatos";
            this.pbCargandoDatos.Size = new System.Drawing.Size(26, 21);
            this.pbCargandoDatos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCargandoDatos.TabIndex = 6;
            this.pbCargandoDatos.TabStop = false;
            // 
            // ReporteDeEventos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1316, 614);
            this.Controls.Add(this.pbCargandoDatos);
            this.Controls.Add(this.lblComplete);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.lblEspera);
            this.Controls.Add(this.lblWaiting);
            this.Controls.Add(this.cBoxSQL);
            this.Controls.Add(this.dgvEventos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReporteDeEventos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReporteDeEventos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCargandoDatos)).EndInit();
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
    }
}