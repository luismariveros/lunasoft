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
    public partial class frmClienteModificar : Form
    {
        NpgsqlConnection con;
        private DataTable dt;
        private int indice;
        int i_last;
        public bool tipo = false; // false->cliente, true->proveedor

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

        public frmClienteModificar()
        {
            InitializeComponent();
        }

        private void guardar()
        {
            con = new NpgsqlConnection(frmInicio.strConexion);
            try
            {
                con.Open();
                string query;
                if(tipo)
                    query = "UPDATE proveedores SET nombre='" + tbNombre.Text + "',direccion='" + tbDireccion.Text + "', mail='" + tbMail.Text + "', telefono='" + tbTelefono.Text + "', celular='" + tbCelular.Text + "',contacto='" + tbContacto.Text + "'  WHERE id_proveedor= " + dt.Rows[indice].ItemArray[dt.Columns["ID"].Ordinal] + ";" + classFunciones.agregar_evento("[PROVEEDORES] Actualización de un registro", true);
                else
                    query = "UPDATE clientes SET nombre='" + tbNombre.Text + "',direccion='" + tbDireccion.Text + "', mail='" + tbMail.Text + "', telefono='" + tbTelefono.Text + "', celular='" + tbCelular.Text + "',contacto='" + tbContacto.Text + "'  WHERE id_cliente= " + dt.Rows[indice].ItemArray[dt.Columns["ID"].Ordinal] + ";" + classFunciones.agregar_evento("[DEPOSITOS] Actualización de un registro", true); 
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

        private void mostrar(int i)
        {
            tbNombre.Text = dt.Rows[i].ItemArray[dt.Columns["Nombre"].Ordinal].ToString();
            tbDireccion.Text = dt.Rows[i].ItemArray[dt.Columns["Dirección"].Ordinal].ToString();
            tbCedula.Text = dt.Rows[i].ItemArray[dt.Columns["Cédula_RUC"].Ordinal].ToString();
            tbCelular.Text = dt.Rows[i].ItemArray[dt.Columns["Celular"].Ordinal].ToString();
            tbMail.Text = dt.Rows[i].ItemArray[dt.Columns["Mail"].Ordinal].ToString();
            tbTelefono.Text = dt.Rows[i].ItemArray[dt.Columns["Teléfono"].Ordinal].ToString();
            tbContacto.Text = dt.Rows[i].ItemArray[dt.Columns["Contacto"].Ordinal].ToString();
        }

        private void frmClienteModificar_Load(object sender, EventArgs e)
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

        private void btAceptar_Click(object sender, EventArgs e)
        {
            guardar();
            this.Close();
        }

        private void btSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmClienteModificar_KeyDown(object sender, KeyEventArgs e)
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
            }
        }

    }
}
