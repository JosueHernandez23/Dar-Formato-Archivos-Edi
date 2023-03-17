namespace Dar_Formato_Archivos_Edi.Forms_secundarios
{
    partial class EventosEdi
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
            this.tableLayoutPanel_Main = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel_Params = new System.Windows.Forms.TableLayoutPanel();
            this.lblClienteEdiConfiguracion = new System.Windows.Forms.Label();
            this.lblEventosEdi = new System.Windows.Forms.Label();
            this.cboClienteEdi = new System.Windows.Forms.ComboBox();
            this.cboEdiEvento = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.dtGV_Data = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel_Main.SuspendLayout();
            this.tableLayoutPanel_Params.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGV_Data)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_Main
            // 
            this.tableLayoutPanel_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel_Main.ColumnCount = 1;
            this.tableLayoutPanel_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_Main.Controls.Add(this.tableLayoutPanel_Params, 0, 0);
            this.tableLayoutPanel_Main.Controls.Add(this.dtGV_Data, 0, 1);
            this.tableLayoutPanel_Main.Location = new System.Drawing.Point(22, 21);
            this.tableLayoutPanel_Main.Name = "tableLayoutPanel_Main";
            this.tableLayoutPanel_Main.RowCount = 2;
            this.tableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.44988F));
            this.tableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.55013F));
            this.tableLayoutPanel_Main.Size = new System.Drawing.Size(944, 416);
            this.tableLayoutPanel_Main.TabIndex = 0;
            // 
            // tableLayoutPanel_Params
            // 
            this.tableLayoutPanel_Params.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel_Params.ColumnCount = 3;
            this.tableLayoutPanel_Params.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_Params.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_Params.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 184F));
            this.tableLayoutPanel_Params.Controls.Add(this.lblEventosEdi, 1, 0);
            this.tableLayoutPanel_Params.Controls.Add(this.lblClienteEdiConfiguracion, 0, 0);
            this.tableLayoutPanel_Params.Controls.Add(this.cboClienteEdi, 0, 1);
            this.tableLayoutPanel_Params.Controls.Add(this.cboEdiEvento, 1, 1);
            this.tableLayoutPanel_Params.Controls.Add(this.btnAceptar, 2, 1);
            this.tableLayoutPanel_Params.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel_Params.Name = "tableLayoutPanel_Params";
            this.tableLayoutPanel_Params.RowCount = 2;
            this.tableLayoutPanel_Params.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_Params.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_Params.Size = new System.Drawing.Size(938, 95);
            this.tableLayoutPanel_Params.TabIndex = 0;
            // 
            // lblClienteEdiConfiguracion
            // 
            this.lblClienteEdiConfiguracion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblClienteEdiConfiguracion.AutoSize = true;
            this.lblClienteEdiConfiguracion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClienteEdiConfiguracion.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblClienteEdiConfiguracion.Location = new System.Drawing.Point(101, 29);
            this.lblClienteEdiConfiguracion.Name = "lblClienteEdiConfiguracion";
            this.lblClienteEdiConfiguracion.Size = new System.Drawing.Size(174, 18);
            this.lblClienteEdiConfiguracion.TabIndex = 0;
            this.lblClienteEdiConfiguracion.Text = "Cliente Edi Configuracion";
            // 
            // lblEventosEdi
            // 
            this.lblEventosEdi.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblEventosEdi.AutoSize = true;
            this.lblEventosEdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventosEdi.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblEventosEdi.Location = new System.Drawing.Point(522, 29);
            this.lblEventosEdi.Name = "lblEventosEdi";
            this.lblEventosEdi.Size = new System.Drawing.Size(87, 18);
            this.lblEventosEdi.TabIndex = 1;
            this.lblEventosEdi.Text = "Eventos Edi";
            // 
            // cboClienteEdi
            // 
            this.cboClienteEdi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboClienteEdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboClienteEdi.FormattingEnabled = true;
            this.cboClienteEdi.Location = new System.Drawing.Point(84, 50);
            this.cboClienteEdi.Name = "cboClienteEdi";
            this.cboClienteEdi.Size = new System.Drawing.Size(208, 24);
            this.cboClienteEdi.TabIndex = 2;
            // 
            // cboEdiEvento
            // 
            this.cboEdiEvento.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboEdiEvento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEdiEvento.FormattingEnabled = true;
            this.cboEdiEvento.Location = new System.Drawing.Point(425, 50);
            this.cboEdiEvento.Name = "cboEdiEvento";
            this.cboEdiEvento.Size = new System.Drawing.Size(280, 21);
            this.cboEdiEvento.TabIndex = 3;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(797, 50);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(98, 36);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Buscar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // dtGV_Data
            // 
            this.dtGV_Data.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtGV_Data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dtGV_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGV_Data.Location = new System.Drawing.Point(3, 104);
            this.dtGV_Data.Name = "dtGV_Data";
            this.dtGV_Data.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dtGV_Data.Size = new System.Drawing.Size(938, 309);
            this.dtGV_Data.TabIndex = 1;
            // 
            // EventosEdi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(990, 457);
            this.Controls.Add(this.tableLayoutPanel_Main);
            this.Name = "EventosEdi";
            this.Text = "EventosEdi";
            this.tableLayoutPanel_Main.ResumeLayout(false);
            this.tableLayoutPanel_Params.ResumeLayout(false);
            this.tableLayoutPanel_Params.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGV_Data)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Main;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Params;
        private System.Windows.Forms.Label lblEventosEdi;
        private System.Windows.Forms.Label lblClienteEdiConfiguracion;
        private System.Windows.Forms.ComboBox cboClienteEdi;
        private System.Windows.Forms.ComboBox cboEdiEvento;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.DataGridView dtGV_Data;
    }
}