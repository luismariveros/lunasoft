namespace LunaSoft
{
    partial class frmListadoHistoricoProducto
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbHoy = new System.Windows.Forms.RadioButton();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.lblCodigoP = new System.Windows.Forms.Label();
            this.lblHasta = new System.Windows.Forms.Label();
            this.btGenerar = new System.Windows.Forms.Button();
            this.tbCodigo = new System.Windows.Forms.TextBox();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.lblDesde = new System.Windows.Forms.Label();
            this.rbMes = new System.Windows.Forms.RadioButton();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.rbTodo = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolTipPrincipal = new System.Windows.Forms.ToolTip(this.components);
            this.btSalir = new System.Windows.Forms.Button();
            this.btPreview = new System.Windows.Forms.Button();
            this.btImprimir = new System.Windows.Forms.Button();
            this.btVer = new System.Windows.Forms.Button();
            this.btEliminar = new System.Windows.Forms.Button();
            this.btEditar = new System.Windows.Forms.Button();
            this.btAgregar = new System.Windows.Forms.Button();
            this.btActualizar = new System.Windows.Forms.Button();
            this.lblListado = new System.Windows.Forms.Label();
            this.lblTipoListado = new System.Windows.Forms.Label();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.lblTipoFiltro = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MyPrintDocument = new System.Drawing.Printing.PrintDocument();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.lblMovimientos = new System.Windows.Forms.Label();
            this.lblTransferencias = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.rbHoy);
            this.panel2.Controls.Add(this.tbNombre);
            this.panel2.Controls.Add(this.lblCodigoP);
            this.panel2.Controls.Add(this.lblHasta);
            this.panel2.Controls.Add(this.btGenerar);
            this.panel2.Controls.Add(this.tbCodigo);
            this.panel2.Controls.Add(this.dtpHasta);
            this.panel2.Controls.Add(this.lblBuscar);
            this.panel2.Controls.Add(this.lblDesde);
            this.panel2.Controls.Add(this.rbMes);
            this.panel2.Controls.Add(this.dtpDesde);
            this.panel2.Controls.Add(this.rbTodo);
            this.panel2.Location = new System.Drawing.Point(13, 73);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1180, 58);
            this.panel2.TabIndex = 1;
            // 
            // rbHoy
            // 
            this.rbHoy.AutoSize = true;
            this.rbHoy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbHoy.Location = new System.Drawing.Point(6, 30);
            this.rbHoy.Name = "rbHoy";
            this.rbHoy.Size = new System.Drawing.Size(51, 20);
            this.rbHoy.TabIndex = 15;
            this.rbHoy.TabStop = true;
            this.rbHoy.Text = "Hoy";
            this.rbHoy.UseVisualStyleBackColor = true;
            this.rbHoy.CheckedChanged += new System.EventHandler(this.rbHoy_CheckedChanged);
            // 
            // tbNombre
            // 
            this.tbNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNombre.Location = new System.Drawing.Point(640, 8);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.ReadOnly = true;
            this.tbNombre.Size = new System.Drawing.Size(497, 24);
            this.tbNombre.TabIndex = 14;
            this.tbNombre.TabStop = false;
            // 
            // lblCodigoP
            // 
            this.lblCodigoP.AutoSize = true;
            this.lblCodigoP.Image = global::LunaSoft.Properties.Resources.magnifier;
            this.lblCodigoP.Location = new System.Drawing.Point(460, 14);
            this.lblCodigoP.Name = "lblCodigoP";
            this.lblCodigoP.Size = new System.Drawing.Size(19, 13);
            this.lblCodigoP.TabIndex = 13;
            this.lblCodigoP.Text = "    ";
            this.lblCodigoP.Click += new System.EventHandler(this.lblCodigoP_Click);
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHasta.Location = new System.Drawing.Point(174, 7);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(52, 18);
            this.lblHasta.TabIndex = 12;
            this.lblHasta.Text = "Hasta";
            // 
            // btGenerar
            // 
            this.btGenerar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btGenerar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btGenerar.Image = global::LunaSoft.Properties.Resources.arrow_refresh;
            this.btGenerar.Location = new System.Drawing.Point(1143, 8);
            this.btGenerar.Name = "btGenerar";
            this.btGenerar.Size = new System.Drawing.Size(26, 26);
            this.btGenerar.TabIndex = 8;
            this.toolTipPrincipal.SetToolTip(this.btGenerar, "Generar Listado");
            this.btGenerar.UseVisualStyleBackColor = true;
            this.btGenerar.Click += new System.EventHandler(this.btGenerar_Click);
            // 
            // tbCodigo
            // 
            this.tbCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCodigo.Location = new System.Drawing.Point(485, 8);
            this.tbCodigo.Name = "tbCodigo";
            this.tbCodigo.Size = new System.Drawing.Size(141, 24);
            this.tbCodigo.TabIndex = 0;
            this.tbCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbBuscar_KeyPress);
            // 
            // dtpHasta
            // 
            this.dtpHasta.CustomFormat = "dd/MM/yyyy";
            this.dtpHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHasta.Location = new System.Drawing.Point(231, 3);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(106, 24);
            this.dtpHasta.TabIndex = 11;
            this.dtpHasta.ValueChanged += new System.EventHandler(this.dtpHasta_ValueChanged);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscar.Location = new System.Drawing.Point(380, 10);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(81, 20);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "Producto";
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesde.Location = new System.Drawing.Point(3, 8);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(48, 15);
            this.lblDesde.TabIndex = 10;
            this.lblDesde.Text = "Desde";
            // 
            // rbMes
            // 
            this.rbMes.AutoSize = true;
            this.rbMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMes.Location = new System.Drawing.Point(57, 30);
            this.rbMes.Name = "rbMes";
            this.rbMes.Size = new System.Drawing.Size(52, 20);
            this.rbMes.TabIndex = 2;
            this.rbMes.TabStop = true;
            this.rbMes.Text = "Mes";
            this.rbMes.UseVisualStyleBackColor = true;
            this.rbMes.CheckedChanged += new System.EventHandler(this.rbMes_CheckedChanged);
            // 
            // dtpDesde
            // 
            this.dtpDesde.CustomFormat = "dd/MM/yyyy";
            this.dtpDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDesde.Location = new System.Drawing.Point(54, 3);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(106, 24);
            this.dtpDesde.TabIndex = 9;
            this.dtpDesde.ValueChanged += new System.EventHandler(this.dtpDesde_ValueChanged);
            // 
            // rbTodo
            // 
            this.rbTodo.AutoSize = true;
            this.rbTodo.Checked = true;
            this.rbTodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTodo.Location = new System.Drawing.Point(113, 30);
            this.rbTodo.Name = "rbTodo";
            this.rbTodo.Size = new System.Drawing.Size(59, 20);
            this.rbTodo.TabIndex = 3;
            this.rbTodo.TabStop = true;
            this.rbTodo.Text = "Todo";
            this.rbTodo.UseVisualStyleBackColor = true;
            this.rbTodo.CheckedChanged += new System.EventHandler(this.rbTodo_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridView1.Location = new System.Drawing.Point(12, 166);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(562, 375);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 0;
            // 
            // btSalir
            // 
            this.btSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btSalir.Image = global::LunaSoft.Properties.Resources.cancel;
            this.btSalir.Location = new System.Drawing.Point(1167, 547);
            this.btSalir.Name = "btSalir";
            this.btSalir.Size = new System.Drawing.Size(26, 26);
            this.btSalir.TabIndex = 6;
            this.toolTipPrincipal.SetToolTip(this.btSalir, "Cerrar formulario (ESC)");
            this.btSalir.UseVisualStyleBackColor = true;
            this.btSalir.Click += new System.EventHandler(this.btSalir_Click);
            // 
            // btPreview
            // 
            this.btPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btPreview.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btPreview.Image = global::LunaSoft.Properties.Resources.page_white_magnify;
            this.btPreview.Location = new System.Drawing.Point(1142, 1);
            this.btPreview.Name = "btPreview";
            this.btPreview.Size = new System.Drawing.Size(29, 26);
            this.btPreview.TabIndex = 15;
            this.toolTipPrincipal.SetToolTip(this.btPreview, "Vista Previa");
            this.btPreview.UseVisualStyleBackColor = true;
            this.btPreview.Click += new System.EventHandler(this.btPreview_Click);
            // 
            // btImprimir
            // 
            this.btImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btImprimir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btImprimir.Image = global::LunaSoft.Properties.Resources.printer;
            this.btImprimir.Location = new System.Drawing.Point(1110, 1);
            this.btImprimir.Name = "btImprimir";
            this.btImprimir.Size = new System.Drawing.Size(29, 26);
            this.btImprimir.TabIndex = 14;
            this.toolTipPrincipal.SetToolTip(this.btImprimir, "Imprimir");
            this.btImprimir.UseVisualStyleBackColor = true;
            this.btImprimir.Click += new System.EventHandler(this.btImprimir_Click);
            // 
            // btVer
            // 
            this.btVer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btVer.Enabled = false;
            this.btVer.Image = global::LunaSoft.Properties.Resources.magnifier;
            this.btVer.Location = new System.Drawing.Point(86, 1);
            this.btVer.Name = "btVer";
            this.btVer.Size = new System.Drawing.Size(26, 26);
            this.btVer.TabIndex = 5;
            this.btVer.TabStop = false;
            this.toolTipPrincipal.SetToolTip(this.btVer, "Ver registro (V)");
            this.btVer.UseVisualStyleBackColor = true;
            // 
            // btEliminar
            // 
            this.btEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btEliminar.Enabled = false;
            this.btEliminar.Image = global::LunaSoft.Properties.Resources.delete;
            this.btEliminar.Location = new System.Drawing.Point(58, 1);
            this.btEliminar.Name = "btEliminar";
            this.btEliminar.Size = new System.Drawing.Size(26, 26);
            this.btEliminar.TabIndex = 4;
            this.btEliminar.TabStop = false;
            this.toolTipPrincipal.SetToolTip(this.btEliminar, "Eliminar registro (E)");
            this.btEliminar.UseVisualStyleBackColor = true;
            // 
            // btEditar
            // 
            this.btEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btEditar.Enabled = false;
            this.btEditar.Image = global::LunaSoft.Properties.Resources.page_white_edit;
            this.btEditar.Location = new System.Drawing.Point(30, 1);
            this.btEditar.Name = "btEditar";
            this.btEditar.Size = new System.Drawing.Size(26, 26);
            this.btEditar.TabIndex = 3;
            this.btEditar.TabStop = false;
            this.toolTipPrincipal.SetToolTip(this.btEditar, "Modificar registro (M)");
            this.btEditar.UseVisualStyleBackColor = true;
            // 
            // btAgregar
            // 
            this.btAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btAgregar.Enabled = false;
            this.btAgregar.Image = global::LunaSoft.Properties.Resources.add;
            this.btAgregar.Location = new System.Drawing.Point(2, 1);
            this.btAgregar.Name = "btAgregar";
            this.btAgregar.Size = new System.Drawing.Size(26, 26);
            this.btAgregar.TabIndex = 6;
            this.btAgregar.TabStop = false;
            this.toolTipPrincipal.SetToolTip(this.btAgregar, "Insertar registro (A)");
            this.btAgregar.UseVisualStyleBackColor = true;
            // 
            // btActualizar
            // 
            this.btActualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btActualizar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btActualizar.Image = global::LunaSoft.Properties.Resources.database_refresh;
            this.btActualizar.Location = new System.Drawing.Point(1135, 547);
            this.btActualizar.Name = "btActualizar";
            this.btActualizar.Size = new System.Drawing.Size(26, 26);
            this.btActualizar.TabIndex = 7;
            this.toolTipPrincipal.SetToolTip(this.btActualizar, "Refrescar Contenido (F4)");
            this.btActualizar.UseVisualStyleBackColor = true;
            this.btActualizar.Click += new System.EventHandler(this.btActualizar_Click);
            // 
            // lblListado
            // 
            this.lblListado.AutoSize = true;
            this.lblListado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListado.Location = new System.Drawing.Point(7, 10);
            this.lblListado.Name = "lblListado";
            this.lblListado.Size = new System.Drawing.Size(91, 20);
            this.lblListado.TabIndex = 9;
            this.lblListado.Text = "Listado de: ";
            // 
            // lblTipoListado
            // 
            this.lblTipoListado.AutoSize = true;
            this.lblTipoListado.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoListado.Location = new System.Drawing.Point(99, 10);
            this.lblTipoListado.Name = "lblTipoListado";
            this.lblTipoListado.Size = new System.Drawing.Size(0, 18);
            this.lblTipoListado.TabIndex = 10;
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltro.Location = new System.Drawing.Point(497, 10);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(48, 20);
            this.lblFiltro.TabIndex = 11;
            this.lblFiltro.Text = "Filtro:";
            
            // 
            // lblTipoFiltro
            // 
            this.lblTipoFiltro.AutoSize = true;
            this.lblTipoFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoFiltro.Location = new System.Drawing.Point(553, 10);
            this.lblTipoFiltro.Name = "lblTipoFiltro";
            this.lblTipoFiltro.Size = new System.Drawing.Size(0, 20);
            this.lblTipoFiltro.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btPreview);
            this.panel1.Controls.Add(this.btImprimir);
            this.panel1.Controls.Add(this.btVer);
            this.panel1.Controls.Add(this.btEliminar);
            this.panel1.Controls.Add(this.btEditar);
            this.panel1.Controls.Add(this.btAgregar);
            this.panel1.Location = new System.Drawing.Point(12, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1181, 30);
            this.panel1.TabIndex = 13;
            // 
            // MyPrintDocument
            // 
            this.MyPrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.MyPrintDocument_PrintPage);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridView2.Location = new System.Drawing.Point(591, 166);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView2.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(602, 375);
            this.dataGridView2.StandardTab = true;
            this.dataGridView2.TabIndex = 14;
            // 
            // lblMovimientos
            // 
            this.lblMovimientos.AutoSize = true;
            this.lblMovimientos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovimientos.Location = new System.Drawing.Point(217, 139);
            this.lblMovimientos.Name = "lblMovimientos";
            this.lblMovimientos.Size = new System.Drawing.Size(116, 24);
            this.lblMovimientos.TabIndex = 15;
            this.lblMovimientos.Text = "Movimientos";
            // 
            // lblTransferencias
            // 
            this.lblTransferencias.AutoSize = true;
            this.lblTransferencias.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransferencias.Location = new System.Drawing.Point(825, 139);
            this.lblTransferencias.Name = "lblTransferencias";
            this.lblTransferencias.Size = new System.Drawing.Size(134, 24);
            this.lblTransferencias.TabIndex = 16;
            this.lblTransferencias.Text = "Transferencias";
            // 
            // frmListadoHistoricoProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btSalir;
            this.ClientSize = new System.Drawing.Size(1205, 583);
            this.Controls.Add(this.lblTransferencias);
            this.Controls.Add(this.lblMovimientos);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTipoFiltro);
            this.Controls.Add(this.lblFiltro);
            this.Controls.Add(this.lblTipoListado);
            this.Controls.Add(this.lblListado);
            this.Controls.Add(this.btActualizar);
            this.Controls.Add(this.btSalir);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmListadoHistoricoProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LunaSoft :: Informe Histórico Producto";
            this.Load += new System.EventHandler(this.frmListadoHistoricoProducto_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox tbCodigo;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolTip toolTipPrincipal;
        private System.Windows.Forms.Button btSalir;
        private System.Windows.Forms.Button btActualizar;
        private System.Windows.Forms.RadioButton rbTodo;
        private System.Windows.Forms.RadioButton rbMes;
        private System.Windows.Forms.Label lblListado;
        private System.Windows.Forms.Label lblTipoListado;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.Label lblTipoFiltro;
        private System.Windows.Forms.Button btGenerar;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btVer;
        private System.Windows.Forms.Button btEliminar;
        private System.Windows.Forms.Button btEditar;
        private System.Windows.Forms.Button btAgregar;
        private System.Windows.Forms.Button btPreview;
        private System.Windows.Forms.Button btImprimir;
        private System.Drawing.Printing.PrintDocument MyPrintDocument;
        private System.Windows.Forms.Label lblCodigoP;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.RadioButton rbHoy;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label lblMovimientos;
        private System.Windows.Forms.Label lblTransferencias;
    }
}