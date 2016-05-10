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

/*
 * Form para listar los productos faltantes
 * Soporta Busqueda por Nombre de Producto.
 * El query inicial esta en frmInicio.cs
 */

namespace LunaSoft
{
    public partial class frmListadosSolo : Form
    {
        NpgsqlConnection con;
        NpgsqlDataAdapter da;
        DataView dv;
        public string query;
        public string tipo;
        private Color color_datagrid;

        DataGridViewPrinter MyDataGridViewPrinter;

        public frmListadosSolo()
        {
            InitializeComponent();
        }

        private void cargar_datos()
        {
            DataSet ds = new DataSet();
            con = new NpgsqlConnection(frmInicio.strConexion);
            try
            {
                con.Open();
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

        private void formatear_datagrid_stock()
        {
            // Columnas Alineacion Derecha
            dataGridView1.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["Stock Minimo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // El ancho de la Columna se establece por el contenido
            dataGridView1.Columns["Total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns["Código"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns["Producto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            // Formato Numerico
            dataGridView1.Columns["Total"].DefaultCellStyle.Format = "n0";
        }

        private void formatear_datagrid()
        {
            // Columnas INVISIBLES
            dataGridView1.Columns["ID"].Visible = false;

            switch (tipo)
            {
                case "stock":
                    formatear_datagrid_stock();
                    break;
            }

            // La Caja de Texto de Buscar limpio
            tbBuscar.Text = "";
        }

        
        private void frmListadosSolo_Load(object sender, EventArgs e)
        {
            lblTipoListado.Text = tipo.ToUpper();
            cargar_datos();
            formatear_datagrid();
        }

        private void btSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btActualizar_Click(object sender, EventArgs e)
        {
            cargar_datos();
            formatear_datagrid();
        }

        private void tbBuscar_TextChanged(object sender, EventArgs e)
        {
            dv.RowFilter = "Producto LIKE '%" + tbBuscar.Text + "%'";
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
