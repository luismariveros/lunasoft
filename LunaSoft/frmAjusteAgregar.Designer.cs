namespace LunaSoft
{
    partial class frmAjusteAgregar
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbNombreP = new System.Windows.Forms.TextBox();
            this.tbCodigoP = new System.Windows.Forms.TextBox();
            this.lblBuscarP = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblExistente = new System.Windows.Forms.Label();
            this.btAdd = new System.Windows.Forms.Button();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblCantAjuste = new System.Windows.Forms.Label();
            this.cbDeposito = new System.Windows.Forms.ComboBox();
            this.tbCantAjuste = new System.Windows.Forms.TextBox();
            this.toolTipAgregar = new System.Windows.Forms.ToolTip(this.components);
            this.btSalir = new System.Windows.Forms.Button();
            this.btAceptar = new System.Windows.Forms.Button();
            this.btRefrescar = new System.Windows.Forms.Button();
            this.btLimpiar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbMotivo = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.tbNombreP);
            this.groupBox1.Controls.Add(this.tbCodigoP);
            this.groupBox1.Controls.Add(this.lblBuscarP);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(574, 58);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Producto";
            // 
            // tbNombreP
            // 
            this.tbNombreP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNombreP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNombreP.Location = new System.Drawing.Point(147, 19);
            this.tbNombreP.Name = "tbNombreP";
            this.tbNombreP.ReadOnly = true;
            this.tbNombreP.Size = new System.Drawing.Size(421, 26);
            this.tbNombreP.TabIndex = 3;
            this.tbNombreP.TabStop = false;
            // 
            // tbCodigoP
            // 
            this.tbCodigoP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCodigoP.Location = new System.Drawing.Point(29, 19);
            this.tbCodigoP.Name = "tbCodigoP";
            this.tbCodigoP.Size = new System.Drawing.Size(112, 26);
            this.tbCodigoP.TabIndex = 0;
            this.toolTipAgregar.SetToolTip(this.tbCodigoP, "F2 para insertar Producto");
            this.tbCodigoP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCodigoP_KeyPress);
            // 
            // lblBuscarP
            // 
            this.lblBuscarP.AutoSize = true;
            this.lblBuscarP.Image = global::LunaSoft.Properties.Resources.magnifier;
            this.lblBuscarP.Location = new System.Drawing.Point(5, 21);
            this.lblBuscarP.Name = "lblBuscarP";
            this.lblBuscarP.Size = new System.Drawing.Size(25, 20);
            this.lblBuscarP.TabIndex = 1;
            this.lblBuscarP.Text = "    ";
            this.lblBuscarP.Click += new System.EventHandler(this.lblBuscarP_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Controls.Add(this.lblExistente);
            this.groupBox2.Controls.Add(this.btAdd);
            this.groupBox2.Controls.Add(this.cbTipo);
            this.groupBox2.Controls.Add(this.lblTipo);
            this.groupBox2.Controls.Add(this.lblCantAjuste);
            this.groupBox2.Controls.Add(this.cbDeposito);
            this.groupBox2.Controls.Add(this.tbCantAjuste);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox2.Location = new System.Drawing.Point(12, 84);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(574, 174);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Depósito";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridView1.Location = new System.Drawing.Point(9, 25);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(229, 137);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 17;
            // 
            // lblExistente
            // 
            this.lblExistente.AutoSize = true;
            this.lblExistente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExistente.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblExistente.Location = new System.Drawing.Point(244, 29);
            this.lblExistente.Name = "lblExistente";
            this.lblExistente.Size = new System.Drawing.Size(73, 20);
            this.lblExistente.TabIndex = 6;
            this.lblExistente.Text = "Depósito";
            // 
            // btAdd
            // 
            this.btAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btAdd.Image = global::LunaSoft.Properties.Resources.add;
            this.btAdd.Location = new System.Drawing.Point(542, 70);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(24, 24);
            this.btAdd.TabIndex = 16;
            this.toolTipAgregar.SetToolTip(this.btAdd, "Guardar y cerrar formulario (F10)");
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // cbTipo
            // 
            this.cbTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Location = new System.Drawing.Point(329, 71);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(207, 24);
            this.cbTipo.TabIndex = 4;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTipo.Location = new System.Drawing.Point(242, 72);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(88, 20);
            this.lblTipo.TabIndex = 15;
            this.lblTipo.Text = "Tipo Ajuste";
            // 
            // lblCantAjuste
            // 
            this.lblCantAjuste.AutoSize = true;
            this.lblCantAjuste.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantAjuste.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCantAjuste.Location = new System.Drawing.Point(391, 114);
            this.lblCantAjuste.Name = "lblCantAjuste";
            this.lblCantAjuste.Size = new System.Drawing.Size(122, 20);
            this.lblCantAjuste.TabIndex = 11;
            this.lblCantAjuste.Text = "Cantidad Ajuste";
            // 
            // cbDeposito
            // 
            this.cbDeposito.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDeposito.FormattingEnabled = true;
            this.cbDeposito.Location = new System.Drawing.Point(329, 28);
            this.cbDeposito.Name = "cbDeposito";
            this.cbDeposito.Size = new System.Drawing.Size(207, 24);
            this.cbDeposito.TabIndex = 2;
            this.cbDeposito.SelectedIndexChanged += new System.EventHandler(this.cbDeposito_SelectedIndexChanged);
            // 
            // tbCantAjuste
            // 
            this.tbCantAjuste.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCantAjuste.Location = new System.Drawing.Point(516, 111);
            this.tbCantAjuste.Name = "tbCantAjuste";
            this.tbCantAjuste.Size = new System.Drawing.Size(50, 26);
            this.tbCantAjuste.TabIndex = 3;
            this.tbCantAjuste.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbCantAjuste.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCantAjuste_KeyPress);
            // 
            // btSalir
            // 
            this.btSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btSalir.Image = global::LunaSoft.Properties.Resources.cancel;
            this.btSalir.Location = new System.Drawing.Point(560, 357);
            this.btSalir.Name = "btSalir";
            this.btSalir.Size = new System.Drawing.Size(26, 26);
            this.btSalir.TabIndex = 7;
            this.btSalir.TabStop = false;
            this.toolTipAgregar.SetToolTip(this.btSalir, "Cerrar formulario (ESC)");
            this.btSalir.UseVisualStyleBackColor = true;
            this.btSalir.Click += new System.EventHandler(this.btSalir_Click);
            // 
            // btAceptar
            // 
            this.btAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btAceptar.Image = global::LunaSoft.Properties.Resources.accept;
            this.btAceptar.Location = new System.Drawing.Point(532, 357);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(26, 26);
            this.btAceptar.TabIndex = 8;
            this.btAceptar.TabStop = false;
            this.toolTipAgregar.SetToolTip(this.btAceptar, "Guardar y cerrar formulario (F10)");
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // btRefrescar
            // 
            this.btRefrescar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btRefrescar.Image = global::LunaSoft.Properties.Resources.arrow_refresh;
            this.btRefrescar.Location = new System.Drawing.Point(503, 357);
            this.btRefrescar.Name = "btRefrescar";
            this.btRefrescar.Size = new System.Drawing.Size(26, 26);
            this.btRefrescar.TabIndex = 17;
            this.btRefrescar.TabStop = false;
            this.toolTipAgregar.SetToolTip(this.btRefrescar, "Guardar y agregar nuevo registro (F9)");
            this.btRefrescar.UseVisualStyleBackColor = true;
            this.btRefrescar.Click += new System.EventHandler(this.btRefrescar_Click);
            // 
            // btLimpiar
            // 
            this.btLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btLimpiar.Image = global::LunaSoft.Properties.Resources.edit_clear;
            this.btLimpiar.Location = new System.Drawing.Point(471, 357);
            this.btLimpiar.Name = "btLimpiar";
            this.btLimpiar.Size = new System.Drawing.Size(26, 26);
            this.btLimpiar.TabIndex = 18;
            this.btLimpiar.TabStop = false;
            this.toolTipAgregar.SetToolTip(this.btLimpiar, "Limpiar formulario (F8)");
            this.btLimpiar.UseVisualStyleBackColor = true;
            this.btLimpiar.Click += new System.EventHandler(this.btLimpiar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 299);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Motivo";
            // 
            // tbMotivo
            // 
            this.tbMotivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMotivo.Location = new System.Drawing.Point(76, 276);
            this.tbMotivo.Name = "tbMotivo";
            this.tbMotivo.Size = new System.Drawing.Size(510, 72);
            this.tbMotivo.TabIndex = 14;
            this.tbMotivo.Text = "";
            // 
            // frmAjusteAgregar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btSalir;
            this.ClientSize = new System.Drawing.Size(598, 391);
            this.Controls.Add(this.btLimpiar);
            this.Controls.Add(this.btRefrescar);
            this.Controls.Add(this.tbMotivo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.btSalir);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmAjusteAgregar";
            this.Text = "Stock :: Ajustes";
            this.Load += new System.EventHandler(this.frmAjusteAgregar_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAjusteAgregar_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbNombreP;
        private System.Windows.Forms.TextBox tbCodigoP;
        private System.Windows.Forms.Label lblBuscarP;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolTip toolTipAgregar;
        private System.Windows.Forms.ComboBox cbDeposito;
        private System.Windows.Forms.Label lblExistente;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.Button btSalir;
        private System.Windows.Forms.Label lblCantAjuste;
        private System.Windows.Forms.TextBox tbCantAjuste;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox tbMotivo;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btRefrescar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btLimpiar;
    }
}