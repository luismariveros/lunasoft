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
    public partial class frmTipoAjusteAgregar : Form
    {
        NpgsqlConnection con;

        public frmTipoAjusteAgregar()
        {
            InitializeComponent();
        }

        private void guardar_agregar()
        {
            guardar();
            limpiar();
            tbTipoAjuste.Focus();
        }

        private void guardar()
        {
            con = new NpgsqlConnection(frmInicio.strConexion);
            try
            {
                con.Open();
                string query = "INSERT INTO tipos_ajustes(nombre) values('" + tbTipoAjuste.Text + "');" + classFunciones.agregar_evento("[TIPOS_AJUSTES] Nuevo registro", true);
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
            tbTipoAjuste.Text = "";
        }

        private void btRefrescar_Click(object sender, EventArgs e)
        {
            guardar_agregar();
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

        private void frmTipoAjusteAgregar_KeyDown(object sender, KeyEventArgs e)
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
