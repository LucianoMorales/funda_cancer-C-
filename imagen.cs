using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Formularios
{
    public partial class imagen : Form
    {
        public static string id;
        string id_pacientes;
        int id_2;


        //OleDbConnection conexion = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Public\pacientes.accdb");
        //OleDbConnection conexion = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\DESKTOP-8Q1H8O9\Users\Public\pacientes.accdb");

        //OleDbConnection conexion = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Z:05. Clínica\5.3 Fundacáncer\BD\BD\pacientes.accdb");
        OleDbConnection conexion = conexiones.conexion;
        OleDbCommand comando = new OleDbCommand();

        public imagen()
        {
            InitializeComponent();

            try
            {
                conexion.Close();
                //Datos booleanos



                /////////////////////////////

                conexion.Open();
                string consulta = "SELECT id_paciente FROM informe_p WHERE cedula = ?";
                OleDbCommand appDB = new OleDbCommand(consulta, conexion);
                appDB.Parameters.AddWithValue("?", id);
                appDB.ExecuteNonQuery();

                OleDbDataReader dr = appDB.ExecuteReader();
                Boolean exisregistro = dr.HasRows;
                if (exisregistro)
                {
                    while (dr.Read())

                    {

                        id_pacientes = dr["id_paciente"].ToString();



                    }
                }


                //BUSCA LAS FECHAS

                int valor = Int32.Parse(id_pacientes);
                DataTable dt = new DataTable();
                String query = "SELECT id, fecha FROM informe_lesion WHERE id_paciente=@id";
                OleDbCommand cmd = new OleDbCommand(query, conexion);
                cmd.Parameters.AddWithValue("@id", valor);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.SelectCommand = cmd;
                da.Fill(dt);
                cmbfechas.DisplayMember = "fecha";
                cmbfechas.ValueMember = "id";
                cmbfechas.DataSource = dt;
                if (cmbfechas.Items.Count <= 0)
                {


                    cmbfechas.Text = "";
                    cmbfechas.DataSource = null;
                    cmbfechas.Items.Clear();

                }
                else
                {





                }




                conexion.Close();


            }
            catch (InvalidCastException g)
            {
                MessageBox.Show("Error", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }





        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void imagen_Load(object sender, EventArgs e)
        {

            Image x = infomedico.imagen_;
            mostrar_imagen.Image = x;
        }

        public static implicit operator imagen(MemoryStream v)
        {
            throw new NotImplementedException();
        }

        private void cmbfechas_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void cmbfechas_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void cmbfechas_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                id_2 = (int)cmbfechas.SelectedValue;

                conexion.Open();
                String consul = "SELECT lesion From informe_lesion WHERE id= ?";
                OleDbCommand x = new OleDbCommand(consul, conexion);


                x.Parameters.AddWithValue("?", id_2);
                x.ExecuteNonQuery();

                OleDbDataReader dr1 = x.ExecuteReader();

                Boolean exisregistroo = dr1.HasRows;
                if (exisregistroo)
                {
                    while (dr1.Read())

                    {

                        if (dr1["lesion"] == DBNull.Value)
                        {
                            mostrar_imagen = null;
                        }
                        else
                        {
                            MemoryStream ms = new MemoryStream((byte[])dr1["lesion"]);
                            Bitmap bm = new Bitmap(ms);
                            mostrar_imagen.Image = bm;

                        }

                    }
                }
                conexion.Close();
            }
            catch (Exception f) {
                MessageBox.Show("error, intentelo de nuevo");
            }



        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbfechas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
