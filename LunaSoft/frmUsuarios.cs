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
    public partial class frmUsuarios : Form
    {
        NpgsqlConnection con;
        NpgsqlDataAdapter da;
        DataView dv;

        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void agregar()
        {
            frmUsuarioAgregar frmAgregar = new frmUsuarioAgregar();
            frmAgregar.ShowDialog();
            frmAgregar = null;
            cargar_datos();
            dataGridView1.Focus();
        }

        private void eliminar()
        {
            List<string> lst_codigo = new List<string>();

            string mensaje = "El registro activo será eliminado. ¿Está seguro?";
            string codigos = " id_usuario = ";

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                if (Convert.ToInt32(dataGridView1.Rows[i].Cells["cbBorrar"].Value) == 1)
                    lst_codigo.Add(dataGridView1.Rows[i].Cells["ID"].Value.ToString());

            if (lst_codigo.Count > 0)
            {
                int cont = 0;

                foreach (string l in lst_codigo)
                {
                    codigos = codigos + "'" + l + "'";
                    cont++;
                    if (cont < lst_codigo.Count)
                        codigos = codigos + " OR id_usuario = ";
                }
                if (lst_codigo.Count > 1)
                    mensaje = "Los " + lst_codigo.Count + " registros marcados serán eliminados. ¿Está seguro?";
            }
            else
            {
                codigos = codigos + "'" + dataGridView1.CurrentRow.Cells["Código"].Value.ToString() + "'";
                lst_codigo.Add(dataGridView1.CurrentRow.Cells["Código"].Value.ToString());
            }

            if (MessageBox.Show(mensaje, "Eliminar Registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                con = new NpgsqlConnection(frmInicio.strConexion);
                try
                {
                    con.Open();

                    string query = "UPDATE usuarios SET estado = '0' WHERE " + codigos + "; " + classFunciones.agregar_evento("[USUARIOS] Se borro uno o varios registros", true);
                    //MessageBox.Show(query);
                    NpgsqlCommand command = new NpgsqlCommand(query, con);
                    command.ExecuteNonQuery();

                    // Se elimina del DataView para no tener que hacer un SELECT de la BD
                    dv.Sort = "ID ASC";
                    foreach (string cod in lst_codigo)
                        dv.Delete((dv.Find(cod)));
                }
                catch (NpgsqlException error)
                {
                    MessageBox.Show(error.Message, "LunaSoft :: ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                    lst_codigo = null;
                    dataGridView1.Focus();
                    tbBuscar.Text = "";
                }
            }
        }

        private void formatear_datagrid()
        {
            // Columnas INVISIBLES
            dataGridView1.Columns["ID"].Visible = false;
        }


        private void cargar_datos()
        {
            DataSet ds = new DataSet();
            con = new NpgsqlConnection(frmInicio.strConexion);
            try
            {
                con.Open();
                string query = "SELECT u.id_usuario as \"ID\", u.nombre as \"Nombre\",nu.nombre as \"Nivel\",nu.descripcion as \"Descripción\" FROM usuarios u inner join niveles_usuarios nu on u.id_nivel_usuario = nu.nivel WHERE u.estado='1' ORDER BY Nivel DESC";
                NpgsqlCommand command = new NpgsqlCommand(query, con);
                da = new NpgsqlDataAdapter(command);
                da.Fill(ds);
                dv = ds.Tables[0].DefaultView;
                dataGridView1.DataSource = dv;
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


        private void btSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            cargar_datos();
            formatear_datagrid();
        }

        private void btAgregar_Click(object sender, EventArgs e)
        {
            agregar();    
        }

        private void frmUsuarios_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.tbBuscar.Focused == false)
            {
                switch (e.KeyChar)
                {
                    case (char)97:
                    case (char)Keys.A:
                        agregar();
                        break;
                    case (char)101:
                    case (char)Keys.E:
                        dataGridView1.EndEdit();
                        eliminar();
                        dataGridView1.BeginEdit(false);
                        break;
                    case (char)109:
                    case (char)Keys.M:
                        //modificar();
                        break;
                    case (char)118:
                    case (char)Keys.V:
                        //ver();
                        break;
                }
            }
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            eliminar();
        }
    }
}
