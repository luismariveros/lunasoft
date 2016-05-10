using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Npgsql;

namespace LunaSoft
{
    public partial class frmInventario : Form
    {
        NpgsqlConnection con;
        NpgsqlDataAdapter da;
        DataView dv;
        Color color_datagrid;
        Boolean detalle_ejecutado = false;

        DataGridViewPrinter MyDataGridViewPrinter;

        public frmInventario()
        {
            InitializeComponent();
        }

        private void frmInventario_Load(object sender, EventArgs e)
        {
            cargar_datos();
            formatear_datagrid();
            //configurar_impresora();
        }

        private void cargar_datos()
        {
            DataSet ds = new DataSet();
            con = new NpgsqlConnection(frmInicio.strConexion);
            try
            {
                con.Open();
                //p.nombre, d.nombre, s.cantidad from productos p, depositos d, stocks s where p.id_producto=s.id_producto and d.id_deposito=s.id_deposito;
                string query;
                if(cbDetalle.Checked)
                    query = "SELECT p.codigo as \"Código\", e.nombre as \"Producto\", e.existencia as \"Existencia\" FROM existencia_total e, productos p WHERE p.estado = '1' AND e.id_producto = p.id_producto ORDER BY p.nombre";
                else
                    query = "SELECT p.codigo as \"Código\", e.nombre as \"Producto\", d.nombre as \"Depósito\", s.existencia as \"# Dep\", e.existencia as \"Existencia\" FROM productos p inner join existencia_total e using (id_producto) inner join stocks s using(id_producto) inner join depositos d using(id_deposito) WHERE p.estado = '1' ORDER BY p.nombre";
                
                NpgsqlCommand command = new NpgsqlCommand(query, con);
                da = new NpgsqlDataAdapter(command);
                da.Fill(ds);
                dv = ds.Tables[0].DefaultView;
                dataGridView1.DataSource = dv;
            }
            catch (NpgsqlException error)
            {
                MessageBox.Show(error.Message, "LunaSoft :: ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void formatear_datagrid()
        {
            // Volver ReadOnly todas las columnas menos la columna Borrar
            for (int i = 1; i < dataGridView1.Columns.Count; i++)
                dataGridView1.Columns[i].ReadOnly = true;
            
            // Columnas Alineacion Derecha
            dataGridView1.Columns["Existencia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            // Cambiar el Nombre de las Columnas
            dataGridView1.Columns["Existencia"].HeaderText = "Total";

            // La Caja de Texto de Buscar limpio
            tbBuscar.Text = "";
        }

        private bool configurar_impresion()
        {
            PrintDialog MyPrintDialog = new PrintDialog();
            MyPrintDialog.AllowCurrentPage = false;
            MyPrintDialog.AllowPrintToFile = false;
            MyPrintDialog.AllowSelection = false;
            MyPrintDialog.AllowSomePages = false;
            MyPrintDialog.PrintToFile = false;
            MyPrintDialog.ShowHelp = false;
            MyPrintDialog.ShowNetwork = false;
            

            if (MyPrintDialog.ShowDialog() != DialogResult.OK)
                return false;

            MyPrintDocument.DocumentName = "Reporte-" + this.Text + "-" + DateTime.Now.ToString("dd-MM-yyyy");
            MyPrintDocument.PrinterSettings = MyPrintDialog.PrinterSettings;
            MyPrintDocument.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            MyPrintDocument.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

            // Guardo el COLOR del datagridview y establezco a BLANCO para imprimir
            color_datagrid = dataGridView1.AlternatingRowsDefaultCellStyle.BackColor;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            MyDataGridViewPrinter = new DataGridViewPrinter(dataGridView1, MyPrintDocument, true, true, "Inventario " + DateTime.Now.ToString("dd-MM-yyyy"), new Font("Tahoma", 14, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);

            return true;
        }

        private void tbBuscar_TextChanged(object sender, EventArgs e)
        {
            if (!detalle_ejecutado)
                dv.RowFilter = "Código LIKE '%" + tbBuscar.Text + "%' OR Producto LIKE '%" + tbBuscar.Text + "%' OR Depósito LIKE '%" + tbBuscar.Text + "%'";
            else   
                dv.RowFilter = "Código LIKE '%" + tbBuscar.Text + "%' OR Producto LIKE '%" + tbBuscar.Text + "%'";
        }

        private void btSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btActualizar_Click(object sender, EventArgs e)
        {
            detalle_ejecutado = cbDetalle.Checked;
            cargar_datos();
            formatear_datagrid();
        }

        private void frmInventario_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (char)Keys.F2:
                    cargar_datos();
                    formatear_datagrid();
                    break;
            }
        }

        private void btGenerar_Click(object sender, EventArgs e)
        {
            detalle_ejecutado = cbDetalle.Checked;
            cargar_datos();
            formatear_datagrid();
        }

        private void btImprimir_Click(object sender, EventArgs e)
        {
            if (configurar_impresion())
            {
                MyPrintDocument.Print();
                // Vuelvo a colocar el color por defecto
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = color_datagrid;
            }
        }

        private void btPreview_Click(object sender, EventArgs e)
        {
            if (configurar_impresion())
            {
                PrintPreviewDialog MyPrintPreviewDialog = new PrintPreviewDialog();
                MyPrintPreviewDialog.Document = MyPrintDocument;
                MyPrintPreviewDialog.ShowDialog();
                // Vuelvo a colocar el color por defecto
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = color_datagrid;
            }
        }

        private void MyPrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            bool more = MyDataGridViewPrinter.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
        }
    }
}
