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
    public partial class frmFabricacionAgregar : Form, IFormProducto
    {
        int id_materia_prima;
        int id_producto_fabricacion;
        bool band_materia_prima = true;
        bool band_producto_fabricacion = false;
        bool band_inicio = false;
        NpgsqlConnection con;
        NpgsqlDataAdapter da;
        DataSet ds;


        public frmFabricacionAgregar()
        {
            InitializeComponent();
        }

        //Region IFormProducto
        public void cargarDatosProducto(string cod, string nom, double precioC, double precioV, int id)
        {
            if (band_materia_prima)
            {
                tbCodigoMP.Text = cod;
                tbNombreMP.Text = nom;
                id_materia_prima = id;
                cargar_cantidad(cbDepositoMP.SelectedValue.ToString(), id_materia_prima.ToString());
            }
            else
            {
                tbCodigoF.Text = cod;
                tbProductoF.Text = nom;
                id_producto_fabricacion = id;
            }
        }
        //Fin Region

        private void producto_agregar(int tipo_producto)
        {
            frmProductos producto = new frmProductos();
            producto.Hijo = true;
            producto.Tipo_Form = tipo_producto;
            producto.ShowDialog(this);
            producto = null;
            if (tipo_producto == 1)
                cbDepositoMP.Focus();
            else
                cbDepositoF.Focus();
        }

        private void cargar_cantidad(string deposito, string producto)
        {
            if (band_inicio)
            {
                DataRow[] res;
                string expresion = "id_deposito=" + deposito + " AND id_producto=" + producto;
                res = ds.Tables["stocks"].Select(expresion);
                if (res.Length > 0)
                {
                    tbExistente.Text = res[0].ItemArray[2].ToString();
                }
                else
                {
                    tbExistente.Text = "0";
                }
            }
        }

        private void guardar()
        {
            con = new NpgsqlConnection(frmInicio.strConexion);
            try
            {
                con.Open();
                NpgsqlTransaction t = con.BeginTransaction();

                string query = "INSERT INTO procesos_fabricacion(id_deposito,id_producto,fecha_hora) values(" + cbDepositoMP.SelectedValue + "," + id_materia_prima + ",'" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:00") + "');" + classFunciones.agregar_evento("[FABRICACIONES] Nuevo registro",true);
                NpgsqlCommand command = new NpgsqlCommand(query, con);
                command.ExecuteNonQuery();

                foreach (DataGridViewRow fila in dataGridView1.Rows)
                {
                    query = "SELECT MAX(id_proceso_fabricacion) from procesos_fabricacion";
                    command = new NpgsqlCommand(query, con);
                    int id_proceso_fabricacion = (int)command.ExecuteScalar();

                    query = "INSERT INTO fabricaciones_detalles(id_proceso_fabricacion,id_deposito,id_producto,cantidad) VALUES(" + id_proceso_fabricacion + "," + Convert.ToInt32(fila.Cells["ID_DEP"].Value) + "," + Convert.ToInt32(fila.Cells["ID"].Value) + "," + classFunciones.eliminarComa(fila.Cells["Cant"].Value.ToString()) + ")";
                    command = new NpgsqlCommand(query, con);
                    command.ExecuteNonQuery();
                }
                t.Commit();
                MessageBox.Show("Fabricación Exitosa", "LunaSoft :: Fabricaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            string[] fila = new string[] { id_producto_fabricacion.ToString(), cbDepositoF.SelectedValue.ToString(), tbCantidadF.Text, tbProductoF.Text, cbDepositoF.Text };
            dataGridView1.Rows.Add(fila);
            tbCantidadF.Text = "1";            
            tbCodigoF.Text = "";
            tbProductoF.Text = "";
            tbCantidadF.Focus();
            //formatear_datagrid();
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            guardar();
            this.Close();
        }

        private void btSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmFabricacionAgregar_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (char)Keys.Escape:
                    this.Close();
                    break;
                case (char)Keys.F2:
                    if (band_materia_prima)
                        producto_agregar(1);
                    if (band_producto_fabricacion)
                        producto_agregar(3);
                    break;
                case (char)Keys.F10:
                    guardar();
                    this.Close();
                    break;
                case (char)Keys.F9:
                    //guardar_agregar();
                    break;
            }
        }

        private void tbCodigoMP_Enter(object sender, EventArgs e)
        {
            band_materia_prima = true;
        }

        private void tbCodigoMP_Leave(object sender, EventArgs e)
        {
            band_materia_prima = false;
        }

        private void tbCodigoF_Leave(object sender, EventArgs e)
        {
            band_producto_fabricacion = false;
        }

        private void tbCodigoF_Enter(object sender, EventArgs e)
        {
            band_producto_fabricacion = true;
        }

        private void tbCantidadF_Enter(object sender, EventArgs e)
        {
            band_producto_fabricacion = true;
        }

        private void tbCantidadF_Leave(object sender, EventArgs e)
        {
            band_producto_fabricacion = false;
        }

        private void frmFabricacionAgregar_Load(object sender, EventArgs e)
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
                cbDepositoF.DataSource = ds.Tables["depositos"];
                cbDepositoF.DisplayMember = "nombre";
                cbDepositoF.ValueMember = "id_deposito";
                cbDepositoMP.DataSource = ds.Tables[0].DefaultView;
                cbDepositoMP.DisplayMember = "nombre";
                cbDepositoMP.ValueMember = "id_deposito";

                // Cargo en DS[1] Tabla Stocks
                query = "SELECT id_producto,id_deposito,existencia FROM stocks";
                command = new NpgsqlCommand(query, con);
                da = new NpgsqlDataAdapter(command);
                da.Fill(ds, "stocks");
                band_inicio = true;
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

        private void cbDepositoMP_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargar_cantidad(cbDepositoMP.SelectedValue.ToString(), id_materia_prima.ToString());
            tbCantidadF.Focus();
        }

        private void lblBuscarP_Click(object sender, EventArgs e)
        {
            producto_agregar(1);
        }

        private void lblCodigoP_Click(object sender, EventArgs e)
        {
            producto_agregar(0);
        }

        private void tbCantidadF_KeyPress(object sender, KeyPressEventArgs e)
        {
            int isNum = 0;

            if (e.KeyChar == ',' || e.KeyChar == (char)Keys.Back)
                e.Handled = false;
            else if (!int.TryParse(e.KeyChar.ToString(), out isNum))
                e.Handled = true;
        }

        private void tbCodigoMP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                DataSet ds = new DataSet();
                con = new NpgsqlConnection(frmInicio.strConexion);
                try
                {
                    con.Open();
                    string query = "SELECT id_producto, nombre FROM productos WHERE codigo = '" + tbCodigoMP.Text + "'";
                    NpgsqlCommand command = new NpgsqlCommand(query, con);
                    NpgsqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        id_materia_prima = Convert.ToInt32(dr["id_producto"]);
                        tbNombreMP.Text = dr["nombre"].ToString();
                        cargar_cantidad(cbDepositoMP.SelectedValue.ToString(), id_materia_prima.ToString());
                        cbDepositoMP.Focus();
                    }
                    else
                    {
                        MessageBox.Show("No existe Producto.", "LunaSoft :: Ventas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbCodigoMP.Focus();
                        tbNombreMP.Text = "";
                        id_materia_prima = 0;
                    }
                }
                catch (NpgsqlException error)
                {
                    MessageBox.Show(error.Message, "LunaSoft :: ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tbCodigoF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                DataSet ds = new DataSet();
                con = new NpgsqlConnection(frmInicio.strConexion);
                try
                {
                    con.Open();
                    string query = "SELECT id_producto, nombre FROM productos WHERE codigo = '" + tbCodigoF.Text + "'";
                    NpgsqlCommand command = new NpgsqlCommand(query, con);
                    NpgsqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        id_producto_fabricacion = Convert.ToInt32(dr["id_producto"]);
                        tbProductoF.Text = dr["nombre"].ToString();
                        cargar_cantidad(cbDepositoF.SelectedValue.ToString(), id_producto_fabricacion.ToString());
                        cbDepositoF.Focus();
                    }
                    else
                    {
                        MessageBox.Show("No existe Producto.", "LunaSoft :: Ventas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbCodigoF.Focus();
                        tbProductoF.Text = "";
                        id_producto_fabricacion = 0;
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
