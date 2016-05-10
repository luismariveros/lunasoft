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
    public partial class frmProductos : Form
    {
        NpgsqlConnection con;
        NpgsqlDataAdapter da;
        DataView dv;
        
        private Color color_datagrid;
        DataGridViewPrinter MyDataGridViewPrinter;

        private bool _esHijo = false; // Bandera para saber que Form le llamo
        private int _tipoForm = 0; // Bandera para saber que mostrar en el DGV   0->productos   1->fabricacion_MP, transferencias    2-> venta    3->compra,ajustes

        public bool Hijo
        {
            set
            {
                _esHijo = value;
            }
            get
            {
                return _esHijo;
            }
        }

        public int Tipo_Form
        {
            set
            {
                _tipoForm = value;
            }
            get
            {
                return _tipoForm;
            }
        }

        public frmProductos()
        {
            InitializeComponent();
        }

        private void controlar_tipo_form()
        {
            switch (Tipo_Form)
            {
                case 0:
                    this.btEditar.Enabled = true;
                    this.btVer.Enabled = true;
                    break;
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

        private void agregar()
        {
            frmProductoAgregar frmAgregar = new frmProductoAgregar();
            frmAgregar.ShowDialog();
            frmAgregar = null;
            cargar_datos();
            formatear_datagrid();
            dataGridView1.Focus();
        }

        private void modificar()
        {
            frmProductoModificar frmModificar = new frmProductoModificar();
            frmModificar.DT = dv.ToTable();
            frmModificar.Indice = dataGridView1.CurrentRow.Index;
            frmModificar.ShowDialog();
            frmModificar = null;
            cargar_datos();
            formatear_datagrid();
            dataGridView1.Focus();
        }

        private void ver()
        {
            frmProductoVer frmVer = new frmProductoVer();
            frmVer.DT = dv.ToTable();
            frmVer.Indice = dataGridView1.CurrentRow.Index;
            frmVer.ShowDialog();
            frmVer = null;
            formatear_datagrid();
            dataGridView1.Focus();
        }

        private void eliminar()
        {
            List<string> lst_codigo = new List<string>();

            string mensaje = "El registro activo será eliminado. ¿Está seguro?";
            string codigos = " codigo = ";

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                if (Convert.ToInt32(dataGridView1.Rows[i].Cells["cbBorrar"].Value) == 1)
                    lst_codigo.Add(dataGridView1.Rows[i].Cells["Código"].Value.ToString());

            if (lst_codigo.Count > 0)
            {
                int cont = 0;

                foreach (string l in lst_codigo)
                {
                    codigos = codigos + "'" + l + "'";
                    cont++;
                    if (cont < lst_codigo.Count)
                        codigos = codigos + " OR codigo = ";
                }
                if (lst_codigo.Count > 1)
                    mensaje = "Los " + lst_codigo.Count + " registros marcados serán eliminados. ¿Está seguro?";
            }
            else
            {
                codigos = codigos + "'" + dataGridView1.CurrentRow.Cells["Código"].Value.ToString() + "'";
                lst_codigo.Add(dataGridView1.CurrentRow.Cells["Código"].Value.ToString());
            }

            if (MessageBox.Show(mensaje, "Eliminar Registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                con = new NpgsqlConnection(frmInicio.strConexion);
                try
                {
                    con.Open();
                    string query = "UPDATE productos SET estado = '0' WHERE " + codigos + "; " + classFunciones.agregar_evento("[PRODUCTOS] Se borro uno o varios registros", true);
                    //MessageBox.Show(query);
                    NpgsqlCommand command = new NpgsqlCommand(query, con);
                    command.ExecuteNonQuery();

                    // Se elimina del DataView para no tener que hacer un SELECT de la BD
                    dv.Sort = "Código ASC";
                    foreach (string cod in lst_codigo)
                        dv.Delete((dv.Find(cod)));
                }
                catch (NpgsqlException error)
                {
                    MessageBox.Show(error.Message, "LunaSoft :: ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                    lst_codigo = null;
                    dataGridView1.Focus();
                    tbBuscar.Text = "";
                }
            }
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            cargar_datos();
            formatear_datagrid();
            controlar_tipo_form();
        }

        private void cargar_datos()
        {
            DataSet ds = new DataSet();
            con = new NpgsqlConnection(frmInicio.strConexion);
            try
            {
                con.Open();
                string query;
                switch (Tipo_Form)
                {
                    case 1:
                        query = "SELECT p.id_producto as \"ID\", p.codigo as \"Código\", p.nombre as \"Nombre\", e.existencia as \"Existencia Total\", f.descripcion as \"Familia\" FROM productos p, existencia_total e, familias f WHERE p.estado = '1' AND e.id_producto=p.id_producto AND p.id_familia = f.id_familia GROUP BY p.id_producto, p.codigo, p.nombre, e.existencia, f.descripcion ORDER BY p.codigo";
                        break;
                    case 2:
                        query = "SELECT p.id_producto as \"ID\", p.codigo as \"Código\", p.nombre as \"Nombre\", p.precio_venta as \"Precio Venta\", e.existencia as \"Existencia Total\" FROM productos p, existencia_total e WHERE p.estado = '1' AND e.id_producto=p.id_producto GROUP BY p.id_producto, p.codigo, p.nombre, p.precio_venta, e.existencia ORDER BY p.codigo";
                        break;
                    case 3:
                        query = "SELECT p.id_producto as \"ID\", p.codigo as \"Código\", p.nombre as \"Nombre\", f.descripcion as \"Familia\" FROM productos p, familias f WHERE p.estado = '1' AND p.id_familia = f.id_familia GROUP BY p.id_producto, p.codigo, p.nombre, f.descripcion ORDER BY p.codigo";
                        break;
                    default:
                        query = "SELECT p.id_producto as \"ID\", p.codigo as \"Código\", p.nombre as \"Nombre\", p.precio_venta as \"Precio Venta\", f.id_familia as \"IDFAMILIA\", f.codigo as \"CodigoF\", f.descripcion as \"Familia\", p.precio_promedio_compra as \"Precio Compra\", p.stock_minimo as \"Stock Minimo\", p.unidad as \"Unidad\", p.observacion as \"Observación\", p.id_familia as \"Id_familia\" from productos p, familias f WHERE p.estado = '1' AND p.id_familia = f.id_familia ORDER BY p.codigo";
                        break;
                }
                    
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
            dataGridView1.Columns["cbBorrar"].DisplayIndex = 0;

            // Columnas Invisibles
            dataGridView1.Columns["ID"].Visible = false;

            switch (Tipo_Form)
            {
                case 0:
                    // Columnas Invisibles
                    dataGridView1.Columns["IDFAMILIA"].Visible = false;
                    dataGridView1.Columns["Precio Compra"].Visible = false;
                    dataGridView1.Columns["Id_familia"].Visible = false;
                    dataGridView1.Columns["CodigoF"].Visible = false;
                    dataGridView1.Columns["Unidad"].Visible = false;
                    dataGridView1.Columns["Stock Minimo"].Visible = false;
                    // La Columna Precio de Venta alineacion derecha
                    dataGridView1.Columns["Precio Venta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    // Columna con Formato Numerico sin decimales
                    dataGridView1.Columns["Precio Venta"].DefaultCellStyle.Format = "n0";
                    break;
                case 1:
                    // Alineacion Derecha
                    dataGridView1.Columns["Existencia Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    //dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    // Columna con Formato Numerico con 2 decimales
                    dataGridView1.Columns["Existencia Total"].DefaultCellStyle.Format = "n2";
                    break;
                case 2:
                    // Alineacion Derecha
                    dataGridView1.Columns["Existencia Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["Precio Venta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    // Columna con Formato Numerico con 2 decimales
                    dataGridView1.Columns["Existencia Total"].DefaultCellStyle.Format = "n2";
                    // Columna con Formato Numerico sin decimales
                    dataGridView1.Columns["Precio Venta"].DefaultCellStyle.Format = "n0";
                    break;
            }


           
            // La Caja de Texto de Buscar limpio
            tbBuscar.Text = "";
        }

        private void btAgregar_Click(object sender, EventArgs e)
        {
            agregar();
        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            modificar();
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            eliminar();
        }

        private void btVer_Click(object sender, EventArgs e)
        {
            ver();
        }

        private void btSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbBuscar_TextChanged(object sender, EventArgs e)
        {
            switch(Tipo_Form)
            {
                case 2:
                    dv.RowFilter = "Código LIKE '%" + tbBuscar.Text + "%' OR Nombre LIKE '%" + tbBuscar.Text + "%'";
                    break;
                default:
                    dv.RowFilter = "Código LIKE '%" + tbBuscar.Text + "%' OR Nombre LIKE '%" + tbBuscar.Text + "%' OR Familia LIKE '%" + tbBuscar.Text + "%'";
                    break;
            }
        }

        private void frmProductos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.tbBuscar.Focused == false)
            {
                switch (e.KeyChar)
                {
                    case (char)97:
                    case (char)Keys.A:
                        agregar();
                        break;
                    case (char)101:
                    case (char)Keys.E:
                        dataGridView1.EndEdit();
                        eliminar();
                        dataGridView1.BeginEdit(false);
                        break;
                    case (char)109:
                    case (char)Keys.M:
                        modificar();
                        break;
                    case (char)118:
                    case (char)Keys.V:
                        ver();
                        break;
                }
            }
        }

        private void cargar_padre()
        {
            IFormProducto formInterface = this.Owner as IFormProducto;

            if (formInterface != null)
            {
                switch (Tipo_Form)
                {
                    case 0:
                        formInterface.cargarDatosProducto(dataGridView1.CurrentRow.Cells["Código"].Value.ToString(), dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString(), Convert.ToDouble(dataGridView1.CurrentRow.Cells["Precio Compra"].Value), Convert.ToDouble(dataGridView1.CurrentRow.Cells["Precio Venta"].Value), Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value));
                        break;
                    case 1: case 3:
                        formInterface.cargarDatosProducto(dataGridView1.CurrentRow.Cells["Código"].Value.ToString(), dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString(), 0, 0, Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value));
                        break;
                    case 2:
                        formInterface.cargarDatosProducto(dataGridView1.CurrentRow.Cells["Código"].Value.ToString(), dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString(), 0, Convert.ToDouble(dataGridView1.CurrentRow.Cells["Precio Venta"].Value), Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value));
                        break;
                }
            }
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Hijo)
                cargar_padre();
            else
                modificar();
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (Hijo)
                    cargar_padre();
            }
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
