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
    public partial class frmDepositoVer : Form
    {
        private DataTable dt;
        private int indice;
        int i_last;

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

        public frmDepositoVer()
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
            tbUbicacion.Text = dt.Rows[i].ItemArray[dt.Columns["Ubicación"].Ordinal].ToString();
            tbObservacion.Text = dt.Rows[i].ItemArray[dt.Columns["Observación"].Ordinal].ToString();
        }

        private void btSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btPrimero_Click(object sender, EventArgs e)
        {
            primero();
        }

        private void btAnterior_Click(object sender, EventArgs e)
        {
            anterior();
        }

        private void btSiguiente_Click(object sender, EventArgs e)
        {
            siguiente();
        }

        private void btUltimo_Click(object sender, EventArgs e)
        {
            ultimo();
        }

        private void frmDepositoVer_KeyDown(object sender, KeyEventArgs e)
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

        private void frmDepositoVer_Load(object sender, EventArgs e)
        {
            mostrar(indice);
            i_last = dt.Rows.Count - 1;
        }

    }
}
