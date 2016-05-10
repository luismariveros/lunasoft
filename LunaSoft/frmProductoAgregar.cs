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
    public partial class frmProductoAgregar : Form, IForm
    {
        bool band_familia = false; // Bandera para saber si esta activo tbCodigoF
        private int id_familia;
        NpgsqlConnection con;
        NpgsqlDataAdapter da;

        public frmProductoAgregar()
        {
            InitializeComponent();
        }
        
        //Region IForm
        public void cargarDatosFamilia(string c, string d, int id)
        {
            tbCodigoF.Text = c;
            tbDescripcionF.Text = d;
            id_familia = id;
        }
        //Fin Region

        private void familia_agregar()
        {
            frmFamilias familias = new frmFamilias();
            familias.Hijo = true;
            familias.ShowDialog(this);
            familias = null;  
        }

        private void guardar()
        {
            con = new NpgsqlConnection(frmInicio.strConexion);
            int id_producto;
            string query;
            
            if (tbCodigoF.Text == "")
                id_familia = 1; // 1=Familia General
            if (tbStock.Text == "")
                tbStock.Text = "1";
            
            try
            {
                con.Open();
                if (tbCompra.Text != "" && tbVenta.Text != "")
                    query = "INSERT INTO productos(codigo,nombre,stock_minimo,unidad,precio_promedio_compra,precio_venta,observacion,id_familia) values('" + tbCodigo.Text + "', '" + tbNombre.Text + "', " + classFunciones.eliminarComa(tbStock.Text) + ", '" + cmbUnidad.SelectedItem.ToString() + "', " + Convert.ToDouble(tbCompra.Text) + ", " + Convert.ToDouble(tbVenta.Text) + ", '" + tbObservacion.Text.ToString() + "', " + id_familia + ");" + classFunciones.agregar_evento("[PRODUCTOS] Se agrego nuevo producto",true);
                else
                {
                    if (tbCompra.Text == "" && tbVenta.Text == "")
                        query = "INSERT INTO productos(codigo,nombre,stock_minimo,unidad,observacion,id_familia) values('" + tbCodigo.Text + "', '" + tbNombre.Text + "', " + classFunciones.eliminarComa(tbStock.Text) + ", '" + cmbUnidad.SelectedItem.ToString() + "', '" + tbObservacion.Text.ToString() + "', " + id_familia + ");" + classFunciones.agregar_evento("[PRODUCTOS] Se agrego nuevo producto", true);
                    else
                    {
                        if (tbCompra.Text != "")
                            query = "INSERT INTO productos(codigo,nombre,stock_minimo,unidad,precio_promedio_compra,observacion,id_familia) values('" + tbCodigo.Text + "', '" + tbNombre.Text + "', " + classFunciones.eliminarComa(tbStock.Text) + ", '" + cmbUnidad.SelectedItem.ToString() + "', " + Convert.ToDouble(tbCompra.Text) + ", '" + tbObservacion.Text.ToString() + "', " + id_familia + ");" + classFunciones.agregar_evento("[PRODUCTOS] Se agrego nuevo producto", true);
                        else
                            query = "INSERT INTO productos(codigo,nombre,stock_minimo,unidad,precio_venta,observacion,id_familia) values('" + tbCodigo.Text + "', '" + tbNombre.Text + "', " + classFunciones.eliminarComa(tbStock.Text) + ", '" + cmbUnidad.SelectedItem.ToString() + "', " + Convert.ToDouble(tbVenta.Text) + ", '" + tbObservacion.Text.ToString() + "', " + id_familia + ");" + classFunciones.agregar_evento("[PRODUCTOS] Se agrego nuevo producto", true);
                    }
                }
                
                NpgsqlCommand command = new NpgsqlCommand(query, con);
                
                command.ExecuteNonQuery();
            }
            catch (NpgsqlException error)
            {
                switch (error.Code)
                {
                    case "23505":
                        MessageBox.Show("Registro Duplicado.\n\nYa existe un registro con el mismo Código", "LunaSoft :: ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    default:
                        MessageBox.Show(error.Message, "LunaSoft :: ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            finally
            {
                con.Close();
            }

            // BORRAR
            if (tbCant1.Text != "")
            {
                try
                {
                    con.Open();
                    query = "SELECT id_producto FROM productos WHERE codigo='" + tbCodigo.Text + "'";
                    NpgsqlCommand command = new NpgsqlCommand(query, con);
                    id_producto = (int)command.ExecuteScalar();

                    query = "INSERT INTO stocks(id_producto,id_deposito,existencia) VALUES(" + id_producto + ", " + (comboBox1.SelectedIndex + 1) + ", " + classFunciones.eliminarComa(tbCant1.Text) + ");" + classFunciones.agregar_evento("[STOCKS] Se agrego stock inicial a un producto", true);
                    command = new NpgsqlCommand(query, con);
                    command.ExecuteNonQuery();
                    //query = "UPDATE stocks SET id_producto="
                    if (tbCant2.Text != "")
                    {
                        query = "INSERT INTO stocks(id_producto,id_deposito,existencia) VALUES(" + id_producto + ", " + (comboBox2.SelectedIndex + 1) + ", " + classFunciones.eliminarComa(tbCant2.Text) + ");" + classFunciones.agregar_evento("[STOCKS] Se agrego stock inicial a un producto", true);
                        command = new NpgsqlCommand(query, con);
                        command.ExecuteNonQuery();
                    }
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
            // HASTA AQUI
        }

        private void limpiar()
        {
            tbCodigo.Text = "";
            tbNombre.Text = "";
            tbCodigoF.Text = "";
            tbDescripcionF.Text = "";
            tbStock.Text = "";
            tbVenta.Text = "";
            tbCompra.Text = "";
            cmbUnidad.Text = "";
            tbObservacion.Text = "";
        }

        private void guardar_agregar()
        {
            guardar();
            limpiar();
            tbCodigo.Focus();
        }     

        private void tbCodigoF_Enter(object sender, EventArgs e)
        {
            band_familia = true;
        }

        private void tbCodigoF_Leave(object sender, EventArgs e)
        {
            band_familia = false;
        }

        private void frmProductoAgregar_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (char)Keys.Escape:
                    this.Close();
                    break;
                case (char)Keys.F2:
                    if (band_familia)
                        familia_agregar();
                    break;
                case (char)Keys.F9:
                    guardar_agregar();
                    break;
                case (char)Keys.F10:
                    guardar();
                    this.Close();
                    break;
            }
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
            guardar_agregar();
        }

        // tbVenta, tbCompra, tbStock tiene el mismo evento
        private void tbVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Back))
                return;
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
                e.Handled = true;
        }

        
        private void frmProductoAgregar_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            con = new NpgsqlConnection(frmInicio.strConexion);
            try
            {
                con.Open();
                string query = "SELECT nombre FROM depositos ORDER BY id_deposito";
                NpgsqlCommand command = new NpgsqlCommand(query, con);
                da = new NpgsqlDataAdapter(command);
                da.Fill(ds);
                comboBox1.DataSource = ds.Tables[0];
                comboBox1.DisplayMember = "nombre";
                comboBox2.DataSource = ds.Tables[0].DefaultView;
                comboBox2.DisplayMember = "nombre";
                comboBox2.SelectedIndex = 1;
            }
            catch (NpgsqlException error)
            {
                MessageBox.Show(error.Message, "LunaSoft :: ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
            cmbUnidad.Text = cmbUnidad.Items[0].ToString();
        }

        

        private void lblBuscarF_Click(object sender, EventArgs e)
        {
            familia_agregar();
        }

        private void tbStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            int isNum = 0;

            if (e.KeyChar == ',' || e.KeyChar == (char)Keys.Back)
                e.Handled = false;
            else if (!int.TryParse(e.KeyChar.ToString(), out isNum))
                e.Handled = true;
        }

        // Evento para tbCant1 y tbCant2
        private void tbCant1_KeyPress(object sender, KeyPressEventArgs e)
        {
            int isNum = 0;

            if (e.KeyChar == ',' || e.KeyChar == (char)Keys.Back)
                e.Handled = false;
            else if (!int.TryParse(e.KeyChar.ToString(), out isNum))
                e.Handled = true;
        }
    }
}
