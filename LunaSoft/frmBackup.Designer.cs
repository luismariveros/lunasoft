namespace LunaSoft
{
    partial class frmBackup
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btbCrearBK = new System.Windows.Forms.Button();
            this.btElegir = new System.Windows.Forms.Button();
            this.tbUbicacion = new System.Windows.Forms.TextBox();
            this.lblUbicacion = new System.Windows.Forms.Label();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btRestablecerBK = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btElegirRestablecer = new System.Windows.Forms.Button();
            this.tbArchivo = new System.Windows.Forms.TextBox();
            this.lblArchivo = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 139);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(325, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btbCrearBK);
            this.groupBox1.Controls.Add(this.btElegir);
            this.groupBox1.Controls.Add(this.tbUbicacion);
            this.groupBox1.Controls.Add(this.lblUbicacion);
            this.groupBox1.Controls.Add(this.tbNombre);
            this.groupBox1.Controls.Add(this.lblNombre);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 113);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Realizar Copia de Seguridad";
            // 
            // btbCrearBK
            // 
            this.btbCrearBK.Location = new System.Drawing.Point(98, 78);
            this.btbCrearBK.Name = "btbCrearBK";
            this.btbCrearBK.Size = new System.Drawing.Size(102, 23);
            this.btbCrearBK.TabIndex = 10;
            this.btbCrearBK.Text = "Crear Backup";
            this.btbCrearBK.UseVisualStyleBackColor = true;
            this.btbCrearBK.Click += new System.EventHandler(this.btbCrearBK_Click);
            // 
            // btElegir
            // 
            this.btElegir.Location = new System.Drawing.Point(238, 52);
            this.btElegir.Name = "btElegir";
            this.btElegir.Size = new System.Drawing.Size(48, 21);
            this.btElegir.TabIndex = 9;
            this.btElegir.Text = "Elegir";
            this.btElegir.UseVisualStyleBackColor = true;
            this.btElegir.Click += new System.EventHandler(this.btElegir_Click);
            // 
            // tbUbicacion
            // 
            this.tbUbicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUbicacion.Location = new System.Drawing.Point(73, 52);
            this.tbUbicacion.Name = "tbUbicacion";
            this.tbUbicacion.Size = new System.Drawing.Size(159, 20);
            this.tbUbicacion.TabIndex = 8;
            // 
            // lblUbicacion
            // 
            this.lblUbicacion.AutoSize = true;
            this.lblUbicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUbicacion.Location = new System.Drawing.Point(4, 55);
            this.lblUbicacion.Name = "lblUbicacion";
            this.lblUbicacion.Size = new System.Drawing.Size(69, 16);
            this.lblUbicacion.TabIndex = 7;
            this.lblUbicacion.Text = "Ubicación";
            // 
            // tbNombre
            // 
            this.tbNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNombre.Location = new System.Drawing.Point(73, 24);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(159, 20);
            this.tbNombre.TabIndex = 6;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(5, 25);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(57, 16);
            this.lblNombre.TabIndex = 5;
            this.lblNombre.Text = "Nombre";
            // 
            // btRestablecerBK
            // 
            this.btRestablecerBK.Enabled = false;
            this.btRestablecerBK.Location = new System.Drawing.Point(88, 48);
            this.btRestablecerBK.Name = "btRestablecerBK";
            this.btRestablecerBK.Size = new System.Drawing.Size(123, 23);
            this.btRestablecerBK.TabIndex = 9;
            this.btRestablecerBK.Text = "Restablecer Backup";
            this.btRestablecerBK.UseVisualStyleBackColor = true;
            this.btRestablecerBK.Click += new System.EventHandler(this.btRestablecerBK_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btElegirRestablecer);
            this.groupBox2.Controls.Add(this.tbArchivo);
            this.groupBox2.Controls.Add(this.lblArchivo);
            this.groupBox2.Controls.Add(this.btRestablecerBK);
            this.groupBox2.Location = new System.Drawing.Point(12, 162);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(299, 85);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Restablecer Copia de Seguridad";
            // 
            // btElegirRestablecer
            // 
            this.btElegirRestablecer.Enabled = false;
            this.btElegirRestablecer.Location = new System.Drawing.Point(241, 22);
            this.btElegirRestablecer.Name = "btElegirRestablecer";
            this.btElegirRestablecer.Size = new System.Drawing.Size(48, 21);
            this.btElegirRestablecer.TabIndex = 12;
            this.btElegirRestablecer.Text = "Elegir";
            this.btElegirRestablecer.UseVisualStyleBackColor = true;
            this.btElegirRestablecer.Click += new System.EventHandler(this.btElegirRestablecer_Click);
            // 
            // tbArchivo
            // 
            this.tbArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbArchivo.Location = new System.Drawing.Point(73, 22);
            this.tbArchivo.Name = "tbArchivo";
            this.tbArchivo.Size = new System.Drawing.Size(159, 20);
            this.tbArchivo.TabIndex = 11;
            // 
            // lblArchivo
            // 
            this.lblArchivo.AutoSize = true;
            this.lblArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArchivo.Location = new System.Drawing.Point(6, 24);
            this.lblArchivo.Name = "lblArchivo";
            this.lblArchivo.Size = new System.Drawing.Size(53, 16);
            this.lblArchivo.TabIndex = 10;
            this.lblArchivo.Text = "Archivo";
            // 
            // frmBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 161);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frmBackup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LunaSoft :: Backup";
            this.Load += new System.EventHandler(this.frmBackup_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btbCrearBK;
        private System.Windows.Forms.Button btElegir;
        private System.Windows.Forms.TextBox tbUbicacion;
        private System.Windows.Forms.Label lblUbicacion;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btRestablecerBK;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btElegirRestablecer;
        private System.Windows.Forms.TextBox tbArchivo;
        private System.Windows.Forms.Label lblArchivo;
    }
}