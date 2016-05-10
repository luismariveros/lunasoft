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
    public partial class frmFamiliaModificar : Form
    {
        NpgsqlConnection con;
        private DataTable dt;
        private int indice;
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

        public frmFamiliaModificar()
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

        private void guardar()
        {
            con = new NpgsqlConnection(frmInicio.strConexion);
            try
            {
                con.Open();
                string query = "UPDATE familias SET descripcion = '" + tbDescripcion.Text + "' WHERE codigo = '" + tbCodigo.Text + "';" + classFunciones.agregar_evento("[FAMILIAS] Actualización de un registro", true);
                NpgsqlCommand command = new NpgsqlCommand(query, con);
                command.ExecuteNonQuery();
            }
            catch (NpgsqlException error)
            {
                MessageBox.Show(error.Message,"LunaSoft :: ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void primero()
        {
            tbCodigo.Text = dt.Rows[0].ItemArray[dt.Columns["Código"].Ordinal].ToString();
            tbDescripcion.Text = dt.Rows[0].ItemArray[dt.Columns["Descripción"].Ordinal].ToString();
            indice = 0;
        }

        private void ultimo()
        {
            tbCodigo.Text = dt.Rows[i_last].ItemArray[dt.Columns["Código"].Ordinal].ToString();
            tbDescripcion.Text = dt.Rows[i_last].ItemArray[dt.Columns["Descripción"].Ordinal].ToString();
            indice = i_last;
        }

        private void anterior()
        {
            int i = i_anterior();
            tbCodigo.Text = dt.Rows[i].ItemArray[dt.Columns["Código"].Ordinal].ToString();
            tbDescripcion.Text = dt.Rows[i].ItemArray[dt.Columns["Descripción"].Ordinal].ToString();
        }

        private void siguiente()
        {
            int i = i_siguiente();
            tbCodigo.Text = dt.Rows[i].ItemArray[dt.Columns["Código"].Ordinal].ToString();
            tbDescripcion.Text = dt.Rows[i].ItemArray[dt.Columns["Descripción"].Ordinal].ToString();
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

        private void frmFamiliaModificar_Load(object sender, EventArgs e)
        {
            tbCodigo.Text = dt.Rows[indice].ItemArray[dt.Columns["Código"].Ordinal].ToString();
            tbDescripcion.Text = dt.Rows[indice].ItemArray[dt.Columns["Descripción"].Ordinal].ToString();
            i_last = dt.Rows.Count - 1;
        }

        private void frmFamiliaModificar_KeyDown(object sender, KeyEventArgs e)
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
