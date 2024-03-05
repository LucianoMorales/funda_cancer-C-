using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Formularios
{
    public partial class historial : Form
    {
        //Evelyn
        //OleDbConnection conexion = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Public\pacientes.accdb");
        //otra pc
        //OleDbConnection conexion = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\DESKTOP-8Q1H8O9\Users\Public\pacientes.accdb");
        //OleDbConnection conexion = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Z:05. Clínica\5.3 Fundacáncer\BD\BD\pacientes.accdb");
        OleDbConnection conexion = conexiones.conexion;
        OleDbCommand comando = new OleDbCommand();
        public static int id_paciente;
        public historial()
        {
            InitializeComponent();
            String consulta = "select fecha, presion_arterial,peso,talla,pulso from informe_datos where id_paciente = @id";
            OleDbCommand cmd = new OleDbCommand(consulta, conexion);
            cmd.Parameters.AddWithValue("@id", id_paciente);

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
           



            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void historial_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
