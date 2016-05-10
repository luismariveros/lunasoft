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
 * Form para listar las ventas, compras, transferencias y ajustes. 
 * Soporta Busqueda, Filtro de Fechas.
 * Por defecto carga las operaciones del dia. Ese query inicial esta en frmInicio.cs
 */

namespace LunaSoft
{
    public partial class frmListados : Form
    {
        NpgsqlConnection con;
        NpgsqlDataAdapter da;
        DataView dv;
        public string query;
        public string tipo;
        private Color color_datagrid;

        DataGridViewPrinter MyDataGridViewPrinter;

        public frmListados()
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

            string titulo = "Listado " + tipo.ToUpper() + " " + lblTipoFiltro.Text;

            // Guardar el COLOR del datagridview y establecer a BLANCO para imprimir
            color_datagrid = dataGridView1.AlternatingRowsDefaultCellStyle.BackColor;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            MyDataGridViewPrinter = new DataGridViewPrinter(dataGridView1, MyPrintDocument, true, true, "Inventario " + DateTime.Now.ToString("dd-MM-yyyy"), new Font("Tahoma", 14, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);

            return true;
        }

        private void limpiar()
        {
            tbBuscar.Text = "";
            rbMes.Checked = false;
            rbTodo.Checked = false;
        }

        private void formatear_datagrid_venta()
        {
            // Columnas Alineacion Derecha
            dataGridView1.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // El ancho de la Columna se establece por el contenido
            dataGridView1.Columns["Total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns["RUC"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns["Fecha"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            // Columnas Invisibles
            dataGridView1.Columns["ID_PERSONA"].Visible = false;

            // Formato Numerico
            dataGridView1.Columns["Total"].DefaultCellStyle.Format = "n0";
        }
        
        private void formatear_datagrid_transferencias()
        {
            // Columnas Alineacion Derecha
            dataGridView1.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // El ancho de la Columna se establece por el contenido
            dataGridView1.Columns["Fecha"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns["Origen"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns["Destino"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns["Cantidad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;

            // Cambiar Nombre de la Columna
            dataGridView1.Columns["Cantidad"].HeaderText = "#";

            // Formato Numerico
            dataGridView1.Columns["Cantidad"].DefaultCellStyle.Format = "n2";
        }

        private void formatear_datagrid()
        {
            // Columnas INVISIBLES
            dataGridView1.Columns["ID"].Visible = false;

            switch (tipo)
            {
                case "venta":case "compra":
                    formatear_datagrid_venta();
                    break;
                case "transferencias":
                    formatear_datagrid_transferencias();
                    break;
                case "ajustes":
                    break;
            }          

            // La Caja de Texto de Buscar limpio
            tbBuscar.Text = "";
        }

        private void controlar_nivel_usuario()
        {
            switch (frmInicio.User.Usuario_Nivel)
            {
                case 1:
                    this.btEliminar.Enabled = true;
                    break;
            }
        }

        private void controlar_tipo_listado()
        {
            switch (tipo)
            {
                case "venta":case "compra":
                    this.btEditar.Enabled = true;
                    this.btEliminar.Enabled = true;
                    break;
                case "transferencias": case "ajustes":
                    this.btEliminar.Enabled = false;
                    this.btVer.Enabled = false;
                    break;
            }
        }

        private void modificar()
        {
            // Elimino y agrego el registro 
            try
            {
                frmCompraModificar compraModificar = new frmCompraModificar();
                compraModificar.ID_Padre = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                compraModificar.Tipo = tipo;
                compraModificar.Nombre = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                compraModificar.Ruc = dataGridView1.CurrentRow.Cells["RUC"].Value.ToString();
                compraModificar.MontoTotal = Convert.ToDouble(dataGridView1.CurrentRow.Cells["Total"].Value);
                compraModificar.Factura = dataGridView1.CurrentRow.Cells["Factura N"].Value.ToString();
                compraModificar.Fecha = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["Fecha"].Value);
                compraModificar.ID_Persona = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID_PERSONA"].Value);
                compraModificar.Show();
                compraModificar = null;
                cargar_datos();
            }
            catch (NullReferenceException)
            {
                return;
            }  
        }

        
        private void eliminar()
        {
            if (tipo == "venta" || tipo == "compra" || tipo == "fabricaciones")
            {
                string mensaje = "El registro activo será eliminado, así como todos los detalles del mismo.\n¿Está seguro?";

                if (MessageBox.Show(mensaje, "Eliminar Registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    con = new NpgsqlConnection(frmInicio.strConexion);
                    try
                    {
                        con.Open();
                        string id = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                        string query = "DELETE FROM " + tipo + "s WHERE id_" + tipo + "=" + Convert.ToInt32(id);
                        if(tipo == "fabricaciones")
                            query = "DELETE FROM procesos_fabricacion WHERE id_proceso_fabricacion = " + Convert.ToInt32(id);
                        NpgsqlCommand command = new NpgsqlCommand(query, con);
                        command.ExecuteNonQuery();

                        // Se elimina del DataView para no tener que hacer un SELECT de la BD
                        dv.Sort = "ID ASC";
                        dv.Delete((dv.Find(id)));
                    }
                    catch (NpgsqlException error)
                    {
                        MessageBox.Show(error.Message, "LunaSoft :: ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        con.Close();
                        dataGridView1.Focus();
                        tbBuscar.Text = "";
                    }
                }
            }
        }

        private void ver()
        {
            switch (tipo)
            {
                case "venta":
                case "compra":
                    frmListadosDetalles detalles = new frmListadosDetalles();
                    detalles.ID_Padre = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                    detalles.Tipo = tipo;
                    detalles.Nombre = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                    detalles.Ruc = dataGridView1.CurrentRow.Cells["RUC"].Value.ToString();
                    detalles.Total = Convert.ToDouble(dataGridView1.CurrentRow.Cells["Total"].Value);
                    detalles.Factura = dataGridView1.CurrentRow.Cells["Factura N"].Value.ToString();
                    detalles.Fecha = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["Fecha"].Value);
                    detalles.Show();
                    break;
                case "fabricaciones":
                    frmListadosDetalles detallesFabricacion = new frmListadosDetalles();
                    detallesFabricacion.ID_Padre = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                    detallesFabricacion.Tipo = tipo;
                    detallesFabricacion.Nombre = dataGridView1.CurrentRow.Cells["Materia Prima"].Value.ToString();
                    detallesFabricacion.Ruc = dataGridView1.CurrentRow.Cells["Código"].Value.ToString();
                    //detallesFabricacion.Total = Convert.ToDouble(dataGridView1.CurrentRow.Cells["Total"].Value);
                    detallesFabricacion.Factura = dataGridView1.CurrentRow.Cells["Depósito"].Value.ToString();
                    detallesFabricacion.Fecha = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["Fecha"].Value);
                    detallesFabricacion.Show();
                    break;
            }
        }

        private void btSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void set_query(string filtro)
        {
            string fecha = "";
            switch (this.tipo)
            {
                case "compra":
                    query = "SELECT c.id_compra as \"ID\", c.fecha as \"Fecha\"," +
                                    "p.id_proveedor as \"ID_PERSONA\",p.cedula_ruc as \"RUC\",p.nombre as \"Nombre\"," +
                                    "c.monto_compra as \"Total\", c.numero_factura as \"Factura N\" FROM compras c, proveedores p WHERE c.id_proveedor = p.id_proveedor ";
                    fecha = "c.fecha";
                    break;
                case "venta":
                    query = "SELECT v.id_venta as \"ID\", v.fecha_hora as \"Fecha\"," +
                                    "c.id_cliente as \"ID_PERSONA\", c.cedula_ruc as \"RUC\", c.nombre as \"Nombre\"" +
                                    ",v.monto_venta  as \"Total\", v.numero_factura as \"Factura N\" FROM ventas v, clientes c WHERE c.id_cliente = v.id_cliente";
                    fecha = "v.fecha_hora";
                    break;
                case "transferencias":
                    query = "SELECT t.id_transferencia as \"ID\", t.fecha_hora as \"Fecha\", p.nombre as \"Producto\"" +
                                    ", d.nombre as \"Origen\", d2.nombre as \"Destino\", t.cantidad as \"Cantidad\"" +
                                    ", t.observacion as \"Observacion\"" +
                                    " FROM transferencias t, depositos d, depositos d2, productos p" +
                                    " WHERE t.id_dep_origen=d.id_deposito AND t.id_dep_destino=d2.id_deposito AND t.id_producto=p.id_producto";
                    fecha = "t.fecha_hora";
                    break;
                case "ajustes":
                    query = "SELECT a.id_ajuste as \"ID\", a.fecha as \"Fecha\", ta.nombre as \"TIPO\"" +
                            ", d.nombre as \"Deposito\", p.nombre as \"Producto\"" +
                            ", a.cantidad as \"Cantidad\", a.descripcion as \"Descripcion\"" +
                            " FROM ajustes a, tipos_ajustes ta, depositos d, productos p " +
                            " WHERE a.id_tipo_ajuste=ta.id_tipo_ajuste AND a.id_deposito=d.id_deposito AND a.id_producto=p.id_producto";
                    fecha = "a.fecha";
                    break;
                case "auditoria":
                    query = "SELECT a.id_auditoria as \"ID\", a.fecha_hora as \"Fecha\"," +
                                    "u.nombre as \"Usuario\", a.descripcion as \"Accion\"" +
                                    " FROM auditorias a, usuarios u WHERE a.id_usuario = u.id_usuario";
                    fecha = "a.fecha_hora";
                    break;
                case "fabricaciones":
                    query = "SELECT pf.id_proceso_fabricacion as \"ID\", pf.fecha_hora as \"Fecha\"," +
                                    "p.codigo as \"Código\", p.nombre as \"Materia Prima\", d.nombre as \"Depósito\" "+
                                    " FROM procesos_fabricacion pf, productos p, depositos d WHERE pf.id_producto = p.id_producto AND pf.id_deposito = d.id_deposito";
                    fecha = "pf.fecha_hora";
                    break;
            }

            switch (filtro)
            {
                case "hoy":
                    query += " AND " + fecha + "> '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
                    break;
                case "mensual":
                    query += " AND " + fecha + " BETWEEN '" + DateTime.Today.Year + "-" + DateTime.Today.Month + "-01' AND '" + DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month).ToString() + "'";
                    break;
                case "variable":
                    query += " AND " + fecha + " BETWEEN '" + dtpDesde.Value.ToString("yyyy-MM-dd")+ "' AND '" + dtpHasta.Value.ToString("yyyy-MM-dd") + "'";
                    break;
                case "dia":
                    query += " AND " + fecha + "::date = '" + dtpDesde.Value.ToString("yyyy-MM-dd") + "'";
                    break;
            }

            query += " ORDER BY " + fecha + " DESC";

        }

        private void frmListados_Load(object sender, EventArgs e)
        {
            lblTipoListado.Text = tipo.ToUpper();
            lblTipoFiltro.Text = "Hoy (" + DateTime.Now.ToString("yyyy-MM-dd") + ")";
            set_query("hoy");
            cargar_datos();
            formatear_datagrid();
            controlar_nivel_usuario();
            controlar_tipo_listado();
        }

        private void btActualizar_Click(object sender, EventArgs e)
        {
            cargar_datos();
            formatear_datagrid();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ver();
        }

        private void rbMes_Click(object sender, EventArgs e)
        {
            lblTipoFiltro.Text = "Mensual";
            set_query("mensual");
        }

        private void rbTodo_CheckedChanged(object sender, EventArgs e)
        {
            lblTipoFiltro.Text = "Todo";
            set_query("todo");
        }

        private void calcular_total()
        {
            int suma;
            suma = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                switch (tipo)
                {
                    case "venta":
                    case "compra":
                        suma += Convert.ToInt32(dataGridView1.Rows[i].Cells["Total"].Value);
                        break;
                    case "transferencias":
                    case "ajustes":
                        suma += Convert.ToInt32(dataGridView1.Rows[i].Cells["Cantidad"].Value);
                        break;
                }
            }

            switch (tipo)
            {
                case "venta":
                case "compra":
                    gpbSumatoria.Text = "Monto en Gs.";
                    break;
                case "transferencias":
                case "ajustes":
                    gpbSumatoria.Text = "Cantidad en Unidades";
                    break;
            }
            txtSumatoria.Text = suma.ToString("n0");
        }

        private void btGenerar_Click(object sender, EventArgs e)
        {
            cargar_datos();
            formatear_datagrid();
            limpiar();
            calcular_total();
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            lblTipoFiltro.Text = "Día (" + dtpDesde.Value.ToString("dd/MM/yyyy") + " - " + dtpHasta.Value.ToString("dd/MM/yyyy") + ")";
            if (dtpDesde.Value.CompareTo(Convert.ToDateTime(dtpHasta.Value)) == 0)
                set_query("dia");
            else
                set_query("variable");
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            lblTipoFiltro.Text = "Día (" + dtpDesde.Value.ToString("dd/MM/yyyy") + " - " + dtpHasta.Value.ToString("dd/MM/yyyy") + ")";
            if (dtpDesde.Value.CompareTo(Convert.ToDateTime(dtpHasta.Value)) == 0)
                set_query("dia");
            else
                set_query("variable");
        }

        private void tbBuscar_TextChanged(object sender, EventArgs e)
        {
            switch (tipo)
            {
                case "venta":
                case "compra":
                    dv.RowFilter = "RUC LIKE '%" + tbBuscar.Text + "%' OR Nombre LIKE '%" + tbBuscar.Text + "%' OR [Factura N] LIKE '%" + tbBuscar.Text + "%'";
                    break;
                case "transferencias":
                case "ajustes":
                    dv.RowFilter = "Producto LIKE '%" + tbBuscar.Text + "%'";
                    break;
                case "auditoria":
                    dv.RowFilter = "Usuario LIKE '%" + tbBuscar.Text + "%' OR Accion LIKE '%" + tbBuscar.Text + "%'";
                    break;
                case "fabricaciones":
                    dv.RowFilter = "[Materia Prima] LIKE '%" + tbBuscar.Text + "%'";
                    break;
            }
            calcular_total();
        }

        private void frmListados_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.tbBuscar.Focused == false)
            {
                switch (e.KeyChar)
                {
                    case (char)101:
                    case (char)Keys.E:
                        //dataGridView1.EndEdit();
                        eliminar();
                        //dataGridView1.BeginEdit(false);
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

        private void MyPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            bool more = MyDataGridViewPrinter.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
        }
    }
}
