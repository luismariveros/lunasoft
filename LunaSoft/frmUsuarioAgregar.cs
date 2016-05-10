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
    public partial class frmUsuarioAgregar : Form
    {
        NpgsqlConnection con;

        public frmUsuarioAgregar()
        {
            InitializeComponent();
        }

        private void guardar_agregar()
        {
            guardar();
            limpiar();
            tbUsuario.Focus();
        }

        private void guardar()
        {
            if (tbUsuario.Text == "" || tbContrasena.Text == "")
            {
                MessageBox.Show("No puede haber campos vacios", "LunaSoft :: ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            int nivel = 0;
            if (this.ckbAdministrador.Checked)
                nivel = 1;
            
            con = new NpgsqlConnection(frmInicio.strConexion);
            try
            {
                con.Open();
                string query = "INSERT INTO usuarios(nombre,password,id_nivel_usuario) values('" + tbUsuario.Text + "', '" + tbContrasena.Text + "'," + nivel + ");" + classFunciones.agregar_evento("[USUARIOS] Se agrego nuevo usuario:" + tbUsuario.Text, true);
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

        private void limpiar()
        {
            tbUsuario.Text = "";
            tbContrasena.Text = "";
        }

        private void btSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            guardar();
        }

        private void btRefrescar_Click(object sender, EventArgs e)
        {
            guardar_agregar();
        }

        private void frmUsuarioAgregar_KeyDown(object sender, KeyEventArgs e)
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
    }
}
