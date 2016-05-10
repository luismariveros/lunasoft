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
    public partial class frmVentaAgregar : Form, IFormCliente, IFormProducto
    {
        bool band_cliente = true; // Bandera para saber si esta activo tbRuc
        bool band_producto = false; // Bandera para saber si esta activo tbCodigo
        bool band_carga_inicial = false;
        private int id_cliente;
        private int id_deposito = 1;
        private double total_venta = 0;
        NpgsqlConnection con;

        public frmVentaAgregar()
        {
            InitializeComponent();
        }

        //Region IFormCliente
        public void cargarDatosCliente(string ruc, string nombre, int id)
        {
            tbRuc.Text = ruc;
            tbNombre.Text = nombre;
            id_cliente = id;
            band_carga_inicial = true;
        }
        //Fin Region

        //Region IFormProducto
        public void cargarDatosProducto(string cod, string nom, double precioC, double precioV, int id)
        {
            dataGridView1.ColumnCount = 6;
            // Calcular Precio Total
            double total = Math.Round((float.Parse(tbCantidad.Text) * precioV));
            total_venta += total;
            // Agrego al Datagridview los datos de los detalles
            string[] fila = new string[] { id.ToString(), tbCantidad.Text, cod, nom, precioV.ToString(), total.ToString() };
            dataGridView1.Rows.Add(fila);
           
            tbTotal.Text = total_venta.ToString("n0");
            tbCantidad.Text = "1";
        }
        //Fin Region

        private void formatear_datagrid()
        {
            /*
            dataGridView1.Columns["Cant"].DefaultCellStyle.Format = "n0";
            dataGridView1.Columns["Precio"].DefaultCellStyle.Format = "n0";
            dataGridView1.Columns["Total"].DefaultCellStyle.Format = "n0";
             */ 
        }

        private void cliente_agregar()
        {
            frmClientes cliente = new frmClientes();
            cliente.Hijo = true;
            cliente.ShowDialog(this);
            cliente = null;
            tbFactura.Focus();
        }

        private void producto_agregar()
        {
            frmProductos producto = new frmProductos();
            producto.Hijo = true;
            producto.Tipo_Form = 2;
            producto.ShowDialog(this);
            producto = null;
            tbCantidad.Focus();
            formatear_datagrid();
        }

        private void frmVentaAgregar_Load(object sender, EventArgs e)
        {
            formatear_datagrid();
        }

        private void lblBuscarF_Click(object sender, EventArgs e)
        {
            cliente_agregar();
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
            guardar_cerrar();
        }

        private void btRefrescar_Click(object sender, EventArgs e)
        {
            guardar_agregar();
        }

        private void limpiar()
        {
            tbCodigo.Text = "";
            tbNombre.Text = "";
            tbCantidad.Text = "1";
            tbRuc.Text = "";
            tbTotal.Text = "";
            total_venta = 0;
            dataGridView1.Rows.Clear();
        }

        private void guardar_cerrar()
        {
            if (guardar())
                this.Close();
        }

        private void guardar_agregar()
        {
            if ( guardar() )
            {
                limpiar();
                tbRuc.Focus();
            }
        }

        private bool guardar()
        {
            bool ret = true;
            con = new NpgsqlConnection(frmInicio.strConexion);
            try
            {
                con.Open();
                NpgsqlTransaction t = con.BeginTransaction();
                DateTime fecha_hora = Convert.ToDateTime(dateTimePicker1.Value);

                string query = "INSERT INTO ventas(id_cliente,fecha_hora,monto_venta,numero_factura) values(" + id_cliente + ",'" + fecha_hora.ToString("yyyy/MM/dd HH:mm:ss") + "', " + Convert.ToDouble(tbTotal.Text) + ",'" + tbFactura.Text + "');" + classFunciones.agregar_evento("[VENTAS] Nuevo registro",true);
                NpgsqlCommand command = new NpgsqlCommand(query, con);
                command.ExecuteNonQuery();
                //MessageBox.Show(query);
                foreach (DataGridViewRow fila in dataGridView1.Rows)
                {
                    query = "SELECT MAX(id_venta) from ventas";
                    command = new NpgsqlCommand(query, con);
                    int id_venta = (int)command.ExecuteScalar();

                    query = "INSERT INTO ventas_detalles(id_venta,id_deposito,id_producto,cantidad,precio_unitario_venta) VALUES(" + id_venta + "," + id_deposito + "," + Convert.ToInt32(fila.Cells["ID"].Value) + "," + classFunciones.eliminarComa(fila.Cells["Cant"].Value.ToString()) + "," + Convert.ToDouble(fila.Cells["precio"].Value) + ")";
                    command = new NpgsqlCommand(query, con);
                    command.ExecuteNonQuery();

                }
                t.Commit();
                MessageBox.Show("Venta Exitosa", "LunaSoft :: Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (NpgsqlException error)
            {
                ret = false;
                MessageBox.Show(error.Message, "LunaSoft :: ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
            return ret;
        }

        private void frmVentaAgregar_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (char)Keys.Escape:
                    this.Close();
                    break;
                case (char)Keys.F2:
                    if (band_producto)
                        producto_agregar();
                    if (band_cliente)
                        cliente_agregar();
                    break;
                case (char)Keys.F10:
                    guardar_cerrar();
                    break;
                case (char)Keys.F9:
                    guardar_agregar();
                    break;
                
            }
        }

        private void tbRuc_Leave(object sender, EventArgs e)
        {
            band_cliente = false;
        }

        private void tbRuc_Enter(object sender, EventArgs e)
        {
            band_cliente = true;
        }

        private void tbCodigo_Enter(object sender, EventArgs e)
        {
            band_producto = true;
        }

        private void tbCodigo_Leave(object sender, EventArgs e)
        {
            band_producto = false;
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            double total = 0;
            foreach(DataGridViewRow fila in dataGridView1.Rows)
                total += Math.Round(Convert.ToDouble(fila.Cells["total"].Value));
            tbTotal.Text = total.ToString("n0");
            total_venta = total;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (band_carga_inicial)
            {
                double total = 0;
                dataGridView1.Rows[e.RowIndex].Cells["total"].Value = float.Parse(dataGridView1.Rows[e.RowIndex].Cells["Cant"].Value.ToString()) * Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["precio"].Value);
                foreach (DataGridViewRow fila in dataGridView1.Rows)
                    total += Math.Round(Convert.ToDouble(fila.Cells["total"].Value));
                tbTotal.Text = total.ToString("n0");
                total_venta = total;
            }
        }

        private void tbCantidad_Leave(object sender, EventArgs e)
        {
            band_producto = false;
        }

        private void tbCantidad_Enter(object sender, EventArgs e)
        {
            band_producto = true;
        }

        private void tbCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            int isNum = 0;

            if (e.KeyChar == ',' || e.KeyChar == (char)Keys.Back)
                e.Handled = false;
            else if (!int.TryParse(e.KeyChar.ToString(), out isNum))
                e.Handled = true;
        }

        private void tbRuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                DataSet ds = new DataSet() ;
                con = new NpgsqlConnection(frmInicio.strConexion);
                try
                {
                    con.Open();
                    string query = "SELECT id_cliente, cedula_ruc, nombre FROM clientes WHERE cedula_ruc = '" + tbRuc.Text + "'";
                    NpgsqlCommand command = new NpgsqlCommand(query, con);
                    NpgsqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        id_cliente = Convert.ToInt32(dr[0].ToString());
                        tbRuc.Text = dr[1].ToString();
                        tbNombre.Text = dr[2].ToString();
                        tbFactura.Focus();
                    }
                    else
                    {
                        MessageBox.Show("No existe Cliente.", "LunaSoft :: Ventas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbRuc.Focus();
                    }                    
                }
                catch (NpgsqlException error)
                {
                    MessageBox.Show(error.Message, "LunaSoft :: ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
                    string query = "SELECT id_producto, nombre, precio_venta FROM productos WHERE codigo = '" + tbCodigo.Text + "'";
                    NpgsqlCommand command = new NpgsqlCommand(query, con);
                    NpgsqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        // Calcular Precio Total
                        double total = Math.Round((float.Parse(tbCantidad.Text) * Convert.ToDouble(dr["precio_venta"])));
                        total_venta += total;
                        // Agrego al Datagridview los datos de los detalles
                        string[] fila = new string[] { dr["id_producto"].ToString(), tbCantidad.Text, tbCodigo.Text, dr["nombre"].ToString(), dr["precio_venta"].ToString(), total.ToString() };
                        dataGridView1.Rows.Add(fila);
                        tbTotal.Text = total_venta.ToString("n0");
                        tbCantidad.Text = "1";
                        tbCantidad.Focus();
                    }
                    else
                    {
                        MessageBox.Show("No existe Producto.", "LunaSoft :: Ventas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbCodigo.Focus();
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
