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
    public partial class frmDepositos : Form
    {
        NpgsqlConnection con;
        NpgsqlDataAdapter da;
        DataView dv;

        public frmDepositos()
        {
            InitializeComponent();
        }

        private void agregar()
        {
            frmDepositoAgregar frmAgregar = new frmDepositoAgregar();
            frmAgregar.ShowDialog();
            frmAgregar = null;
            cargar_datos();
            formatear_datagrid();
            dataGridView1.Focus();
        }
        
        private void eliminar()
        {
            List<string> lst_codigo = new List<string>();

            string mensaje = "El registro activo será eliminado. ¿Está seguro?";
            string codigos = " id_deposito = ";

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                if (Convert.ToInt32(dataGridView1.Rows[i].Cells["cbBorrar"].Value) == 1)
                    lst_codigo.Add(dataGridView1.Rows[i].Cells["ID"].Value.ToString());
            if (lst_codigo.Count > 0)
            {
                int cont = 0;

                foreach (string l in lst_codigo)
                {
                    codigos = codigos + l;
                    cont++;
                    if (cont < lst_codigo.Count)
                        codigos = codigos + " OR id_deposito = ";
                }
                if (lst_codigo.Count > 1)
                    mensaje = "Los " + lst_codigo.Count + " registros marcados serán eliminados. ¿Está seguro?";
            }
            else
            {
                codigos = codigos + dataGridView1.CurrentRow.Cells["ID"].Value;
                lst_codigo.Add(dataGridView1.CurrentRow.Cells["ID"].Value.ToString());
            }

            if (MessageBox.Show(mensaje, "Eliminar Registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                con = new NpgsqlConnection(frmInicio.strConexion);
                try
                {
                    con.Open();

                    string query = "DELETE FROM depositos WHERE " + codigos;
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

        private void modificar()
        {
            frmDepositoModificar frmModificar = new frmDepositoModificar();
            frmModificar.DT = dv.ToTable();
            frmModificar.Indice = dataGridView1.CurrentRow.Index;
            frmModificar.ShowDialog();
            frmModificar = null;
            cargar_datos();
            formatear_datagrid();
            dataGridView1.Focus();
        }

        private void ver()
        {
            frmDepositoVer frmVer = new frmDepositoVer();
            frmVer.DT = dv.ToTable();
            frmVer.Indice = dataGridView1.CurrentRow.Index;
            frmVer.ShowDialog();
            frmVer = null;
            formatear_datagrid();
            dataGridView1.Focus();
        }


        private void cargar_datos()
        {
            DataSet ds = new DataSet();
            con = new NpgsqlConnection(frmInicio.strConexion);
            try
            {
                con.Open();
                string query = "SELECT d.id_deposito as \"ID\", d.nombre as \"Nombre\", d.ubicacion as \"Ubicación\", d.observacion as \"Observación\" from depositos d ORDER BY d.id_deposito";
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

        private void formatear_datagrid()
        {
            // Volver ReadOnly todas las columnas menos la columna Borrar
            for (int i = 1; i < dataGridView1.Columns.Count; i++)
                dataGridView1.Columns[i].ReadOnly = true;
            dataGridView1.Columns["cbBorrar"].DisplayIndex = 0;
            // Columnas INVISIBLES
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["Observación"].Visible = false;
            // La Caja de Texto de Buscar limpio
            tbBuscar.Text = "";
        }

        private void frmDepositos_Load(object sender, EventArgs e)
        {
            cargar_datos();
            formatear_datagrid();
        }

        private void tbBuscar_TextChanged(object sender, EventArgs e)
        {
            dv.RowFilter = "Nombre LIKE '%" + tbBuscar.Text + "%' OR Ubicación LIKE '%" + tbBuscar.Text + "%'";
        }

        private void frmDepositos_KeyPress(object sender, KeyPressEventArgs e)
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
                        modificar();
                        break;
                    case (char)118:
                    case (char)Keys.V:
                        ver();
                        break;
                }
            }
        }

        private void btAgregar_Click(object sender, EventArgs e)
        {
            agregar();
        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            modificar();
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            eliminar();
        }

        private void btVer_Click(object sender, EventArgs e)
        {
            ver();
        }

        private void btSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
