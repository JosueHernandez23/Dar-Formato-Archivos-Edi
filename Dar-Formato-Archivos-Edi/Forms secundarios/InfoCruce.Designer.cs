namespace Dar_Formato_Archivos_Edi.Forms_secundarios
{
    partial class InfoCruce
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
            this.tblMainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dtgRecibido = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dtFechaFinRecibido = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtFechaInicioRecibido = new System.Windows.Forms.DateTimePicker();
            this.gpbEnviado = new System.Windows.Forms.GroupBox();
            this.tblEnviado = new System.Windows.Forms.TableLayoutPanel();
            this.tblFiltros = new System.Windows.Forms.TableLayoutPanel();
            this.dtFechaFinEnviado = new System.Windows.Forms.DateTimePicker();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtFechaInicioEnviado = new System.Windows.Forms.DateTimePicker();
            this.btnEnviado = new System.Windows.Forms.Button();
            this.dtgEnviado = new System.Windows.Forms.DataGridView();
            this.btnRecibido = new System.Windows.Forms.Button();
            this.tblMainLayout.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgRecibido)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.gpbEnviado.SuspendLayout();
            this.tblEnviado.SuspendLayout();
            this.tblFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEnviado)).BeginInit();
            this.SuspendLayout();
            // 
            // tblMainLayout
            // 
            this.tblMainLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblMainLayout.ColumnCount = 1;
            this.tblMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMainLayout.Controls.Add(this.groupBox1, 0, 1);
            this.tblMainLayout.Controls.Add(this.gpbEnviado, 0, 0);
            this.tblMainLayout.Location = new System.Drawing.Point(12, 12);
            this.tblMainLayout.Name = "tblMainLayout";
            this.tblMainLayout.RowCount = 2;
            this.tblMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMainLayout.Size = new System.Drawing.Size(886, 572);
            this.tblMainLayout.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(3, 289);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(880, 280);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Recibido";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dtgRecibido, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 22);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.63492F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.36508F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(883, 252);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dtgRecibido
            // 
            this.dtgRecibido.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgRecibido.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgRecibido.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgRecibido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgRecibido.Location = new System.Drawing.Point(3, 55);
            this.dtgRecibido.Name = "dtgRecibido";
            this.dtgRecibido.Size = new System.Drawing.Size(877, 194);
            this.dtgRecibido.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.79919F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.20081F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 153F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 219F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 265F));
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.dtFechaInicioRecibido, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.dtFechaFinRecibido, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnRecibido, 4, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(877, 46);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // dtFechaFinRecibido
            // 
            this.dtFechaFinRecibido.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtFechaFinRecibido.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaFinRecibido.Location = new System.Drawing.Point(395, 11);
            this.dtFechaFinRecibido.Name = "dtFechaFinRecibido";
            this.dtFechaFinRecibido.Size = new System.Drawing.Size(150, 23);
            this.dtFechaFinRecibido.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Fecha Inicio:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(315, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Fecha Fin:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtFechaInicioRecibido
            // 
            this.dtFechaInicioRecibido.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtFechaInicioRecibido.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaInicioRecibido.Location = new System.Drawing.Point(105, 11);
            this.dtFechaInicioRecibido.Name = "dtFechaInicioRecibido";
            this.dtFechaInicioRecibido.Size = new System.Drawing.Size(131, 23);
            this.dtFechaInicioRecibido.TabIndex = 2;
            // 
            // gpbEnviado
            // 
            this.gpbEnviado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbEnviado.Controls.Add(this.tblEnviado);
            this.gpbEnviado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbEnviado.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gpbEnviado.Location = new System.Drawing.Point(3, 3);
            this.gpbEnviado.Name = "gpbEnviado";
            this.gpbEnviado.Size = new System.Drawing.Size(880, 280);
            this.gpbEnviado.TabIndex = 0;
            this.gpbEnviado.TabStop = false;
            this.gpbEnviado.Text = "Enviado";
            // 
            // tblEnviado
            // 
            this.tblEnviado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblEnviado.ColumnCount = 1;
            this.tblEnviado.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblEnviado.Controls.Add(this.tblFiltros, 0, 0);
            this.tblEnviado.Controls.Add(this.dtgEnviado, 0, 1);
            this.tblEnviado.Location = new System.Drawing.Point(6, 22);
            this.tblEnviado.Name = "tblEnviado";
            this.tblEnviado.RowCount = 2;
            this.tblEnviado.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.44444F));
            this.tblEnviado.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.55556F));
            this.tblEnviado.Size = new System.Drawing.Size(883, 252);
            this.tblEnviado.TabIndex = 0;
            // 
            // tblFiltros
            // 
            this.tblFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblFiltros.ColumnCount = 5;
            this.tblFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.79919F));
            this.tblFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.20081F));
            this.tblFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 153F));
            this.tblFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 280F));
            this.tblFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 204F));
            this.tblFiltros.Controls.Add(this.lblFechaInicio, 0, 0);
            this.tblFiltros.Controls.Add(this.label1, 2, 0);
            this.tblFiltros.Controls.Add(this.dtFechaInicioEnviado, 1, 0);
            this.tblFiltros.Controls.Add(this.btnEnviado, 4, 0);
            this.tblFiltros.Controls.Add(this.dtFechaFinEnviado, 3, 0);
            this.tblFiltros.Location = new System.Drawing.Point(3, 3);
            this.tblFiltros.Name = "tblFiltros";
            this.tblFiltros.RowCount = 1;
            this.tblFiltros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblFiltros.Size = new System.Drawing.Size(877, 42);
            this.tblFiltros.TabIndex = 1;
            // 
            // dtFechaFinEnviado
            // 
            this.dtFechaFinEnviado.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtFechaFinEnviado.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaFinEnviado.Location = new System.Drawing.Point(395, 9);
            this.dtFechaFinEnviado.Name = "dtFechaFinEnviado";
            this.dtFechaFinEnviado.Size = new System.Drawing.Size(150, 23);
            this.dtFechaFinEnviado.TabIndex = 3;
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Location = new System.Drawing.Point(12, 12);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(87, 17);
            this.lblFechaInicio.TabIndex = 0;
            this.lblFechaInicio.Text = "Fecha Inicio:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(315, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha Fin:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtFechaInicioEnviado
            // 
            this.dtFechaInicioEnviado.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtFechaInicioEnviado.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaInicioEnviado.Location = new System.Drawing.Point(105, 9);
            this.dtFechaInicioEnviado.Name = "dtFechaInicioEnviado";
            this.dtFechaInicioEnviado.Size = new System.Drawing.Size(131, 23);
            this.dtFechaInicioEnviado.TabIndex = 2;
            // 
            // btnEnviado
            // 
            this.btnEnviado.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnEnviado.ForeColor = System.Drawing.Color.Black;
            this.btnEnviado.Location = new System.Drawing.Point(675, 7);
            this.btnEnviado.Name = "btnEnviado";
            this.btnEnviado.Size = new System.Drawing.Size(133, 27);
            this.btnEnviado.TabIndex = 4;
            this.btnEnviado.Text = "Buscar";
            this.btnEnviado.UseVisualStyleBackColor = true;
            this.btnEnviado.Click += new System.EventHandler(this.btnEnviado_Click);
            // 
            // dtgEnviado
            // 
            this.dtgEnviado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgEnviado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgEnviado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgEnviado.Location = new System.Drawing.Point(3, 51);
            this.dtgEnviado.Name = "dtgEnviado";
            this.dtgEnviado.Size = new System.Drawing.Size(877, 198);
            this.dtgEnviado.TabIndex = 0;
            // 
            // btnRecibido
            // 
            this.btnRecibido.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnRecibido.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnRecibido.Location = new System.Drawing.Point(614, 9);
            this.btnRecibido.Name = "btnRecibido";
            this.btnRecibido.Size = new System.Drawing.Size(133, 27);
            this.btnRecibido.TabIndex = 5;
            this.btnRecibido.Text = "Buscar";
            this.btnRecibido.UseVisualStyleBackColor = true;
            this.btnRecibido.Click += new System.EventHandler(this.btnRecibido_Click);
            // 
            // InfoCruce
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(910, 596);
            this.Controls.Add(this.tblMainLayout);
            this.Name = "InfoCruce";
            this.Text = "Informacion cruces";
            this.tblMainLayout.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgRecibido)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.gpbEnviado.ResumeLayout(false);
            this.tblEnviado.ResumeLayout(false);
            this.tblFiltros.ResumeLayout(false);
            this.tblFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEnviado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblMainLayout;
        private System.Windows.Forms.GroupBox gpbEnviado;
        private System.Windows.Forms.TableLayoutPanel tblEnviado;
        private System.Windows.Forms.DataGridView dtgEnviado;
        private System.Windows.Forms.TableLayoutPanel tblFiltros;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.DateTimePicker dtFechaFinEnviado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtFechaInicioEnviado;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dtgRecibido;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DateTimePicker dtFechaFinRecibido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtFechaInicioRecibido;
        private System.Windows.Forms.Button btnEnviado;
        private System.Windows.Forms.Button btnRecibido;
    }
}