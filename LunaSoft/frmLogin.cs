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
    public partial class frmLogin : Form
    {
        NpgsqlConnection con;
        public bool es_hijo = false;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btIngresar_Click(object sender, EventArgs e)
        {
            NpgsqlCommand command;
            NpgsqlDataReader dr;
            string query = "";

            con = new NpgsqlConnection(frmInicio.strConexion);
            bool hubo_error = false;
            
            /*
            if (tbUsuario.Text == string.Empty)
            {
                tbUsuario.Text = "admin";
                tbContrasena.Text = "admin";
            }
            */
            try
            {
                con.Open();
                query = "SELECT u.nombre,u.id_usuario,nu.nivel FROM usuarios u inner join niveles_usuarios nu using (id_nivel_usuario) WHERE u.nombre='" + tbUsuario.Text + "' AND u.password='" + tbContrasena.Text + "' AND u.estado='1'";
                command = new NpgsqlCommand(query, con);
                dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    frmInicio.User.Usuario = dr[0].ToString();
                    frmInicio.User.Usuario_ID = Convert.ToInt32(dr[1]);
                    frmInicio.User.Usuario_Nivel = Convert.ToInt32(dr[2]);
                    query = classFunciones.agregar_evento("[LOGIN] Ingreso al sistema", true);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ingreso incorrecto", "LunaSoft :: ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    query = classFunciones.agregar_evento("[LOGIN][error] Intento de Ingreso al sistema por Usuario:" + tbUsuario.Text, false);
                    tbUsuario.Text = "";
                    tbContrasena.Text = "";
                    tbUsuario.Focus();
                }
                hubo_error = false;            
            }
            catch (NpgsqlException error)
            {
                hubo_error = true;
                MessageBox.Show(error.Message, "LunaSoft :: ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }

            if (!hubo_error)
            {
                con.Open();
                command = new NpgsqlCommand(query, con);
                command.ExecuteNonQuery();
                con.Close();
            }

        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            frmInicio.terminar = true;
            Application.ExitThread();
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (es_hijo)
            {
                frmInicio.terminar = true;
                Application.ExitThread();
            }
        }
    }
}
