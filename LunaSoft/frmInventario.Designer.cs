namespace LunaSoft
{
    partial class frmInventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInventario));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btPreview = new System.Windows.Forms.Button();
            this.btImprimir = new System.Windows.Forms.Button();
            this.btGenerar = new System.Windows.Forms.Button();
            this.cbDetalle = new System.Windows.Forms.CheckBox();
            this.tbBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.toolTipPrincipal = new System.Windows.Forms.ToolTip(this.components);
            this.btSalir = new System.Windows.Forms.Button();
            this.btActualizar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.MyPrintDocument = new System.Drawing.Printing.PrintDocument();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btPreview);
            this.panel2.Controls.Add(this.btImprimir);
            this.panel2.Controls.Add(this.btGenerar);
            this.panel2.Controls.Add(this.cbDetalle);
            this.panel2.Controls.Add(this.tbBuscar);
            this.panel2.Controls.Add(this.lblBuscar);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(840, 36);
            this.panel2.TabIndex = 1;
            // 
            // btPreview
            // 
            this.btPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btPreview.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btPreview.Image = ((System.Drawing.Image)(resources.GetObject("btPreview.Image")));
            this.btPreview.Location = new System.Drawing.Point(803, 3);
            this.btPreview.Name = "btPreview";
            this.btPreview.Size = new System.Drawing.Size(26, 26);
            this.btPreview.TabIndex = 10;
            this.toolTipPrincipal.SetToolTip(this.btPreview, "Vista Previa");
            this.btPreview.UseVisualStyleBackColor = true;
            this.btPreview.Click += new System.EventHandler(this.btPreview_Click);
            // 
            // btImprimir
            // 
            this.btImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btImprimir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btImprimir.Image")));
            this.btImprimir.Location = new System.Drawing.Point(771, 3);
            this.btImprimir.Name = "btImprimir";
            this.btImprimir.Size = new System.Drawing.Size(26, 26);
            this.btImprimir.TabIndex = 9;
            this.toolTipPrincipal.SetToolTip(this.btImprimir, "Imprimir");
            this.btImprimir.UseVisualStyleBackColor = true;
            this.btImprimir.Click += new System.EventHandler(this.btImprimir_Click);
            // 
            // btGenerar
            // 
            this.btGenerar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btGenerar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btGenerar.Image = ((System.Drawing.Image)(resources.GetObject("btGenerar.Image")));
            this.btGenerar.Location = new System.Drawing.Point(505, 3);
            this.btGenerar.Name = "btGenerar";
            this.btGenerar.Size = new System.Drawing.Size(26, 26);
            this.btGenerar.TabIndex = 9;
            this.toolTipPrincipal.SetToolTip(this.btGenerar, "Generar Listado");
            this.btGenerar.UseVisualStyleBackColor = true;
            this.btGenerar.Click += new System.EventHandler(this.btGenerar_Click);
            // 
            // cbDetalle
            // 
            this.cbDetalle.AutoSize = true;
            this.cbDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDetalle.Location = new System.Drawing.Point(362, 5);
            this.cbDetalle.Name = "cbDetalle";
            this.cbDetalle.Size = new System.Drawing.Size(137, 24);
            this.cbDetalle.TabIndex = 1;
            this.cbDetalle.Text = "Inventario Total";
            this.cbDetalle.UseVisualStyleBackColor = true;
            // 
            // tbBuscar
            // 
            this.tbBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBuscar.Location = new System.Drawing.Point(74, 5);
            this.tbBuscar.Name = "tbBuscar";
            this.tbBuscar.Size = new System.Drawing.Size(270, 22);
            this.tbBuscar.TabIndex = 0;
            this.tbBuscar.TextChanged += new System.EventHandler(this.tbBuscar_TextChanged);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscar.Location = new System.Drawing.Point(3, 6);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(65, 20);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "Buscar";
            // 
            // btSalir
            // 
            this.btSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btSalir.Image = ((System.Drawing.Image)(resources.GetObject("btSalir.Image")));
            this.btSalir.Location = new System.Drawing.Point(826, 530);
            this.btSalir.Name = "btSalir";
            this.btSalir.Size = new System.Drawing.Size(26, 26);
            this.btSalir.TabIndex = 6;
            this.toolTipPrincipal.SetToolTip(this.btSalir, "Cerrar formulario (ESC)");
            this.btSalir.UseVisualStyleBackColor = true;
            this.btSalir.Click += new System.EventHandler(this.btSalir_Click);
            // 
            // btActualizar
            // 
            this.btActualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btActualizar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btActualizar.Image")));
            this.btActualizar.Location = new System.Drawing.Point(794, 530);
            this.btActualizar.Name = "btActualizar";
            this.btActualizar.Size = new System.Drawing.Size(26, 26);
            this.btActualizar.TabIndex = 7;
            this.toolTipPrincipal.SetToolTip(this.btActualizar, "Refrescar Contenido (F4)");
            this.btActualizar.UseVisualStyleBackColor = true;
            this.btActualizar.Click += new System.EventHandler(this.btActualizar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 54);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(840, 470);
            this.dataGridView1.TabIndex = 8;
            // 
            // MyPrintDocument
            // 
            this.MyPrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.MyPrintDocument_PrintPage);
            // 
            // frmInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.btSalir;
            this.ClientSize = new System.Drawing.Size(864, 568);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btActualizar);
            this.Controls.Add(this.btSalir);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmInventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock :: Inventario";
            this.Load += new System.EventHandler(this.frmInventario_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmInventario_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox tbBuscar;
        private System.Windows.Forms.ToolTip toolTipPrincipal;
        private System.Windows.Forms.Button btSalir;
        private System.Windows.Forms.Button btActualizar;
        private System.Windows.Forms.CheckBox cbDetalle;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btGenerar;
        private System.Drawing.Printing.PrintDocument MyPrintDocument;
        private System.Windows.Forms.Button btImprimir;
        private System.Windows.Forms.Button btPreview;
    }
}