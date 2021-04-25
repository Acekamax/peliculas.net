using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace peliculas.Models.cliente
{
    public class cliente
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }

        public bool crearcliente(cliente cli) {
            string query = "INSERT INTO cliente(nombre,telefono,email) VALUES('"+cli.nombre+"','"+cli.telefono+"','"+cli.email+"')";
            conexion con = new conexion();
            MySqlCommand commandDatabase = new MySqlCommand(query, con.ObtenerConexion());
            commandDatabase.CommandTimeout = 60;
            
            try{
                commandDatabase.ExecuteScalar();
            }
            catch (Exception ex) { 
            
            }
            return true;
        }
        public List<cliente> consultar_clientes()
        {
            string query = "SELECT * from cliente";
            conexion con = new conexion();
            MySqlCommand commandDatabase = new MySqlCommand(query, con.ObtenerConexion());
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            List<cliente> lista = new List<cliente>();
            try
            {
                reader = commandDatabase.ExecuteReader();


                // Si se encontraron datos
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        cliente cli = new cliente();
                        cli.id = Int32.Parse(reader.GetString(0));
                        cli.nombre = reader.GetString(1);
                        cli.telefono = reader.GetString(2);
                        cli.email= reader.GetString(3);
                        lista.Add(cli);
                    }
                    return lista;
                }
                else
                {
                    Console.WriteLine("No se encontro nada");
                    return lista;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return lista;
            }

        }

    }
}