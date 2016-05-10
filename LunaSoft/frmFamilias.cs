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
    public partial class frmFamilias : Form
    {
        NpgsqlConnection con;
        NpgsqlDataAdapter da;
        DataView dv;

        private bool es_hijo = false; // Bandera para saber que Form le llamo
        
        public bool Hijo
        {
            set
            {
                es_hijo = value;
            }
        }

        public frmFamilias()
        {
            InitializeComponent();
        }

        private void agregar()
        {
            frmFamiliaAgregar frmAgregar = new frmFamiliaAgregar();
            frmAgregar.ShowDialog();
            frmAgregar = null;
            cargar_datos();
            formatear_datagrid();
        }

        private void modificar()
        {
            frmFamiliaModificar frmModificar = new frmFamiliaModificar();
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
            frmFamiliaVer frmVer = new frmFamiliaVer();
            frmVer.DT = dv.ToTable();
            frmVer.Indice = dataGridView1.CurrentRow.Index;
            frmVer.ShowDialog();
            frmVer = null;
            formatear_datagrid();
            dataGridView1.Focus();
        }

        private void eliminar()
        {
            List<string> lst_codigo = new List<string>();

            string mensaje = "El registro activo será eliminado. ¿Está seguro?";
            string codigos = " codigo = ";

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                if (Convert.ToInt32(dataGridView1.Rows[i].Cells["cbBorrar"].Value) == 1)
                    lst_codigo.Add(dataGridView1.Rows[i].Cells["Código"].Value.ToString());
            if (lst_codigo.Count > 0)
            {
                int cont = 0;

                foreach (string l in lst_codigo)
                {
                    codigos = codigos + "'" + l + "'";
                    cont++;
                    if (cont < lst_codigo.Count)
                        codigos = codigos + " OR codigo = ";
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
                    
                    string query = "DELETE FROM familias WHERE " + codigos;
                    //MessageBox.Show(query);
                    NpgsqlCommand command = new NpgsqlCommand(query, con);
                    command.ExecuteNonQuery();
                    
                    // Se elimina del DataView para no tener que hacer un SELECT de la BD
                    dv.Sort = "Código ASC";
                    foreach (string cod in lst_codigo)
                        dv.Delete((dv.Find(cod)));
                }
                catch (NpgsqlException error)
                {
                    switch (error.Code)
                    {
                        case "23503":
                            MessageBox.Show("No se puede eliminar el registro.\n\nExisten Productos que hacen referencia a la Familia.","LunaSoft :: ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            //MessageBox.Show(,,,MessageBoxIcon.Error
                            break;
                        default:
                            MessageBox.Show(error.Message, "LunaSoft :: ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                        
                }
                finally
                {
                    con.Close();
                    dataGridView1.Focus();
                    tbBuscar.Text = "";
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

        private void frmFamilias_Load(object sender, EventArgs e)
        {
            cargar_datos();
            formatear_datagrid();
            
            /*
            con = new NpgsqlConnection(frmInicio.strConexion);
            con.Open();

            NpgsqlCommand command = new NpgsqlCommand("select * from familias", con);

            try
            {
                NpgsqlDataReader dr = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;           
            }
            catch (NpgsqlException error)
            {
                MessageBox.Show("ERRROR " + error);
            }
            finally
            {
                con.Close();
            }
             */
        }

        private void cargar_datos()
        {
            DataSet ds = new DataSet();
            con = new NpgsqlConnection(frmInicio.strConexion);
            try
            {
                con.Open();
                string query = "SELECT f.id_familia as \"ID\", f.codigo as \"Código\", f.descripcion as \"Descripción\" FROM familias f ORDER BY codigo";
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
            // Intercalar colores de cada fila
            for (int i = 1; i < dataGridView1.Rows.Count; i += 2)
                dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
            // La columna ID no muestro
            dataGridView1.Columns["ID"].Visible = false;

            // El ancho de la Columna se establece por el contenido
            dataGridView1.Columns["Código"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns["Descripción"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            // La Caja de Texto de Buscar limpio
            tbBuscar.Text = "";
        }

        private void tbBuscar_TextChanged(object sender, EventArgs e)
        {
            dv.RowFilter = "Código LIKE '%" + tbBuscar.Text + "%' OR Descripción LIKE '%" + tbBuscar.Text + "%'";
        }

        private void frmFamilias_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (es_hijo)
                cargar_padre();
            else
                modificar();
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (es_hijo)
                    cargar_padre();
            }
            if (e.KeyChar == Convert.ToChar(Keys.Space))
                dataGridView1.CurrentRow.Cells["cbBorrar"].Value = true;
        }

        private void cargar_padre()
        {
            IForm formInterface = this.Owner as IForm;

            if (formInterface != null)
                formInterface.cargarDatosFamilia(dataGridView1.CurrentRow.Cells["Código"].Value.ToString(), dataGridView1.CurrentRow.Cells["Descripción"].Value.ToString(),Convert.ToInt32( dataGridView1.CurrentRow.Cells["ID"].Value));
            this.Close();
        }
    }
}
