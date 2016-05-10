namespace LunaSoft
{
    partial class frmListadoSeleccionImpresion
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
            this.rbMovimientos = new System.Windows.Forms.RadioButton();
            this.rbTransferencias = new System.Windows.Forms.RadioButton();
            this.btOK = new System.Windows.Forms.Button();
            this.btSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rbMovimientos
            // 
            this.rbMovimientos.AutoSize = true;
            this.rbMovimientos.Checked = true;
            this.rbMovimientos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMovimientos.Location = new System.Drawing.Point(12, 24);
            this.rbMovimientos.Name = "rbMovimientos";
            this.rbMovimientos.Size = new System.Drawing.Size(115, 24);
            this.rbMovimientos.TabIndex = 0;
            this.rbMovimientos.TabStop = true;
            this.rbMovimientos.Text = "Movimientos";
            this.rbMovimientos.UseVisualStyleBackColor = true;
            // 
            // rbTransferencias
            // 
            this.rbTransferencias.AutoSize = true;
            this.rbTransferencias.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTransferencias.Location = new System.Drawing.Point(166, 24);
            this.rbTransferencias.Name = "rbTransferencias";
            this.rbTransferencias.Size = new System.Drawing.Size(132, 24);
            this.rbTransferencias.TabIndex = 1;
            this.rbTransferencias.Text = "Transferencias";
            this.rbTransferencias.UseVisualStyleBackColor = true;
            // 
            // btOK
            // 
            this.btOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btOK.Image = global::LunaSoft.Properties.Resources.accept;
            this.btOK.Location = new System.Drawing.Point(244, 72);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(26, 26);
            this.btOK.TabIndex = 4;
            this.btOK.TabStop = false;
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btSalir
            // 
            this.btSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btSalir.Image = global::LunaSoft.Properties.Resources.cancel;
            this.btSalir.Location = new System.Drawing.Point(272, 72);
            this.btSalir.Name = "btSalir";
            this.btSalir.Size = new System.Drawing.Size(26, 26);
            this.btSalir.TabIndex = 3;
            this.btSalir.TabStop = false;
            this.btSalir.UseVisualStyleBackColor = true;
            // 
            // frmListadoSeleccionImpresion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 110);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.btSalir);
            this.Controls.Add(this.rbTransferencias);
            this.Controls.Add(this.rbMovimientos);
            this.Name = "frmListadoSeleccionImpresion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LunaSoft :: Selección de Reporte";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbMovimientos;
        private System.Windows.Forms.RadioButton rbTransferencias;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btSalir;
    }
}