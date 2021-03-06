﻿using System;
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
    public partial class frmDepositoAgregar : Form
    {
        NpgsqlConnection con;

        public frmDepositoAgregar()
        {
            InitializeComponent();
        }

        private void guardar_agregar()
        {
            guardar();
            limpiar();
            tbNombre.Focus();
        }

        private void guardar()
        {
            con = new NpgsqlConnection(frmInicio.strConexion);
            try
            {
                con.Open();
                string query = "INSERT INTO depositos(nombre,ubicacion,observacion) values('" + tbNombre.Text + "', '" + tbUbicacion.Text + "', '" + tbObservacion.Text + "');" + classFunciones.agregar_evento("[DEPOSITOS] Se agrego Deposito:"+tbNombre.Text, true);
                NpgsqlCommand command = new NpgsqlCommand(query, con);
                command.ExecuteNonQuery();
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

        private void limpiar()
        {
            tbNombre.Text = "";
            tbObservacion.Text = "";
            tbUbicacion.Text = "";
        }

        private void btSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            guardar();
            this.Close();
        }

        private void btRefrescar_Click(object sender, EventArgs e)
        {
            guardar_agregar();   
        }

        private void frmDepositoAgregar_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (char)Keys.Escape:
                    this.Close();
                    break;
                case (char)Keys.F10:
                    guardar();
                    this.Close();
                    break;
                case (char)Keys.F9:
                    guardar_agregar();
                    break;
            }
        }
    }
}
