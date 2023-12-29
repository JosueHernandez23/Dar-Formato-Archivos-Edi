namespace Dar_Formato_Archivos_Edi.PopUp
{
    partial class EdiShipmentDuplicado
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
            this.DtgShipment = new Krypton.Toolkit.KryptonDataGridView();
            this.kryptonDataGridView2 = new Krypton.Toolkit.KryptonDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DtgShipment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // DtgShipment
            // 
            this.DtgShipment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DtgShipment.Location = new System.Drawing.Point(0, 0);
            this.DtgShipment.Name = "DtgShipment";
            this.DtgShipment.RowTemplate.Height = 24;
            this.DtgShipment.Size = new System.Drawing.Size(479, 185);
            this.DtgShipment.TabIndex = 0;
            this.DtgShipment.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgShipment_CellDoubleClick);
            // 
            // kryptonDataGridView2
            // 
            this.kryptonDataGridView2.Location = new System.Drawing.Point(198, 127);
            this.kryptonDataGridView2.Name = "kryptonDataGridView2";
            this.kryptonDataGridView2.RowTemplate.Height = 24;
            this.kryptonDataGridView2.Size = new System.Drawing.Size(16, 11);
            this.kryptonDataGridView2.TabIndex = 1;
            // 
            // EdiShipmentDuplicado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(475, 184);
            this.Controls.Add(this.kryptonDataGridView2);
            this.Controls.Add(this.DtgShipment);
            this.Name = "EdiShipmentDuplicado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Selecciona un archivo";
            ((System.ComponentModel.ISupportInitialize)(this.DtgShipment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonDataGridView DtgShipment;
        private Krypton.Toolkit.KryptonDataGridView kryptonDataGridView2;
    }
}