﻿namespace Dar_Formato_Archivos_Edi.Forms_secundarios
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnConfigurarSegmentos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtDatos)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboClientes
            // 
            this.cboClientes.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboClientes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboClientes.FormattingEnabled = true;
            this.cboClientes.Location = new System.Drawing.Point(68, 3);
            this.cboClientes.Name = "cboClientes";
            this.cboClientes.Size = new System.Drawing.Size(179, 24);
            this.cboClientes.TabIndex = 0;
            // 
            // LblCliente
            // 
            this.LblCliente.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblCliente.AutoSize = true;
            this.LblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCliente.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LblCliente.Location = new System.Drawing.Point(3, 7);
            this.LblCliente.Name = "LblCliente";
            this.LblCliente.Size = new System.Drawing.Size(59, 17);
            this.LblCliente.TabIndex = 1;
            this.LblCliente.Text = "Cliente: ";
            // 
            // lblTipoArchivo
            // 
            this.lblTipoArchivo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTipoArchivo.AutoSize = true;
            this.lblTipoArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoArchivo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTipoArchivo.Location = new System.Drawing.Point(3, 7);
            this.lblTipoArchivo.Name = "lblTipoArchivo";
            this.lblTipoArchivo.Size = new System.Drawing.Size(95, 17);
            this.lblTipoArchivo.TabIndex = 2;
            this.lblTipoArchivo.Text = "Tipo Archivo: ";
            // 
            // cboTipoArchivo
            // 
            this.cboTipoArchivo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboTipoArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoArchivo.FormattingEnabled = true;
            this.cboTipoArchivo.Location = new System.Drawing.Point(104, 3);
            this.cboTipoArchivo.Name = "cboTipoArchivo";
            this.cboTipoArchivo.Size = new System.Drawing.Size(133, 24);
            this.cboTipoArchivo.TabIndex = 3;
            // 
            // dtDatos
            // 
            this.dtDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtDatos.Location = new System.Drawing.Point(3, 46);
            this.dtDatos.MinimumSize = new System.Drawing.Size(965, 401);
            this.dtDatos.Name = "dtDatos";
            this.dtDatos.Size = new System.Drawing.Size(965, 401);
            this.dtDatos.TabIndex = 4;
            // 
            // btnSelectClienteSegmento
            // 
            this.btnSelectClienteSegmento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSelectClienteSegmento.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSelectClienteSegmento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectClienteSegmento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectClienteSegmento.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSelectClienteSegmento.Location = new System.Drawing.Point(16, 3);
            this.btnSelectClienteSegmento.Name = "btnSelectClienteSegmento";
            this.btnSelectClienteSegmento.Size = new System.Drawing.Size(137, 30);
            this.btnSelectClienteSegmento.TabIndex = 9;
            this.btnSelectClienteSegmento.Text = "Consultar";
            this.btnSelectClienteSegmento.UseVisualStyleBackColor = true;
            this.btnSelectClienteSegmento.Click += new System.EventHandler(this.btnSelectClienteSegmento_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtDatos, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(17, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.955752F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.04425F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(965, 433);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.72736F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.05093F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.49115F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.73056F));
            this.tableLayoutPanel2.Controls.Add(this.btnSelectClienteSegmento, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnConfigurarSegmentos, 3, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(959, 37);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.71483F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.28517F));
            this.tableLayoutPanel3.Controls.Add(this.LblCliente, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.cboClientes, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(173, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(263, 31);
            this.tableLayoutPanel3.TabIndex = 10;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.44606F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.55393F));
            this.tableLayoutPanel4.Controls.Add(this.lblTipoArchivo, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.cboTipoArchivo, 1, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(442, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(343, 31);
            this.tableLayoutPanel4.TabIndex = 11;
            // 
            // BtnConfigurarSegmentos
            // 
            this.BtnConfigurarSegmentos.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnConfigurarSegmentos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnConfigurarSegmentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConfigurarSegmentos.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnConfigurarSegmentos.Location = new System.Drawing.Point(791, 3);
            this.BtnConfigurarSegmentos.Name = "BtnConfigurarSegmentos";
            this.BtnConfigurarSegmentos.Size = new System.Drawing.Size(165, 30);
            this.BtnConfigurarSegmentos.TabIndex = 12;
            this.BtnConfigurarSegmentos.Text = "Configurar segmentos";
            this.BtnConfigurarSegmentos.UseVisualStyleBackColor = true;
            this.BtnConfigurarSegmentos.Click += new System.EventHandler(this.BtnConfigurarSegmentos_Click);
            // 
            // Listado_Segmentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1000, 481);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(1016, 511);
            this.Name = "Listado_Segmentos";
            this.Text = "Listado_Segmentos";
            ((System.ComponentModel.ISupportInitialize)(this.dtDatos)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboClientes;
        private System.Windows.Forms.Label LblCliente;
        private System.Windows.Forms.Label lblTipoArchivo;
        private System.Windows.Forms.ComboBox cboTipoArchivo;
        private System.Windows.Forms.DataGridView dtDatos;
        private System.Windows.Forms.Button btnSelectClienteSegmento;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button BtnConfigurarSegmentos;
    }
}