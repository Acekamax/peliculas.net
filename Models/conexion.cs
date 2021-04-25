using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace peliculas.Models
{
    public class conexion
    {
        

        public MySqlConnection ObtenerConexion()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=Daniel950908*;database=peliculas;";
            MySqlConnection conectar = new MySqlConnection(connectionString);
            conectar.Open();
            return conectar;
        }
        public void cerrarConexion(MySqlConnection con) {
            con.Close();
        }
    }
}