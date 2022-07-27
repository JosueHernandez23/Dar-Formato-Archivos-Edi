namespace Dar_Formato_Archivos_Edi
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombreArchivo = new System.Windows.Forms.Label();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.btnCargarArchivo = new System.Windows.Forms.Button();
            this.txtSegmento = new System.Windows.Forms.TextBox();
            this.txtElemento = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbDeshabilitar = new System.Windows.Forms.RadioButton();
            this.rbHabilitar = new System.Windows.Forms.RadioButton();
            this.TxtFormatoTexto = new System.Windows.Forms.RichTextBox();
            this.btnTexto = new System.Windows.Forms.Button();
            this.btnListadoSegmentos = new System.Windows.Forms.Button();
            this.btnGenerarEdi = new System.Windows.Forms.Button();
            this.btnCorreosEdi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre archivo: ";
            // 
            // txtNombreArchivo
            // 
            this.txtNombreArchivo.AutoSize = true;
            this.txtNombreArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreArchivo.Location = new System.Drawing.Point(157, 27);
            this.txtNombreArchivo.Name = "txtNombreArchivo";
            this.txtNombreArchivo.Size = new System.Drawing.Size(0, 15);
            this.txtNombreArchivo.TabIndex = 1;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // btnCargarArchivo
            // 
            this.btnCargarArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarArchivo.Location = new System.Drawing.Point(14, 82);
            this.btnCargarArchivo.Name = "btnCargarArchivo";
            this.btnCargarArchivo.Size = new System.Drawing.Size(137, 36);
            this.btnCargarArchivo.TabIndex = 2;
            this.btnCargarArchivo.Text = "Cargar archivo";
            this.btnCargarArchivo.UseVisualStyleBackColor = true;
            this.btnCargarArchivo.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtSegmento
            // 
            this.txtSegmento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSegmento.Location = new System.Drawing.Point(289, 89);
            this.txtSegmento.MaxLength = 1;
            this.txtSegmento.Name = "txtSegmento";
            this.txtSegmento.Size = new System.Drawing.Size(100, 23);
            this.txtSegmento.TabIndex = 3;
            // 
            // txtElemento
            // 
            this.txtElemento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtElemento.Location = new System.Drawing.Point(492, 89);
            this.txtElemento.MaxLength = 1;
            this.txtElemento.Name = "txtElemento";
            this.txtElemento.Size = new System.Drawing.Size(100, 23);
            this.txtElemento.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(203, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Segmento: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(411, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Elemento: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbDeshabilitar);
            this.groupBox1.Controls.Add(this.rbHabilitar);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(613, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(175, 108);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Deteccion automatica de caracteres: ";
            // 
            // rbDeshabilitar
            // 
            this.rbDeshabilitar.AutoSize = true;
            this.rbDeshabilitar.Location = new System.Drawing.Point(6, 68);
            this.rbDeshabilitar.Name = "rbDeshabilitar";
            this.rbDeshabilitar.Size = new System.Drawing.Size(101, 21);
            this.rbDeshabilitar.TabIndex = 1;
            this.rbDeshabilitar.Text = "Deshabilitar";
            this.rbDeshabilitar.UseVisualStyleBackColor = true;
            // 
            // rbHabilitar
            // 
            this.rbHabilitar.AutoSize = true;
            this.rbHabilitar.Checked = true;
            this.rbHabilitar.Location = new System.Drawing.Point(6, 44);
            this.rbHabilitar.Name = "rbHabilitar";
            this.rbHabilitar.Size = new System.Drawing.Size(78, 21);
            this.rbHabilitar.TabIndex = 0;
            this.rbHabilitar.TabStop = true;
            this.rbHabilitar.Text = "Habilitar";
            this.rbHabilitar.UseVisualStyleBackColor = true;
            // 
            // TxtFormatoTexto
            // 
            this.TxtFormatoTexto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFormatoTexto.Location = new System.Drawing.Point(14, 196);
            this.TxtFormatoTexto.Name = "TxtFormatoTexto";
            this.TxtFormatoTexto.Size = new System.Drawing.Size(844, 361);
            this.TxtFormatoTexto.TabIndex = 8;
            this.TxtFormatoTexto.Text = "";
            // 
            // btnTexto
            // 
            this.btnTexto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTexto.Location = new System.Drawing.Point(14, 134);
            this.btnTexto.Name = "btnTexto";
            this.btnTexto.Size = new System.Drawing.Size(137, 36);
            this.btnTexto.TabIndex = 9;
            this.btnTexto.Text = "Texto";
            this.btnTexto.UseVisualStyleBackColor = true;
            this.btnTexto.Click += new System.EventHandler(this.btnTexto_Click);
            // 
            // btnListadoSegmentos
            // 
            this.btnListadoSegmentos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnListadoSegmentos.BackgroundImage")));
            this.btnListadoSegmentos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnListadoSegmentos.Location = new System.Drawing.Point(794, 12);
            this.btnListadoSegmentos.Name = "btnListadoSegmentos";
            this.btnListadoSegmentos.Size = new System.Drawing.Size(64, 67);
            this.btnListadoSegmentos.TabIndex = 10;
            this.btnListadoSegmentos.UseVisualStyleBackColor = true;
            this.btnListadoSegmentos.Click += new System.EventHandler(this.btnListadoSegmentos_Click);
            // 
            // btnGenerarEdi
            // 
            this.btnGenerarEdi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerarEdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarEdi.Location = new System.Drawing.Point(761, 166);
            this.btnGenerarEdi.Name = "btnGenerarEdi";
            this.btnGenerarEdi.Size = new System.Drawing.Size(87, 24);
            this.btnGenerarEdi.TabIndex = 11;
            this.btnGenerarEdi.Text = "Generar EDI";
            this.btnGenerarEdi.UseVisualStyleBackColor = true;
            this.btnGenerarEdi.Click += new System.EventHandler(this.btnGenerarEdi_Click);
            // 
            // btnCorreosEdi
            // 
            this.btnCorreosEdi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCorreosEdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCorreosEdi.Location = new System.Drawing.Point(656, 166);
            this.btnCorreosEdi.Name = "btnCorreosEdi";
            this.btnCorreosEdi.Size = new System.Drawing.Size(87, 24);
            this.btnCorreosEdi.TabIndex = 12;
            this.btnCorreosEdi.Text = "Correos EDI";
            this.btnCorreosEdi.UseVisualStyleBackColor = true;
            this.btnCorreosEdi.Click += new System.EventHandler(this.btnCorreosEdi_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 593);
            this.Controls.Add(this.btnCorreosEdi);
            this.Controls.Add(this.btnGenerarEdi);
            this.Controls.Add(this.btnListadoSegmentos);
            this.Controls.Add(this.btnTexto);
            this.Controls.Add(this.TxtFormatoTexto);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtElemento);
            this.Controls.Add(this.txtSegmento);
            this.Controls.Add(this.btnCargarArchivo);
            this.Controls.Add(this.txtNombreArchivo);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Formato Edi";
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtNombreArchivo;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbDeshabilitar;
        private System.Windows.Forms.RadioButton rbHabilitar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtElemento;
        private System.Windows.Forms.TextBox txtSegmento;
        private System.Windows.Forms.Button btnCargarArchivo;
        private System.Windows.Forms.RichTextBox TxtFormatoTexto;
        private System.Windows.Forms.Button btnTexto;
        private System.Windows.Forms.Button btnListadoSegmentos;
        private System.Windows.Forms.Button btnGenerarEdi;
        private System.Windows.Forms.Button btnCorreosEdi;
    }
}

