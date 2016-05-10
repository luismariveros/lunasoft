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
    public partial class frmBackup : Form
    {
        bool band_formulario_crear = false;
        bool band_formulario_restablecer = false;

        public frmBackup()
        {
            InitializeComponent();
        }

        private void controlar_nivel_usuario()
        {
            switch (frmInicio.User.Usuario_Nivel)
            {
                case 1:
                    this.btElegirRestablecer.Enabled = true;
                    this.btRestablecerBK.Enabled = true;
                    break;
            }
        }

        private void executeCommand(string commandType, string commandSentence)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo();
                info.FileName = "C:\\Program Files\\PostgreSQL\\8.3\\bin\\" + commandType + ".exe ";
                info.Arguments = commandSentence;
                info.CreateNoWindow = true;
                info.UseShellExecute = false;
                try
                {
                    using (System.Diagnostics.Process proc = System.Diagnostics.Process.Start(info))
                    {
                        //proc.StartInfo = info;
                        //proc.Start();
                        proc.WaitForExit();
                    }
                }
                catch
                {
                    MessageBox.Show("Error");
                }
                if(commandType == "pg_dump")
                    toolStripStatusLabel1.Text = "Copia de Seguridad " +  tbNombre.Text + ".backup creada exitosamente";                
                if(commandType == "pg_restore")
                    toolStripStatusLabel1.Text = "Copia de Seguridad " + tbNombre.Text + ".backup restaurada exitosamente";                
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = ex.ToString();
            }
        }

        private void btElegir_Click(object sender, EventArgs e)
        {
            if (tbNombre.Text != "")
            {
                toolStripStatusLabel1.Text = "Elegir ubicación para el Backup .....";
                FolderBrowserDialog ubicacion = new FolderBrowserDialog();
                ubicacion.RootFolder = Environment.SpecialFolder.MyComputer;

                if (ubicacion.ShowDialog() == DialogResult.OK)
                {
                    tbUbicacion.Text = ubicacion.SelectedPath;
                    band_formulario_crear = true;
                    toolStripStatusLabel1.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Nombre de archivo vacío.\n\nIntroduzca el nombre que tendrá el backup.", "LunaSoft :: ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btbCrearBK_Click(object sender, EventArgs e)
        {
            if (band_formulario_crear)
            {
                toolStripStatusLabel1.Text = "Creando Copia de Seguridad .....";
                string cmd = "-h localhost -p 5432 -U postgres -F c -b -v -f \"" + tbUbicacion.Text + @"\" + tbNombre.Text + ".backup\" lunasoft";
                executeCommand("pg_dump", cmd);
            }
            else
            {
                MessageBox.Show("Campos vacíos.\n\nIntroduzca el nombre que tendrá el backup y su ubicación.", "LunaSoft :: ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btRestablecerBK_Click(object sender, EventArgs e)
        {
            if (band_formulario_restablecer)
            {
                if (MessageBox.Show("Cuidado. \n\nSe borrará toda la Base de Datos y restablecerá al archivo seleccionado.\n\n Está seguro?", "LunaSoft :: Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string cmd = "-h localhost -p 5432 -U postgres -d lunasoft -v \"" + tbArchivo.Text + "\"";
                    executeCommand("dropdb", "-U postgres lunasoft");
                    //executeCommand("pg_restore", cmd);
                }
            }
            else
            {
                MessageBox.Show("Debe elegir primero el archivo para restablecer.", "LunaSoft :: ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btElegirRestablecer_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Elegir un Backup para restablecer .....";
            OpenFileDialog arc = new OpenFileDialog();
            arc.InitialDirectory = @"C:\lunasoft\";
            arc.Filter = "Copias de Seguridad (*.backup)|*.backup";
            arc.CheckFileExists = true;
            arc.CheckPathExists = true;

            if (arc.ShowDialog() == DialogResult.OK)
            {
                tbArchivo.Text = arc.FileName;
                band_formulario_restablecer = true;
                toolStripStatusLabel1.Text = "";
            }
        }

        private void frmBackup_Load(object sender, EventArgs e)
        {
            controlar_nivel_usuario();
        }        
    }
}
