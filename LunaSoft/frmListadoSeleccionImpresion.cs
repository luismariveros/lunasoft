using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LunaSoft
{
    public partial class frmListadoSeleccionImpresion : Form
    {
        public string tipo_impresion;

        public frmListadoSeleccionImpresion()
        {
            InitializeComponent();
        }

        public void cargar_padre()
        {
            IFormSeleccionImpresion formInterface = this.Owner as IFormSeleccionImpresion;

            if (formInterface != null)
                formInterface.seleccionarTipoImpresion(tipo_impresion);
            this.Close();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            if (rbMovimientos.Checked)
                tipo_impresion = "movimientos";
            else
                tipo_impresion = "transferencias";
            cargar_padre();
        }
    }
}
