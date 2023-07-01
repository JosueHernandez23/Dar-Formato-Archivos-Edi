namespace Dar_Formato_Archivos_Edi.Forms_secundarios
{
    partial class PopUpInfoEdi
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
            this.dtgEdiResult = new System.Windows.Forms.DataGridView();
            this.MainLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEdiResult)).BeginInit();
            this.SuspendLayout();
            // 
            // MainLayoutPanel
            // 
            this.MainLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainLayoutPanel.ColumnCount = 1;
            this.MainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainLayoutPanel.Controls.Add(this.dtgEdiResult, 0, 0);
            this.MainLayoutPanel.Location = new System.Drawing.Point(12, 12);
            this.MainLayoutPanel.Name = "MainLayoutPanel";
            this.MainLayoutPanel.RowCount = 1;
            this.MainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.3709F));
            this.MainLayoutPanel.Size = new System.Drawing.Size(1072, 412);
            this.MainLayoutPanel.TabIndex = 0;
            // 
            // dtgEdiResult
            // 
            this.dtgEdiResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgEdiResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgEdiResult.Location = new System.Drawing.Point(3, 3);
            this.dtgEdiResult.Name = "dtgEdiResult";
            this.dtgEdiResult.Size = new System.Drawing.Size(1066, 406);
            this.dtgEdiResult.TabIndex = 1;
            // 
            // PopUpInfoEdi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1096, 436);
            this.Controls.Add(this.MainLayoutPanel);
            this.Name = "PopUpInfoEdi";
            this.Text = "PopUpInfoEdi";
            this.MainLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgEdiResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainLayoutPanel;
        private System.Windows.Forms.DataGridView dtgEdiResult;
    }
}