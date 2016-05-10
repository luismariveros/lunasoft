namespace LunaSoft
{
    partial class frmListados
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.btGenerar = new System.Windows.Forms.Button();
            this.rbTodo = new System.Windows.Forms.RadioButton();
            this.rbMes = new System.Windows.Forms.RadioButton();
            this.tbBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolTipPrincipal = new System.Windows.Forms.ToolTip(this.components);
            this.btSalir = new System.Windows.Forms.Button();
            this.btVer = new System.Windows.Forms.Button();
            this.btEliminar = new System.Windows.Forms.Button();
            this.btEditar = new System.Windows.Forms.Button();
            this.btAgregar = new System.Windows.Forms.Button();
            this.btActualizar = new System.Windows.Forms.Button();
            this.btPreview = new System.Windows.Forms.Button();
            this.btImprimir = new System.Windows.Forms.Button();
            this.lblListado = new System.Windows.Forms.Label();
            this.lblTipoListado = new System.Windows.Forms.Label();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.lblTipoFiltro = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MyPrintDocument = new System.Drawing.Printing.PrintDocument();
            this.lblSumatoria = new System.Windows.Forms.Label();
            this.txtSumatoria = new System.Windows.Forms.TextBox();
            this.gpbSumatoria = new System.Windows.Forms.GroupBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.gpbSumatoria.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lblHasta);
            this.panel2.Controls.Add(this.dtpHasta);
            this.panel2.Controls.Add(this.lblDesde);
            this.panel2.Controls.Add(this.dtpDesde);
            this.panel2.Controls.Add(this.btGenerar);
            this.panel2.Controls.Add(this.rbTodo);
            this.panel2.Controls.Add(this.rbMes);
            this.panel2.Controls.Add(this.tbBuscar);
            this.panel2.Controls.Add(this.lblBuscar);
            this.panel2.Location = new System.Drawing.Point(12, 73);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(790, 36);
            this.panel2.TabIndex = 1;
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHasta.Location = new System.Drawing.Point(491, 8);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(39, 15);
            this.lblHasta.TabIndex = 12;
            this.lblHasta.Text = "Hasta";
            // 
            // dtpHasta
            // 
            this.dtpHasta.CustomFormat = "dd/MM/yy";
            this.dtpHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHasta.Location = new System.Drawing.Point(531, 4);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(106, 24);
            this.dtpHasta.TabIndex = 11;
            this.dtpHasta.ValueChanged += new System.EventHandler(this.dtpHasta_ValueChanged);
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesde.Location = new System.Drawing.Point(335, 8);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(43, 15);
            this.lblDesde.TabIndex = 10;
            this.lblDesde.Text = "Desde";
            // 
            // dtpDesde
            // 
            this.dtpDesde.CustomFormat = "dd/MM/yy";
            this.dtpDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDesde.Location = new System.Drawing.Point(378, 4);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(106, 24);
            this.dtpDesde.TabIndex = 9;
            this.dtpDesde.ValueChanged += new System.EventHandler(this.dtpDesde_ValueChanged);
            // 
            // btGenerar
            // 
            this.btGenerar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btGenerar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btGenerar.Image = global::LunaSoft.Properties.Resources.arrow_refresh;
            this.btGenerar.Location = new System.Drawing.Point(757, 4);
            this.btGenerar.Name = "btGenerar";
            this.btGenerar.Size = new System.Drawing.Size(26, 26);
            this.btGenerar.TabIndex = 8;
            this.toolTipPrincipal.SetToolTip(this.btGenerar, "Generar Listado");
            this.btGenerar.UseVisualStyleBackColor = true;
            this.btGenerar.Click += new System.EventHandler(this.btGenerar_Click);
            // 
            // rbTodo
            // 
            this.rbTodo.AutoSize = true;
            this.rbTodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTodo.Location = new System.Drawing.Point(695, 9);
            this.rbTodo.Name = "rbTodo";
            this.rbTodo.Size = new System.Drawing.Size(59, 20);
            this.rbTodo.TabIndex = 3;
            this.rbTodo.TabStop = true;
            this.rbTodo.Text = "Todo";
            this.rbTodo.UseVisualStyleBackColor = true;
            this.rbTodo.CheckedChanged += new System.EventHandler(this.rbTodo_CheckedChanged);
            // 
            // rbMes
            // 
            this.rbMes.AutoSize = true;
            this.rbMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMes.Location = new System.Drawing.Point(643, 9);
            this.rbMes.Name = "rbMes";
            this.rbMes.Size = new System.Drawing.Size(52, 20);
            this.rbMes.TabIndex = 2;
            this.rbMes.TabStop = true;
            this.rbMes.Text = "Mes";
            this.rbMes.UseVisualStyleBackColor = true;
            this.rbMes.Click += new System.EventHandler(this.rbMes_Click);
            // 
            // tbBuscar
            // 
            this.tbBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBuscar.Location = new System.Drawing.Point(69, 5);
            this.tbBuscar.Name = "tbBuscar";
            this.tbBuscar.Size = new System.Drawing.Size(261, 24);
            this.tbBuscar.TabIndex = 0;
            this.tbBuscar.TextChanged += new System.EventHandler(this.tbBuscar_TextChanged);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscar.Location = new System.Drawing.Point(2, 6);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(65, 20);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "Buscar";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridView1.Location = new System.Drawing.Point(12, 115);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(790, 403);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // btSalir
            // 
            this.btSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btSalir.Image = global::LunaSoft.Properties.Resources.cancel;
            this.btSalir.Location = new System.Drawing.Point(776, 546);
            this.btSalir.Name = "btSalir";
            this.btSalir.Size = new System.Drawing.Size(26, 26);
            this.btSalir.TabIndex = 6;
            this.toolTipPrincipal.SetToolTip(this.btSalir, "Cerrar formulario (ESC)");
            this.btSalir.UseVisualStyleBackColor = true;
            this.btSalir.Click += new System.EventHandler(this.btSalir_Click);
            // 
            // btVer
            // 
            this.btVer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btVer.Image = global::LunaSoft.Properties.Resources.magnifier;
            this.btVer.Location = new System.Drawing.Point(86, 1);
            this.btVer.Name = "btVer";
            this.btVer.Size = new System.Drawing.Size(26, 26);
            this.btVer.TabIndex = 5;
            this.btVer.TabStop = false;
            this.toolTipPrincipal.SetToolTip(this.btVer, "Ver registro (V)");
            this.btVer.UseVisualStyleBackColor = true;
            this.btVer.Click += new System.EventHandler(this.btVer_Click);
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
            this.btEliminar.Click += new System.EventHandler(this.btEliminar_Click);
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
            this.btEditar.Click += new System.EventHandler(this.btEditar_Click);
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
            this.btActualizar.Location = new System.Drawing.Point(744, 546);
            this.btActualizar.Name = "btActualizar";
            this.btActualizar.Size = new System.Drawing.Size(26, 26);
            this.btActualizar.TabIndex = 7;
            this.toolTipPrincipal.SetToolTip(this.btActualizar, "Refrescar Contenido (F4)");
            this.btActualizar.UseVisualStyleBackColor = true;
            this.btActualizar.Click += new System.EventHandler(this.btActualizar_Click);
            // 
            // btPreview
            // 
            this.btPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btPreview.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btPreview.Image = global::LunaSoft.Properties.Resources.page_white_magnify;
            this.btPreview.Location = new System.Drawing.Point(759, 1);
            this.btPreview.Name = "btPreview";
            this.btPreview.Size = new System.Drawing.Size(26, 26);
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
            this.btImprimir.Location = new System.Drawing.Point(727, 1);
            this.btImprimir.Name = "btImprimir";
            this.btImprimir.Size = new System.Drawing.Size(26, 26);
            this.btImprimir.TabIndex = 14;
            this.toolTipPrincipal.SetToolTip(this.btImprimir, "Imprimir");
            this.btImprimir.UseVisualStyleBackColor = true;
            this.btImprimir.Click += new System.EventHandler(this.btImprimir_Click);
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
            this.lblTipoListado.Location = new System.Drawing.Point(87, 10);
            this.lblTipoListado.Name = "lblTipoListado";
            this.lblTipoListado.Size = new System.Drawing.Size(0, 18);
            this.lblTipoListado.TabIndex = 10;
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltro.Location = new System.Drawing.Point(259, 10);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(48, 20);
            this.lblFiltro.TabIndex = 11;
            this.lblFiltro.Text = "Filtro:";
            // 
            // lblTipoFiltro
            // 
            this.lblTipoFiltro.AutoSize = true;
            this.lblTipoFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoFiltro.Location = new System.Drawing.Point(313, 10);
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
            this.panel1.Size = new System.Drawing.Size(790, 30);
            this.panel1.TabIndex = 13;
            // 
            // MyPrintDocument
            // 
            this.MyPrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.MyPrintDocument_PrintPage);
            // 
            // lblSumatoria
            // 
            this.lblSumatoria.AutoSize = true;
            this.lblSumatoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSumatoria.Location = new System.Drawing.Point(6, 18);
            this.lblSumatoria.Name = "lblSumatoria";
            this.lblSumatoria.Size = new System.Drawing.Size(60, 18);
            this.lblSumatoria.TabIndex = 14;
            this.lblSumatoria.Text = "TOTAL";
            // 
            // txtSumatoria
            // 
            this.txtSumatoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSumatoria.Location = new System.Drawing.Point(86, 14);
            this.txtSumatoria.Name = "txtSumatoria";
            this.txtSumatoria.ReadOnly = true;
            this.txtSumatoria.Size = new System.Drawing.Size(100, 26);
            this.txtSumatoria.TabIndex = 15;
            this.txtSumatoria.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gpbSumatoria
            // 
            this.gpbSumatoria.Controls.Add(this.txtSumatoria);
            this.gpbSumatoria.Controls.Add(this.lblSumatoria);
            this.gpbSumatoria.Location = new System.Drawing.Point(12, 524);
            this.gpbSumatoria.Name = "gpbSumatoria";
            this.gpbSumatoria.Size = new System.Drawing.Size(197, 49);
            this.gpbSumatoria.TabIndex = 16;
            this.gpbSumatoria.TabStop = false;
            // 
            // frmListados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btSalir;
            this.ClientSize = new System.Drawing.Size(814, 581);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTipoFiltro);
            this.Controls.Add(this.lblFiltro);
            this.Controls.Add(this.lblTipoListado);
            this.Controls.Add(this.lblListado);
            this.Controls.Add(this.btActualizar);
            this.Controls.Add(this.btSalir);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.gpbSumatoria);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmListados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LunaSoft :: Informes";
            this.Load += new System.EventHandler(this.frmListados_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmListados_KeyPress);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.gpbSumatoria.ResumeLayout(false);
            this.gpbSumatoria.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox tbBuscar;
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
        private System.Windows.Forms.Label lblSumatoria;
        private System.Windows.Forms.TextBox txtSumatoria;
        private System.Windows.Forms.GroupBox gpbSumatoria;
    }
}