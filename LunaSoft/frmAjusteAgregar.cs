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
    public partial class frmAjusteAgregar : Form, IFormProducto
    {
        private int id_producto;
        bool band_inicio = false;
        bool cargar_tipo_ajuste = false;
        NpgsqlConnection con;
        NpgsqlDataAdapter da;
        DataSet ds;
        DataView dv;
        string ultimo_deposito;

        public frmAjusteAgregar()
        {
            InitializeComponent();
        }

        //Region IFormProducto
        public void cargarDatosProducto(string cod, string nom, double precioC, double precioV, int id)
        {
            id_producto = id;
            tbNombreP.Text = nom;
            tbCodigoP.Text = cod;
            cargar_cantidad(ultimo_deposito, id_producto.ToString());
        }
        //Fin Region

        private void cargar_cantidad(string deposito, string producto)
        {
            if (band_inicio)
            {
                con = new NpgsqlConnection(frmInicio.strConexion);
                try
                {
                    con.Open();
                    DataSet ds2 = new DataSet();
                    string query = "";
                    NpgsqlCommand command;
                    query = "SELECT d.id_deposito as \"ID\",d.nombre as \"Nombre\",s.existencia as \"Cant\" FROM depositos d, stocks s WHERE d.id_deposito = s.id_deposito AND s.id_producto =" + producto + " ORDER BY d.id_deposito";
                    command = new NpgsqlCommand(query, con);
                    da = new NpgsqlDataAdapter(command);
                    da.Fill(ds2);
                    dv = ds2.Tables[0].DefaultView;
                    dataGridView1.DataSource = dv;
                }
                catch (NpgsqlException error)
                {
                    MessageBox.Show(error.Message, "LunaSoft :: ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    formatear_datagrid();
                    con.Close();
                }
            }
        }

        private void formatear_datagrid()
        {
            // Columnas Alineacion Derecha
            dataGridView1.Columns["Cant"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            // Columnas Invisibles
            dataGridView1.Columns["ID"].Visible = false;
            // El ancho de la Columna se establece por el contenido
            dataGridView1.Columns["Cant"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            // Formato Numerico
            dataGridView1.Columns["Cant"].DefaultCellStyle.Format = "n0";


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

        private void guardar_agregar()
        {
            guardar();
            //limpiar();
            cargar_cantidad(ultimo_deposito, id_producto.ToString());
            tbCantAjuste.ResetText();
            //tbCodigoP.
            tbCodigoP.Focus();
        }

        private void guardar_cerrar()
        {
            if (guardar())
                this.Close();
        }

        private void limpiar()
        {
            tbCodigoP.Text = "";
            tbNombreP.Text = "";
            tbCantAjuste.Text = "";
            tbMotivo.Text = "";
            dataGridView1.DataSource = null;
        }

        private bool guardar()
        {
            bool ret = true;
            con = new NpgsqlConnection(frmInicio.strConexion);
            try
            {
                con.Open();
                string query = "INSERT INTO ajustes(id_tipo_ajuste,id_deposito,id_producto,fecha,cantidad,descripcion) VALUES(" + cbTipo.SelectedValue.ToString() + "," + cbDeposito.SelectedValue.ToString() + "," + id_producto + ",'" + DateTime.Now.ToString("yyyy-MM-dd") + "'," + classFunciones.eliminarComa(tbCantAjuste.Text) + ",'" + tbMotivo.Text + "');" + classFunciones.agregar_evento("[AJUSTES] Nuevo registro", true); 
                NpgsqlCommand command = new NpgsqlCommand(query, con);
                command.ExecuteScalar();
            }
            catch (NpgsqlException error)
            {
                ret = false;
                MessageBox.Show(error.Message, "LunaSoft :: ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ultimo_deposito = cbDeposito.SelectedValue.ToString();
                con.Close();
            }
            return ret;
        }


        private void cargar_datos()
        {
            ds = new DataSet();
            con = new NpgsqlConnection(frmInicio.strConexion);
            try
            {
                con.Open();
                string query = "";
                NpgsqlCommand command;
                if (!cargar_tipo_ajuste)
                {
                    // Cargo en DS[0] Tabla Depositos
                    query = "SELECT id_deposito,nombre FROM depositos ORDER BY id_deposito";
                    command = new NpgsqlCommand(query, con);
                    da = new NpgsqlDataAdapter(command);
                    da.Fill(ds, "depositos");
                    cbDeposito.DataSource = ds.Tables["depositos"];
                    cbDeposito.DisplayMember = "nombre";
                    cbDeposito.ValueMember = "id_deposito";
                    /*
                    // Cargo en DS[1] Tabla Stocks
                    query = "SELECT id_producto,id_deposito,existencia FROM stocks";
                    command = new NpgsqlCommand(query, con);
                    da = new NpgsqlDataAdapter(command);
                    da.Fill(ds, "stocks");
                     */ 
                    band_inicio = true;
                     
                }
                // Cargo en cbTipo Tabla tipos_ajustes
                query = "SELECT id_tipo_ajuste,nombre FROM tipos_ajustes WHERE estado='1'";
                command = new NpgsqlCommand(query, con);
                da = new NpgsqlDataAdapter(command);
                da.Fill(ds, "tipos");
                cbTipo.DataSource = ds.Tables["tipos"];
                cbTipo.DisplayMember = "nombre";
                cbTipo.ValueMember = "id_tipo_ajuste";
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

        private void frmAjusteAgregar_Load(object sender, EventArgs e)
        {
            cargar_datos();
            ultimo_deposito = cbDeposito.SelectedValue.ToString();
        }

        private void frmAjusteAgregar_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (char)Keys.Escape:
                    this.Close();
                    break;
                case (char)Keys.F2:
                    producto_agregar();
                    break;
                case (char)Keys.F9:
                    guardar_agregar();
                    break;
                case (char)Keys.F10:
                    guardar_cerrar();
                    break;
            }
        }

        private void cbDeposito_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargar_cantidad(cbDeposito.SelectedValue.ToString(), id_producto.ToString());
        }

        private void lblBuscarP_Click(object sender, EventArgs e)
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

        private void tbCantAjuste_KeyPress(object sender, KeyPressEventArgs e)
        {
            int isNum = 0;

            if (e.KeyChar == '-' || e.KeyChar == ',' || e.KeyChar == (char)Keys.Back)
                e.Handled = false;
            else if (!int.TryParse(e.KeyChar.ToString(), out isNum))
                e.Handled = true;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            frmTipoAjusteAgregar agregar_tipo_ajuste = new frmTipoAjusteAgregar();
            agregar_tipo_ajuste.ShowDialog();
            agregar_tipo_ajuste = null;
            cargar_tipo_ajuste = true;
            cargar_datos();
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
                        cargar_cantidad(cbDeposito.SelectedValue.ToString(), id_producto.ToString());
                        cbDeposito.Focus();
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

        private void btRefrescar_Click(object sender, EventArgs e)
        {
            guardar_agregar();
        }

        private void btLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

       
    }
}
