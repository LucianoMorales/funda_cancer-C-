using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formularios
{

  
    internal class conexiones
    {
        //public static OleDbConnection conexion = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Public\pacientes.accdb");
        //conexion laptop
        public static OleDbConnection conexion = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\DESKTOP-8Q1H8O9\Users\Public\pacientes.accdb");
        //conexion mi compu
        //public static OleDbConnection conexion = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Z:05. Clínica\5.3 Fundacáncer\BD\BD\pacientes.accdb");



    }
}
