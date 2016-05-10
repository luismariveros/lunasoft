using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Npgsql;

namespace LunaSoft
{
    public partial class frmCompraAgregar : Form, IFormProducto, IFormProveedor
    {
        bool band_proveedor = true; // Bandera para saber si esta activo tbRuc
        bool band_producto = false; // Bandera para saber si esta activo tbCodigo
        bool band_carga_inicial = false;
        private int id_proveedor;
        private int id_producto;
        private double total_compra = 0;
        NpgsqlConnection con;
        NpgsqlDataAdapter da;
        DataSet ds;

        public frmCompraAgregar()
        {
            InitializeComponent();
        }

        //Region IFormProveedor
        public void cargarDatosProveedor(string ruc, string nombre, int id)
        {
            tbRuc.Text = ruc;
            tbNombre.Text = nombre;
            id_proveedor = id;
            band_carga_inicial = true;
        }
        //Fin Region

        //Region IFormProducto
        public void cargarDatosProducto(string cod, string nom, double precioC, double precioV, int id)
        {
            tbCodigo.Text = cod;
            tbProducto.Text = nom;
            id_producto = id;
            tbPrecio.Text = precioC.ToString();
        }
        //Fin Region

        private void proveedor_agregar()
        {
            frmProveedores proveedor = new frmProveedores();
            proveedor.Hijo = true;
            proveedor.ShowDialog(this);
            proveedor = null;
            tbFactura.Focus();
        }

        private void producto_agregar()
        {
            frmProductos producto = new frmProductos();
            producto.Hijo = true;
            producto.Tipo_Form = 3;
            producto.ShowDialog(this);
            producto = null;
            cbDeposito.Focus();
       } 

        private void formatear_datagrid()
        {
            dataGridView1.Columns["Cant"].DefaultCellStyle.Format = "n0";
            dataGridView1.Columns["Precio"].DefaultCellStyle.Format = "n0";
            dataGridView1.Columns["Total"].DefaultCellStyle.Format = "n0";
        }

        private void limpiar()
        {
            tbCodigo.Text = "";
            tbNombre.Text = "";
            tbCantidad.Text = "1";
            tbRuc.Text = "";
            tbTotal.Text = "";
            tbProducto.Text = "";
            tbFactura.Text = "";
            tbTotal.Text = "0";
            total_compra = 0;
            dataGridView1.Rows.Clear();
        }

        private void guardar_agregar()
        {
            guardar();
            limpiar();
            tbRuc.Focus();
        }

