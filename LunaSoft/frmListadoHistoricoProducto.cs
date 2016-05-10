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
    public partial class frmListadoHistoricoProducto : Form, IFormProducto, IFormSeleccionImpresion
    {
        NpgsqlConnection con;
        NpgsqlDataAdapter da,da2;
        DataView dv,dv2;
        public string query, query_filtro, query_filtro2, query_transferencia,tipo_impresion;
        private Color color_datagrid;
        int id_producto;

        DataGridViewPrinter MyDataGridViewPrinter;

        // Region IFormProducto
        public void cargarDatosProducto(string cod, string nom, double precioC, double precioV, int id)
        {
            tbCodigo.Text = cod;
            tbNombre.Text = nom;
            id_producto = id;
            set_query();
            cargar_datos();
        }
        // Fin Region

        // Region IFormSeleccionImpresion
        public void seleccionarTipoImpresion(string impresion)
        {
            tipo_impresion = impresion;
        }
        // Fin Region

        public frmListadoHistoricoProducto()
        {
            InitializeComponent();
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

            frmListadoSeleccionImpresion seleccionImpresion = new frmListadoSeleccionImpresion();
            seleccionImpresion.ShowDialog(this);

            if (MyPrintDialog.ShowDialog() != DialogResult.OK)
                return false;

            MyPrintDocument.DocumentName = "Reporte-" + this.Text + " de Productos-" + DateTime.Now.ToString("dd-MM-yyyy");
            MyPrintDocument.PrinterSettings = MyPrintDialog.PrinterSettings;
            MyPrintDocument.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            MyPrintDocument.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);
                
            // Guardar el COLOR del datagridview y establecer a BLANCO para imprimir
            color_datagrid = dataGridView1.AlternatingRowsDefaultCellStyle.BackColor;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            
            if(tipo_impresion == "transferencias")
                MyDataGridViewPrinter = new DataGridViewPrinter(dataGridView2, MyPrintDocument, true, true, "Transferencias Cód:" + tbCodigo.Text + "  " + DateTime.Now.ToString("dd-MM-yyyy"), new Font("Tahoma", 14, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            else
                MyDataGridViewPrinter = new DataGridViewPrinter(dataGridView1, MyPrintDocument, true, true, "Movimientos Cód:" + tbCodigo.Text + "  " + DateTime.Now.ToString("dd-MM-yyyy"), new Font("Tahoma", 14, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);

            return true;
        }

        private void producto_agregar()
        {
            frmProductos producto = new frmProductos();
            producto.Hijo = true;
            producto.Tipo_Form = 2;
            producto.ShowDialog(this);
            producto = null;
        }

        private void cargar_datos()
        {
            DataSet ds = new DataSet();
            DataSet ds2 = new DataSet();
            con = new NpgsqlConnection(frmInicio.strConexion);
            try
            {
                con.Open();
                NpgsqlCommand command = new NpgsqlCommand(query, con);
                da = new NpgsqlDataAdapter(command);
                da.Fill(ds);
                dv = ds.Tables[0].DefaultView;
                dataGridView1.DataSource = dv;
                
                // TRANSFERENCIA
                NpgsqlCommand command2 = new NpgsqlCommand(query_transferencia, con);
                da2 = new NpgsqlDataAdapter(command2);
                da2.Fill(ds2);
                dv2 = ds2.Tables[0].DefaultView;
                dataGridView2.DataSource = dv2;

                formatear_datagrid();
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

        private void limpiar()
        {
            tbCodigo.Text = "";
            rbMes.Checked = false;
            rbTodo.Checked = false;
        }

        private void formatear_datagrid()
        {
            // Columnas INVISIBLES
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView2.Columns["ID"].Visible = false;

            // Columnas con formato Numerico
            dataGridView1.Columns["Cantidad"].DefaultCellStyle.Format = "n0";
            dataGridView2.Columns["Cantidad"].DefaultCellStyle.Format = "n0";
            dataGridView1.Columns["Precio"].DefaultCellStyle.Format = "n0";

            dataGridView1.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView2.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";

            // Columnas alineacion derecha
            dataGridView1.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView2.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Cambio de nombre de Columnas
            dataGridView1.Columns["Cantidad"].HeaderText = " # ";
            dataGridView2.Columns["Cantidad"].HeaderText = " # ";

            // La Caja de Texto de Buscar limpio
            //tbCodigo.Text = "";
        }

        private void set_filtro(string filtro)
        {
            string fecha = "fecha";
            string fecha2 = "t.fecha_hora";

            switch (filtro)
            {
                case "hoy":
                    query_filtro = " AND " + fecha + "> '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
                    query_filtro2 = " AND " + fecha2 + "> '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
                    break;
                case "mensual":
                    query_filtro = " AND " + fecha + " BETWEEN '" + DateTime.Today.Year + "-" + DateTime.Today.Month + "-01' AND '" + DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month).ToString() + "'";
                    query_filtro2 = " AND " + fecha2 + " BETWEEN '" + DateTime.Today.Year + "-" + DateTime.Today.Month + "-01' AND '" + DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month).ToString() + "'";
                    break;
                case "variable":
                    query_filtro = " AND " + fecha + " BETWEEN '" + dtpDesde.Value.ToString("yyyy-MM-dd") + "' AND '" + dtpHasta.Value.ToString("yyyy-MM-dd") + "'";
                    query_filtro2 = " AND " + fecha2 + " BETWEEN '" + dtpDesde.Value.ToString("yyyy-MM-dd") + "' AND '" + dtpHasta.Value.ToString("yyyy-MM-dd") + "'";
                    break;
                case "dia":
                    query_filtro = " AND " + fecha + "::date = '" + dtpDesde.Value.ToString("yyyy-MM-dd") + "'";
                    query_filtro2 = " AND " + fecha2 + "::date = '" + dtpDesde.Value.ToString("yyyy-MM-dd") + "'";
                    break;
                case "todo":
                    query_filtro = "";
                    query_filtro2 = "";
                    break;
            }
        }
        private void set_query()
        {
            query_transferencia = "SELECT t.id_transferencia as \"ID\", t.fecha_hora as \"Fecha\"" +
                                    ", d.nombre as \"Origen\", d2.nombre as \"Destino\", t.cantidad as \"Cantidad\"" +
                                    ", t.observacion as \"Observacion\"" +
                                    " FROM transferencias t, depositos d, depositos d2 " +
                                    " WHERE t.id_dep_origen=d.id_deposito AND t.id_dep_destino=d2.id_deposito AND t.id_producto= " + id_producto + query_filtro2 + " ORDER BY t.fecha_hora";
            
                    
            query = "SELECT id as \"ID\", tipo as \"Tipo\", fecha as \"Fecha\", cantidad as \"Cantidad\", precio as \"Precio\" from historial_x_producto WHERE id_producto = " + id_producto + query_filtro + " ORDER BY fecha";
            query_filtro = "";
            query_filtro2 = "";
        }

        private void frmListadoHistoricoProducto_Load(object sender, EventArgs e)
        {
            lblTipoListado.Text = "Movimiento y Transferencias por Producto";
            lblTipoFiltro.Text = "Todo";
            tbCodigo.Focus();
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

        private void btGenerar_Click(object sender, EventArgs e)
        {
            if (tbCodigo.Text != "")
            {
                set_query();
                cargar_datos();
                formatear_datagrid();
            }
        }

        private void rbHoy_CheckedChanged(object sender, EventArgs e)
        {
            lblTipoFiltro.Text = "Hoy";
            set_filtro("hoy");
        }

        private void rbMes_CheckedChanged(object sender, EventArgs e)
        {
            lblTipoFiltro.Text = "Mensual";
            set_filtro("mensual");
        }

        private void rbTodo_CheckedChanged(object sender, EventArgs e)
        {
            lblTipoFiltro.Text = "Todo";
            set_filtro("todo");
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            lblTipoFiltro.Text = "Día (" + dtpDesde.Value.ToString("dd/MM/yyyy") + " - " + dtpHasta.Value.ToString("dd/MM/yyyy") + ")";
            if (dtpDesde.Value.CompareTo(Convert.ToDateTime(dtpHasta.Value)) == 0)
                set_filtro("dia");
            else
                set_filtro("variable");
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            lblTipoFiltro.Text = "Día (" + dtpDesde.Value.ToString("dd/MM/yyyy") + " - " + dtpHasta.Value.ToString("dd/MM/yyyy") + ")";
            if (dtpDesde.Value.CompareTo(Convert.ToDateTime(dtpHasta.Value)) == 0)
                set_filtro("dia");
            else
                set_filtro("variable");
        }

        private void tbBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                DataSet ds = new DataSet();
                con = new NpgsqlConnection(frmInicio.strConexion);
                try
                {
                    con.Open();
                    string query = "SELECT id_producto, nombre FROM productos WHERE codigo = '" + tbCodigo.Text + "'";
                    NpgsqlCommand command = new NpgsqlCommand(query, con);
                    NpgsqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        id_producto = Convert.ToInt32(dr[0].ToString());
                        tbNombre.Text = dr[1].ToString();
                        set_query();
                        cargar_datos();
                    }
                    else
                    {
                        MessageBox.Show("No existe Producto.", "LunaSoft :: Historial Producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (NpgsqlException error)
                {
                    MessageBox.Show(error.Message, "LunaSoft :: ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lblCodigoP_Click(object sender, EventArgs e)
        {
            producto_agregar();
        }

        private void btImprimir_Click(object sender, EventArgs e)
        {
            if (configurar_impresion())
            {
                MyPrintDocument.Print();
                // Vuelvo a colocar el color por defecto
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = color_datagrid;
                dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = color_datagrid;
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
                dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = color_datagrid;
            }
        }

        private void MyPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            bool more = MyDataGridViewPrinter.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
        }            
    }
}
