using System;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;


namespace Formularios
{
    public partial class infopaciente : Form
    {
        String nombre = String.Empty;
        String ruta = String.Empty;
        String ruta_con = String.Empty;
        String valor = String.Empty;
        public static DateTime datos;
        bool datos_encontrados = false;
        String id_paciente;
        byte[] abyte;
        int edad;
        int id;
        public static int id_pac_pac;
        private int conteo;
        //Evelyn
        //OleDbConnection conexion = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Public\pacientes.accdb");
        //otra pc
        //OleDbConnection conexion = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\DESKTOP-8Q1H8O9\Users\Public\pacientes.accdb");
        //  OleDbConnection conexion = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Windows\proyectos_C#\pacientes.accdb");
        //OleDbConnection conexion = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Z:05. Clínica\5.3 Fundacáncer\BD\BD\pacientes.accdb");
        OleDbConnection conexion = conexiones.conexion;

        OleDbCommand comando = new OleDbCommand();
        public infopaciente()
        {

            InitializeComponent();
            //button2.Enabled = false;
            button3.Visible = false;
            button5.Visible = false;
            conteo = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                String seguro = null;

                String sexo = null;
                String alergico = null;







                if (chexsi.Checked == true && chexno.Checked == false)
                {
                    seguro = "si";
                }
                else if (chexno.Checked == true && chexsi.Checked == false)
                {
                    seguro = "no";
                }
                else
                {
                    seguro = null;
                }
                if (chexM.Checked == true && chexF.Checked == false)
                {
                    sexo = "M";
                }
                else if (chexF.Checked == true && chexM.Checked == false)
                {
                    sexo = "F";
                }
                else
                {
                    sexo = null;
                }

                if (chexalergsi.Checked == true && chexalergno.Checked == false)
                {
                    alergico = "si";
                }
                else if (chexalergno.Checked == true && chexalergsi.Checked == false)
                {
                    alergico = "no";
                }
                else
                {
                    alergico = null;
                }

                if (datos_encontrados == false)
                {


                    if (pbimagen.Image == null)
                    {
                        conexion.Open();
                        comando.Connection = conexion;

                        comando.CommandText = "INSERT INTO informe_p (cedula, nombre, fecha, sexo, telefono, seguro, direccion, lugar_trabajo, ocupacion, estado_civil, medico_referente, alergico,app, ahf, medicamentos, aqt,fecha_nac ) VALUES ('" + txtcedula.Text + "','" + txtnombre.Text + "', '" + datetime.Value + "','" + sexo + "','" + txttelefono.Text + "','" + seguro + "','" + txtdireccion.Text + "','" + txtlugar_trabajo.Text + "','" + txtocupacion.Text + "','" + estado_civil.Text + "','" + txtmedicorefe.Text + "', '" + alergico + "', '" + txtapp.Text + "', '" + txthf.Text + "', '" + medicamentos.Text + "','" + txtaqt.Text + "','" + dateTimePicker1.Value.Date + "')";

                        comando.ExecuteNonQuery();
                        conexion.Close();




                        MessageBox.Show("REGISTRO SE COMPLETÓ SATISFACTORIAMENTE", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        button2.Enabled = false;
                        button3.Visible = true;
                        button2.Visible = false;
                        conexion.Close();


                    }
                    else
                    {
                        MemoryStream ms = new MemoryStream();

                        pbimagen.Image.Save(ms, ImageFormat.Jpeg);
                        byte[] abyte = ms.ToArray();

                        conexion.Open();
                        comando.Connection = conexion;

                        comando.CommandText = "INSERT INTO informe_p (cedula, nombre, fecha, sexo, telefono, seguro, direccion, lugar_trabajo, ocupacion, estado_civil, medico_referente, alergico,app, ahf, medicamentos, aqt,imagen ) VALUES ('" + txtcedula.Text + "','" + txtnombre.Text + "', '" + datetime.Value + "','" + sexo + "','" + txttelefono.Text + "','" + seguro + "','" + txtdireccion.Text + "','" + txtlugar_trabajo.Text + "','" + txtocupacion.Text + "','" + estado_civil.Text + "','" + txtmedicorefe.Text + "', '" + alergico + "', '" + txtapp.Text + "', '" + txthf.Text + "', '" + medicamentos.Text + "','" + txtaqt.Text + "',imagen)";
                        comando.Parameters.AddWithValue("imagen", abyte);
                        comando.ExecuteNonQuery();
                        conexion.Close();
                        MessageBox.Show("REGISTRO SE COMPLETÓ SATISFACTORIAMENTE", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        button2.Enabled = false;
                        button3.Visible = true;
                        button2.Visible = false;
                    }






                }
                else
                {
                    MessageBox.Show("EL PACIENTE QUE INTENTA INGRESAR YA SE ENCUENTRA DENTRO DE NUESTRO SISTEMA", "Información", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }

            }
            catch (Exception k)
            {
                MessageBox.Show("Error, Vuelva a intentarlo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void chexsi_CheckedChanged(object sender, EventArgs e)
        {
            chexno.Checked = false;

        }

        private void chexno_CheckedChanged(object sender, EventArgs e)
        {
            chexsi.Checked = false;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            datos_encontrados = false;
            /*
             Limpia de campor
             */
            pbimagen.Image = null;
            lb_archivo.Items.Clear();
            txtnombre.Text = "";
            datetime.Text = "";

            chexF.Checked = false;
            chexM.Checked = false;
            txttelefono.Text = "";
            chexno.Checked = false;
            chexsi.Checked = false;
            txtdireccion.Text = "";
            txtlugar_trabajo.Text = "";
            txtocupacion.Text = "";
            estado_civil.Text = "";
            txtmedicorefe.Text = "";
            chexalergno.Checked = false;
            chexalergsi.Checked = false;
            txtapp.Text = "";
            txthf.Text = "";
            medicamentos.Text = "";
            txtaqt.Text = "";


            /*
               ////////////////////////////////////7   
             */


            String alergico;
            String seguro;
            String sexo;
            string consulta;

            try
            {

                conexion.Open();
                consulta = "SELECT id_paciente, nombre, sexo,telefono,  seguro, direccion,lugar_trabajo,ocupacion,estado_civil, medico_referente, alergico,app, ahf, medicamentos,aqt,imagen,fecha_nac FROM informe_p WHERE cedula = ?";
                OleDbCommand appDB = new OleDbCommand(consulta, conexion);


                appDB.Parameters.AddWithValue("?", txtcedula.Text);
                appDB.ExecuteNonQuery();

                OleDbDataReader dr = appDB.ExecuteReader();

                Boolean exisregistro = dr.HasRows;
                if (exisregistro)
                {
                    while (dr.Read())

                    {

                        id_paciente = dr["id_paciente"].ToString();
                        id = Int32.Parse(id_paciente);
                        txtnombre.Text = dr["nombre"].ToString();


                        sexo = dr["sexo"].ToString();
                        if (sexo == "M")
                        {
                            chexM.Checked = true;
                            chexF.Checked = false;
                        }
                        else
                        {
                            chexF.Checked = true;
                            chexM.Checked = false;
                        }

                        txttelefono.Text = dr["telefono"].ToString();

                        seguro = dr["seguro"].ToString();
                        if (seguro == "si")
                        {
                            chexsi.Checked = true;
                            chexno.Checked = false;
                        }
                        else
                        {
                            chexno.Checked = true;
                            chexsi.Checked = false;
                        }
                        //seguro, direccion, medico_referente, alergico,app, apf, medicamentos
                        txtdireccion.Text = dr["direccion"].ToString();
                        txtlugar_trabajo.Text = dr["lugar_trabajo"].ToString();
                        txtocupacion.Text = dr["ocupacion"].ToString();
                        estado_civil.Text = dr["estado_civil"].ToString();
                        txtmedicorefe.Text = dr["medico_referente"].ToString();
                        alergico = dr["alergico"].ToString();
                        if (alergico == "si")
                        {
                            chexalergsi.Checked = true;
                            chexalergno.Checked = false;
                        }
                        else
                        {
                            chexalergno.Checked = true;
                            chexalergsi.Checked = false;
                        }
                        txtapp.Text = dr["app"].ToString();
                        txthf.Text = dr["ahf"].ToString();
                        medicamentos.Text = dr["medicamentos"].ToString();

                        txtaqt.Text = dr["aqt"].ToString();
                        dateTimePicker1.Text = dr["fecha_nac"].ToString();

                        if (dr["imagen"] == DBNull.Value)
                        {

                        }
                        else
                        {
                            MemoryStream ms = new MemoryStream((byte[])dr["imagen"]);


                            Bitmap bm = new Bitmap(ms);
                            pbimagen.Image = bm;

                        }

                        datos_encontrados = true;
                        button2.Enabled = false;
                        button3.Visible = true;
                        button2.Visible = false;


                        nombre = txtcedula.Text;
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
                                label18.Text = " ";
                            }
                            else
                            {
                                label18.Text = "El paciente no cuenta con archivos adjuntos";
                            }
                        }


                    }
                    button5.Visible = true;
                }
                else
                {
                    MessageBox.Show("El número de cédula que ingreso no se encuentra en nuestra base de datos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    button2.Enabled = true;
                    button3.Visible = false;
                    button2.Visible = true;
                    button5.Visible = false;
                }


                conexion.Close();
            }
            catch (Exception f) {
                MessageBox.Show("Error, Vuelva a intentarlo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {//variables para lo checkbox
            try
            {
                String seguro = null;
                String sexo = null;
                String alergico = null;


                id = Int32.Parse(id_paciente);
                String consulta;

                //Valores transformar 
                if (chexsi.Checked == true && chexno.Checked == false)
                {
                    seguro = "si";
                }
                else if (chexno.Checked == true && chexsi.Checked == false)
                {
                    seguro = "no";
                }
                else
                {
                    seguro = null;
                }
                if (chexM.Checked == true && chexF.Checked == false)
                {
                    sexo = "M";
                }
                else if (chexF.Checked == true && chexM.Checked == false)
                {
                    sexo = "F";
                }
                else
                {
                    sexo = null;
                }

                if (chexalergsi.Checked == true && chexalergno.Checked == false)
                {
                    alergico = "si";
                }
                else if (chexalergno.Checked == true && chexalergsi.Checked == false)
                {
                    alergico = "no";
                }
                else
                {
                    alergico = null;
                }

                if (pbimagen.Image == null)
                {
                  
                    conexion.Open();
                    comando.Connection = conexion;
                    comando.CommandText = "UPDATE informe_p SET cedula='" + txtcedula.Text + "', nombre = '" + txtnombre.Text + "', edad ='" + edad + "', sexo ='" + sexo + "', telefono ='" + txttelefono.Text + "' , seguro ='" + seguro + "' , direccion ='" + txtdireccion.Text + "' , lugar_trabajo = '" + txtlugar_trabajo.Text + "', ocupacion = '" + txtocupacion.Text + "', estado_civil = '" + estado_civil.Text + "', medico_referente = '" + txtmedicorefe.Text + "', alergico = '" + alergico + "', app = '" + txtapp.Text + "', ahf = '" + txthf.Text + "', medicamentos = '" + medicamentos.Text + "', aqt = '" + txtaqt.Text + "' WHERE id_paciente = " + id + "";

                    
                    comando.ExecuteNonQuery();
                    conexion.Close();


                    MessageBox.Show("Datos Actualizados", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    conexion.Close();
                }
                else {
                    MemoryStream ma = new MemoryStream();

                    pbimagen.Image.Save(ma, ImageFormat.Jpeg);
                    byte[] bts = ma.ToArray();

                    conexion.Open();
                    comando.Connection = conexion;
                    comando.CommandText = "UPDATE informe_p SET cedula='" + txtcedula.Text + "', nombre = '" + txtnombre.Text + "', edad ='" + edad + "', sexo ='" + sexo + "', telefono ='" + txttelefono.Text + "' , seguro ='" + seguro + "' , direccion ='" + txtdireccion.Text + "' , lugar_trabajo = '" + txtlugar_trabajo.Text + "', ocupacion = '" + txtocupacion.Text + "', estado_civil = '" + estado_civil.Text + "', medico_referente = '" + txtmedicorefe.Text + "', alergico = '" + alergico + "', app = '" + txtapp.Text + "', ahf = '" + txthf.Text + "', medicamentos = '" + medicamentos.Text + "', aqt = '" + txtaqt.Text + "', imagen = @bts WHERE id_paciente = " + id + "";

                    comando.Parameters.AddWithValue("bts", bts);
                    comando.ExecuteNonQuery();
                    conexion.Close();


                    MessageBox.Show("Datos Actualizados", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    conexion.Close();

                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron guardar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void infopaciente_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txttelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtaqt_TextChanged(object sender, EventArgs e)
        {

        }

        private void informe_Click(object sender, EventArgs e)
        {

        }

        private void txtcedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = char.IsWhiteSpace(e.KeyChar);
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {




                    datos_encontrados = false;
                    /*
                     Limpia de campor
                     */
                    pbimagen.Image = null;
                    lb_archivo.Items.Clear();
                    txtnombre.Text = "";
                    datetime.Text = "";

                    chexF.Checked = false;
                    chexM.Checked = false;
                    txttelefono.Text = "";
                    chexno.Checked = false;
                    chexsi.Checked = false;
                    txtdireccion.Text = "";
                    txtlugar_trabajo.Text = "";
                    txtocupacion.Text = "";
                    estado_civil.Text = "";
                    txtmedicorefe.Text = "";
                    chexalergno.Checked = false;
                    chexalergsi.Checked = false;
                    txtapp.Text = "";
                    txthf.Text = "";
                    medicamentos.Text = "";
                    txtaqt.Text = "";


                    /*
                       ////////////////////////////////////7   
                     */


                    String alergico;
                    String seguro;
                    String sexo;
                    string consulta;

                    conexion.Open();
                    consulta = "SELECT id_paciente, nombre, sexo,telefono,  seguro, direccion,lugar_trabajo,ocupacion,estado_civil, medico_referente, alergico,app, ahf, medicamentos,aqt,imagen,fecha_nac FROM informe_p WHERE cedula = ?";
                    OleDbCommand appDB = new OleDbCommand(consulta, conexion);


                    appDB.Parameters.AddWithValue("?", txtcedula.Text);
                    appDB.ExecuteNonQuery();

                    OleDbDataReader dr = appDB.ExecuteReader();

                    Boolean exisregistro = dr.HasRows;
                    if (exisregistro)
                    {
                        while (dr.Read())

                        {

                            id_paciente = dr["id_paciente"].ToString();
                            id = Int32.Parse(id_paciente);
                            txtnombre.Text = dr["nombre"].ToString();


                            sexo = dr["sexo"].ToString();
                            if (sexo == "M")
                            {
                                chexM.Checked = true;
                                chexF.Checked = false;
                            }
                            else
                            {
                                chexF.Checked = true;
                                chexM.Checked = false;
                            }

                            txttelefono.Text = dr["telefono"].ToString();

                            seguro = dr["seguro"].ToString();
                            if (seguro == "si")
                            {
                                chexsi.Checked = true;
                                chexno.Checked = false;
                            }
                            else
                            {
                                chexno.Checked = true;
                                chexsi.Checked = false;
                            }
                            //seguro, direccion, medico_referente, alergico,app, apf, medicamentos
                            txtdireccion.Text = dr["direccion"].ToString();
                            txtlugar_trabajo.Text = dr["lugar_trabajo"].ToString();
                            txtocupacion.Text = dr["ocupacion"].ToString();
                            estado_civil.Text = dr["estado_civil"].ToString();
                            txtmedicorefe.Text = dr["medico_referente"].ToString();
                            alergico = dr["alergico"].ToString();
                            if (alergico == "si")
                            {
                                chexalergsi.Checked = true;
                                chexalergno.Checked = false;
                            }
                            else
                            {
                                chexalergno.Checked = true;
                                chexalergsi.Checked = false;
                            }
                            txtapp.Text = dr["app"].ToString();
                            txthf.Text = dr["ahf"].ToString();
                            medicamentos.Text = dr["medicamentos"].ToString();

                            txtaqt.Text = dr["aqt"].ToString();
                            dateTimePicker1.Text = dr["fecha_nac"].ToString();

                            if (dr["imagen"] == DBNull.Value)
                            {

                            }
                            else
                            {
                                MemoryStream ms = new MemoryStream((byte[])dr["imagen"]);


                                Bitmap bm = new Bitmap(ms);
                                pbimagen.Image = bm;

                            }

                            datos_encontrados = true;
                            button2.Enabled = false;
                            button3.Visible = true;
                            button2.Visible = false;


                            nombre = txtcedula.Text;
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
                                    label18.Text = " ";
                                }
                                else
                                {
                                    label18.Text = "El paciente no cuenta con archivos adjuntos";
                                }
                            }


                        }
                        button5.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("El número de cédula que ingreso no se encuentra en nuestra base de datos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        button2.Enabled = true;
                        button3.Visible = false;
                        button2.Visible = true;
                        button5.Visible = false;
                    }


                    conexion.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vuelva a intentarlo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {




        }

        private void lb_archivo_MouseDoubleClick(object sender, MouseEventArgs e)
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

        private void button4_Click_1(object sender, EventArgs e)
        {
            //seleccionar imagen
            pbimagen.Image = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Imagenes| *.jpg; *.png";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            openFileDialog.Title = "Seleccionar Imagen";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pbimagen.Image = Image.FromFile(openFileDialog.FileName);
            }
            else
            {
                pbimagen.Image = null;
            }


        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            control.cedula = txtcedula.Text;
            datos = datetime.Value;

            Form formulario = new control();
            formulario.Show();
        }

        private void dateTimePicker1_EnabledChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ContextMenuStripChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime fechaActual = DateTime.Today;
            int edad = fechaActual.Year - dateTimePicker1.Value.Year;
            if (fechaActual < dateTimePicker1.Value.AddYears(edad)) edad--;
            label17.Text = "Edad: " + edad + " años";
        }
    }
}

