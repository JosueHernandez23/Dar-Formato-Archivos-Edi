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
            this.btnGenerarArchivo = new System.Windows.Forms.Button();
            this.txtNombreArchivo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            this.btnEventoEdi = new System.Windows.Forms.Button();
            this.btnEstadistica = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnListadoSegmentos = new System.Windows.Forms.Button();
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
            this.btnGenerarEdi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerarEdi.Enabled = false;
            this.btnGenerarEdi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarEdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarEdi.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnGenerarEdi.Location = new System.Drawing.Point(8, 170);
            this.btnGenerarEdi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGenerarEdi.Name = "btnGenerarEdi";
            this.btnGenerarEdi.Size = new System.Drawing.Size(193, 46);
            this.btnGenerarEdi.TabIndex = 11;
            this.btnGenerarEdi.Text = "Generar EDI";
            this.btnGenerarEdi.UseVisualStyleBackColor = true;
            this.btnGenerarEdi.Visible = false;
            this.btnGenerarEdi.Click += new System.EventHandler(this.btnGenerarEdi_Click);
            // 
            // btnCorreosEdi
            // 
            this.btnCorreosEdi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCorreosEdi.Enabled = false;
            this.btnCorreosEdi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCorreosEdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCorreosEdi.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCorreosEdi.Location = new System.Drawing.Point(8, 276);
            this.btnCorreosEdi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCorreosEdi.Name = "btnCorreosEdi";
            this.btnCorreosEdi.Size = new System.Drawing.Size(193, 46);
            this.btnCorreosEdi.TabIndex = 12;
            this.btnCorreosEdi.Text = "Correos EDI";
            this.btnCorreosEdi.UseVisualStyleBackColor = true;
            this.btnCorreosEdi.Visible = false;
            this.btnCorreosEdi.Click += new System.EventHandler(this.btnCorreosEdi_Click);
            // 
            // btnEdiPedidos
            // 
            this.btnEdiPedidos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdiPedidos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdiPedidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdiPedidos.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEdiPedidos.Location = new System.Drawing.Point(8, 11);
            this.btnEdiPedidos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEdiPedidos.Name = "btnEdiPedidos";
            this.btnEdiPedidos.Size = new System.Drawing.Size(193, 46);
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(225, 15);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 185F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1357, 199);
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
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel2.MinimumSize = new System.Drawing.Size(0, 188);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1349, 188);
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
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.97279F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.69388F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.01361F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(260, 180);
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
            this.btnCargarArchivo.Location = new System.Drawing.Point(4, 61);
            this.btnCargarArchivo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCargarArchivo.Name = "btnCargarArchivo";
            this.btnCargarArchivo.Size = new System.Drawing.Size(252, 54);
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
            this.btnTexto.Location = new System.Drawing.Point(4, 123);
            this.btnTexto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTexto.Name = "btnTexto";
            this.btnTexto.Size = new System.Drawing.Size(252, 53);
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
            this.btnLimpiar.Location = new System.Drawing.Point(4, 4);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(252, 49);
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
            this.tableLayoutPanel4.Location = new System.Drawing.Point(272, 4);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1073, 180);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(6, 172);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.btnGenerarArchivo);
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
            this.groupBox1.Location = new System.Drawing.Point(18, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(1051, 172);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Deteccion automatica de caracteres: ";
            // 
            // btnGenerarArchivo
            // 
            this.btnGenerarArchivo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerarArchivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarArchivo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnGenerarArchivo.Location = new System.Drawing.Point(8, 107);
            this.btnGenerarArchivo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGenerarArchivo.Name = "btnGenerarArchivo";
            this.btnGenerarArchivo.Size = new System.Drawing.Size(153, 50);
            this.btnGenerarArchivo.TabIndex = 16;
            this.btnGenerarArchivo.Text = "Generar Archivo";
            this.btnGenerarArchivo.UseVisualStyleBackColor = true;
            this.btnGenerarArchivo.Click += new System.EventHandler(this.btnGenerarArchivo_Click);
            // 
            // txtNombreArchivo
            // 
            this.txtNombreArchivo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombreArchivo.AutoSize = true;
            this.txtNombreArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreArchivo.Location = new System.Drawing.Point(299, 119);
            this.txtNombreArchivo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
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
            this.label1.Location = new System.Drawing.Point(169, 115);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre archivo: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(17, 27);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = "Elemento: ";
            // 
            // txtSegmento
            // 
            this.txtSegmento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSegmento.Location = new System.Drawing.Point(132, 66);
            this.txtSegmento.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSegmento.MaxLength = 1;
            this.txtSegmento.Name = "txtSegmento";
            this.txtSegmento.Size = new System.Drawing.Size(244, 23);
            this.txtSegmento.TabIndex = 7;
            // 
            // txtElemento
            // 
            this.txtElemento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtElemento.Location = new System.Drawing.Point(132, 27);
            this.txtElemento.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtElemento.MaxLength = 1;
            this.txtElemento.Name = "txtElemento";
            this.txtElemento.Size = new System.Drawing.Size(244, 23);
            this.txtElemento.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(17, 66);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
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
            this.rbDeshabilitar.Location = new System.Drawing.Point(385, 66);
            this.rbDeshabilitar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.rbHabilitar.Location = new System.Drawing.Point(385, 25);
            this.rbHabilitar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.TxtFormatoTexto.Location = new System.Drawing.Point(4, 6);
            this.TxtFormatoTexto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtFormatoTexto.Name = "TxtFormatoTexto";
            this.TxtFormatoTexto.Size = new System.Drawing.Size(1348, 496);
            this.TxtFormatoTexto.TabIndex = 8;
            this.TxtFormatoTexto.Text = "";
            // 
            // btnReporteEventos
            // 
            this.btnReporteEventos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReporteEventos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporteEventos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteEventos.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnReporteEventos.Location = new System.Drawing.Point(8, 64);
            this.btnReporteEventos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReporteEventos.Name = "btnReporteEventos";
            this.btnReporteEventos.Size = new System.Drawing.Size(193, 46);
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
            this.btnDirectorioSFTP.Location = new System.Drawing.Point(8, 118);
            this.btnDirectorioSFTP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDirectorioSFTP.Name = "btnDirectorioSFTP";
            this.btnDirectorioSFTP.Size = new System.Drawing.Size(193, 46);
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
            this.groupBox2.Controls.Add(this.btnEventoEdi);
            this.groupBox2.Controls.Add(this.btnEstadistica);
            this.groupBox2.Controls.Add(this.btnCorreosEdi);
            this.groupBox2.Controls.Add(this.btnGenerarEdi);
            this.groupBox2.Controls.Add(this.btnEdiPedidos);
            this.groupBox2.Controls.Add(this.btnDirectorioSFTP);
            this.groupBox2.Controls.Add(this.btnReporteEventos);
            this.groupBox2.Location = new System.Drawing.Point(8, 15);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(209, 730);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            // 
            // btnEventoEdi
            // 
            this.btnEventoEdi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEventoEdi.Enabled = false;
            this.btnEventoEdi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEventoEdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEventoEdi.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEventoEdi.Location = new System.Drawing.Point(8, 329);
            this.btnEventoEdi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEventoEdi.Name = "btnEventoEdi";
            this.btnEventoEdi.Size = new System.Drawing.Size(193, 46);
            this.btnEventoEdi.TabIndex = 18;
            this.btnEventoEdi.Text = "Eventos EDI";
            this.btnEventoEdi.UseVisualStyleBackColor = true;
            this.btnEventoEdi.Visible = false;
            this.btnEventoEdi.Click += new System.EventHandler(this.btnEventoEdi_Click);
            // 
            // btnEstadistica
            // 
            this.btnEstadistica.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEstadistica.Enabled = false;
            this.btnEstadistica.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstadistica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstadistica.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEstadistica.Location = new System.Drawing.Point(8, 223);
            this.btnEstadistica.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEstadistica.Name = "btnEstadistica";
            this.btnEstadistica.Size = new System.Drawing.Size(193, 46);
            this.btnEstadistica.TabIndex = 17;
            this.btnEstadistica.Text = "Estadistica EDI";
            this.btnEstadistica.UseVisualStyleBackColor = true;
            this.btnEstadistica.Visible = false;
            this.btnEstadistica.Click += new System.EventHandler(this.btnEstadistica_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.TxtFormatoTexto);
            this.panel2.Location = new System.Drawing.Point(225, 238);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1357, 507);
            this.panel2.TabIndex = 18;
            // 
            // btnListadoSegmentos
            // 
            this.btnListadoSegmentos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnListadoSegmentos.BackgroundImage")));
            this.btnListadoSegmentos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnListadoSegmentos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnListadoSegmentos.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnListadoSegmentos.Location = new System.Drawing.Point(997, 20);
            this.btnListadoSegmentos.Margin = new System.Windows.Forms.Padding(4);
            this.btnListadoSegmentos.Name = "btnListadoSegmentos";
            this.btnListadoSegmentos.Size = new System.Drawing.Size(45, 42);
            this.btnListadoSegmentos.TabIndex = 10;
            this.btnListadoSegmentos.UseVisualStyleBackColor = true;
            this.btnListadoSegmentos.Click += new System.EventHandler(this.btnListadoSegmentos_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1599, 759);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(1237, 605);
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
        private System.Windows.Forms.Button btnEventoEdi;
        private System.Windows.Forms.Button btnGenerarArchivo;
    }
}

