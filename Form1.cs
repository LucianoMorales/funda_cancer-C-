using System;
using System.Windows.Forms;

namespace Formularios
{
    public partial class Yolucho : Form
    {
        String nombre = String.Empty;
        String ruta = String.Empty;
        String ruta_con = String.Empty;
        String valor = String.Empty;
        public Yolucho()
        {
            InitializeComponent();
            diseño.Visible = false;
            diseño1.Visible = false;
            diseño2.Visible = false;
            diseño3.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void abrirpanelhijo(object hijo)
        {

            if (this.panelhijo.Controls.Count > 0)
                this.panelhijo.Controls.RemoveAt(0);
            Form fh = hijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelhijo.Controls.Add(fh);
            this.panelhijo.Tag = fh;
            fh.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            abrirpanelhijo(new digitalizacion());
            diseño.Visible = true;

            diseño1.Visible = false;
            diseño2.Visible = false;
            diseño3.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            abrirpanelhijo(new infopaciente());
            diseño.Visible = false;
            diseño1.Visible = true;
            diseño2.Visible = false;
            diseño3.Visible = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            abrirpanelhijo(new infomedico());
            diseño.Visible = false;
            diseño1.Visible = false;
            diseño2.Visible = true;
            diseño3.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            abrirpanelhijo(new historia());
            diseño.Visible = false;
            diseño1.Visible = false;
            diseño2.Visible = false;
            diseño3.Visible = true;
        }
    }
}
