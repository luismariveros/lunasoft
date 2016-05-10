namespace LunaSoft
{
    partial class frmClienteModificar
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
            this.tbCedula = new System.Windows.Forms.TextBox();
            this.lblCedula = new System.Windows.Forms.Label();
            this.toolTipModificar = new System.Windows.Forms.ToolTip(this.components);
            this.btSalir = new System.Windows.Forms.Button();
            this.btSiguiente = new System.Windows.Forms.Button();
            this.btUltimo = new System.Windows.Forms.Button();
            this.btPrimero = new System.Windows.Forms.Button();
            this.btAnterior = new System.Windows.Forms.Button();
            this.btAceptar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbContacto = new System.Windows.Forms.TextBox();
            this.lblContacto = new System.Windows.Forms.Label();
            this.tbMail = new System.Windows.Forms.TextBox();
            this.lblMail = new System.Windows.Forms.Label();
            this.tbCelular = new System.Windows.Forms.TextBox();
            this.lblCelular = new System.Windows.Forms.Label();
            this.tbTelefono = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.tbDireccion = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tbNombre);
            this.panel1.Controls.Add(this.lblNombre);
            this.panel1.Controls.Add(this.tbCedula);
            this.panel1.Controls.Add(this.lblCedula);
            this.panel1.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(12, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(582, 44);
            this.panel1.TabIndex = 1;
            // 
            // tbNombre
            // 
            this.tbNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNombre.Location = new System.Drawing.Point(267, 7);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(302, 24);
            this.tbNombre.TabIndex = 0;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(211, 14);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(50, 13);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre";
            // 
            // tbCedula
            // 
            this.tbCedula.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbCedula.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCedula.Location = new System.Drawing.Point(90, 7);
            this.tbCedula.Name = "tbCedula";
            this.tbCedula.ReadOnly = true;
            this.tbCedula.Size = new System.Drawing.Size(115, 24);
            this.tbCedula.TabIndex = 0;
            this.tbCedula.TabStop = false;
            // 
            // lblCedula
            // 
            this.lblCedula.AutoSize = true;
            this.lblCedula.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCedula.Location = new System.Drawing.Point(3, 14);
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Size = new System.Drawing.Size(84, 13);
            this.lblCedula.TabIndex = 0;
            this.lblCedula.Text = "Cédula - RUC";
            // 
            // btSalir
            // 
            this.btSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btSalir.Image = global::LunaSoft.Properties.Resources.cancel;
            this.btSalir.Location = new System.Drawing.Point(567, 196);
            this.btSalir.Name = "btSalir";
            this.btSalir.Size = new System.Drawing.Size(26, 26);
            this.btSalir.TabIndex = 4;
            this.btSalir.TabStop = false;
            this.toolTipModificar.SetToolTip(this.btSalir, "Cerrar formulario (ESC)");
            this.btSalir.UseVisualStyleBackColor = true;
            this.btSalir.Click += new System.EventHandler(this.btSalir_Click);
            // 
            // btSiguiente
            // 
            this.btSiguiente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btSiguiente.Image = global::LunaSoft.Properties.Resources.resultset_next;
            this.btSiguiente.Location = new System.Drawing.Point(482, 196);
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
            this.btUltimo.Location = new System.Drawing.Point(510, 196);
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
            this.btPrimero.Location = new System.Drawing.Point(426, 196);
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
            this.btAnterior.Location = new System.Drawing.Point(454, 196);
            this.btAnterior.Name = "btAnterior";
            this.btAnterior.Size = new System.Drawing.Size(26, 26);
            this.btAnterior.TabIndex = 8;
            this.btAnterior.TabStop = false;
            this.toolTipModificar.SetToolTip(this.btAnterior, "Anterior registro (F6)");
            this.btAnterior.UseVisualStyleBackColor = true;
            this.btAnterior.Click += new System.EventHandler(this.btAnterior_Click);
            // 
            // btAceptar
            // 
            this.btAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btAceptar.Image = global::LunaSoft.Properties.Resources.accept;
            this.btAceptar.Location = new System.Drawing.Point(539, 196);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(26, 26);
            this.btAceptar.TabIndex = 5;
            this.btAceptar.TabStop = false;
            this.toolTipModificar.SetToolTip(this.btAceptar, "Guardar y cerrar formulario (F10)");
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.tbContacto);
            this.groupBox2.Controls.Add(this.lblContacto);
            this.groupBox2.Controls.Add(this.tbMail);
            this.groupBox2.Controls.Add(this.lblMail);
            this.groupBox2.Controls.Add(this.tbCelular);
            this.groupBox2.Controls.Add(this.lblCelular);
            this.groupBox2.Controls.Add(this.tbTelefono);
            this.groupBox2.Controls.Add(this.lblTelefono);
            this.groupBox2.Controls.Add(this.tbDireccion);
            this.groupBox2.Controls.Add(this.lblDireccion);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(11, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(582, 119);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos";
            // 
            // tbContacto
            // 
            this.tbContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbContacto.Location = new System.Drawing.Point(102, 85);
            this.tbContacto.Name = "tbContacto";
            this.tbContacto.Size = new System.Drawing.Size(468, 22);
            this.tbContacto.TabIndex = 15;
            // 
            // lblContacto
            // 
            this.lblContacto.AutoSize = true;
            this.lblContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContacto.Location = new System.Drawing.Point(6, 90);
            this.lblContacto.Name = "lblContacto";
            this.lblContacto.Size = new System.Drawing.Size(90, 13);
            this.lblContacto.TabIndex = 14;
            this.lblContacto.Text = "Nombre Contacto";
            // 
            // tbMail
            // 
            this.tbMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMail.Location = new System.Drawing.Point(385, 53);
            this.tbMail.Name = "tbMail";
            this.tbMail.Size = new System.Drawing.Size(185, 22);
            this.tbMail.TabIndex = 13;
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMail.Location = new System.Drawing.Point(343, 58);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(36, 13);
            this.lblMail.TabIndex = 12;
            this.lblMail.Text = "E-Mail";
            // 
            // tbCelular
            // 
            this.tbCelular.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCelular.Location = new System.Drawing.Point(222, 53);
            this.tbCelular.Name = "tbCelular";
            this.tbCelular.Size = new System.Drawing.Size(101, 22);
            this.tbCelular.TabIndex = 11;
            this.tbCelular.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCelular
            // 
            this.lblCelular.AutoSize = true;
            this.lblCelular.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCelular.Location = new System.Drawing.Point(177, 58);
            this.lblCelular.Name = "lblCelular";
            this.lblCelular.Size = new System.Drawing.Size(39, 13);
            this.lblCelular.TabIndex = 10;
            this.lblCelular.Text = "Celular";
            // 
            // tbTelefono
            // 
            this.tbTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTelefono.Location = new System.Drawing.Point(64, 53);
            this.tbTelefono.Name = "tbTelefono";
            this.tbTelefono.Size = new System.Drawing.Size(101, 22);
            this.tbTelefono.TabIndex = 9;
            this.tbTelefono.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefono.Location = new System.Drawing.Point(6, 58);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(49, 13);
            this.lblTelefono.TabIndex = 8;
            this.lblTelefono.Text = "Teléfono";
            // 
            // tbDireccion
            // 
            this.tbDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDireccion.Location = new System.Drawing.Point(64, 23);
            this.tbDireccion.Name = "tbDireccion";
            this.tbDireccion.Size = new System.Drawing.Size(506, 22);
            this.tbDireccion.TabIndex = 1;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDireccion.Location = new System.Drawing.Point(6, 30);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(52, 13);
            this.lblDireccion.TabIndex = 7;
            this.lblDireccion.Text = "Dirección";
            // 
            // frmClienteModificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btSalir;
            this.ClientSize = new System.Drawing.Size(605, 234);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btSiguiente);
            this.Controls.Add(this.btUltimo);
            this.Controls.Add(this.btPrimero);
            this.Controls.Add(this.btAnterior);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.btSalir);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmClienteModificar";
            this.Text = "Clientes :: Modificar";
            this.Load += new System.EventHandler(this.frmClienteModificar_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmClienteModificar_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox tbCedula;
        private System.Windows.Forms.Label lblCedula;
        private System.Windows.Forms.ToolTip toolTipModificar;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.Button btSalir;
        private System.Windows.Forms.Button btSiguiente;
        private System.Windows.Forms.Button btUltimo;
        private System.Windows.Forms.Button btPrimero;
        private System.Windows.Forms.Button btAnterior;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbContacto;
        private System.Windows.Forms.Label lblContacto;
        private System.Windows.Forms.TextBox tbMail;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.TextBox tbCelular;
        private System.Windows.Forms.Label lblCelular;
        private System.Windows.Forms.TextBox tbTelefono;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox tbDireccion;
        private System.Windows.Forms.Label lblDireccion;
    }
}