namespace LunaSoft
{
    partial class frmTransferencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTransferencia));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbNombreP = new System.Windows.Forms.TextBox();
            this.tbCodigoP = new System.Windows.Forms.TextBox();
            this.lblBuscarF = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbOrigen = new System.Windows.Forms.ComboBox();
            this.lblExistente = new System.Windows.Forms.Label();
            this.tbExistente = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblTransferir = new System.Windows.Forms.Label();
            this.tbCantidad = new System.Windows.Forms.TextBox();
            this.cbDestino = new System.Windows.Forms.ComboBox();
            this.toolTipAgregar = new System.Windows.Forms.ToolTip(this.components);
            this.btSalir = new System.Windows.Forms.Button();
            this.btAceptar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.tbNombreP);
            this.groupBox1.Controls.Add(this.tbCodigoP);
            this.groupBox1.Controls.Add(this.lblBuscarF);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(398, 49);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Producto";
            // 
            // tbNombreP
            // 
            this.tbNombreP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNombreP.Location = new System.Drawing.Point(144, 18);
            this.tbNombreP.Name = "tbNombreP";
            this.tbNombreP.ReadOnly = true;
            this.tbNombreP.Size = new System.Drawing.Size(248, 22);
            this.tbNombreP.TabIndex = 3;
            this.tbNombreP.TabStop = false;
            // 
            // tbCodigoP
            // 
            this.tbCodigoP.Location = new System.Drawing.Point(29, 18);
            this.tbCodigoP.Name = "tbCodigoP";
            this.tbCodigoP.Size = new System.Drawing.Size(109, 22);
            this.tbCodigoP.TabIndex = 0;
            this.toolTipAgregar.SetToolTip(this.tbCodigoP, "F2 para insertar Producto");
            this.tbCodigoP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCodigoP_KeyPress);
            // 
            // lblBuscarF
            // 
            this.lblBuscarF.AutoSize = true;
            this.lblBuscarF.Image = ((System.Drawing.Image)(resources.GetObject("lblBuscarF.Image")));
            this.lblBuscarF.Location = new System.Drawing.Point(5, 21);
            this.lblBuscarF.Name = "lblBuscarF";
            this.lblBuscarF.Size = new System.Drawing.Size(20, 16);
            this.lblBuscarF.TabIndex = 1;
            this.lblBuscarF.Text = "    ";
            this.lblBuscarF.Click += new System.EventHandler(this.lblBuscarF_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.cbOrigen);
            this.groupBox2.Controls.Add(this.lblExistente);
            this.groupBox2.Controls.Add(this.tbExistente);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox2.Location = new System.Drawing.Point(12, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(190, 96);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Depósito Origen";
            // 
            // cbOrigen
            // 
            this.cbOrigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbOrigen.FormattingEnabled = true;
            this.cbOrigen.Location = new System.Drawing.Point(8, 20);
            this.cbOrigen.Name = "cbOrigen";
            this.cbOrigen.Size = new System.Drawing.Size(174, 23);
            this.cbOrigen.TabIndex = 60;
            this.cbOrigen.SelectedIndexChanged += new System.EventHandler(this.cbOrigen_SelectedIndexChanged);
            // 
            // lblExistente
            // 
            this.lblExistente.AutoSize = true;
            this.lblExistente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExistente.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblExistente.Location = new System.Drawing.Point(5, 60);
            this.lblExistente.Name = "lblExistente";
            this.lblExistente.Size = new System.Drawing.Size(137, 16);
            this.lblExistente.TabIndex = 6;
            this.lblExistente.Text = "Cantidad Existente";
            // 
            // tbExistente
            // 
            this.tbExistente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbExistente.Location = new System.Drawing.Point(144, 54);
            this.tbExistente.Name = "tbExistente";
            this.tbExistente.ReadOnly = true;
            this.tbExistente.Size = new System.Drawing.Size(36, 26);
            this.tbExistente.TabIndex = 7;
            this.tbExistente.TabStop = false;
            this.tbExistente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Controls.Add(this.lblTransferir);
            this.groupBox3.Controls.Add(this.tbCantidad);
            this.groupBox3.Controls.Add(this.cbDestino);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox3.Location = new System.Drawing.Point(220, 75);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(190, 96);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Depósito Destino";
            // 
            // lblTransferir
            // 
            this.lblTransferir.AutoSize = true;
            this.lblTransferir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransferir.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTransferir.Location = new System.Drawing.Point(61, 60);
            this.lblTransferir.Name = "lblTransferir";
            this.lblTransferir.Size = new System.Drawing.Size(75, 16);
            this.lblTransferir.TabIndex = 8;
            this.lblTransferir.Text = "Transferir";
            // 
            // tbCantidad
            // 
            this.tbCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCantidad.Location = new System.Drawing.Point(142, 54);
            this.tbCantidad.Name = "tbCantidad";
            this.tbCantidad.Size = new System.Drawing.Size(36, 26);
            this.tbCantidad.TabIndex = 9;
            this.tbCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCantidad_KeyPress);
            // 
            // cbDestino
            // 
            this.cbDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDestino.FormattingEnabled = true;
            this.cbDestino.Location = new System.Drawing.Point(8, 20);
            this.cbDestino.Name = "cbDestino";
            this.cbDestino.Size = new System.Drawing.Size(170, 23);
            this.cbDestino.TabIndex = 1;
            this.cbDestino.SelectedIndexChanged += new System.EventHandler(this.cbDestino_SelectedIndexChanged);
            // 
            // btSalir
            // 
            this.btSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btSalir.Image = ((System.Drawing.Image)(resources.GetObject("btSalir.Image")));
            this.btSalir.Location = new System.Drawing.Point(384, 190);
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
            this.btAceptar.Location = new System.Drawing.Point(356, 190);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(26, 26);
            this.btAceptar.TabIndex = 8;
            this.btAceptar.TabStop = false;
            this.toolTipAgregar.SetToolTip(this.btAceptar, "Guardar y cerrar formulario (F10)");
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // frmTransferencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btSalir;
            this.ClientSize = new System.Drawing.Size(423, 228);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.btSalir);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.Name = "frmTransferencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock :: Transferencia";
            this.Load += new System.EventHandler(this.frmTransferencia_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTransferencia_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbNombreP;
        private System.Windows.Forms.TextBox tbCodigoP;
        private System.Windows.Forms.Label lblBuscarF;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolTip toolTipAgregar;
        private System.Windows.Forms.ComboBox cbOrigen;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbDestino;
        private System.Windows.Forms.Label lblExistente;
        private System.Windows.Forms.TextBox tbExistente;
        private System.Windows.Forms.Label lblTransferir;
        private System.Windows.Forms.TextBox tbCantidad;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.Button btSalir;
    }
}