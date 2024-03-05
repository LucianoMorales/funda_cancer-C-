using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Formularios
{
    public partial class historia : Form
    {

        //OleDbConnection conexion = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Public\pacientes.accdb");
        //OleDbConnection conexion = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\DESKTOP-8Q1H8O9\Users\Public\pacientes.accdb");
        //  OleDbConnection conexion = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Windows\proyectos_C#\pacientes.accdb");
        //OleDbConnection conexion = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Z:05. Clínica\5.3 Fundacáncer\BD\BD\pacientes.accdb");
        OleDbConnection conexion = conexiones.conexion;

        OleDbCommand comando = new OleDbCommand();
        int id_pac;
        public historia()
        {
            InitializeComponent();

        }

        private void historia_Load(object sender, EventArgs e)
        {


        }



        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                string id_pacientes;


                //buscar id

                conexion.Open();
                string consulta1 = "SELECT id_paciente FROM informe_p WHERE cedula = ?";
                OleDbCommand x = new OleDbCommand(consulta1, conexion);
                x.Parameters.AddWithValue("?", txtcedula.Text);
                x.ExecuteNonQuery();

                OleDbDataReader dr = x.ExecuteReader();
                Boolean exisregistro = dr.HasRows;
                if (exisregistro)
                {
                    while (dr.Read())

                    {

                        id_pacientes = dr["id_paciente"].ToString();
                        id_pac = Int32.Parse(id_pacientes);
                    }

                }
                else
                {
                    MessageBox.Show("Paciente No encontrado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }



                //datos
                String consulta = "SELECT id_paciente,cedula, nombre, fecha, fecha_nac, sexo,telefono,  seguro,direccion,lugar_trabajo,ocupacion,estado_civil, medico_referente, alergico,app, ahf, medicamentos,aqt,imagen FROM informe_p WHERE cedula = '" + txtcedula.Text + "' ";

                //datos
                OleDbCommand appDB = new OleDbCommand(consulta, conexion);

                //daots
                OleDbDataAdapter dp = new OleDbDataAdapter();

                //datos
                dp.SelectCommand = appDB;



                DataSet ds = new DataSet();
                dp.Fill(ds);

                // informacion medico

                String query = "SELECT motivo, impresion_, tratamiento, recomendacion, biopsia, referido,examen_re, impresion_dia_re,fecha_rm, medico,coordenadas From informe_doc WHERE id_paciente= " + id_pac + " ";
                OleDbDataAdapter dapv = new OleDbDataAdapter(query, conexion);
                DataSet dsv = new DataSet();
                dapv.Fill(dsv, "DataTable1");
                //control

                String queri = "SELECT fecha,presion_arterial,peso,talla,pulso  From informe_datos WHERE id_paciente= " + id_pac + " ";
                OleDbDataAdapter dapvv = new OleDbDataAdapter(queri, conexion);
                DataSet dsvv = new DataSet();
                dapvv.Fill(dsvv, "dtcontrol");

                String querii = "SELECT fecha, lesion From informe_lesion WHERE id_paciente= " + id_pac + " ";
                OleDbDataAdapter dapvvv = new OleDbDataAdapter(querii, conexion);
                DataSet dsvvv = new DataSet();
                dapvvv.Fill(dsvvv, "lesion");
                reportViewer1.ProcessingMode = ProcessingMode.Local;
                reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
                reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
                reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
                this.reportViewer1.LocalReport.DataSources.Clear();
                //C:\Windows\proyectos_C#\Formularios\Formulario\

                //@"C:\Windows\proyectos_C#\Formularios\Formulario\
                this.reportViewer1.LocalReport.ReportPath = @"C:\Windows\proyectos_C#\Formularios\Formulario\Report1.rdlc";
                ReportDataSource source = new ReportDataSource("DataSet1", ds.Tables[0]);
                this.reportViewer1.LocalReport.DataSources.Add(source);
                reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", dsv.Tables["DataTable1"]));
                reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet3", dsvv.Tables["dtcontrol"]));
                reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet4", dsvvv.Tables["lesion"]));




                this.reportViewer1.RefreshReport();
                conexion.Close();
                this.reportViewer1.RefreshReport();
            }
            catch (Exception m) {
                MessageBox.Show("Error, Vuelva a intentarlo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtcedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsWhiteSpace(e.KeyChar);
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {

                string id_pacientes;


                //buscar id

                conexion.Open();
                string consulta1 = "SELECT id_paciente FROM informe_p WHERE cedula = ?";
                OleDbCommand x = new OleDbCommand(consulta1, conexion);
                x.Parameters.AddWithValue("?", txtcedula.Text);
                x.ExecuteNonQuery();

                OleDbDataReader dr = x.ExecuteReader();
                Boolean exisregistro = dr.HasRows;
                if (exisregistro)
                {
                    while (dr.Read())

                    {

                        id_pacientes = dr["id_paciente"].ToString();
                        id_pac = Int32.Parse(id_pacientes);
                    }

                }
                else
                {
                    MessageBox.Show("Paciente No encontrado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }



                //datos
                String consulta = "SELECT id_paciente,cedula, nombre, fecha, fecha_nac, sexo,telefono,  seguro,direccion,lugar_trabajo,ocupacion,estado_civil, medico_referente, alergico,app, ahf, medicamentos,aqt,imagen FROM informe_p WHERE cedula = '" + txtcedula.Text + "' ";

                //datos
                OleDbCommand appDB = new OleDbCommand(consulta, conexion);

                //daots
                OleDbDataAdapter dp = new OleDbDataAdapter();

                //datos
                dp.SelectCommand = appDB;



                DataSet ds = new DataSet();
                dp.Fill(ds);

                // informacion medico

                String query = "SELECT motivo, impresion_, tratamiento, recomendacion, biopsia, referido,examen_re, impresion_dia_re,fecha_rm, medico,coordenadas From informe_doc WHERE id_paciente= " + id_pac + " ";
                OleDbDataAdapter dapv = new OleDbDataAdapter(query, conexion);
                DataSet dsv = new DataSet();
                dapv.Fill(dsv, "DataTable1");
                //control

                String queri = "SELECT fecha,presion_arterial,peso,talla,pulso  From informe_datos WHERE id_paciente= " + id_pac + " ";
                OleDbDataAdapter dapvv = new OleDbDataAdapter(queri, conexion);
                DataSet dsvv = new DataSet();
                dapvv.Fill(dsvv, "dtcontrol");

                String querii = "SELECT fecha, lesion From informe_lesion WHERE id_paciente= " + id_pac + " ";
                OleDbDataAdapter dapvvv = new OleDbDataAdapter(querii, conexion);
                DataSet dsvvv = new DataSet();
                dapvvv.Fill(dsvvv, "lesion");
                reportViewer1.ProcessingMode = ProcessingMode.Local;
                reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
                reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
                reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
                this.reportViewer1.LocalReport.DataSources.Clear();
                //C:\Windows\proyectos_C#\Formularios\Formulario\

                //@"C:\Windows\proyectos_C#\Formularios\Formulario\
                this.reportViewer1.LocalReport.ReportPath = @"C:\Windows\proyectos_C#\Formularios\Formulario\Report1.rdlc";
                ReportDataSource source = new ReportDataSource("DataSet1", ds.Tables[0]);
                this.reportViewer1.LocalReport.DataSources.Add(source);
                reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", dsv.Tables["DataTable1"]));
                reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet3", dsvv.Tables["dtcontrol"]));
                reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet4", dsvvv.Tables["lesion"]));




                this.reportViewer1.RefreshReport();
                conexion.Close();
                this.reportViewer1.RefreshReport();
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void reportViewer2_Load(object sender, EventArgs e)
        {

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
