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
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.btnGenerarEdi = new System.Windows.Forms.Button();
            this.btnCorreosEdi = new System.Windows.Forms.Button();
            this.btnEdiPedidos = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCargarArchivo = new System.Windows.Forms.Button();
            this.btnTexto = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNombreArchivo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnListadoSegmentos = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSegmento = new System.Windows.Forms.TextBox();
            this.txtElemento = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rbDeshabilitar = new System.Windows.Forms.RadioButton();
            this.rbHabilitar = new System.Windows.Forms.RadioButton();
            this.TxtFormatoTexto = new System.Windows.Forms.RichTextBox();
            this.btnReporteEventos = new System.Windows.Forms.Button();
            this.btnDirectorioSFTP = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEstadistica = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReporteEventos = new System.Windows.Forms.Button();
            this.btnDirectorioSFTP = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // btnGenerarEdi
            // 
            this.btnGenerarEdi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerarEdi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerarEdi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarEdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarEdi.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnGenerarEdi.Location = new System.Drawing.Point(6, 138);
            this.btnGenerarEdi.Name = "btnGenerarEdi";
            this.btnGenerarEdi.Size = new System.Drawing.Size(145, 37);
            this.btnGenerarEdi.TabIndex = 11;
            this.btnGenerarEdi.Text = "Generar EDI";
            this.btnGenerarEdi.UseVisualStyleBackColor = true;
            this.btnGenerarEdi.Click += new System.EventHandler(this.btnGenerarEdi_Click);
            // 
            // btnCorreosEdi
            // 
            this.btnCorreosEdi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCorreosEdi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCorreosEdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCorreosEdi.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCorreosEdi.Location = new System.Drawing.Point(6, 181);
            this.btnCorreosEdi.Name = "btnCorreosEdi";
            this.btnCorreosEdi.Size = new System.Drawing.Size(145, 37);
            this.btnCorreosEdi.TabIndex = 12;
            this.btnCorreosEdi.Text = "Correos EDI";
            this.btnCorreosEdi.UseVisualStyleBackColor = true;
            this.btnCorreosEdi.Click += new System.EventHandler(this.btnCorreosEdi_Click);
            // 
            // btnEdiPedidos
            // 
            this.btnEdiPedidos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdiPedidos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdiPedidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdiPedidos.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEdiPedidos.Location = new System.Drawing.Point(6, 9);
            this.btnEdiPedidos.Name = "btnEdiPedidos";
            this.btnEdiPedidos.Size = new System.Drawing.Size(145, 37);
            this.btnEdiPedidos.TabIndex = 15;
            this.btnEdiPedidos.Text = "Edi Pedidos";
            this.btnEdiPedidos.UseVisualStyleBackColor = true;
            this.btnEdiPedidos.Click += new System.EventHandler(this.btnEdiPedidos_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(169, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1018, 162);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.88095F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.11905F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.MinimumSize = new System.Drawing.Size(0, 153);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1012, 153);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.btnCargarArchivo, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.btnTexto, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.btnLimpiar, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.97279F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.69388F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.01361F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(195, 147);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // btnCargarArchivo
            // 
            this.btnCargarArchivo.AllowDrop = true;
            this.btnCargarArchivo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCargarArchivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargarArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarArchivo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCargarArchivo.Location = new System.Drawing.Point(3, 49);
            this.btnCargarArchivo.Name = "btnCargarArchivo";
            this.btnCargarArchivo.Size = new System.Drawing.Size(189, 44);
            this.btnCargarArchivo.TabIndex = 2;
            this.btnCargarArchivo.Text = "Cargar archivo";
            this.btnCargarArchivo.UseVisualStyleBackColor = true;
            this.btnCargarArchivo.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTexto
            // 
            this.btnTexto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTexto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTexto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTexto.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnTexto.Location = new System.Drawing.Point(3, 99);
            this.btnTexto.Name = "btnTexto";
            this.btnTexto.Size = new System.Drawing.Size(189, 45);
            this.btnTexto.TabIndex = 9;
            this.btnTexto.Text = "Texto";
            this.btnTexto.UseVisualStyleBackColor = true;
            this.btnTexto.Click += new System.EventHandler(this.btnTexto_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnLimpiar.Location = new System.Drawing.Point(3, 3);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(189, 40);
            this.btnLimpiar.TabIndex = 13;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.386749F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 98.61325F));
            this.tableLayoutPanel4.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.groupBox1, 1, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(204, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(805, 147);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 141);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.txtNombreArchivo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnListadoSegmentos);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtSegmento);
            this.groupBox1.Controls.Add(this.txtElemento);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.rbDeshabilitar);
            this.groupBox1.Controls.Add(this.rbHabilitar);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(14, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(788, 141);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Deteccion automatica de caracteres: ";
            // 
            // txtNombreArchivo
            // 
            this.txtNombreArchivo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombreArchivo.AutoSize = true;
            this.txtNombreArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreArchivo.Location = new System.Drawing.Point(162, 100);
            this.txtNombreArchivo.Name = "txtNombreArchivo";
            this.txtNombreArchivo.Size = new System.Drawing.Size(14, 15);
            this.txtNombreArchivo.TabIndex = 1;
            this.txtNombreArchivo.Text = "_";
            this.txtNombreArchivo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(56, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre archivo: ";
            // 
            // txtNombreArchivo
            // 
            this.txtNombreArchivo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombreArchivo.AutoSize = true;
            this.txtNombreArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreArchivo.Location = new System.Drawing.Point(678, 0);
            this.txtNombreArchivo.Name = "txtNombreArchivo";
            this.txtNombreArchivo.Size = new System.Drawing.Size(250, 40);
            this.txtNombreArchivo.TabIndex = 1;
            this.txtNombreArchivo.Text = "_";
            this.txtNombreArchivo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnListadoSegmentos
            // 
            this.btnListadoSegmentos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnListadoSegmentos.BackgroundImage")));
            this.btnListadoSegmentos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnListadoSegmentos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnListadoSegmentos.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnListadoSegmentos.Location = new System.Drawing.Point(16, 86);
            this.btnListadoSegmentos.Name = "btnListadoSegmentos";
            this.btnListadoSegmentos.Size = new System.Drawing.Size(34, 34);
            this.btnListadoSegmentos.TabIndex = 10;
            this.btnListadoSegmentos.UseVisualStyleBackColor = true;
            this.btnListadoSegmentos.Click += new System.EventHandler(this.btnListadoSegmentos_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(575, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre archivo: ";
            // 
            // btnReporteEventos
            // 
            this.btnReporteEventos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReporteEventos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReporteEventos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporteEventos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteEventos.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnReporteEventos.Location = new System.Drawing.Point(343, 3);
            this.btnReporteEventos.Name = "btnReporteEventos";
            this.btnReporteEventos.Size = new System.Drawing.Size(122, 34);
            this.btnReporteEventos.TabIndex = 16;
            this.btnReporteEventos.Text = "Reporte Eventos EDI";
            this.btnReporteEventos.UseVisualStyleBackColor = true;
            this.btnReporteEventos.Click += new System.EventHandler(this.btnReporteEventos_Click);
            // 
            // btnDirectorioSFTP
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(13, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = "Elemento: ";
            // 
            // txtSegmento
            // 
            this.txtSegmento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSegmento.Location = new System.Drawing.Point(99, 54);
            this.txtSegmento.MaxLength = 1;
            this.txtSegmento.Name = "txtSegmento";
            this.txtSegmento.Size = new System.Drawing.Size(184, 23);
            this.txtSegmento.TabIndex = 7;
            // 
            // txtElemento
            // 
            this.txtElemento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtElemento.Location = new System.Drawing.Point(99, 22);
            this.txtElemento.MaxLength = 1;
            this.txtElemento.Name = "txtElemento";
            this.txtElemento.Size = new System.Drawing.Size(184, 23);
            this.txtElemento.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(13, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "Segmento: ";
            // 
            // rbDeshabilitar
            // 
            this.rbDeshabilitar.AutoSize = true;
            this.rbDeshabilitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDeshabilitar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rbDeshabilitar.Location = new System.Drawing.Point(289, 54);
            this.rbDeshabilitar.Name = "rbDeshabilitar";
            this.rbDeshabilitar.Size = new System.Drawing.Size(103, 22);
            this.rbDeshabilitar.TabIndex = 1;
            this.rbDeshabilitar.Text = "Deshabilitar";
            this.rbDeshabilitar.UseVisualStyleBackColor = true;
            // 
            // rbHabilitar
            // 
            this.rbHabilitar.AutoSize = true;
            this.rbHabilitar.Checked = true;
            this.rbHabilitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbHabilitar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rbHabilitar.Location = new System.Drawing.Point(289, 20);
            this.rbHabilitar.Name = "rbHabilitar";
            this.rbHabilitar.Size = new System.Drawing.Size(79, 22);
            this.rbHabilitar.TabIndex = 0;
            this.rbHabilitar.TabStop = true;
            this.rbHabilitar.Text = "Habilitar";
            this.rbHabilitar.UseVisualStyleBackColor = true;
            // 
            // TxtFormatoTexto
            // 
            this.TxtFormatoTexto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtFormatoTexto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFormatoTexto.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtFormatoTexto.Location = new System.Drawing.Point(3, 5);
            this.TxtFormatoTexto.Name = "TxtFormatoTexto";
            this.TxtFormatoTexto.Size = new System.Drawing.Size(1012, 404);
            this.TxtFormatoTexto.TabIndex = 8;
            this.TxtFormatoTexto.Text = "";
            // 
            // btnReporteEventos
            // 
            this.btnReporteEventos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReporteEventos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporteEventos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteEventos.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnReporteEventos.Location = new System.Drawing.Point(6, 95);
            this.btnReporteEventos.Name = "btnReporteEventos";
            this.btnReporteEventos.Size = new System.Drawing.Size(145, 37);
            this.btnReporteEventos.TabIndex = 16;
            this.btnReporteEventos.Text = "Reporte Eventos EDI";
            this.btnReporteEventos.UseVisualStyleBackColor = true;
            this.btnReporteEventos.Click += new System.EventHandler(this.btnReporteEventos_Click);
            // 
            // btnDirectorioSFTP
            // 
            this.btnDirectorioSFTP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDirectorioSFTP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDirectorioSFTP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDirectorioSFTP.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDirectorioSFTP.Location = new System.Drawing.Point(6, 52);
            this.btnDirectorioSFTP.Name = "btnDirectorioSFTP";
            this.btnDirectorioSFTP.Size = new System.Drawing.Size(145, 37);
            this.btnDirectorioSFTP.TabIndex = 16;
            this.btnDirectorioSFTP.Text = "Directorio SFTP";
            this.btnDirectorioSFTP.UseVisualStyleBackColor = true;
            this.btnDirectorioSFTP.Click += new System.EventHandler(this.btnDirectorioSFTP_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.btnEstadistica);
            this.groupBox2.Controls.Add(this.btnCorreosEdi);
            this.groupBox2.Controls.Add(this.btnGenerarEdi);
            this.groupBox2.Controls.Add(this.btnEdiPedidos);
            this.groupBox2.Controls.Add(this.btnDirectorioSFTP);
            this.groupBox2.Controls.Add(this.btnReporteEventos);
            this.groupBox2.Location = new System.Drawing.Point(6, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(157, 593);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            // 
            // btnEstadistica
            // 
            this.btnEstadistica.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEstadistica.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstadistica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstadistica.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEstadistica.Location = new System.Drawing.Point(6, 224);
            this.btnEstadistica.Name = "btnEstadistica";
            this.btnEstadistica.Size = new System.Drawing.Size(145, 37);
            this.btnEstadistica.TabIndex = 17;
            this.btnEstadistica.Text = "Estadistica EDI";
            this.btnEstadistica.UseVisualStyleBackColor = true;
            this.btnEstadistica.Click += new System.EventHandler(this.btnEstadistica_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.TxtFormatoTexto);
            this.panel2.Location = new System.Drawing.Point(169, 193);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1018, 412);
            this.panel2.TabIndex = 18;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1199, 617);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(933, 501);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formato Edi";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.Form1_DragOver);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button btnGenerarEdi;
        private System.Windows.Forms.Button btnCorreosEdi;
        private System.Windows.Forms.Button btnEdiPedidos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnReporteEventos;
        private System.Windows.Forms.Button btnDirectorioSFTP;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnCargarArchivo;
        private System.Windows.Forms.Button btnTexto;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label txtNombreArchivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnListadoSegmentos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSegmento;
        private System.Windows.Forms.TextBox txtElemento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbDeshabilitar;
        private System.Windows.Forms.RadioButton rbHabilitar;
        private System.Windows.Forms.RichTextBox TxtFormatoTexto;
        private System.Windows.Forms.Button btnEstadistica;
        private System.Windows.Forms.Panel panel2;
    }
}

