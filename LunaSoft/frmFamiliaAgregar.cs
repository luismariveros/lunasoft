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
    public partial class frmFamiliaAgregar : Form
    {
        NpgsqlConnection con;

        public frmFamiliaAgregar()
        {
            InitializeComponent();
        }

        private void frmFamiliaAgregar_KeyDown(object sender, KeyEventArgs e)
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
                case (char)Keys.F9:
                    guardar_agregar();
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

        private void guardar_agregar()
        {
            guardar();
            limpiar();
            tbCodigo.Focus();
        }

        private void guardar()
        {
            con = new NpgsqlConnection(frmInicio.strConexion);
            try
            {
                con.Open();
                string query = "INSERT INTO familias(codigo,descripcion) values('" + tbCodigo.Text + "', '" + tbDescripcion.Text + "');" + classFunciones.agregar_evento("[FAMILIAS] Se agrego nueva familia", true);
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
        }

        private void limpiar()
        {
            tbCodigo.Text = "";
            tbDescripcion.Text = "";
        }
    }
}
