namespace LunaSoft
{
    partial class frmFabricacionAgregar
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbDepositoMP = new System.Windows.Forms.ComboBox();
            this.tbNombreMP = new System.Windows.Forms.TextBox();
            this.tbExistente = new System.Windows.Forms.TextBox();
            this.tbCodigoMP = new System.Windows.Forms.TextBox();
            this.toolTipAgregar = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbDepositoF = new System.Windows.Forms.ComboBox();
            this.lblProducto = new System.Windows.Forms.Label();
            this.tbProductoF = new System.Windows.Forms.TextBox();
            this.lblDeposito = new System.Windows.Forms.Label();
            this.tbCodigoF = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.tbCantidadF = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_DEP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Deposito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btSalir = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.lblCodigoP = new System.Windows.Forms.Label();
            this.btAceptar = new System.Windows.Forms.Button();
            this.lblBuscarP = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbDepositoMP);
            this.groupBox1.Controls.Add(this.tbNombreMP);
            this.groupBox1.Controls.Add(this.tbExistente);
            this.groupBox1.Controls.Add(this.tbCodigoMP);
            this.groupBox1.Controls.Add(this.lblBuscarP);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(676, 51);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Materia Prima";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(430, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Depósito";
            // 
            // cbDepositoMP
            // 
            this.cbDepositoMP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDepositoMP.FormattingEnabled = true;
            this.cbDepositoMP.Location = new System.Drawing.Point(489, 17);
            this.cbDepositoMP.Name = "cbDepositoMP";
            this.cbDepositoMP.Size = new System.Drawing.Size(128, 23);
            this.cbDepositoMP.TabIndex = 2;
            this.cbDepositoMP.SelectedIndexChanged += new System.EventHandler(this.cbDepositoMP_SelectedIndexChanged);
            // 
            // tbNombreMP
            // 
            this.tbNombreMP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNombreMP.Location = new System.Drawing.Point(144, 18);
            this.tbNombreMP.Name = "tbNombreMP";
            this.tbNombreMP.ReadOnly = true;
            this.tbNombreMP.Size = new System.Drawing.Size(283, 22);
            this.tbNombreMP.TabIndex = 3;
            this.tbNombreMP.TabStop = false;
            // 
            // tbExistente
            // 
            this.tbExistente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbExistente.Location = new System.Drawing.Point(630, 15);
            this.tbExistente.Name = "tbExistente";
            this.tbExistente.ReadOnly = true;
            this.tbExistente.Size = new System.Drawing.Size(36, 26);
            this.tbExistente.TabIndex = 7;
            this.tbExistente.TabStop = false;
            this.tbExistente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbCodigoMP
            // 
            this.tbCodigoMP.Location = new System.Drawing.Point(29, 18);
            this.tbCodigoMP.Name = "tbCodigoMP";
            this.tbCodigoMP.Size = new System.Drawing.Size(109, 22);
            this.tbCodigoMP.TabIndex = 0;
            this.tbCodigoMP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTipAgregar.SetToolTip(this.tbCodigoMP, "F2 para insertar Producto");
            this.tbCodigoMP.Leave += new System.EventHandler(this.tbCodigoMP_Leave);
            this.tbCodigoMP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCodigoMP_KeyPress);
            this.tbCodigoMP.Enter += new System.EventHandler(this.tbCodigoMP_Enter);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbDepositoF);
            this.groupBox3.Controls.Add(this.lblProducto);
            this.groupBox3.Controls.Add(this.tbProductoF);
            this.groupBox3.Controls.Add(this.lblDeposito);
            this.groupBox3.Controls.Add(this.btAdd);
            this.groupBox3.Controls.Add(this.lblCodigoP);
            this.groupBox3.Controls.Add(this.tbCodigoF);
            this.groupBox3.Controls.Add(this.lblCodigo);
            this.groupBox3.Controls.Add(this.tbCantidadF);
            this.groupBox3.Controls.Add(this.lblCantidad);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(13, 69);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(675, 67);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Producto a Fabricar";
            // 
            // cbDepositoF
            // 
            this.cbDepositoF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDepositoF.FormattingEnabled = true;
            this.cbDepositoF.Location = new System.Drawing.Point(472, 36);
            this.cbDepositoF.Name = "cbDepositoF";
            this.cbDepositoF.Size = new System.Drawing.Size(153, 23);
            this.cbDepositoF.TabIndex = 2;
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProducto.Location = new System.Drawing.Point(291, 18);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(56, 15);
            this.lblProducto.TabIndex = 10;
            this.lblProducto.Text = "Producto";
            // 
            // tbProductoF
            // 
            this.tbProductoF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbProductoF.Location = new System.Drawing.Point(165, 36);
            this.tbProductoF.Name = "tbProductoF";
            this.tbProductoF.ReadOnly = true;
            this.tbProductoF.Size = new System.Drawing.Size(301, 22);
            this.tbProductoF.TabIndex = 9;
            this.tbProductoF.TabStop = false;
            // 
            // lblDeposito
            // 
            this.lblDeposito.AutoSize = true;
            this.lblDeposito.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeposito.Location = new System.Drawing.Point(527, 18);
            this.lblDeposito.Name = "lblDeposito";
            this.lblDeposito.Size = new System.Drawing.Size(56, 15);
            this.lblDeposito.TabIndex = 8;
            this.lblDeposito.Text = "Depósito";
            // 
            // tbCodigoF
            // 
            this.tbCodigoF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCodigoF.Location = new System.Drawing.Point(66, 36);
            this.tbCodigoF.Name = "tbCodigoF";
            this.tbCodigoF.Size = new System.Drawing.Size(93, 22);
            this.tbCodigoF.TabIndex = 1;
            this.tbCodigoF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbCodigoF.Leave += new System.EventHandler(this.tbCodigoF_Leave);
            this.tbCodigoF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCodigoF_KeyPress);
            this.tbCodigoF.Enter += new System.EventHandler(this.tbCodigoF_Enter);
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.Location = new System.Drawing.Point(85, 18);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(46, 15);
            this.lblCodigo.TabIndex = 2;
            this.lblCodigo.Text = "Código";
            // 
            // tbCantidadF
            // 
            this.tbCantidadF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCantidadF.Location = new System.Drawing.Point(21, 36);
            this.tbCantidadF.Name = "tbCantidadF";
            this.tbCantidadF.Size = new System.Drawing.Size(30, 22);
            this.tbCantidadF.TabIndex = 0;
            this.tbCantidadF.Text = "1";
            this.tbCantidadF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbCantidadF.Leave += new System.EventHandler(this.tbCantidadF_Leave);
            this.tbCantidadF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCantidadF_KeyPress);
            this.tbCantidadF.Enter += new System.EventHandler(this.tbCantidadF_Enter);
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(8, 18);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(56, 15);
            this.lblCantidad.TabIndex = 0;
            this.lblCantidad.Text = "Cantidad";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ID_DEP,
            this.Cant,
            this.producto,
            this.Deposito});
            this.dataGridView1.Location = new System.Drawing.Point(12, 142);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Size = new System.Drawing.Size(675, 158);
            this.dataGridView1.TabIndex = 17;
            // 
            // ID
            // 
            this.ID.Frozen = true;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // ID_DEP
            // 
            this.ID_DEP.Frozen = true;
            this.ID_DEP.HeaderText = "ID_DEP";
            this.ID_DEP.Name = "ID_DEP";
            this.ID_DEP.ReadOnly = true;
            this.ID_DEP.Visible = false;
            // 
            // Cant
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Cant.DefaultCellStyle = dataGridViewCellStyle3;
            this.Cant.Frozen = true;
            this.Cant.HeaderText = "Cant";
            this.Cant.Name = "Cant";
            this.Cant.ToolTipText = "Cantidad";
            this.Cant.Width = 38;
            // 
            // producto
            // 
            this.producto.Frozen = true;
            this.producto.HeaderText = "Producto";
            this.producto.Name = "producto";
            this.producto.ReadOnly = true;
            this.producto.ToolTipText = "Descripción Producto";
            this.producto.Width = 300;
            // 
            // Deposito
            // 
            this.Deposito.Frozen = true;
            this.Deposito.HeaderText = "Deposito";
            this.Deposito.Name = "Deposito";
            this.Deposito.ReadOnly = true;
            this.Deposito.ToolTipText = "Depósito";
            // 
            // btSalir
            // 
            this.btSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btSalir.Image = global::LunaSoft.Properties.Resources.cancel;
            this.btSalir.Location = new System.Drawing.Point(662, 315);
            this.btSalir.Name = "btSalir";
            this.btSalir.Size = new System.Drawing.Size(26, 26);
            this.btSalir.TabIndex = 7;
            this.btSalir.TabStop = false;
            this.toolTipAgregar.SetToolTip(this.btSalir, "Cerrar formulario (ESC)");
            this.btSalir.UseVisualStyleBackColor = true;
            this.btSalir.Click += new System.EventHandler(this.btSalir_Click);
            // 
            // btAdd
            // 
            this.btAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btAdd.Image = global::LunaSoft.Properties.Resources.add;
            this.btAdd.Location = new System.Drawing.Point(643, 36);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(24, 24);
            this.btAdd.TabIndex = 4;
            this.toolTipAgregar.SetToolTip(this.btAdd, "Guardar y cerrar formulario (F10)");
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // lblCodigoP
            // 
            this.lblCodigoP.AutoSize = true;
            this.lblCodigoP.Image = global::LunaSoft.Properties.Resources.magnifier;
            this.lblCodigoP.Location = new System.Drawing.Point(128, 19);
            this.lblCodigoP.Name = "lblCodigoP";
            this.lblCodigoP.Size = new System.Drawing.Size(20, 16);
            this.lblCodigoP.TabIndex = 4;
            this.lblCodigoP.Text = "    ";
            this.lblCodigoP.Click += new System.EventHandler(this.lblCodigoP_Click);
            // 
            // btAceptar
            // 
            this.btAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btAceptar.Image = global::LunaSoft.Properties.Resources.accept;
            this.btAceptar.Location = new System.Drawing.Point(634, 315);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(26, 26);
            this.btAceptar.TabIndex = 8;
            this.btAceptar.TabStop = false;
            this.toolTipAgregar.SetToolTip(this.btAceptar, "Guardar y cerrar formulario (F10)");
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // lblBuscarP
            // 
            this.lblBuscarP.AutoSize = true;
            this.lblBuscarP.Image = global::LunaSoft.Properties.Resources.magnifier;
            this.lblBuscarP.Location = new System.Drawing.Point(5, 21);
            this.lblBuscarP.Name = "lblBuscarP";
            this.lblBuscarP.Size = new System.Drawing.Size(20, 16);
            this.lblBuscarP.TabIndex = 1;
            this.lblBuscarP.Text = "    ";
            this.lblBuscarP.Click += new System.EventHandler(this.lblBuscarP_Click);
            // 
            // frmFabricacionAgregar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btSalir;
            this.ClientSize = new System.Drawing.Size(699, 347);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.btSalir);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmFabricacionAgregar";
            this.Text = "Fabricación de Productos :: Agregar";
            this.Load += new System.EventHandler(this.frmFabricacionAgregar_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmFabricacionAgregar_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbNombreMP;
        private System.Windows.Forms.TextBox tbCodigoMP;
        private System.Windows.Forms.Label lblBuscarP;
        private System.Windows.Forms.ToolTip toolTipAgregar;
        private System.Windows.Forms.ComboBox cbDepositoMP;
        private System.Windows.Forms.TextBox tbExistente;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.Button btSalir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbDepositoF;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.TextBox tbProductoF;
        private System.Windows.Forms.Label lblDeposito;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Label lblCodigoP;
        private System.Windows.Forms.TextBox tbCodigoF;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox tbCantidadF;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_DEP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cant;
        private System.Windows.Forms.DataGridViewTextBoxColumn producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Deposito;
    }
}