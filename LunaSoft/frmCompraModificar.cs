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
    public partial class frmCompraModificar : Form, IFormProveedor,IFormCliente, IFormProducto
    {
        bool band_persona = true; // Bandera para saber si esta activo tbRuc
        bool band_producto = false; // Bandera para saber si esta activo tbCodigo
        //bool band_carga_inicial = false;
        private int id_persona; // ID del proveedor o del cliente
        private int id_producto;
        private double total_compra = 0;
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

        public double MontoTotal
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

        public int ID_Persona
        {
            set
            {
                id_persona = value;
            }
            get
            {
                return id_persona;
            }
        }

        public frmCompraModificar()
        {
            InitializeComponent();
        }

        //Region IFormCliente
        public void cargarDatosCliente(string ruc, string nombre, int id)
        {
            tbRuc.Text = ruc;
            tbNombre.Text = nombre;
            id_persona = id;
        }
        //Fin Region

        //Region IFormProveedor
        public void cargarDatosProveedor(string ruc, string nombre, int id)
        {
            tbRuc.Text = ruc;
            tbNombre.Text = nombre;
            id_persona = id;
        }
        //Fin Region

        //Region IFormProducto
        public void cargarDatosProducto(string cod, string nom, double precioC, double precioV, int id)
        {
            tbCodigo.Text = cod;
            tbProducto.Text = nom;
            id_producto = id;
            tbPrecio.Text = precioC.ToString();
        }
        //Fin Region

        private void persona_agregar()
        {
            switch (tipo)
            {
                case "venta":
                    frmClientes cliente = new frmClientes();
                    cliente.Hijo = true;
                    cliente.ShowDialog(this);
                    cliente = null;
                    tbFactura.Focus();
                    break;
                case "compra":
                    frmProveedores proveedor = new frmProveedores();
                    proveedor.Hijo = true;
                    proveedor.ShowDialog(this);
                    proveedor = null;
                    tbFactura.Focus();
                    break;
            }
        }

        private void producto_agregar()
        {
            frmProductos producto = new frmProductos();
            producto.Hijo = true;
            producto.Tipo_Form = 3;
            producto.ShowDialog(this);
            producto = null;
            cbDeposito.Focus();
        }

        private void formatear_datagrid()
        {
            dataGridView1.Columns["Cant"].DefaultCellStyle.Format = "n2";
            dataGridView1.Columns["Precio"].DefaultCellStyle.Format = "n0";
            dataGridView1.Columns["Total"].DefaultCellStyle.Format = "n0";
            // Columnas Ocultas
            dataGridView1.Columns["ID"].Visible = false;
            // Alineacion
            dataGridView1.Columns["Cant"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            if (tipo == "venta")
            {
                dataGridView1.Columns["Depósito"].Visible = false;
            }
        }

        private void limpiar()
        {
            tbCodigo.Text = "";
            tbNombre.Text = "";
            tbCantidad.Text = "1";
            tbRuc.Text = "";
            tbTotal.Text = "";
            tbProducto.Text = "";
            tbFactura.Text = "";
            tbTotal.Text = "0";
            total_compra = 0;
            dataGridView1.Rows.Clear();
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
                    query = "SELECT this.id_" + tipo + "_detalle as \"ID\", d.nombre as \"Depósito\", this.cantidad as \"Cant\", p.codigo as \"Código\", " +
                                " p.nombre as \"Producto\", this.precio_unitario_" + Tipo + " as \"Precio\"," +
                                " this.precio_total_" + Tipo + " as \"Total\" " +
                                " FROM " + Tipo + "s_detalles this, depositos d, productos p WHERE id_" + Tipo + " = " + ID_Padre.ToString() +
                                " AND this.id_producto=p.id_producto AND this.id_deposito=d.id_deposito";
                }
                if (tipo == "fabricaciones")
                {
                    query = "SELECT p.codigo as \"Código\", p.nombre as \"Producto\", d.nombre as \"Depósito\", this.cantidad as \"Cant\" " +
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

        private string armar_query(DataGridViewRow fila)
        {
            string ret = "";
            DateTime fecha = Convert.ToDateTime(dateTimePicker1.Value);

            switch (tipo)
            {
                case "compra":
                    ret = "UPDATE compras SET id_proveedor=" + id_persona + ",fecha='" + fecha.ToString("yyyy-MM-dd") + "',monto_compra=" + Convert.ToDouble(tbTotal.Text) + ",numero_factura='" + tbFactura.Text + "' WHERE id_compra=" + ID_Padre;
                    break;
                case "venta":
                    ret = "UPDATE ventas SET id_cliente=" + id_persona + ",fecha_hora='" + fecha.ToString("yyyy-MM-dd HH:mm:00") + "',monto_venta=" + Convert.ToDouble(tbTotal.Text) + ",numero_factura='" + tbFactura.Text + "' WHERE id_venta=" + ID_Padre;
                    break;
                case "fabricaciones":
                    ret = "";
                    break;
            }

            if (fila != null)
            {
                switch (tipo)
                {
                    case "compra":
                        ret = "; UPDATE compras_detalles SET cantidad=" + classFunciones.eliminarComa(fila.Cells["Cant"].Value.ToString()) + ",precio_unitario_compra=" + Convert.ToDouble(fila.Cells["precio"].Value) + " WHERE id_compra_detalle=" + Convert.ToInt32(fila.Cells["ID"].Value);
                        //ret = ret + " ; UPDATE compras SET monto_compra = " + total_compra;
                        break;
                    case "venta":
                        ret = ";UPDATE ventas_detalles SET cantidad=" + classFunciones.eliminarComa(fila.Cells["Cant"].Value.ToString()) + ",precio_unitario_venta=" + Convert.ToDouble(fila.Cells["precio"].Value) + " WHERE id_venta_detalle=" + Convert.ToInt32(fila.Cells["ID"].Value);
                        //ret = ret + " ; UPDATE ventas SET monto_venta = " + total_compra;
                        break;
                    case "fabricaciones":
                        ret = "";
                        break;
                }
            }

            return ret;
        }

        private bool guardar()
        {
            bool ret = true;
            con = new NpgsqlConnection(frmInicio.strConexion);
            try
            {
                con.Open();
                NpgsqlTransaction t = con.BeginTransaction();

                string query = armar_query(null) + ";" + classFunciones.agregar_evento("["+tipo.ToUpper()+"] Actualización de Registro",true);
                NpgsqlCommand command = new NpgsqlCommand(query, con);
                command.ExecuteNonQuery();

                foreach (DataGridViewRow fila in dataGridView1.Rows)
                {
                    query = armar_query(fila);
                    command = new NpgsqlCommand(query, con);
                    command.ExecuteNonQuery();
                }
                t.Commit();
                MessageBox.Show("Actualización Exitosa", "LunaSoft :: " + tipo.ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (NpgsqlException error)
            {
                ret = false;
                MessageBox.Show(error.Message, "LunaSoft :: ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
            return ret;
        }

        private void guardar_cerrar()
        {
            if (guardar())
                this.Close();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Agrego al Datagridview los datos de los detalles
                double total = Math.Round((float.Parse(tbCantidad.Text) * Convert.ToDouble(tbPrecio.Text)));
                total_compra += total;

                string[] fila = new string[] { id_producto.ToString(), cbDeposito.SelectedValue.ToString(), cbDeposito.Text, tbCantidad.Text, tbProducto.Text, tbPrecio.Text, total.ToString() };
                dataGridView1.Rows.Add(fila);

                tbTotal.Text = total_compra.ToString("n0");
                tbCantidad.Text = "1";
                tbCodigo.Text = "";
                tbProducto.Text = "";
                tbPrecio.Text = "";
                tbCantidad.Focus();
                formatear_datagrid();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Campos nulos en el formulario.", "LunaSoft :: Compras", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            

        }

        private void lblBuscarP_Click(object sender, EventArgs e)
        {
            persona_agregar();
        }

        private void lblCodigoP_Click(object sender, EventArgs e)
        {
            producto_agregar();
        }

        private void btSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            guardar_cerrar();
        }

        private void frmCompraModificar_Load(object sender, EventArgs e)
        {
            tbNombre.Text = Nombre;
            tbRuc.Text = Ruc;
            tbFactura.Text = Factura;
            if (tipo == "venta")
            {
                this.lblRuc.Text = "Cliente";
                this.Text = "Ventas :: Modificar";
            }
            dateTimePicker1.Value = Fecha;
            tbTotal.Text = MontoTotal.ToString("n0");
            cargar_datos();
            formatear_datagrid();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            double total = 0;
            dataGridView1.Rows[e.RowIndex].Cells["total"].Value = float.Parse(dataGridView1.Rows[e.RowIndex].Cells["Cant"].Value.ToString()) * Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["precio"].Value);
            foreach (DataGridViewRow fila in dataGridView1.Rows)
                total += Math.Round(Convert.ToDouble(fila.Cells["total"].Value));
            tbTotal.Text = total.ToString("n0");
            total_compra = total;
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Formulario con datos no válidos.", "LunaSoft :: ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void frmCompraModificar_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (char)Keys.Escape:
                    this.Close();
                    break;
                case (char)Keys.F2:
                    if (band_producto)
                        producto_agregar();
                    if (band_persona)
                        persona_agregar();
                    break;
                case (char)Keys.F10:
                    guardar_cerrar();
                    break;
            }
        }

        private void tbRuc_Leave(object sender, EventArgs e)
        {
            band_persona = false;
        }

        private void tbRuc_Enter(object sender, EventArgs e)
        {
            band_persona = true;
        }

        private void tbCodigo_Enter(object sender, EventArgs e)
        {
            band_producto = true;
        }

        private void tbCodigo_Leave(object sender, EventArgs e)
        {
            band_producto = false;
        }

        private void tbRuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                DataSet ds = new DataSet();
                con = new NpgsqlConnection(frmInicio.strConexion);
                try
                {
                    con.Open();
                    string query = "";
                    if (tipo == "venta")
                        query = "SELECT id_cliente, cedula_ruc, nombre FROM clientes WHERE cedula_ruc = '" + tbRuc.Text + "'";
                    if (tipo == "compra")
                        query = "SELECT id_proveedor, cedula_ruc, nombre FROM proveedores WHERE cedula_ruc = '" + tbRuc.Text + "'";
                    NpgsqlCommand command = new NpgsqlCommand(query, con);
                    NpgsqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        ID_Persona = Convert.ToInt32(dr[0].ToString());
                        tbRuc.Text = dr[1].ToString();
                        tbNombre.Text = dr[2].ToString();
                        tbFactura.Focus();
                    }
                    else
                    {
                        MessageBox.Show("No existe ningún Registro que coincida.", "LunaSoft :: Ventas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbRuc.Focus();
                    }
                }
                catch (NpgsqlException error)
                {
                    MessageBox.Show(error.Message, "LunaSoft :: ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

