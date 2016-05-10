namespace LunaSoft
{
    partial class frmProductoAgregar
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.tbCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.toolTipAgregar = new System.Windows.Forms.ToolTip(this.components);
            this.tbCodigoF = new System.Windows.Forms.TextBox();
            this.btSalir = new System.Windows.Forms.Button();
            this.btRefrescar = new System.Windows.Forms.Button();
            this.btAceptar = new System.Windows.Forms.Button();
            this.tbCant1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbUnidad = new System.Windows.Forms.ComboBox();
            this.lblUnidad = new System.Windows.Forms.Label();
            this.tbStock = new System.Windows.Forms.TextBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.tbObservacion = new System.Windows.Forms.RichTextBox();
            this.lblObservacion = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbCompra = new System.Windows.Forms.TextBox();
            this.lblCompra = new System.Windows.Forms.Label();
            this.tbVenta = new System.Windows.Forms.TextBox();
            this.lblVenta = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbDescripcionF = new System.Windows.Forms.TextBox();
            this.lblBuscarF = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.tbCant2 = new System.Windows.Forms.TextBox();
            this.lblDeposito = new System.Windows.Forms.Label();
            this.lblCantidadStock = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tbNombre);
            this.panel1.Controls.Add(this.lblNombre);
            this.panel1.Controls.Add(this.tbCodigo);
            this.panel1.Controls.Add(this.lblCodigo);
            this.panel1.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(637, 44);
            this.panel1.TabIndex = 0;
            // 
            // tbNombre
            // 
            this.tbNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNombre.Location = new System.Drawing.Point(302, 11);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(325, 20);
            this.tbNombre.TabIndex = 1;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(246, 14);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(50, 13);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre";
            // 
            // tbCodigo
            // 
            this.tbCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCodigo.Location = new System.Drawing.Point(55, 11);
            this.tbCodigo.Name = "tbCodigo";
            this.tbCodigo.Size = new System.Drawing.Size(185, 20);
            this.tbCodigo.TabIndex = 0;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.Location = new System.Drawing.Point(3, 14);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(46, 13);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código";
            // 
            // tbCodigoF
            // 
            this.tbCodigoF.Location = new System.Drawing.Point(29, 18);
            this.tbCodigoF.Name = "tbCodigoF";
            this.tbCodigoF.Size = new System.Drawing.Size(179, 22);
            this.tbCodigoF.TabIndex = 2;
            this.toolTipAgregar.SetToolTip(this.tbCodigoF, "F2 para insertar Familia");
            this.tbCodigoF.Leave += new System.EventHandler(this.tbCodigoF_Leave);
            this.tbCodigoF.Enter += new System.EventHandler(this.tbCodigoF_Enter);
            // 
            // btSalir
            // 
            this.btSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btSalir.Image = global::LunaSoft.Properties.Resources.cancel;
            this.btSalir.Location = new System.Drawing.Point(623, 298);
            this.btSalir.Name = "btSalir";
            this.btSalir.Size = new System.Drawing.Size(26, 26);
            this.btSalir.TabIndex = 1;
            this.btSalir.TabStop = false;
            this.toolTipAgregar.SetToolTip(this.btSalir, "Cerrar formulario (ESC)");
            this.btSalir.UseVisualStyleBackColor = true;
            this.btSalir.Click += new System.EventHandler(this.btSalir_Click);
            // 
            // btRefrescar
            // 
            this.btRefrescar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btRefrescar.Image = global::LunaSoft.Properties.Resources.arrow_refresh;
            this.btRefrescar.Location = new System.Drawing.Point(567, 298);
            this.btRefrescar.Name = "btRefrescar";
            this.btRefrescar.Size = new System.Drawing.Size(26, 26);
            this.btRefrescar.TabIndex = 3;
            this.btRefrescar.TabStop = false;
            this.toolTipAgregar.SetToolTip(this.btRefrescar, "Guardar y agregar nuevo registro (F9)");
            this.btRefrescar.UseVisualStyleBackColor = true;
            this.btRefrescar.Click += new System.EventHandler(this.btRefrescar_Click);
            // 
            // btAceptar
            // 
            this.btAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btAceptar.Image = global::LunaSoft.Properties.Resources.accept;
            this.btAceptar.Location = new System.Drawing.Point(595, 298);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(26, 26);
            this.btAceptar.TabIndex = 2;
            this.btAceptar.TabStop = false;
            this.toolTipAgregar.SetToolTip(this.btAceptar, "Guardar y cerrar formulario (F10)");
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // tbCant1
            // 
            this.tbCant1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCant1.Location = new System.Drawing.Point(27, 35);
            this.tbCant1.Name = "tbCant1";
            this.tbCant1.Size = new System.Drawing.Size(55, 26);
            this.tbCant1.TabIndex = 8;
            this.tbCant1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbCant1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCant1_KeyPress);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(103, 34);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(189, 26);
            this.comboBox1.TabIndex = 9;
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(13, 62);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(640, 230);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.tbObservacion);
            this.tabPage1.Controls.Add(this.lblObservacion);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(632, 201);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Controls.Add(this.cmbUnidad);
            this.groupBox3.Controls.Add(this.lblUnidad);
            this.groupBox3.Controls.Add(this.tbStock);
            this.groupBox3.Controls.Add(this.lblStock);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox3.Location = new System.Drawing.Point(463, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(159, 112);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos";
            // 
            // cmbUnidad
            // 
            this.cmbUnidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbUnidad.FormattingEnabled = true;
            this.cmbUnidad.Items.AddRange(new object[] {
            "Unidad",
            "Litros",
            "Kilos",
            "Metros"});
            this.cmbUnidad.Location = new System.Drawing.Point(9, 38);
            this.cmbUnidad.Name = "cmbUnidad";
            this.cmbUnidad.Size = new System.Drawing.Size(139, 24);
            this.cmbUnidad.TabIndex = 1;
            // 
            // lblUnidad
            // 
            this.lblUnidad.AutoSize = true;
            this.lblUnidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnidad.Location = new System.Drawing.Point(18, 38);
            this.lblUnidad.Name = "lblUnidad";
            this.lblUnidad.Size = new System.Drawing.Size(94, 13);
            this.lblUnidad.TabIndex = 5;
            this.lblUnidad.Text = "Unidad de Medida";
            // 
            // tbStock
            // 
            this.tbStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbStock.Location = new System.Drawing.Point(85, 76);
            this.tbStock.Name = "tbStock";
            this.tbStock.Size = new System.Drawing.Size(63, 24);
            this.tbStock.TabIndex = 2;
            this.tbStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbStock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbStock_KeyPress);
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStock.Location = new System.Drawing.Point(6, 81);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(73, 13);
            this.lblStock.TabIndex = 4;
            this.lblStock.Text = "Stock Mínimo";
            // 
            // tbObservacion
            // 
            this.tbObservacion.Location = new System.Drawing.Point(85, 128);
            this.tbObservacion.Name = "tbObservacion";
            this.tbObservacion.Size = new System.Drawing.Size(537, 62);
            this.tbObservacion.TabIndex = 12;
            this.tbObservacion.Text = "";
            // 
            // lblObservacion
            // 
            this.lblObservacion.AutoSize = true;
            this.lblObservacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObservacion.Location = new System.Drawing.Point(8, 151);
            this.lblObservacion.Name = "lblObservacion";
            this.lblObservacion.Size = new System.Drawing.Size(67, 13);
            this.lblObservacion.TabIndex = 11;
            this.lblObservacion.Text = "Observación";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.tbCompra);
            this.groupBox2.Controls.Add(this.lblCompra);
            this.groupBox2.Controls.Add(this.tbVenta);
            this.groupBox2.Controls.Add(this.lblVenta);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(6, 65);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(451, 53);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Precios";
            // 
            // tbCompra
            // 
            this.tbCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCompra.Location = new System.Drawing.Point(344, 17);
            this.tbCompra.Name = "tbCompra";
            this.tbCompra.Size = new System.Drawing.Size(101, 26);
            this.tbCompra.TabIndex = 9;
            this.tbCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCompra
            // 
            this.lblCompra.AutoSize = true;
            this.lblCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompra.Location = new System.Drawing.Point(222, 22);
            this.lblCompra.Name = "lblCompra";
            this.lblCompra.Size = new System.Drawing.Size(121, 13);
            this.lblCompra.TabIndex = 8;
            this.lblCompra.Text = "Precio Prom. de Compra";
            // 
            // tbVenta
            // 
            this.tbVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbVenta.Location = new System.Drawing.Point(113, 17);
            this.tbVenta.Name = "tbVenta";
            this.tbVenta.Size = new System.Drawing.Size(101, 24);
            this.tbVenta.TabIndex = 1;
            this.tbVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblVenta
            // 
            this.lblVenta.AutoSize = true;
            this.lblVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVenta.Location = new System.Drawing.Point(2, 22);
            this.lblVenta.Name = "lblVenta";
            this.lblVenta.Size = new System.Drawing.Size(108, 13);
            this.lblVenta.TabIndex = 7;
            this.lblVenta.Text = "Precio Unit. de Venta";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.tbDescripcionF);
            this.groupBox1.Controls.Add(this.tbCodigoF);
            this.groupBox1.Controls.Add(this.lblBuscarF);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(6, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(451, 54);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Familia";
            // 
            // tbDescripcionF
            // 
            this.tbDescripcionF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDescripcionF.Location = new System.Drawing.Point(221, 18);
            this.tbDescripcionF.Name = "tbDescripcionF";
            this.tbDescripcionF.ReadOnly = true;
            this.tbDescripcionF.Size = new System.Drawing.Size(224, 22);
            this.tbDescripcionF.TabIndex = 3;
            this.tbDescripcionF.TabStop = false;
            this.tbDescripcionF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBuscarF
            // 
            this.lblBuscarF.AutoSize = true;
            this.lblBuscarF.Image = global::LunaSoft.Properties.Resources.magnifier;
            this.lblBuscarF.Location = new System.Drawing.Point(8, 21);
            this.lblBuscarF.Name = "lblBuscarF";
            this.lblBuscarF.Size = new System.Drawing.Size(24, 16);
            this.lblBuscarF.TabIndex = 1;
            this.lblBuscarF.Text = "    ";
            this.lblBuscarF.Click += new System.EventHandler(this.lblBuscarF_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.comboBox2);
            this.tabPage2.Controls.Add(this.tbCant2);
            this.tabPage2.Controls.Add(this.lblDeposito);
            this.tabPage2.Controls.Add(this.tbCant1);
            this.tabPage2.Controls.Add(this.comboBox1);
            this.tabPage2.Controls.Add(this.lblCantidadStock);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(632, 201);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Stock Inicial";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(103, 79);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(189, 26);
            this.comboBox2.TabIndex = 11;
            // 
            // tbCant2
            // 
            this.tbCant2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCant2.Location = new System.Drawing.Point(27, 78);
            this.tbCant2.Name = "tbCant2";
            this.tbCant2.Size = new System.Drawing.Size(55, 26);
            this.tbCant2.TabIndex = 10;
            this.tbCant2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbCant2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCant1_KeyPress);
            // 
            // lblDeposito
            // 
            this.lblDeposito.AutoSize = true;
            this.lblDeposito.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeposito.Location = new System.Drawing.Point(155, 16);
            this.lblDeposito.Name = "lblDeposito";
            this.lblDeposito.Size = new System.Drawing.Size(71, 16);
            this.lblDeposito.TabIndex = 2;
            this.lblDeposito.Text = "Depósito";
            // 
            // lblCantidadStock
            // 
            this.lblCantidadStock.AutoSize = true;
            this.lblCantidadStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadStock.Location = new System.Drawing.Point(18, 16);
            this.lblCantidadStock.Name = "lblCantidadStock";
            this.lblCantidadStock.Size = new System.Drawing.Size(70, 16);
            this.lblCantidadStock.TabIndex = 1;
            this.lblCantidadStock.Text = "Cantidad";
            // 
            // frmProductoAgregar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btSalir;
            this.ClientSize = new System.Drawing.Size(665, 336);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btRefrescar);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.btSalir);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "frmProductoAgregar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Artículos :: Agregar";
            this.Load += new System.EventHandler(this.frmProductoAgregar_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmProductoAgregar_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox tbCodigo;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.Button btSalir;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.Button btRefrescar;
        private System.Windows.Forms.ToolTip toolTipAgregar;
        private System.Windows.Forms.TextBox tbCant1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmbUnidad;
        private System.Windows.Forms.Label lblUnidad;
        private System.Windows.Forms.TextBox tbStock;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.RichTextBox tbObservacion;
        private System.Windows.Forms.Label lblObservacion;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbCompra;
        private System.Windows.Forms.Label lblCompra;
        private System.Windows.Forms.TextBox tbVenta;
        private System.Windows.Forms.Label lblVenta;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbDescripcionF;
        private System.Windows.Forms.TextBox tbCodigoF;
        private System.Windows.Forms.Label lblBuscarF;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblDeposito;
        private System.Windows.Forms.Label lblCantidadStock;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox tbCant2;
    }
}