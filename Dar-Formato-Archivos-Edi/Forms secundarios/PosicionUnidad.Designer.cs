namespace Dar_Formato_Archivos_Edi.Forms_secundarios
{
    partial class PosicionUnidad
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
            this.MainLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.OptionsLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.dtFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cboOrigenDatos = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.pbEstatus = new System.Windows.Forms.PictureBox();
            this.dtDatos = new System.Windows.Forms.DataGridView();
            this.MainLayoutPanel.SuspendLayout();
            this.OptionsLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEstatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // MainLayoutPanel
            // 
            this.MainLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainLayoutPanel.ColumnCount = 1;
            this.MainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.MainLayoutPanel.Controls.Add(this.OptionsLayoutPanel, 0, 0);
            this.MainLayoutPanel.Controls.Add(this.dtDatos, 0, 1);
            this.MainLayoutPanel.Location = new System.Drawing.Point(12, 12);
            this.MainLayoutPanel.Name = "MainLayoutPanel";
            this.MainLayoutPanel.RowCount = 2;
            this.MainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 335F));
            this.MainLayoutPanel.Size = new System.Drawing.Size(776, 426);
            this.MainLayoutPanel.TabIndex = 3;
            // 
            // OptionsLayoutPanel
            // 
            this.OptionsLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OptionsLayoutPanel.ColumnCount = 4;
            this.OptionsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.28571F));
            this.OptionsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.71429F));
            this.OptionsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.OptionsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 195F));
            this.OptionsLayoutPanel.Controls.Add(this.pbEstatus, 3, 1);
            this.OptionsLayoutPanel.Controls.Add(this.label2, 2, 0);
            this.OptionsLayoutPanel.Controls.Add(this.lblFechaInicio, 0, 0);
            this.OptionsLayoutPanel.Controls.Add(this.label1, 0, 1);
            this.OptionsLayoutPanel.Controls.Add(this.dtFechaFin, 0, 1);
            this.OptionsLayoutPanel.Controls.Add(this.dtFechaInicio, 1, 0);
            this.OptionsLayoutPanel.Controls.Add(this.cboOrigenDatos, 3, 0);
            this.OptionsLayoutPanel.Controls.Add(this.btnBuscar, 2, 1);
            this.OptionsLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.OptionsLayoutPanel.Name = "OptionsLayoutPanel";
            this.OptionsLayoutPanel.RowCount = 2;
            this.OptionsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.OptionsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.OptionsLayoutPanel.Size = new System.Drawing.Size(770, 85);
            this.OptionsLayoutPanel.TabIndex = 0;
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaInicio.Location = new System.Drawing.Point(64, 12);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(87, 17);
            this.lblFechaInicio.TabIndex = 7;
            this.lblFechaInicio.Text = "Fecha Inicio:";
            // 
            // dtFechaInicio
            // 
            this.dtFechaInicio.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFechaInicio.Location = new System.Drawing.Point(157, 10);
            this.dtFechaInicio.Name = "dtFechaInicio";
            this.dtFechaInicio.Size = new System.Drawing.Size(239, 21);
            this.dtFechaInicio.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(77, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Fecha Fin:";
            // 
            // dtFechaFin
            // 
            this.dtFechaFin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtFechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFechaFin.Location = new System.Drawing.Point(157, 53);
            this.dtFechaFin.Name = "dtFechaFin";
            this.dtFechaFin.Size = new System.Drawing.Size(239, 21);
            this.dtFechaFin.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(477, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Origen datos:";
            // 
            // cboOrigenDatos
            // 
            this.cboOrigenDatos.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboOrigenDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboOrigenDatos.FormattingEnabled = true;
            this.cboOrigenDatos.Location = new System.Drawing.Point(577, 10);
            this.cboOrigenDatos.Name = "cboOrigenDatos";
            this.cboOrigenDatos.Size = new System.Drawing.Size(158, 23);
            this.cboOrigenDatos.TabIndex = 12;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBuscar.Location = new System.Drawing.Point(452, 49);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(119, 29);
            this.btnBuscar.TabIndex = 13;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // pbEstatus
            // 
            this.pbEstatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pbEstatus.Image = global::Dar_Formato_Archivos_Edi.Properties.Resources.loading;
            this.pbEstatus.Location = new System.Drawing.Point(577, 51);
            this.pbEstatus.Name = "pbEstatus";
            this.pbEstatus.Size = new System.Drawing.Size(34, 24);
            this.pbEstatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbEstatus.TabIndex = 14;
            this.pbEstatus.TabStop = false;
            // 
            // dtDatos
            // 
            this.dtDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtDatos.Location = new System.Drawing.Point(3, 94);
            this.dtDatos.Name = "dtDatos";
            this.dtDatos.Size = new System.Drawing.Size(770, 329);
            this.dtDatos.TabIndex = 1;
            // 
            // PosicionUnidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MainLayoutPanel);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "PosicionUnidad";
            this.Text = "Posicion Unidad";
            this.MainLayoutPanel.ResumeLayout(false);
            this.OptionsLayoutPanel.ResumeLayout(false);
            this.OptionsLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEstatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel OptionsLayoutPanel;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtFechaFin;
        private System.Windows.Forms.DateTimePicker dtFechaInicio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboOrigenDatos;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.PictureBox pbEstatus;
        private System.Windows.Forms.DataGridView dtDatos;
    }
}