using System;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Formularios
{
    public partial class infomedico : Form
    {
        String mensaje = "LLENAR LOS CAMPOS QUE HACEN FALTA";
        bool permiso;
        string referido;
        String biopsia;
        String Cadena;
        String examen;
        int sumatoria;
        public static int enviar_idpaciente;
        public static String coordenadas_x;
        public static String coordenadas_y;
        public static Bitmap enviodatos;
        public static byte datos;
        public static Bitmap imagen_;
        String nombre = String.Empty;
        String ruta = String.Empty;
        String ruta_con = String.Empty;
        String valor = String.Empty;
        byte[] abyte;
        int id_fecha;
        int id_pacientes_;
        string e;
        String id_pacientes;

        OleDbConnection conexion = conexiones.conexion;

        //OleDbConnection conexion = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Public\pacientes.accdb");
        //OleDbConnection conexion = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\DESKTOP-8Q1H8O9\Users\Public\pacientes.accdb");

        //OleDbConnection conexion = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Z:05. Clínica\5.3 Fundacáncer\BD\BD\pacientes.accdb");
        OleDbCommand comando = new OleDbCommand();

        public infomedico()
        {
            InitializeComponent();
            abrirsis.Hide();
            btnnuevo_re.Hide();
            btnmodificar.Visible = false;
            btnmodificar.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;


        }

        private void informe_docBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {



        }

        private void infomedico_Load(object sender, EventArgs e)
        {

        }

        private void motivoTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {


            try
            {
                conexion.Close();
                //Datos booleanos
                permiso = true;
                btnnuevo_re.Visible = true;
                limpiar_datos_doctor();


                /////////////////////////////
                btnnuevo_re.Hide();
                String alergico;
                String seguro;
                String sexo;
                string consulta;
                string fecha;
                if (txtcedula.Text != " ")
                {
                    conexion.Open();
                    consulta = "SELECT id_paciente, nombre, fecha, fecha_nac, sexo,  seguro, direccion, medico_referente, alergico,app, ahf, medicamentos, aqt,imagen FROM informe_p WHERE cedula = ?";
                    OleDbCommand appDB = new OleDbCommand(consulta, conexion);
                    appDB.Parameters.AddWithValue("?", txtcedula.Text);
                    appDB.ExecuteNonQuery();

                    OleDbDataReader dr = appDB.ExecuteReader();
                    Boolean exisregistro = dr.HasRows;
                    if (exisregistro)
                    {
                        while (dr.Read())

                        {

                            id_pacientes = dr["id_paciente"].ToString();
                            id_pacientes_ = Int32.Parse(id_pacientes);
                            enviar_idpaciente = id_pacientes_;
                            txtnombre.Text = dr["nombre"].ToString();
                            date.Text = dr["fecha"].ToString();
                            fecha = dr["fecha"].ToString();

                            dtpicker1.Text = dr["fecha_nac"].ToString();
                            sexo = dr["sexo"].ToString();
                            if (sexo == "M")
                            {
                                chexsexom.Checked = true;
                                chexsexof.Checked = false;
                            }
                            else
                            {
                                chexsexof.Checked = true;
                                chexsexom.Checked = false;
                            }

                            seguro = dr["seguro"].ToString();
                            if (seguro == "si")
                            {
                                chexsegurosi.Checked = true;
                                chexsegurono.Checked = false;
                            }
                            else
                            {
                                chexsegurono.Checked = true;
                                chexsegurosi.Checked = false;
                            }
                            //seguro, direccion, medico_referente, alergico,app, apf, medicamentos
                            txtdireccion.Text = dr["direccion"].ToString();
                            txtmedico_re.Text = dr["medico_referente"].ToString();
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
                            txtahf.Text = dr["ahf"].ToString();
                            txtaqt.Text = dr["aqt"].ToString();
                            txtmedicamentos.Text = dr["medicamentos"].ToString();








                            // buscar archivos dentro de las carpetas

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
                                }
                                else
                                {
                                    informacion.Text = "El paciente no cuenta con Archivos adjuntos";

                                }
                            }

                            ///

                        }

                        //BUSCA LOS CONTROLES
                        string consul = "SELECT presion_arterial,peso,talla, pulso From informe_datos  WHERE id_paciente= ?";
                        OleDbCommand envio = new OleDbCommand(consul, conexion);
                        envio.Parameters.AddWithValue("?", enviar_idpaciente);
                        envio.ExecuteNonQuery();

                        OleDbDataReader dr2 = envio.ExecuteReader();
                        Boolean exit = dr2.HasRows;
                        if (exit)
                        {
                            while (dr.Read())
                            {
                                txtpresion_art.Text = dr["presion_arterial"].ToString();

                                txtpeso.Text = dr["peso"].ToString();
                                txttalla.Text = dr["talla"].ToString();
                                txtpulso.Text = dr["pulso"].ToString();
                            }
                        }
                        //BUSCA LAS FECHAS

                        int valor = Int32.Parse(id_pacientes);
                        DataTable dt = new DataTable();
                        String query = "SELECT id, fecha_rm FROM informe_doc WHERE id_paciente=@id";
                        OleDbCommand cmd = new OleDbCommand(query, conexion);
                        cmd.Parameters.AddWithValue("@id", valor);
                        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        cmbfechas.DisplayMember = "fecha_rm";
                        cmbfechas.ValueMember = "id";
                        cmbfechas.DataSource = dt;
                        if (cmbfechas.Items.Count <= 0)
                        {
                            permiso = true;

                            cmbfechas.Text = "";
                            cmbfechas.DataSource = null;
                            cmbfechas.Items.Clear();
                            button2.Visible = true;
                            btnmodificar.Visible = false;
                        }
                        else
                        {
                            permiso = true;
                            mensaje = "EL PACIENTE YA CUENTA CON UN HISTORIAL, SELECCIONAR NUEVO REGISTRO";



                        }

                        button2.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Paciente No encontrado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        limpiar_datos_pacientes();
                        btnmodificar.Visible = false;
                        button2.Visible = true;
                        cmbfechas.Items.Clear();
                        button3.Enabled = false;
                    }
                    conexion.Close();
                    button3.Enabled = true;
                }

                else
                {
                    MessageBox.Show("El campo cédula esta vacio", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    button3.Enabled = true;
                }
            }
            catch (Exception g)
            {
                MessageBox.Show("Error", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }


        private void button3_Click(object sender, EventArgs e)
        {
            cuerpo_humano.datosrecibidos = enviodatos;

            Form formulario = new cuerpo_humano();
            formulario.Show();




        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                sumatoria = 0;
                conexion.Close();
                if (permiso == true)
                {
                    if (String.IsNullOrEmpty(txtmedico.Text))
                    {
                        MessageBox.Show("Faltan Campos por llenar", "Mensaje Informativo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    else
                    {
                        //Selección del Diagnostico
                        if (chexQS.Checked)
                        {
                            Cadena += chexQS.Text + ",";
                        }
                        if (chexQA.Checked)
                        {
                            Cadena += chexQA.Text + ",";
                        }
                        if (chexCB.Checked)
                        {
                            Cadena += chexQA.Text + ",";
                        }
                        if (chexCCE.Checked)
                        {
                            Cadena += chexCCE.Text + ",";
                        }
                        if (chexLD.Checked)
                        {
                            Cadena += chexLD.Text + ",";
                        }
                        if (chexLC.Checked)
                        {
                            Cadena += chexLC.Text + ",";
                        }
                        if (chexP.Checked)
                        {
                            Cadena += chexP.Text + ",";
                        }
                        if (chexM.Checked)
                        {
                            Cadena += chexM.Text + ",";
                        }
                        if (chexotro.Checked)
                        {
                            Cadena += txtdiagotro.Text + ",";

                        }

                        //Seleccion de los examanes realizados 
                        if (chexcompleto.Checked)
                        {
                            chexlesionE.Checked = false;
                            chexsobrecin.Checked = false;
                            examen = chexcompleto.Text;
                            coordenadas_x = "0";
                            coordenadas_y = "0";
                            byte[] abyte = null;

                            sumatoria = 0;
                        }
                        if (chexsobrecin.Checked)
                        {
                            chexlesionE.Checked = false;
                            chexcompleto.Checked = false;
                            examen = chexsobrecin.Text;


                            byte[] abyte = null;
                            sumatoria = 0;
                        }
                        if (chexlesionE.Checked)
                        {
                            chexsobrecin.Checked = false;
                            chexcompleto.Checked = false;
                            examen = chexlesionE.Text;

                            sumatoria = 1;
                        }

                        // Seleccion de biopsia
                        if (chexbiosi.Checked)
                        {
                            biopsia = chexbiosi.Text;
                        }
                        if (chexbiono.Checked)
                        {
                            biopsia = chexbiono.Text;
                        }
                        // Seleccion de referido
                        if (chexrefecss.Checked)
                        {
                            referido = chexrefecss.Text;
                        }
                        if (chexrefate.Checked)
                        {
                            referido = chexrefate.Text;
                        }
                        if (chexminsa.Checked)
                        {
                            referido = chexminsa.Text;
                        }
                        if (chexyolucho.Checked)
                        {
                            referido = chexyolucho.Text;
                        }
                        if (chexion.Checked)
                        {
                            referido = chexion.Text;
                        }
                        if (chexonco.Checked)
                        {
                            referido = chexonco.Text;
                        }
                        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////77
                        //ARREGLAR ERROR

                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////7

                        if (sumatoria == 0)
                        {
                            int id = Int32.Parse(id_pacientes);
                            conexion.Open();
                            comando.Connection = conexion;

                            comando.CommandText = @"INSERT INTO informe_doc ( motivo, impresion_, tratamiento, recomendacion, id_paciente, examen_re, impresion_dia_re, biopsia, referido, fecha_rm, medico) VALUES ('" + txtmotivo.Text + "', '" + txtimpresion_dia.Text + "', '" + txttratamiento.Text + "', '" + txtrecomendacion.Text + "', '" + id + "', '" + examen + "', '" + Cadena + "', '" + biopsia + "', '" + referido + "', '" + datem.Value + "', '" + txtmedico.Text + "')";


                            comando.ExecuteNonQuery();

                            conexion.Close();

                            MessageBox.Show("El registro se guardo con exito", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            permiso = false;
                            mensaje = "IMPOSIBLE GUARDAR LOS DATOS QUE YA FUERON REGISTRADOS";
                            button2.Visible = false;
                            btnmodificar.Visible = true;
                            btnnuevo_re.Visible = true;
                        }
                        else
                        {
                            byte[] abyte = cuerpo_humano.bits;
                            int id = Int32.Parse(id_pacientes);
                            conexion.Open();
                            comando.Connection = conexion;

                            comando.CommandText = @"INSERT INTO informe_doc ( motivo, impresion_, tratamiento, recomendacion, id_paciente, examen_re, impresion_dia_re, biopsia, referido, fecha_rm, medico,coordenadas) VALUES ('" + txtmotivo.Text + "', '" + txtimpresion_dia.Text + "', '" + txttratamiento.Text + "', '" + txtrecomendacion.Text + "', '" + id + "', '" + examen + "', '" + Cadena + "', '" + biopsia + "', '" + referido + "', '" + datem.Value + "', '" + txtmedico.Text + "',coordenadas)";
                            comando.Parameters.AddWithValue("coordenadas", abyte);

                            comando.ExecuteNonQuery();

                            conexion.Close();

                            MessageBox.Show("El registro se guardo con exito", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            permiso = false;
                            mensaje = "IMPOSIBLE GUARDAR LOS DATOS QUE YA FUERON REGISTRADOS";
                            button2.Visible = false;
                            btnmodificar.Visible = true;
                            btnnuevo_re.Visible = true;
                        }
                        //conexion e ingreso de datos a la BD;

                    }

                }
                else
                {

                    MessageBox.Show(mensaje, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            catch (Exception m) {
                MessageBox.Show("Error, Vuelva a intentarlo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txtapp_TextChanged(object sender, EventArgs e)
        {

        }

        private void chexQA_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chexlesionE_CheckedChanged(object sender, EventArgs e)
        {
            if (chexlesionE.Checked)
            {
                abrirsis.Visible = true;
            }
            else
            {
                abrirsis.Hide();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Close();
                var id = 0;
                //Limpiar CheckBox
                limpiar_datos_doctor1();
                if (cmbfechas.SelectedValue == null)
                {
                    MessageBox.Show("Error, buscar una cédula", "Informacíon", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    id = (int)cmbfechas.SelectedValue;
                    id_fecha = id;

                }
                ////////////////////////////////////////////////////77
                conexion.Open();
                String consulta = "SELECT * From informe_doc WHERE id= ?";
                OleDbCommand appDB = new OleDbCommand(consulta, conexion);


                appDB.Parameters.AddWithValue("?", id);
                appDB.ExecuteNonQuery();

                OleDbDataReader dr = appDB.ExecuteReader();

                Boolean exisregistro = dr.HasRows;
                if (exisregistro)
                {
                    while (dr.Read())

                    {

                        txtmotivo.Text = dr["motivo"].ToString();
                        txtimpresion_dia.Text = dr["impresion_"].ToString();
                        txttratamiento.Text = dr["tratamiento"].ToString();
                        txtrecomendacion.Text = dr["recomendacion"].ToString();
                        String examen_revision = dr["examen_re"].ToString();
                        if (examen_revision == chexcompleto.Text)
                        {
                            chexcompleto.Checked = true;
                        }
                        if (examen_revision == chexsobrecin.Text)
                        {
                            chexsobrecin.Checked = true;
                        }
                        if (examen_revision == chexlesionE.Text)
                        {
                            chexlesionE.Checked = true;
                        }
                        String diag = dr["impresion_dia_re"].ToString();
                        string[] diagnostico = diag.Split(',');
                        for (int i = 0; i < diagnostico.Length; i++)
                        {


                            if (diagnostico[i] == chexQS.Text)
                            {
                                chexQS.Checked = true;
                            }
                            if (diagnostico[i] == chexQA.Text)
                            {
                                chexQA.Checked = true;
                            }
                            if (diagnostico[i] == chexCB.Text)
                            {
                                chexCB.Checked = true;
                            }
                            if (diagnostico[i] == chexCCE.Text)
                            {
                                chexCCE.Checked = true;
                            }
                            if (diagnostico[i] == chexLD.Text)
                            {

                                chexLD.Checked = true;
                            }
                            if (diagnostico[i] == chexLC.Text)
                            {

                                chexLC.Checked = true;
                            }
                            if (diagnostico[i] == chexP.Text)
                            {

                                chexP.Checked = true;
                            }
                            if (diagnostico[i] == chexM.Text)
                            {

                                chexM.Checked = true;
                            }
                            if (diagnostico[i] == chexotro.Text)
                            {

                                chexotro.Checked = true;
                                txtdiagotro.Text = diag;

                            }
                        }
                        String biopsia = dr["biopsia"].ToString();
                        if (biopsia == chexbiosi.Text)
                        {
                            chexbiosi.Checked = true;
                        }
                        if (biopsia == chexbiono.Text)
                        {

                            chexbiono.Checked = true;
                        }

                        String referido = dr["referido"].ToString();
                        if (referido == chexrefecss.Text)
                        {

                            chexrefecss.Checked = true;
                        }
                        if (referido == chexrefate.Text)
                        {

                            chexrefate.Checked = true;
                        }
                        if (referido == chexminsa.Text)
                        {
                            chexminsa.Checked = true;
                        }
                        if (referido == chexyolucho.Text)
                        {
                            chexyolucho.Checked = true;
                        }
                        if (referido == chexion.Text)
                        {
                            chexion.Checked = true;
                        }
                        if (referido == chexonco.Text)
                        {
                            chexonco.Checked = true;
                        }


                        if (dr["coordenadas"] == DBNull.Value)
                        {
                            enviodatos = null;
                        }
                        else
                        {
                            MemoryStream ms = new MemoryStream((byte[])dr["coordenadas"]);


                            enviodatos = new Bitmap(ms);


                        }




                        btnnuevo_re.Visible = true;
                        button2.Visible = false;
                        btnmodificar.Visible = true;

                        //////
                        permiso = false;
                        ///////////////////////////////////////////////////////7////

                    }

                }



                conexion.Close();
            }
            catch (Exception f) {
                MessageBox.Show("Error, Vuelva a intentarlo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void date_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnnuevo_re_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (lb_archivo.Items.Count <= 0)
                {
                    MessageBox.Show("Seleccione un Archivo de la lista o búsque cédula del paciente para cargar información", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
            catch (Exception f) {
                MessageBox.Show("Error, Vuelva a intentarlo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            sumatoria = 0;
            try
            {

                int id;
                int edad;

                id = Int32.Parse(id_pacientes);


                //Valores transformar 
                if (chexQS.Checked)
                {
                    Cadena += chexQS.Text + ",";
                }
                if (chexQA.Checked)
                {
                    Cadena += chexQA.Text + ",";
                }
                if (chexCB.Checked)
                {
                    Cadena += chexQA.Text + ",";
                }
                if (chexCCE.Checked)
                {
                    Cadena += chexCCE.Text + ",";
                }
                if (chexLD.Checked)
                {
                    Cadena += chexLD.Text + ",";
                }
                if (chexLC.Checked)
                {
                    Cadena += chexLC.Text + ",";
                }
                if (chexP.Checked)
                {
                    Cadena += chexP.Text + ",";
                }
                if (chexM.Checked)
                {
                    Cadena += chexM.Text + ",";
                }
                if (chexotro.Checked)
                {
                    Cadena += txtdiagotro.Text + ",";

                }

                //Seleccion de los examanes realizados 
                if (chexcompleto.Checked)
                {
                    chexlesionE.Checked = false;
                    chexsobrecin.Checked = false;
                    examen = chexcompleto.Text;

                    byte[] abyte = null;

                    sumatoria = 0;
                }
                if (chexsobrecin.Checked)
                {
                    chexlesionE.Checked = false;
                    chexcompleto.Checked = false;
                    examen = chexsobrecin.Text;


                    byte[] abyte = null;
                    sumatoria = 0;
                }
                if (chexlesionE.Checked)
                {
                    chexsobrecin.Checked = false;
                    chexcompleto.Checked = false;
                    examen = chexlesionE.Text;

                    sumatoria = 1;
                }
                // Seleccion de biopsia
                if (chexbiosi.Checked)
                {
                    biopsia = chexbiosi.Text;
                }
                if (chexbiono.Checked)
                {
                    biopsia = chexbiono.Text;
                }
                // Seleccion de referido
                if (chexrefecss.Checked)
                {
                    referido = chexrefecss.Text;
                }
                if (chexrefate.Checked)
                {
                    referido = chexrefate.Text;
                }
                if (chexion.Checked)
                {
                    referido = chexion.Text;
                }
                if (chexonco.Checked)
                {
                    referido = chexonco.Text;
                }

                conexion.Open();

                if (sumatoria == 0)
                {

                    comando.Connection = conexion;
                    // (, '" + txtimpresion_dia.Text + "', , , '" + id + "', '" + examen + "', '" + Cadena + "',, , '" + datem.Value.Date + "', , , '" + txtmedico.Text + "')";
                    comando.CommandText = "UPDATE informe_doc SET motivo='" + txtmotivo.Text + "',impresion_='" + txtimpresion_dia.Text + "',tratamiento='" + txttratamiento.Text + "',recomendacion='" + txtrecomendacion.Text + "',examen_re='" + examen + "',impresion_dia_re='" + Cadena + "',biopsia='" + biopsia + "',referido='" + referido + "' , medico = '" + txtmedico.Text + "' WHERE id_paciente = " + id + " AND  id=" + id_fecha + "";



                    comando.ExecuteNonQuery();
                    conexion.Close();


                    MessageBox.Show("Datos Actualizados", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    conexion.Close();
                }
                else
                {

                    byte[] bts = cuerpo_humano.bits;
                    comando.Connection = conexion;
                    // (, '" + txtimpresion_dia.Text + "', , , '" + id + "', '" + examen + "', '" + Cadena + "',, , '" + datem.Value.Date + "', , , '" + txtmedico.Text + "')";
                    comando.CommandText = "UPDATE informe_doc SET motivo='" + txtmotivo.Text + "',impresion_='" + txtimpresion_dia.Text + "',tratamiento='" + txttratamiento.Text + "',recomendacion='" + txtrecomendacion.Text + "',examen_re='" + examen + "',impresion_dia_re='" + Cadena + "',biopsia='" + biopsia + "',referido='" + referido + "' , medico = '" + txtmedico.Text + "', coordenadas =@bts WHERE id_paciente = " + id + " AND  id=" + id_fecha + "";

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

        //controles para limpiar formularios
        public void limpiar_datos_pacientes()
        {
            cmbfechas.DataSource = null;
            cmbfechas.Items.Clear();
            txtnombre.Text = " ";


            chexsexom.Checked = false;
            chexsexof.Checked = false;

            chexsegurosi.Checked = false;
            chexsegurono.Checked = false;
            txtdireccion.Text = " ";


            chexalergno.Checked = false;
            chexalergsi.Checked = false;
            txtapp.Text = " ";
            txtahf.Text = " ";
            txtmedicamentos.Text = " ";
            txtmedico_re.Text = " ";

        }

        public void limpiar_datos_doctor()
        {
            lb_archivo.Items.Clear();
            //Limpiar Valores
            informacion.Text = " ";


            txtmotivo.Text = " ";
            txtimpresion_dia.Text = " ";
            txttratamiento.Text = " ";
            txtrecomendacion.Text = " ";
            txtaqt.Text = "";

            coordenadas_x = String.Empty;

            coordenadas_y = String.Empty;
            chexcompleto.Checked = false;
            chexsobrecin.Checked = false;
            chexlesionE.Checked = false;
            chexQS.Checked = false;
            chexQA.Checked = false;
            chexCB.Checked = false;
            chexCCE.Checked = false;
            chexLD.Checked = false;
            chexLC.Checked = false;
            chexP.Checked = false;
            chexM.Checked = false;
            chexotro.Checked = false;
            chexbiosi.Checked = false;
            chexbiono.Checked = false;
            chexrefecss.Checked = false;
            chexrefate.Checked = false;
            chexyolucho.Checked = false;
            chexminsa.Checked = false;
            chexion.Checked = false;

            chexonco.Checked = false;

        }
        public void limpiar_datos_doctor1()
        {

            //Limpiar Valores
            informacion.Text = " ";


            txtmotivo.Text = " ";
            txtimpresion_dia.Text = " ";
            txttratamiento.Text = " ";
            txtrecomendacion.Text = " ";
            txtaqt.Text = "";

            coordenadas_x = String.Empty;

            coordenadas_y = String.Empty;
            chexcompleto.Checked = false;
            chexsobrecin.Checked = false;
            chexlesionE.Checked = false;
            chexQS.Checked = false;
            chexQA.Checked = false;
            chexCB.Checked = false;
            chexCCE.Checked = false;
            chexLD.Checked = false;
            chexLC.Checked = false;
            chexP.Checked = false;
            chexM.Checked = false;
            chexotro.Checked = false;
            chexbiosi.Checked = false;
            chexbiono.Checked = false;
            chexrefecss.Checked = false;
            chexrefate.Checked = false;
            chexyolucho.Checked = false;
            chexminsa.Checked = false;

            chexion.Checked = false;

            chexonco.Checked = false;



        }

        private void btnnuevo_re_Click_1(object sender, EventArgs e)
        {
            permiso = true;
            btnnuevo_re.Visible = true;

            limpiar_datos_doctor();
            btnmodificar.Visible = false;
            button2.Visible = true;
        }

        private void txtrecomendacion_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

            }
        }

        private void button1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                button1.Focus();

                try
                {
                    conexion.Close();
                    //Datos booleanos
                    permiso = true;
                    btnnuevo_re.Visible = true;
                    limpiar_datos_doctor();


                    /////////////////////////////
                    btnnuevo_re.Hide();
                    String alergico;
                    String seguro;
                    String sexo;
                    string consulta;
                    string fecha;
                    if (txtcedula.Text != " ")
                    {
                        conexion.Open();
                        consulta = "SELECT id_paciente, nombre, fecha, edad, sexo,  seguro, direccion, medico_referente, alergico,app, ahf, medicamentos, aqt,presion_arterial,peso,pulso,talla  FROM informe_p WHERE cedula = ?";
                        OleDbCommand appDB = new OleDbCommand(consulta, conexion);
                        appDB.Parameters.AddWithValue("?", txtcedula.Text);
                        appDB.ExecuteNonQuery();

                        OleDbDataReader dr = appDB.ExecuteReader();
                        Boolean exisregistro = dr.HasRows;
                        if (exisregistro)
                        {
                            while (dr.Read())

                            {

                                id_pacientes = dr["id_paciente"].ToString();
                                id_pacientes_ = Int32.Parse(id_pacientes);
                                txtnombre.Text = dr["nombre"].ToString();
                                date.Text = dr["fecha"].ToString();
                                fecha = dr["fecha"].ToString();


                                sexo = dr["sexo"].ToString();
                                if (sexo == "M")
                                {
                                    chexsexom.Checked = true;
                                    chexsexof.Checked = false;
                                }
                                else
                                {
                                    chexsexof.Checked = true;
                                    chexsexom.Checked = false;
                                }

                                seguro = dr["seguro"].ToString();
                                if (seguro == "si")
                                {
                                    chexsegurosi.Checked = true;
                                    chexsegurono.Checked = false;
                                }
                                else
                                {
                                    chexsegurono.Checked = true;
                                    chexsegurosi.Checked = false;
                                }
                                //seguro, direccion, medico_referente, alergico,app, apf, medicamentos
                                txtdireccion.Text = dr["direccion"].ToString();
                                txtmedico_re.Text = dr["medico_referente"].ToString();
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
                                txtahf.Text = dr["ahf"].ToString();
                                txtaqt.Text = dr["aqt"].ToString();
                                txtmedicamentos.Text = dr["medicamentos"].ToString();
                                txtpresion_art.Text = dr["presion_arterial"].ToString();
                                txtpeso.Text = dr["peso"].ToString();
                                txttalla.Text = dr["talla"].ToString();
                                txtpulso.Text = dr["pulso"].ToString();

                                //buscar archivos dentro de las carpetas

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
                                    }
                                    else
                                    {
                                        informacion.Text = "El paciente no cuenta con Archivos adjuntos";

                                    }
                                }

                                ///

                            }
                            int valor = Int32.Parse(id_pacientes);
                            DataTable dt = new DataTable();
                            String query = "SELECT id, fecha_rm FROM informe_doc WHERE id_paciente=@id";
                            OleDbCommand cmd = new OleDbCommand(query, conexion);
                            cmd.Parameters.AddWithValue("@id", valor);
                            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                            da.SelectCommand = cmd;
                            da.Fill(dt);
                            cmbfechas.DisplayMember = "fecha_rm";
                            cmbfechas.ValueMember = "id";
                            cmbfechas.DataSource = dt;
                            if (cmbfechas.Items.Count <= 0)
                            {
                                permiso = true;

                                cmbfechas.Text = "";
                                cmbfechas.DataSource = null;
                                cmbfechas.Items.Clear();
                                button2.Visible = true;
                                btnmodificar.Visible = false;
                            }
                            else
                            {
                                permiso = true;
                                mensaje = "EL PACIENTE YA CUENTA CON UN HISTORIAL, SELECCIONAR NUEVO REGISTRO";



                            }

                            button2.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Paciente No encontrado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            limpiar_datos_pacientes();
                            btnmodificar.Visible = false;
                            button2.Visible = true;
                            cmbfechas.Items.Clear();
                        }
                        conexion.Close();
                    }

                    else
                    {
                        MessageBox.Show("El campo cédula esta vacio", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (InvalidCastException g)
                {
                    MessageBox.Show("Error", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }




        }

        private void txtcedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsWhiteSpace(e.KeyChar);
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {

                try
                {
                    conexion.Close();
                    //Datos booleanos
                    permiso = true;
                    btnnuevo_re.Visible = true;
                    limpiar_datos_doctor();


                    /////////////////////////////
                    btnnuevo_re.Hide();
                    String alergico;
                    String seguro;
                    String sexo;
                    string consulta;
                    string fecha;
                    if (txtcedula.Text != " ")
                    {
                        conexion.Open();
                        consulta = "SELECT id_paciente, nombre, fecha, fecha_nac, sexo,  seguro, direccion, medico_referente, alergico,app, ahf, medicamentos, aqt,imagen FROM informe_p WHERE cedula = ?";
                        OleDbCommand appDB = new OleDbCommand(consulta, conexion);
                        appDB.Parameters.AddWithValue("?", txtcedula.Text);
                        appDB.ExecuteNonQuery();

                        OleDbDataReader dr = appDB.ExecuteReader();
                        Boolean exisregistro = dr.HasRows;
                        if (exisregistro)
                        {
                            while (dr.Read())

                            {

                                id_pacientes = dr["id_paciente"].ToString();
                                id_pacientes_ = Int32.Parse(id_pacientes);
                                enviar_idpaciente = id_pacientes_;
                                txtnombre.Text = dr["nombre"].ToString();
                                date.Text = dr["fecha"].ToString();
                                fecha = dr["fecha"].ToString();

                                dtpicker1.Text = dr["fecha_nac"].ToString();
                                sexo = dr["sexo"].ToString();
                                if (sexo == "M")
                                {
                                    chexsexom.Checked = true;
                                    chexsexof.Checked = false;
                                }
                                else
                                {
                                    chexsexof.Checked = true;
                                    chexsexom.Checked = false;
                                }

                                seguro = dr["seguro"].ToString();
                                if (seguro == "si")
                                {
                                    chexsegurosi.Checked = true;
                                    chexsegurono.Checked = false;
                                }
                                else
                                {
                                    chexsegurono.Checked = true;
                                    chexsegurosi.Checked = false;
                                }
                                //seguro, direccion, medico_referente, alergico,app, apf, medicamentos
                                txtdireccion.Text = dr["direccion"].ToString();
                                txtmedico_re.Text = dr["medico_referente"].ToString();
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
                                txtahf.Text = dr["ahf"].ToString();
                                txtaqt.Text = dr["aqt"].ToString();
                                txtmedicamentos.Text = dr["medicamentos"].ToString();








                                // buscar archivos dentro de las carpetas

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
                                    }
                                    else
                                    {
                                        informacion.Text = "El paciente no cuenta con Archivos adjuntos";

                                    }
                                }

                                ///

                            }

                            //BUSCA LOS CONTROLES
                            string consul = "SELECT presion_arterial,peso,talla, pulso From informe_datos  WHERE id_paciente= ?";
                            OleDbCommand envio = new OleDbCommand(consul, conexion);
                            envio.Parameters.AddWithValue("?", enviar_idpaciente);
                            envio.ExecuteNonQuery();

                            OleDbDataReader dr2 = envio.ExecuteReader();
                            Boolean exit = dr2.HasRows;
                            if (exit)
                            {
                                while (dr.Read())
                                {
                                    txtpresion_art.Text = dr["presion_arterial"].ToString();

                                    txtpeso.Text = dr["peso"].ToString();
                                    txttalla.Text = dr["talla"].ToString();
                                    txtpulso.Text = dr["pulso"].ToString();
                                }
                            }
                            //BUSCA LAS FECHAS

                            int valor = Int32.Parse(id_pacientes);
                            DataTable dt = new DataTable();
                            String query = "SELECT id, fecha_rm FROM informe_doc WHERE id_paciente=@id";
                            OleDbCommand cmd = new OleDbCommand(query, conexion);
                            cmd.Parameters.AddWithValue("@id", valor);
                            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                            da.SelectCommand = cmd;
                            da.Fill(dt);
                            cmbfechas.DisplayMember = "fecha_rm";
                            cmbfechas.ValueMember = "id";
                            cmbfechas.DataSource = dt;
                            if (cmbfechas.Items.Count <= 0)
                            {
                                permiso = true;

                                cmbfechas.Text = "";
                                cmbfechas.DataSource = null;
                                cmbfechas.Items.Clear();
                                button2.Visible = true;
                                btnmodificar.Visible = false;
                            }
                            else
                            {
                                permiso = true;
                                mensaje = "EL PACIENTE YA CUENTA CON UN HISTORIAL, SELECCIONAR NUEVO REGISTRO";



                            }

                            button2.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Paciente No encontrado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            limpiar_datos_pacientes();
                            btnmodificar.Visible = false;
                            button2.Visible = true;
                            cmbfechas.Items.Clear();
                            button3.Enabled = false;
                        }
                        conexion.Close();
                        button3.Enabled = true;
                    }

                    else
                    {
                        MessageBox.Show("El campo cédula esta vacio", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        button3.Enabled = true;
                    }
                }
                catch (Exception g)
                {
                    MessageBox.Show("Error", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
        }

        private void cmbfechas_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = char.IsWhiteSpace(e.KeyChar);
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                try
                {
                    conexion.Close();
                    var id = 0;
                    //Limpiar CheckBox
                    limpiar_datos_doctor1();
                    if (cmbfechas.SelectedValue == null)
                    {
                        MessageBox.Show("Error, buscar una cédula", "Informacíon", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        id = (int)cmbfechas.SelectedValue;
                        id_fecha = id;

                    }
                    ////////////////////////////////////////////////////77
                    conexion.Open();
                    String consulta = "SELECT * From informe_doc WHERE id= ?";
                    OleDbCommand appDB = new OleDbCommand(consulta, conexion);


                    appDB.Parameters.AddWithValue("?", id);
                    appDB.ExecuteNonQuery();

                    OleDbDataReader dr = appDB.ExecuteReader();

                    Boolean exisregistro = dr.HasRows;
                    if (exisregistro)
                    {
                        while (dr.Read())

                        {

                            txtmotivo.Text = dr["motivo"].ToString();
                            txtimpresion_dia.Text = dr["impresion_"].ToString();
                            txttratamiento.Text = dr["tratamiento"].ToString();
                            txtrecomendacion.Text = dr["recomendacion"].ToString();
                            String examen_revision = dr["examen_re"].ToString();
                            if (examen_revision == chexcompleto.Text)
                            {
                                chexcompleto.Checked = true;
                            }
                            if (examen_revision == chexsobrecin.Text)
                            {
                                chexsobrecin.Checked = true;
                            }
                            if (examen_revision == chexlesionE.Text)
                            {
                                chexlesionE.Checked = true;
                            }
                            String diag = dr["impresion_dia_re"].ToString();
                            string[] diagnostico = diag.Split(',');
                            for (int i = 0; i < diagnostico.Length; i++)
                            {


                                if (diagnostico[i] == chexQS.Text)
                                {
                                    chexQS.Checked = true;
                                }
                                if (diagnostico[i] == chexQA.Text)
                                {
                                    chexQA.Checked = true;
                                }
                                if (diagnostico[i] == chexCB.Text)
                                {
                                    chexCB.Checked = true;
                                }
                                if (diagnostico[i] == chexCCE.Text)
                                {
                                    chexCCE.Checked = true;
                                }
                                if (diagnostico[i] == chexLD.Text)
                                {

                                    chexLD.Checked = true;
                                }
                                if (diagnostico[i] == chexLC.Text)
                                {

                                    chexLC.Checked = true;
                                }
                                if (diagnostico[i] == chexP.Text)
                                {

                                    chexP.Checked = true;
                                }
                                if (diagnostico[i] == chexM.Text)
                                {

                                    chexM.Checked = true;
                                }
                                if (diagnostico[i] == chexotro.Text)
                                {

                                    chexotro.Checked = true;
                                    txtdiagotro.Text = diag;

                                }
                            }
                            String biopsia = dr["biopsia"].ToString();
                            if (biopsia == chexbiosi.Text)
                            {
                                chexbiosi.Checked = true;
                            }
                            if (biopsia == chexbiono.Text)
                            {

                                chexbiono.Checked = true;
                            }

                            String referido = dr["referido"].ToString();
                            if (referido == chexrefecss.Text)
                            {

                                chexrefecss.Checked = true;
                            }
                            if (referido == chexrefate.Text)
                            {

                                chexrefate.Checked = true;
                            }
                            if (referido == chexminsa.Text)
                            {
                                chexminsa.Checked = true;
                            }
                            if (referido == chexyolucho.Text)
                            {
                                chexyolucho.Checked = true;
                            }
                            if (referido == chexion.Text)
                            {
                                chexion.Checked = true;
                            }
                            if (referido == chexonco.Text)
                            {
                                chexonco.Checked = true;
                            }


                            if (dr["coordenadas"] == DBNull.Value)
                            {
                                enviodatos = null;
                            }
                            else
                            {
                                MemoryStream ms = new MemoryStream((byte[])dr["coordenadas"]);


                                enviodatos = new Bitmap(ms);


                            }




                            btnnuevo_re.Visible = true;
                            button2.Visible = false;
                            btnmodificar.Visible = true;

                            //////
                            permiso = false;
                            ///////////////////////////////////////////////////////7////

                        }

                    }



                    conexion.Close();
                }
                catch (Exception f) {
                    MessageBox.Show("Error, Vuelva a intentarlo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form formulario = new imagen();
            formulario.Show();
        }

        private void lb_archivo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lb_archivo.Items.Count <= 0)
            {
                MessageBox.Show("Seleccione un Archivo de la lista o búsque cédula del paciente para cargar información", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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

        private void button3_Click_2(object sender, EventArgs e)
        {
            imagen.id = txtcedula.Text;
            Form formulario = new imagen();
            formulario.Show();

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            historial.id_paciente = enviar_idpaciente;
            Form formulario = new historial();
            formulario.Show();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtpicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime fechaActual = DateTime.Today;
            int edad = fechaActual.Year - dtpicker1.Value.Year;
            if (fechaActual < dtpicker1.Value.AddYears(edad)) edad--;
            label18.Text = "Edad: " + edad + " años";
        }
    }
}


