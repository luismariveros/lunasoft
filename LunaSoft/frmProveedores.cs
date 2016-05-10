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
    public partial class frmProveedores : Form
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

        public frmProveedores()
        {
            InitializeComponent();
        }

        private void agregar()
        {
            frmClienteAgregar frmAgregar = new frmClienteAgregar();
            frmAgregar.tipo = true;
            frmAgregar.Text = "Proveedores :: Agregar";
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
            string codigos = " id_proveedor = ";

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
                        codigos = codigos + " OR id_proveedor = ";
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

                    string query = "UPDATE proveedores SET estado='0' WHERE " + codigos + classFunciones.agregar_evento("[PROVEEDORES] Se borro uno o varios registros", true);
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
            frmClienteModificar frmModificar = new frmClienteModificar();
            frmModificar.Indice = dataGridView1.CurrentRow.Index;
            frmModificar.DT = dv.ToTable();
            frmModificar.Text = "Proveedores :: Modificar";
            frmModificar.tipo = true;
            frmModificar.ShowDialog();
            cargar_datos();
            formatear_datagrid();
            dataGridView1.Focus();
        }

        private void ver()
        {
            frmClienteVer frmVer = new frmClienteVer();
            frmVer.tipo = true;
            frmVer.Text = "Proveedores :: Ver";
            frmVer.Indice = dataGridView1.CurrentRow.Index;
            frmVer.DT = dv.ToTable();
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
                string query = "SELECT id_proveedor as \"ID\", nombre as \"Nombre\", cedula_ruc as \"Cédula_RUC\", telefono as \"Teléfono\", celular as \"Celular\", contacto as \"Contacto\", mail as \"Mail\", direccion as \"Dirección\" FROM proveedores WHERE estado=\'1\' ORDER BY nombre";
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

        private void frmProveedores_KeyPress(object sender, KeyPressEventArgs e)
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

        private void frmProveedores_Load(object sender, EventArgs e)
        {
            cargar_datos();
            formatear_datagrid();
        }

        private void formatear_datagrid()
        {
            // Columna INVISIBLES
            dataGridView1.Columns["ID"].Visible = false;

            // Columnas Alineacion Derecha
            dataGridView1.Columns["Cédula_RUC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["Teléfono"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["Celular"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            
            // Headers alineacion Central
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // El ancho de la Columna se establece por el contenido
            dataGridView1.Columns["Cédula_RUC"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns["Teléfono"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            dataGridView1.Columns["Celular"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;

            // Columnas ReadOnly=false
            for (int i = 1; i < dataGridView1.Columns.Count; i++)
                dataGridView1.Columns[i].ReadOnly = true;

            // La Caja de Texto de Buscar limpio
            tbBuscar.Text = "";
        }

        private void tbBuscar_TextChanged(object sender, EventArgs e)
        {
            dv.RowFilter = "Cédula_RUC LIKE '%" + tbBuscar.Text + "%' OR Nombre LIKE '%" + tbBuscar.Text + "%'";
        }

        private void cargar_padre()
        {
            IFormProveedor formInterface = this.Owner as IFormProveedor;

            if (formInterface != null)
                formInterface.cargarDatosProveedor(dataGridView1.CurrentRow.Cells["Cédula_RUC"].Value.ToString(), dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString(), Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value));
            this.Close();
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
        }
    }
}
