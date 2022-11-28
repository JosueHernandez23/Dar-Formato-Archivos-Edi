namespace Dar_Formato_Archivos_Edi.Forms_secundarios
{
    partial class CorreosEDI
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
            this.listbox_Emails = new System.Windows.Forms.ListBox();
            this.lblDetalles = new System.Windows.Forms.Label();
            this.DTG_EmailDetalles = new System.Windows.Forms.DataGridView();
            this.lbl_total = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DTG_EmailDetalles)).BeginInit();
            this.SuspendLayout();
            // 
            // listbox_Emails
            // 
            this.listbox_Emails.FormattingEnabled = true;
            this.listbox_Emails.Location = new System.Drawing.Point(33, 23);
            this.listbox_Emails.Name = "listbox_Emails";
            this.listbox_Emails.Size = new System.Drawing.Size(764, 251);
            this.listbox_Emails.TabIndex = 0;
            this.listbox_Emails.SelectedIndexChanged += new System.EventHandler(this.listbox_Emails_SelectedIndexChanged);
            // 
            // lblDetalles
            // 
            this.lblDetalles.AutoSize = true;
            this.lblDetalles.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalles.Location = new System.Drawing.Point(290, 295);
            this.lblDetalles.Name = "lblDetalles";
            this.lblDetalles.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDetalles.Size = new System.Drawing.Size(75, 20);
            this.lblDetalles.TabIndex = 2;
            this.lblDetalles.Text = "Detalles";
            // 
            // DTG_EmailDetalles
            // 
            this.DTG_EmailDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTG_EmailDetalles.Location = new System.Drawing.Point(33, 349);
            this.DTG_EmailDetalles.Name = "DTG_EmailDetalles";
            this.DTG_EmailDetalles.Size = new System.Drawing.Size(764, 183);
            this.DTG_EmailDetalles.TabIndex = 3;
            // 
            // lbl_total
            // 
            this.lbl_total.AutoSize = true;
            this.lbl_total.Location = new System.Drawing.Point(33, 4);
            this.lbl_total.Name = "lbl_total";
            this.lbl_total.Size = new System.Drawing.Size(37, 13);
            this.lbl_total.TabIndex = 4;
            this.lbl_total.Text = "Total: ";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(77, 4);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(13, 13);
            this.lblTotal.TabIndex = 5;
            this.lblTotal.Text = "0";
            // 
            // CorreosEDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 580);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lbl_total);
            this.Controls.Add(this.DTG_EmailDetalles);
            this.Controls.Add(this.lblDetalles);
            this.Controls.Add(this.listbox_Emails);
            this.Name = "CorreosEDI";
            this.Text = "CorreosEDI";
            ((System.ComponentModel.ISupportInitialize)(this.DTG_EmailDetalles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listbox_Emails;
        private System.Windows.Forms.Label lblDetalles;
        private System.Windows.Forms.DataGridView DTG_EmailDetalles;
        private System.Windows.Forms.Label lbl_total;
        private System.Windows.Forms.Label lblTotal;
    }
}