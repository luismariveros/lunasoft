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
    public partial class frmProductoModificar : Form, IForm
    {
        bool band_familia = false; // Bandera para saber si esta activo tbCodigoF
        NpgsqlConnection con;
        private DataTable dt;
        private int indice, id_familia,id_producto;
        int i_last;

        public int Indice
        {
            set
            {
                indice = value;
            }
        }

        public DataTable DT
        {
            set
            {
                dt = value;
            }
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

        public frmProductoModificar()
        {
            InitializeComponent();
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
     
        private void guardar()
        {
            con = new NpgsqlConnection(frmInicio.strConexion);
            
            if (tbCodigoF.Text == "")
                id_familia = 1; // 1=Familia General
            if (tbStock.Text == "")
                tbStock.Text = "1";
            
            try
            {
                con.Open();
                string query = "UPDATE productos SET codigo ='" + tbCodigo.Text + "', nombre = '" + tbNombre.Text + "', stock_minimo=" + classFunciones.eliminarComa(tbStock.Text) + ", unidad='" + cmbUnidad.SelectedItem.ToString() + "', precio_promedio_compra=" + Convert.ToDouble(tbCompra.Text) + ", precio_venta=" + Convert.ToDouble(tbVenta.Text) + ", observacion = '" + tbObservacion.Text.ToString() + "', id_familia =" + id_familia + " WHERE id_producto = '" + id_producto + "';" + classFunciones.agregar_evento("[PRODUCTOS] Actualización de producto con codigo:"+tbCodigo.Text, true);
                NpgsqlCommand command = new NpgsqlCommand(query, con);
                command.ExecuteNonQuery();
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

        private void mostrar(int indice)
        {
            tbCodigo.Text = dt.Rows[indice].ItemArray[dt.Columns["Código"].Ordinal].ToString();
            tbNombre.Text = dt.Rows[indice].ItemArray[dt.Columns["Nombre"].Ordinal].ToString();
            tbVenta.Text = dt.Rows[indice].ItemArray[dt.Columns["Precio Venta"].Ordinal].ToString();
            tbCompra.Text = dt.Rows[indice].ItemArray[dt.Columns["Precio Compra"].Ordinal].ToString();
            tbStock.Text = dt.Rows[indice].ItemArray[dt.Columns["Stock Minimo"].Ordinal].ToString();
            cmbUnidad.Text = dt.Rows[indice].ItemArray[dt.Columns["Unidad"].Ordinal].ToString();
            tbCodigoF.Text = dt.Rows[indice].ItemArray[dt.Columns["CodigoF"].Ordinal].ToString();
            tbDescripcionF.Text = dt.Rows[indice].ItemArray[dt.Columns["Familia"].Ordinal].ToString();
            tbObservacion.Text = dt.Rows[indice].ItemArray[dt.Columns["Observación"].Ordinal].ToString();
            id_familia = Convert.ToInt32(dt.Rows[indice].ItemArray[dt.Columns["IDFAMILIA"].Ordinal]);
            id_producto = Convert.ToInt32(dt.Rows[indice].ItemArray[dt.Columns["ID"].Ordinal]);
        }

        private void primero()
        {
            mostrar(0);
            indice = 0;
        }

        private void ultimo()
        {
            mostrar(i_last);
            indice = i_last;
        }

        private void anterior()
        {
            int i = i_anterior();
            mostrar(i);
        }

        private void siguiente()
        {
            int i = i_siguiente();
            mostrar(i);
        }

        private int i_anterior()
        {
            if (indice == 0)
                indice = i_last;
            else
                indice--;
            return indice;
        }

        private int i_siguiente()
        {
            if (indice == i_last)
                indice = 0;
            else
                indice++;
            return indice;
        }

        private void frmProductoModificar_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (char)Keys.Escape:
                    this.Close();
                    break;
                case (char)Keys.F10:
                    guardar();
                    this.Close();
                    break;
                case (char)Keys.F8:
                    ultimo();
                    break;
                case (char)Keys.F7:
                    siguiente();
                    break;
                case (char)Keys.F6:
                    anterior();
                    break;
                case (char)Keys.F5:
                    primero();
                    break;
                case (char)Keys.F2:
                    if (band_familia)
                        familia_agregar();
                    break;
            }
        }

        private void frmProductoModificar_Load(object sender, EventArgs e)
        {
            mostrar(indice);
            i_last = dt.Rows.Count - 1;
        }

        private void btPrimero_Click(object sender, EventArgs e)
        {
            primero();
        }

        private void btAnterior_Click(object sender, EventArgs e)
        {
            anterior();
        }

        private void btSiguiente_Click(object sender, EventArgs e)
        {
            siguiente();
        }

        private void btUltimo_Click(object sender, EventArgs e)
        {
            ultimo();
        }

        private void lblBuscarF_Click(object sender, EventArgs e)
        {
            familia_agregar();
        }

        private void tbCodigoF_Enter(object sender, EventArgs e)
        {
            band_familia = true;
        }

        private void tbCodigoF_Leave(object sender, EventArgs e)
        {
            band_familia = false;
        }
    }
}
