using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using Npgsql;

namespace LunaSoft
{
    public partial class frmInicio : Form
    {        
        public static string strConexion;
        public static classUsuario User = new classUsuario();
        public static bool terminar = false;
        
        public frmInicio()
        {
            InitializeComponent();
        }

        private void cargar_configuracion_bd()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("c:\\lunasoft\\configuracion.xml");
            XmlNodeList configuraciones = doc.GetElementsByTagName("configuraciones");
            foreach (XmlElement nodo in configuraciones)
            {
                XmlNodeList server = nodo.GetElementsByTagName("server");
                XmlNodeList port = nodo.GetElementsByTagName("port");
                XmlNodeList database = nodo.GetElementsByTagName("database");
                strConexion = "Server=" + server[0].InnerText + ";Port=" + port[0].InnerText + ";User Id=postgres;Password=postgres;Database=" + database[0].InnerText + ";";
            }
        }

        private void familiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFamilias familias = new frmFamilias();
            familias.Show();
            familias = null;
        }

        private void itemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductos productos = new frmProductos();
            productos.Show();
            productos = null;
        }

        private void depósitosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDepositos depositos = new frmDepositos();
            depositos.Show();
            depositos = null;
        }

        private void inventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInventario inventario = new frmInventario();
            inventario.Show();
            inventario = null;
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClientes clientes = new frmClientes();
            clientes.Show();
            clientes = null;
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void salidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVentaAgregar salidas = new frmVentaAgregar();
            salidas.Show();
        }

        private void transferenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTransferencia transferencia = new frmTransferencia();
            transferencia.Show();
            transferencia = null;
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProveedores proveedores = new frmProveedores();
            proveedores.Show();
            proveedores = null;
        }

        private void entradasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCompraAgregar compra = new frmCompraAgregar();
            compra.Show();
            compra = null;
        }

        private void ajustesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAjusteAgregar ajustes = new frmAjusteAgregar();
            ajustes.Show();
            ajustes = null;
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuarios usuarios = new frmUsuarios();
            usuarios.Show();
        }

        private void fabricarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFabricacionAgregar fabricacion = new frmFabricacionAgregar();
            fabricacion.Show();
        }

        private void tipoDeAjusteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTipoAjusteAgregar tipoAjuste = new frmTipoAjusteAgregar();
            tipoAjuste.Show();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User.Usuario = "";
            frmLogin login = new frmLogin();
            login.ShowDialog();
            login = null;
            while(User.Usuario == String.Empty)
            {
                frmLogin login2 = new frmLogin();
                login2.ShowDialog();
                login2 = null;
                if (terminar == true)
                    break;
            }
            this.Text = "Control de Stock :: LunaSoft";
            this.Text += "                Usuario:" + User.Usuario;
        }

        private void frmInicio_Load(object sender, EventArgs e)
        {
            cargar_configuracion_bd();
            frmLogin login = new frmLogin();
            login.ShowDialog();
            this.Text += "                Usuario:" + User.Usuario;
            if (frmInicio.User.Usuario_Nivel == 0)
                this.usuariosToolStripMenuItem.Visible = false;
        }

        private void frmInicio_Activated(object sender, EventArgs e)
        {
            if (frmInicio.User.Usuario_Nivel == 0)
            {
                comprasToolStripMenuItem.Visible = false;
                usuariosToolStripMenuItem.Visible = false;
                //ajustesToolStripMenuItem.Visible = false;
                //auditoríaToolStripMenuItem1.Visible = false;
                principalToolStripMenuItem.DropDownItems.Remove(usuariosToolStripMenuItem);
            }
            else
            {
                if (frmInicio.User.Usuario_Nivel == 1 && usuariosToolStripMenuItem.Visible == false)
                {
                    comprasToolStripMenuItem.Visible = true;
                    usuariosToolStripMenuItem.Visible = true;
                    principalToolStripMenuItem.DropDownItems.Insert(3, usuariosToolStripMenuItem);
                }
            }
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListados ventas = new frmListados();
            ventas.tipo = "venta";
            ventas.Show();
            ventas = null;
        }

        private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListados compras = new frmListados();
            compras.tipo = "compra";
            compras.Show();
            compras = null;
        }


        private void transferenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListados transferencias = new frmListados();
            transferencias.tipo = "transferencias";
            transferencias.Show();
            transferencias = null;
        }

        private void ajustesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmListados ajustes = new frmListados();
            ajustes.tipo = "ajustes";
            ajustes.Show();
            ajustes = null;
        }

        private void auditoríaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListados auditoria = new frmListados();
            auditoria.tipo = "auditoria";
            auditoria.Show();
            auditoria = null;
        }

        private void fabricacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListados fabricaciones = new frmListados();
            fabricaciones.tipo = "fabricaciones";
            fabricaciones.Show();
            fabricaciones = null;
        }

        private void copiaDeSeguridadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBackup bk = new frmBackup();
            bk.Show();
            bk = null;
        }

        private void auditoríaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmListados auditoria = new frmListados();
            auditoria.tipo = "auditoria";
            auditoria.Show();
            auditoria = null;
        }

        private void cerrarSesiónToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            User.Usuario = "";
            frmLogin login = new frmLogin();
            login.es_hijo = true;
            login.ShowDialog();
            login = null;
            while (User.Usuario == String.Empty)
            {
                frmLogin login2 = new frmLogin();
                login2.ShowDialog();
                login2 = null;
                if (terminar == true)
                    break;
            }
            this.Text = "Control de Stock :: LunaSoft";
            this.Text += "                Usuario:" + User.Usuario;
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tiposDeAjustesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTipoAjustes tipo_ajustes = new frmTipoAjustes();
            tipo_ajustes.Show();
            tipo_ajustes = null;
        }

        private void usuariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmUsuarios usuarios = new frmUsuarios();
            usuarios.Show();
        }

        private void stockFaltanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListadosSolo stock_faltante = new frmListadosSolo();
            stock_faltante.tipo = "stock";
            stock_faltante.query = "SELECT p.id_producto as \"ID\", p.codigo as \"Código\", e.nombre as \"Producto\", e.existencia as \"Total\"" +
                                    ", p.stock_minimo as \"Stock Minimo\" FROM existencia_total e, productos p " +
                                    "WHERE e.existencia < p.stock_minimo AND e.id_producto = p.id_producto";
            stock_faltante.Show();
            stock_faltante = null;
        }

        private void historialProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListadoHistoricoProducto historial = new frmListadoHistoricoProducto();
            historial.Show();
            historial = null;
        }
    }
}
