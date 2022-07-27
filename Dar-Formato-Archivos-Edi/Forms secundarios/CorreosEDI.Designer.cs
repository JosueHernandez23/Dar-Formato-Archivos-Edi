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
            this.listbox_EmailDetalles = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listbox_Emails
            // 
            this.listbox_Emails.FormattingEnabled = true;
            this.listbox_Emails.Location = new System.Drawing.Point(33, 23);
            this.listbox_Emails.Name = "listbox_Emails";
            this.listbox_Emails.Size = new System.Drawing.Size(581, 251);
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
            // listbox_EmailDetalles
            // 
            this.listbox_EmailDetalles.FormattingEnabled = true;
            this.listbox_EmailDetalles.Location = new System.Drawing.Point(33, 336);
            this.listbox_EmailDetalles.Name = "listbox_EmailDetalles";
            this.listbox_EmailDetalles.Size = new System.Drawing.Size(778, 160);
            this.listbox_EmailDetalles.TabIndex = 3;
            // 
            // CorreosEDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 508);
            this.Controls.Add(this.listbox_EmailDetalles);
            this.Controls.Add(this.lblDetalles);
            this.Controls.Add(this.listbox_Emails);
            this.Name = "CorreosEDI";
            this.Text = "CorreosEDI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listbox_Emails;
        private System.Windows.Forms.Label lblDetalles;
        private System.Windows.Forms.ListBox listbox_EmailDetalles;
    }
}