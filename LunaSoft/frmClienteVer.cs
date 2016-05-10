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
    public partial class frmClienteVer : Form
    {
        private DataTable dt;
        private int indice;
        int i_last;
        public bool tipo = false; // false->cliente, true->proveedor

        public int Indice
        {
            set
            {
                indice = value;
            }
        }

        public DataTable DT
        {
            set
            {
                dt = value;
            }
        }

        public frmClienteVer()
        {
            InitializeComponent();
        }

        private void primero()
        {
            mostrar(0);
            indice = 0;
        }

        private void ultimo()
        {
            mostrar(i_last);
            indice = i_last;
        }

        private void anterior()
        {
            int i = i_anterior();
            mostrar(i);
        }

        private void siguiente()
        {
            int i = i_siguiente();
            mostrar(i);
        }

        private int i_anterior()
        {
            if (indice == 0)
                indice = i_last;
            else
                indice--;
            return indice;
        }

        private int i_siguiente()
        {
            if (indice == i_last)
                indice = 0;
            else
                indice++;
            return indice;
        }

        private void mostrar(int i)
        {
            tbNombre.Text = dt.Rows[i].ItemArray[dt.Columns["Nombre"].Ordinal].ToString();
            tbDireccion.Text = dt.Rows[i].ItemArray[dt.Columns["Dirección"].Ordinal].ToString();
            tbCedula.Text = dt.Rows[i].ItemArray[dt.Columns["Cédula_RUC"].Ordinal].ToString();
            tbCelular.Text = dt.Rows[i].ItemArray[dt.Columns["Celular"].Ordinal].ToString();
            tbMail.Text = dt.Rows[i].ItemArray[dt.Columns["Mail"].Ordinal].ToString();
            tbTelefono.Text = dt.Rows[i].ItemArray[dt.Columns["Teléfono"].Ordinal].ToString();
            tbContacto.Text = dt.Rows[i].ItemArray[dt.Columns["Contacto"].Ordinal].ToString();
        }

        private void frmClienteVer_Load(object sender, EventArgs e)
        {
            mostrar(indice);
            i_last = dt.Rows.Count - 1;
        }

        private void frmClienteVer_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (char)Keys.Escape:
                    this.Close();
                    break;
                case (char)Keys.F8:
                    ultimo();
                    break;
                case (char)Keys.F7:
                    siguiente();
                    break;
                case (char)Keys.F6:
                    anterior();
                    break;
                case (char)Keys.F5:
                    primero();
                    break;
            }
        }

        private void btSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btUltimo_Click(object sender, EventArgs e)
        {
            ultimo();
        }

        private void btSiguiente_Click(object sender, EventArgs e)
        {
            siguiente();
        }

        private void btAnterior_Click(object sender, EventArgs e)
        {
            anterior();
        }

        private void btPrimero_Click(object sender, EventArgs e)
        {
            primero();
        }
    }
}
