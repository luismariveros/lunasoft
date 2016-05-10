namespace LunaSoft
{
    partial class frmProductoModificar
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
            this.toolTipModificar = new System.Windows.Forms.ToolTip(this.components);
            this.btSalir = new System.Windows.Forms.Button();
            this.btAceptar = new System.Windows.Forms.Button();
            this.btSiguiente = new System.Windows.Forms.Button();
            this.btUltimo = new System.Windows.Forms.Button();
            this.btPrimero = new System.Windows.Forms.Button();
            this.btAnterior = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbDescripcionF = new System.Windows.Forms.TextBox();
            this.tbCodigoF = new System.Windows.Forms.TextBox();
            this.lblBuscarF = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbCompra = new System.Windows.Forms.TextBox();
            this.lblCompra = new System.Windows.Forms.Label();
            this.tbVenta = new System.Windows.Forms.TextBox();
            this.lblVenta = new System.Windows.Forms.Label();
            this.tbStock = new System.Windows.Forms.TextBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblUnidad = new System.Windows.Forms.Label();
            this.cmbUnidad = new System.Windows.Forms.ComboBox();
            this.lblObservacion = new System.Windows.Forms.Label();
            this.tbObservacion = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(616, 44);
            this.panel1.TabIndex = 0;
            // 
            // tbNombre
            // 
            this.tbNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNombre.Location = new System.Drawing.Point(302, 11);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(302, 20);
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
            this.tbCodigo.TabStop = false;
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
            // btSalir
            // 
            this.btSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btSalir.Image = global::LunaSoft.Properties.Resources.cancel;
            this.btSalir.Location = new System.Drawing.Point(601, 275);
            this.btSalir.Name = "btSalir";
            this.btSalir.Size = new System.Drawing.Size(26, 26);
            this.btSalir.TabIndex = 1;
            this.btSalir.TabStop = false;
            this.toolTipModificar.SetToolTip(this.btSalir, "Cerrar formulario (ESC)");
            this.btSalir.UseVisualStyleBackColor = true;
            this.btSalir.Click += new System.EventHandler(this.btSalir_Click);
            // 
            // btAceptar
            // 
            this.btAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btAceptar.Image = global::LunaSoft.Properties.Resources.accept;
            this.btAceptar.Location = new System.Drawing.Point(573, 275);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(26, 26);
            this.btAceptar.TabIndex = 2;
            this.btAceptar.TabStop = false;
            this.toolTipModificar.SetToolTip(this.btAceptar, "Guardar y cerrar formulario (F10)");
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // btSiguiente
            // 
            this.btSiguiente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btSiguiente.Image = global::LunaSoft.Properties.Resources.resultset_next;
            this.btSiguiente.Location = new System.Drawing.Point(516, 275);
            this.btSiguiente.Name = "btSiguiente";
            this.btSiguiente.Size = new System.Drawing.Size(26, 26);
            this.btSiguiente.TabIndex = 11;
            this.btSiguiente.TabStop = false;
            this.toolTipModificar.SetToolTip(this.btSiguiente, "Siguiente registro (F7)");
            this.btSiguiente.UseVisualStyleBackColor = true;
            this.btSiguiente.Click += new System.EventHandler(this.btSiguiente_Click);
            // 
            // btUltimo
            // 
            this.btUltimo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btUltimo.Image = global::LunaSoft.Properties.Resources.resultset_last;
            this.btUltimo.Location = new System.Drawing.Point(544, 275);
            this.btUltimo.Name = "btUltimo";
            this.btUltimo.Size = new System.Drawing.Size(26, 26);
            this.btUltimo.TabIndex = 10;
            this.btUltimo.TabStop = false;
            this.toolTipModificar.SetToolTip(this.btUltimo, "Ir al último registro (F8)");
            this.btUltimo.UseVisualStyleBackColor = true;
            this.btUltimo.Click += new System.EventHandler(this.btUltimo_Click);
            // 
            // btPrimero
            // 
            this.btPrimero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btPrimero.Image = global::LunaSoft.Properties.Resources.resultset_first;
            this.btPrimero.Location = new System.Drawing.Point(460, 275);
            this.btPrimero.Name = "btPrimero";
            this.btPrimero.Size = new System.Drawing.Size(26, 26);
            this.btPrimero.TabIndex = 9;
            this.btPrimero.TabStop = false;
            this.toolTipModificar.SetToolTip(this.btPrimero, "Ir al primer registro (F5)");
            this.btPrimero.UseVisualStyleBackColor = true;
            this.btPrimero.Click += new System.EventHandler(this.btPrimero_Click);
            // 
            // btAnterior
            // 
            this.btAnterior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btAnterior.Image = global::LunaSoft.Properties.Resources.resultset_previous;
            this.btAnterior.Location = new System.Drawing.Point(488, 275);
            this.btAnterior.Name = "btAnterior";
            this.btAnterior.Size = new System.Drawing.Size(26, 26);
            this.btAnterior.TabIndex = 8;
            this.btAnterior.TabStop = false;
            this.toolTipModificar.SetToolTip(this.btAnterior, "Anterior registro (F6)");
            this.btAnterior.UseVisualStyleBackColor = true;
            this.btAnterior.Click += new System.EventHandler(this.btAnterior_Click);
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
            this.groupBox1.Location = new System.Drawing.Point(12, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(451, 54);
            this.groupBox1.TabIndex = 1;
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
            // tbCodigoF
            // 
            this.tbCodigoF.Location = new System.Drawing.Point(29, 18);
            this.tbCodigoF.Name = "tbCodigoF";
            this.tbCodigoF.Size = new System.Drawing.Size(179, 22);
            this.tbCodigoF.TabIndex = 2;
            this.tbCodigoF.Leave += new System.EventHandler(this.tbCodigoF_Leave);
            this.tbCodigoF.Enter += new System.EventHandler(this.tbCodigoF_Enter);
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
            this.groupBox2.Location = new System.Drawing.Point(12, 133);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(451, 53);
            this.groupBox2.TabIndex = 2;
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
            this.tbVenta.Location = new System.Drawing.Point(111, 17);
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
            // tbStock
            // 
            this.tbStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbStock.Location = new System.Drawing.Point(85, 76);
            this.tbStock.Name = "tbStock";
            this.tbStock.Size = new System.Drawing.Size(63, 24);
            this.tbStock.TabIndex = 2;
            this.tbStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            // lblUnidad
            // 
            this.lblUnidad.AutoSize = true;
            this.lblUnidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnidad.Location = new System.Drawing.Point(6, 22);
            this.lblUnidad.Name = "lblUnidad";
            this.lblUnidad.Size = new System.Drawing.Size(94, 13);
            this.lblUnidad.TabIndex = 5;
            this.lblUnidad.Text = "Unidad de Medida";
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
            // lblObservacion
            // 
            this.lblObservacion.AutoSize = true;
            this.lblObservacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObservacion.Location = new System.Drawing.Point(14, 223);
            this.lblObservacion.Name = "lblObservacion";
            this.lblObservacion.Size = new System.Drawing.Size(67, 13);
            this.lblObservacion.TabIndex = 6;
            this.lblObservacion.Text = "Observación";
            // 
            // tbObservacion
            // 
            this.tbObservacion.Location = new System.Drawing.Point(91, 196);
            this.tbObservacion.Name = "tbObservacion";
            this.tbObservacion.Size = new System.Drawing.Size(537, 71);
            this.tbObservacion.TabIndex = 7;
            this.tbObservacion.Text = "";
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
            this.groupBox3.Location = new System.Drawing.Point(469, 74);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(159, 112);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos";
            // 
            // frmProductoModificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btSalir;
            this.ClientSize = new System.Drawing.Size(640, 310);
            this.Controls.Add(this.btSiguiente);
            this.Controls.Add(this.btUltimo);
            this.Controls.Add(this.btPrimero);
            this.Controls.Add(this.btAnterior);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.tbObservacion);
            this.Controls.Add(this.lblObservacion);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.btSalir);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "frmProductoModificar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Artículos :: Modificar";
            this.Load += new System.EventHandler(this.frmProductoModificar_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmProductoModificar_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox tbCodigo;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.Button btSalir;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.ToolTip toolTipModificar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblBuscarF;
        private System.Windows.Forms.TextBox tbDescripcionF;
        private System.Windows.Forms.TextBox tbCodigoF;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbStock;
        private System.Windows.Forms.Label lblUnidad;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.ComboBox cmbUnidad;
        private System.Windows.Forms.Label lblObservacion;
        private System.Windows.Forms.RichTextBox tbObservacion;
        private System.Windows.Forms.Label lblVenta;
        private System.Windows.Forms.TextBox tbVenta;
        private System.Windows.Forms.Label lblCompra;
        private System.Windows.Forms.TextBox tbCompra;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btSiguiente;
        private System.Windows.Forms.Button btUltimo;
        private System.Windows.Forms.Button btPrimero;
        private System.Windows.Forms.Button btAnterior;
    }
}