        private void guardar()
        {
            con = new NpgsqlConnection(frmInicio.strConexion);
            try
            {
                con.Open();
                NpgsqlTransaction t = con.BeginTransaction();
                DateTime fecha = Convert.ToDateTime(dateTimePicker1.Value);

                string query = "INSERT INTO compras(id_proveedor,fecha,monto_compra,numero_factura) values(" + id_proveedor + ",'" + fecha.ToString("yyyy/MM/dd") + "', " + Convert.ToDouble(tbTotal.Text) + ",'" + tbFactura.Text + "');" + classFunciones.agregar_evento("[COMPRAS] Nuevo registro", true);
                NpgsqlCommand command = new NpgsqlCommand(query, con);
                command.ExecuteNonQuery();

                foreach (DataGridViewRow fila in dataGridView1.Rows)
                {
                    query = "SELECT MAX(id_compra) from compras";
                    command = new NpgsqlCommand(query, con);
                    int id_compra = (int)command.ExecuteScalar();

                    query = "INSERT INTO compras_detalles(id_compra,id_deposito,id_producto,cantidad,precio_unitario_compra,precio_total_compra) VALUES(" + id_compra + "," + Convert.ToInt32(fila.Cells["ID_DEP"].Value) + "," + Convert.ToInt32(fila.Cells["ID"].Value) + "," + classFunciones.eliminarComa(fila.Cells["Cant"].Value.ToString()) + "," + Convert.ToDouble(fila.Cells["precio"].Value) + "," + Convert.ToDouble(fila.Cells["total"].Value) + ")";
                    command = new NpgsqlCommand(query, con);
                    command.ExecuteNonQuery();
                }
                t.Commit();
                MessageBox.Show("Compra Exitosa", "LunaSoft :: Compra", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btAdd_Click(object sender, EventArgs e)
        {
            // Agrego al Datagridview los datos de los detalles
            try
            {
                double total = Math.Round(float.Parse(tbCantidad.Text) * Convert.ToDouble(tbPrecio.Text));
                total_compra += total;

                string[] fila = new string[] { id_producto.ToString(), cbDeposito.SelectedValue.ToString(), cbDeposito.Text, tbCantidad.Text, tbProducto.Text, tbPrecio.Text, total.ToString() };
                dataGridView1.Rows.Add(fila);

                tbTotal.Text = total_compra.ToString("n0");
                tbCantidad.Text = "1";
                tbCodigo.Text = "";
                tbProducto.Text = "";
                tbPrecio.Text = "";
                tbCantidad.Focus();
                formatear_datagrid();
            }
            catch (FormatException)
            {
                MessageBox.Show("Formato de Entrada INCORRECTO en el Formulario actual.", "LunaSoft :: ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblBuscarP_Click(object sender, EventArgs e)
        {
            proveedor_agregar();
        }

        private void lblCodigoP_Click(object sender, EventArgs e)
        {
            producto_agregar();
        }

        private void btSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            guardar();
            this.Close();
        }

        private void btRefrescar_Click(object sender, EventArgs e)
        {
            guardar();
            limpiar();
            tbRuc.Focus();
        }

        private void tbRuc_Leave(object sender, EventArgs e)
        {
            band_proveedor = false;
        }

        private void tbRuc_Enter(object sender, EventArgs e)
        {
            band_proveedor = true;
        }

        private void tbCodigo_Enter(object sender, EventArgs e)
        {
            band_producto = true;
        }

        private void tbCodigo_Leave(object sender, EventArgs e)
        {
            band_producto = false;
        }

        private void frmCompraAgregar_Load(object sender, EventArgs e)
        {
            ds = new DataSet();
            con = new NpgsqlConnection(frmInicio.strConexion);
            try
            {
                con.Open();
                // Cargo en DS[0] Tabla Depositos
                string query = "SELECT id_deposito,nombre FROM depositos";
                NpgsqlCommand command = new NpgsqlCommand(query, con);
                da = new NpgsqlDataAdapter(command);
                da.Fill(ds, "depositos");
                cbDeposito.DataSource = ds.Tables["depositos"];
                cbDeposito.DisplayMember = "nombre";
                cbDeposito.ValueMember = "id_deposito";
            }
            catch (NpgsqlException error)
            {
                MessageBox.Show(error.Message, "LunaSoft :: ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }

            formatear_datagrid();
        }

        private void frmCompraAgregar_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (char)Keys.Escape:
                    this.Close();
                    break;
                case (char)Keys.F2:
                    if (band_producto)
                        producto_agregar();
                    if (band_proveedor)
                        proveedor_agregar();
                    break;
                case (char)Keys.F10:
                    guardar();
                    this.Close();
                    break;
                case (char)Keys.F9:
                    guardar_agregar();
                    break;
            }
        }

        private void tbPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Back))
                return;
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
                e.Handled = true;
        }

        private void tbCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            int isNum = 0;

            if (e.KeyChar == ',' || e.KeyChar == (char)Keys.Back) 
                e.Handled = false;
            else if (!int.TryParse(e.KeyChar.ToString(), out isNum))
                e.Handled = true;
        }

        private void tbCantidad_Leave(object sender, EventArgs e)
        {
            band_producto = false;
        }

        private void tbCantidad_Enter(object sender, EventArgs e)
        {
            band_producto = true;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (band_carga_inicial)
            {
                double total = 0;
                dataGridView1.Rows[e.RowIndex].Cells["total"].Value = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Cant"].Value) * Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["precio"].Value);
                foreach (DataGridViewRow fila in dataGridView1.Rows)
                    total += Convert.ToDouble(fila.Cells["total"].Value);
                total_compra = total;
                tbTotal.Text = total_compra.ToString("n0");
            }
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            double total = 0;
            foreach (DataGridViewRow fila in dataGridView1.Rows)
                total += Math.Round(Convert.ToDouble(fila.Cells["total"].Value));
            tbTotal.Text = total.ToString("n0");
            total_compra = total;
        }

        private void tbCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                DataSet ds = new DataSet();
                con = new NpgsqlConnection(frmInicio.strConexion);
                try
                {
                    con.Open();
                    string query = "SELECT id_producto, nombre, precio_promedio_compra FROM productos WHERE codigo = '" + tbCodigo.Text + "'";
                    NpgsqlCommand command = new NpgsqlCommand(query, con);
                    NpgsqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        // Setear Nombre
                        tbProducto.Text = dr["nombre"].ToString();
                        // Setear Precio Promedio de Compra
                        tbPrecio.Text = dr["precio_promedio_compra"].ToString();
                        //double total = Math.Round((float.Parse(tbCantidad.Text) * Convert.ToDouble(dr["precio_venta"])));
                        //total_compra += total;
                        // Agrego al Datagridview los datos de los detalles
                        //string[] fila = new string[] { dr["id_producto"].ToString(), tbCantidad.Text, tbCodigo.Text, dr["nombre"].ToString(), dr["precio_venta"].ToString(), total.ToString() };
                        //dataGridView1.Rows.Add(fila);
                        tbTotal.Text = total_compra.ToString("n0");
                        cbDeposito.Focus();
                    }
                    else
                    {
                        MessageBox.Show("No existe Producto.", "LunaSoft :: Compras", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbCodigo.Focus();
                    }
                }
                catch (NpgsqlException error)
                {
                    MessageBox.Show(error.Message, "LunaSoft :: ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tbRuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                DataSet ds = new DataSet();
                con = new NpgsqlConnection(frmInicio.strConexion);
                try
                {
                    con.Open();
                    string query = "SELECT id_proveedor, cedula_ruc, nombre FROM proveedores WHERE cedula_ruc = '" + tbRuc.Text + "'";
                    NpgsqlCommand command = new NpgsqlCommand(query, con);
                    NpgsqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        id_proveedor = Convert.ToInt32(dr[0].ToString());
                        tbRuc.Text = dr[1].ToString();
                        tbNombre.Text = dr[2].ToString();
                        tbFactura.Focus();
                    }
                    else
                    {
                        MessageBox.Show("No existe Proveedor.", "LunaSoft :: Compras", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbRuc.Focus();
                    }
                }
                catch (NpgsqlException error)
                {
                    MessageBox.Show(error.Message, "LunaSoft :: ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }  
    }
}
