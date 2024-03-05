using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Formularios
{
    public partial class digitalizacion : Form
    {
        String texto;
        String nombre = String.Empty;
        String ruta = String.Empty;
        String ruta_con = String.Empty;
        String valor = String.Empty;
        public digitalizacion()
        {
            InitializeComponent();
        }

      
        private void digitalizacion_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'pacientesDataSet.informe_p' Puede moverla o quitarla según sea necesario.
            //this.informe_pTableAdapter.Fill(this.pacientesDataSet.informe_p);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            lb_archivo.Items.Clear();
            nombre = cedula.Text;
            if (String.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Porfavor, llenar el campo de la cedula", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ruta = @"Z:\05. Clínica\5.3 Fundacáncer\Pacientes" + @"\" + nombre;
                ruta_con = ruta + @"\";
                //  System.Diagnostics.Process.Start("explorer.exe", ruta);


                DirectoryInfo di = new DirectoryInfo(@ruta);
                if (di.Exists)
                {
                    foreach (var item in di.GetFiles())
                    {
                        lb_archivo.Items.Add(item.Name);

                    }
                }
                else
                {
                    MessageBox.Show("numero de cédula buscado no encontrado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (lb_archivo.Items.Count <= 0)
            {
                MessageBox.Show("Escoger un Archivo de la lista", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                valor = lb_archivo.SelectedItem.ToString();
                ProcessStartInfo psi = new ProcessStartInfo()
                {
                    FileName = ruta_con + valor,
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsWhiteSpace(e.KeyChar);

            if (e.KeyChar == (char)Keys.Enter)
            {


                lb_archivo.Items.Clear();
                nombre = cedula.Text;
                if (String.IsNullOrEmpty(nombre))
                {
                    MessageBox.Show("Porfavor, llenar el campo de la cedula", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ruta = @"Z:\05. Clínica\5.3 Fundacáncer\Pacientes" + @"\" + nombre;
                    ruta_con = ruta + @"\";
                    //  System.Diagnostics.Process.Start("explorer.exe", ruta);


                    DirectoryInfo di = new DirectoryInfo(@ruta);
                    if (di.Exists)
                    {
                        foreach (var item in di.GetFiles())
                        {
                            lb_archivo.Items.Add(item.Name);

                        }
                    }
                    else
                    {
                        MessageBox.Show("numero de cédula buscado no encontrado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }

            }
        }

        private void cedula_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cedula.Text.Trim();
            }

        }
        private void cedula_KeyUp(object sender, KeyEventArgs e)
        {


        }
    }
}
