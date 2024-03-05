using System;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Formularios
{


    public partial class control : Form
    {
        DateTime datitos;
        String id_paciente;
        public static String cedula;
        int id;
        int id_;

        //OleDbConnection conexion = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Public\pacientes.accdb");
        //otra pc
        //OleDbConnection conexion = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\DESKTOP-8Q1H8O9\Users\Public\pacientes.accdb");
        //OleDbConnection conexion = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Windows\proyectos_C#\pacientes.accdb");
        //OleDbConnection conexion = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Z:05. Clínica\5.3 Fundacáncer\BD\BD\pacientes.accdb");

        OleDbConnection conexion = conexiones.conexion;

        OleDbCommand comando = new OleDbCommand();



        public control()
        {
            InitializeComponent();
            datitos = infopaciente.datos;

            txtcedula.Text = cedula;
            pictureBox1.Visible = false;
            button5.Visible = false;
            barra2.Visible = false;
            lbl7.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void control_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                String cedula = txtcedula.Text;
                conexion.Open();

                String consulta = "SELECT id_paciente From informe_p  WHERE cedula = '" + txtcedula.Text + "'";
                OleDbCommand appDB = new OleDbCommand(consulta, conexion);



                appDB.ExecuteNonQuery();

                OleDbDataReader dr = appDB.ExecuteReader();

                Boolean exisregistro = dr.HasRows;
                if (exisregistro)
                {
                    while (dr.Read())

                    {

                        id_paciente = dr["id_paciente"].ToString();
                        id = Int32.Parse(id_paciente);
                    }
                }



                comando.Connection = conexion;

                comando.CommandText = "INSERT INTO informe_datos(id_paciente, fecha,presion_arterial,peso,talla, pulso ) VALUES (?,'" + datitos + "','" + txtpresion.Text + "', '" + txtpeso.Text + "','" + txttalla.Text + "','" + txtpresion.Text + "')";
                comando.Parameters.AddWithValue("?", id);
                comando.ExecuteNonQuery();
                conexion.Close();
                MessageBox.Show("REGISTRO SE COMPLETÓ SATISFACTORIAMENTE", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);




                conexion.Close();
            }
            catch (Exception m)
            {
                MessageBox.Show("Error, Vuelva a intentarlo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            conexion.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            lbl7.Visible = true;

            barra2.Visible = true;
            barra1.Visible = false;

            lbl2.Visible = false;
            lbl3.Visible = false;
            lbl4.Visible = false;
            lbl5.Visible = false;
            lblcontrol.Visible = false;

            txtpeso.Visible = false;
            txtpresion.Visible = false;
            txttalla.Visible = false;
            txtpresion.Visible = false;
            txtpulso.Visible = false;
            pictureBox1.Visible = true;
            button5.Visible = true;
            button2.Visible = false;


        }

        private void button3_Click(object sender, EventArgs e)

        {
            lbl7.Visible = false;
            panel3.Visible = true;
            barra1.Visible = true;
            barra2.Visible = false;

            lbl2.Visible = true;
            lbl3.Visible = true;
            lbl4.Visible = true;
            lbl5.Visible = true;
            lblcontrol.Visible = true;

            txtpeso.Visible = true;
            txtpresion.Visible = true;
            txttalla.Visible = true;
            txtpresion.Visible = true;
            txtpulso.Visible = true;

            button2.Visible = true;
            button5.Visible = false;
            pictureBox1.Visible = false;
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void barra2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            try
            {
                if (pictureBox1.Image==null)
                {
                    MessageBox.Show("Seleccione una imagen antes de guardar");
                }
                else {
                    String cedula = txtcedula.Text;
                    conexion.Open();

                    String consulta = "SELECT id_paciente From informe_p  WHERE cedula = '" + txtcedula.Text + "'";
                    OleDbCommand appDB = new OleDbCommand(consulta, conexion);



                    appDB.ExecuteNonQuery();

                    OleDbDataReader dra = appDB.ExecuteReader();

                    Boolean exiregistro = dra.HasRows;
                    if (exiregistro)
                    {
                        while (dra.Read())

                        {

                            id_paciente = dra["id_paciente"].ToString();
                            id_ = Int32.Parse(id_paciente);
                        }
                    }


                    MemoryStream ms = new MemoryStream();

                    pictureBox1.Image.Save(ms, ImageFormat.Jpeg);
                    byte[] abyte = ms.ToArray();


                    comando.Connection = conexion;

                    comando.CommandText = "INSERT INTO informe_lesion (id_paciente, fecha, lesion ) VALUES (?,'" + datitos + "',imagen)";
                    comando.Parameters.AddWithValue("?", id_);
                    comando.Parameters.AddWithValue("imagen", abyte);
                    comando.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("REGISTRO SE COMPLETÓ SATISFACTORIAMENTE", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);


                    conexion.Close();
                }
            }
            catch (Exception m)
            {
                MessageBox.Show("Error, Vuelva a intentarlo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {

            try
            {
                pictureBox1.Image = null;
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Imagenes| *.jpg; *.png";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                openFileDialog.Title = "Seleccionar Imagen";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                }
                else
                {
                    pictureBox1.Image = null;
                }
            }
            catch (Exception f) {
                MessageBox.Show("Error, Vuelva a intentarlo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }


}
