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
    public partial class frmListadosDetalles : Form
    {
        NpgsqlConnection con;
        NpgsqlDataAdapter da;
        DataView dv;
        private int id_padre; // id_compra o id_venta
        private string tipo; // compra o venta
        private string _nombre; // Nombre del Cliente o Proveedor
        private string _ruc;
        private double _total;
        private DateTime _fecha;
        private string _factura;

        public int ID_Padre
        {
            set
            {
                id_padre = value;
            }
            get
            {
                return id_padre;
            }
        }

        public string Tipo
        {
            set
            {
                tipo = value;
            }
            get
            {
                return tipo;
            }
        }

        public string Nombre
        {
            set
            {
                _nombre = value;
            }
            get
            {
                return _nombre;
            }
        }

        public string Ruc
        {
            set
            {
                _ruc = value;
            }
            get
            {
                return _ruc;
            }
        }

        public double Total
        {
            set
            {
                _total = value;
            }
            get
            {
                return _total;
            }
        }

        public DateTime Fecha
        {
            set
            {
                _fecha = value;
            }
            get
            {
                return _fecha;
            }
        }

        public string Factura
        {
            set
            {
                _factura = value;
            }
            get
            {
                return _factura;
            }
        }

        public frmListadosDetalles()
        {
            InitializeComponent();
        }

        private void cargar_datos()
        {
            DataSet ds = new DataSet();
            con = new NpgsqlConnection(frmInicio.strConexion);
            try
            {
                con.Open();
                string query = "";
                if (tipo == "venta" || tipo == "compra")
                {
                    query = "SELECT d.nombre as \"Depósito\", this.cantidad as \"Cantidad\", p.codigo as \"Código\", " +
                                " p.nombre as \"Producto\", this.precio_unitario_" + Tipo + " as \"Precio\"," +
                                " this.precio_total_" + Tipo + " as \"Total\" " +
                                " FROM " + Tipo + "s_detalles this, depositos d, productos p WHERE id_" + Tipo + " = " + ID_Padre.ToString() +
                                " AND this.id_producto=p.id_producto AND this.id_deposito=d.id_deposito";
                }
                if (tipo == "fabricaciones")
                {
                    query = "SELECT p.codigo as \"Código\", p.nombre as \"Producto\", d.nombre as \"Depósito\", this.cantidad as \"Cantidad\" " +
                        " FROM productos p, depositos d, fabricaciones_detalles this WHERE id_proceso_fabricacion = " + ID_Padre.ToString() + 
                        " AND this.id_producto=p.id_producto AND this.id_deposito=d.id_deposito";
                }

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
            // Columnas con formato Numerico
            dataGridView1.Columns["Cantidad"].DefaultCellStyle.Format = "n2";
            // Cambiar el Nombre de las Columnas
            dataGridView1.Columns["Cantidad"].HeaderText = "#";
            dataGridView1.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            if (tipo != "fabricaciones")
            {
                // Columnas con formato Numerico
                dataGridView1.Columns["Precio"].DefaultCellStyle.Format = "n0";
                dataGridView1.Columns["Total"].DefaultCellStyle.Format = "n0";
                // La Columna Precio de Venta alineacion derecha
                dataGridView1.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (tipo == "venta")
                    dataGridView1.Columns["Depósito"].Visible = false;
            }
        }


        private void frmListadosDetalles_Load(object sender, EventArgs e)
        {
            this.Text += tipo.ToUpper();
            if (tipo == "fabricaciones")
            {
                this.lblRuc.Text = "Código";
                this.lblNombre.Text = "Materia Prima";
                this.lblFactura.Text = "Depósito";
            }
            tbNombre.Text = Nombre;
            tbRuc.Text = Ruc;
            tbFactura.Text = Factura;
            tbFecha.Text = Fecha.ToString();
            if(tipo == "compra")
                tbFecha.Text = Fecha.ToString("dd/MM/yyyy");
            tbTotal.Text = Total.ToString("n0");
            cargar_datos();
            formatear_datagrid();
        }

        private void btSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
