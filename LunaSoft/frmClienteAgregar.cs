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
    public partial class frmClienteAgregar : Form
    {
        NpgsqlConnection con;
        public bool tipo = false; // false->cliente, true->proveedor

        public frmClienteAgregar()
        {
            InitializeComponent();
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

        private void guardar_agregar()
        {
            guardar();
            limpiar();
            tbCedula.Focus();
        }

        private void guardar()
        {
            con = new NpgsqlConnection(frmInicio.strConexion);
            try
            {
                con.Open();
                string query;
                if(tipo)
                    query = "INSERT INTO proveedores(nombre,cedula_ruc,direccion,mail,telefono,celular,contacto) values('" + tbNombre.Text + "', '" + tbCedula.Text + "', '" + tbDireccion.Text + "', '" + tbMail.Text + "', '" + tbTelefono.Text + "', '" + tbCelular.Text + "','" + tbContacto.Text + "');" + classFunciones.agregar_evento("[PROVEEDORES] Se agrego nuevo proveedor:"+tbNombre.Text, true);
                else
                    query = "INSERT INTO clientes(nombre,cedula_ruc,direccion,mail,telefono,celular,contacto) values('" + tbNombre.Text + "', '" + tbCedula.Text + "', '" + tbDireccion.Text + "', '" + tbMail.Text + "', '" + tbTelefono.Text + "', '" + tbCelular.Text + "','" + tbContacto.Text + "');" + classFunciones.agregar_evento("[CLIENTES] Se agrego nuevo cliente:"+tbNombre.Text, true);
                NpgsqlCommand command = new NpgsqlCommand(query, con);
                command.ExecuteNonQuery();
            }
            catch (NpgsqlException error)
            {
                switch (error.Code)
                {
                    case "23505":
                        MessageBox.Show("Registro Duplicado.\n\nYa existe un registro con el mismo RUC", "LunaSoft :: ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            tbCelular.Text = "";
            tbDireccion.Text = "";
            tbCedula.Text = "";
            tbNombre.Text = "";
            tbMail.Text = "";
            tbTelefono.Text = "";
            tbContacto.Text = "";
        }

        private void frmClienteAgregar_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (char)Keys.Escape:
                    this.Close();
                    break;
                case (char)Keys.F9:
                    guardar_agregar();
                    break;
                case (char)Keys.F10:
                    guardar();
                    this.Close();
                    break;
            }
        }
    }
}
