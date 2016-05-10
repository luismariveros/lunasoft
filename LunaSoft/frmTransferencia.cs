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
    public partial class frmTransferencia : Form, IFormProducto
    {
        private int id_producto;
        bool band_inicio = false;
        NpgsqlConnection con;
        NpgsqlDataAdapter da;
        DataSet ds;

        public frmTransferencia()
        {
            InitializeComponent();
        }

        //Region IFormProducto
        public void cargarDatosProducto(string cod, string nom, double precioC, double precioV, int id)
        {
            id_producto = id;
            tbNombreP.Text = nom;
            tbCodigoP.Text = cod;
            cargar_cantidad(cbOrigen.SelectedValue.ToString(), id_producto.ToString());
        }
        //Fin Region

        private void cargar_cantidad(string deposito,string producto)
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

        private void producto_agregar()
        {
            frmProductos producto = new frmProductos();
            producto.Hijo = true;
            producto.Tipo_Form = 1;
            producto.ShowDialog(this);
            producto = null;
            tbCantidad.Focus();
        }

        private void lblBuscarF_Click(object sender, EventArgs e)
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

        private void frmTransferencia_Load(object sender, EventArgs e)
        {
            ds = new DataSet();
            con = new NpgsqlConnection(frmInicio.strConexion);
            try
            {
                con.Open();
                
                // Cargo en DS[0] Tabla Depositos
                string query = "SELECT id_deposito,nombre FROM depositos ORDER BY id_deposito";
                NpgsqlCommand command = new NpgsqlCommand(query, con);
                da = new NpgsqlDataAdapter(command);
                da.Fill(ds,"depositos");
                cbOrigen.DataSource = ds.Tables["depositos"];
                cbOrigen.DisplayMember = "nombre";
                cbOrigen.ValueMember = "id_deposito";
                cbDestino.DataSource = ds.Tables[0].DefaultView;
                cbDestino.DisplayMember = "nombre";
                cbDestino.ValueMember = "id_deposito";

                // Cargo en DS[1] Tabla Stocks
                query = "SELECT id_producto,id_deposito,existencia FROM stocks";
                command = new NpgsqlCommand(query, con);
                da = new NpgsqlDataAdapter(command);
                da.Fill(ds,"stocks");
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

        private void cbOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargar_cantidad(cbOrigen.SelectedValue.ToString(), id_producto.ToString());
            cbDestino.Focus();
        }

        private void frmTransferencia_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (char)Keys.Escape:
                    this.Close();
                    break;
                case (char)Keys.F2:
                    producto_agregar();
                    break;
                case (char)Keys.F10:
                    guardar();
                    this.Close();
                    break;
            }
        }

        private void guardar()
        {
            con = new NpgsqlConnection(frmInicio.strConexion);
            try
            {
                con.Open();
                string query = "INSERT INTO transferencias(id_dep_origen,id_dep_destino,id_producto,cantidad,fecha_hora) VALUES(" + cbOrigen.SelectedValue.ToString() + "," + cbDestino.SelectedValue.ToString() + "," + id_producto + "," + classFunciones.eliminarComa(tbCantidad.Text) + ",'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:00") + "');" + classFunciones.agregar_evento("[TRANSFERENCIAS] Nuevo registro",true);
                NpgsqlCommand command = new NpgsqlCommand(query, con);
                command.ExecuteScalar();
                MessageBox.Show("Transferencia Exitosa", "LunaSoft :: Transferencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void cbDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbCantidad.Focus();
        }

        private void tbCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            int isNum = 0;

            if (e.KeyChar == ',' || e.KeyChar == (char)Keys.Back)
                e.Handled = false;
            else if (!int.TryParse(e.KeyChar.ToString(), out isNum))
                e.Handled = true;
        }

        private void tbCodigoP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                DataSet ds = new DataSet();
                con = new NpgsqlConnection(frmInicio.strConexion);
                try
                {
                    con.Open();
                    string query = "SELECT id_producto, nombre FROM productos WHERE codigo = '" + tbCodigoP.Text + "'";
                    NpgsqlCommand command = new NpgsqlCommand(query, con);
                    NpgsqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        id_producto = Convert.ToInt32(dr["id_producto"]);
                        tbNombreP.Text = dr["nombre"].ToString();
                        cargar_cantidad(cbOrigen.SelectedValue.ToString(), id_producto.ToString());
                        cbOrigen.Focus();
                    }
                    else
                    {
                        MessageBox.Show("No existe Producto.", "LunaSoft :: Ventas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbCodigoP.Focus();
                        tbNombreP.Text = "";
                        id_producto = 0;
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
