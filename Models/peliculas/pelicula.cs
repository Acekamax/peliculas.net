using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using peliculas.Models;

namespace peliculas.Models.peliculas
{
    public class pelicula
    {
        public int id { get; set; }
        public string nombre_pelicula { get; set; }
        public string descripcion { get; set; }
        public string genero { get; set; }
       public List<pelicula> consultar_pelicula() {
            string query = "SELECT * from peliculas";
            conexion con = new conexion();
            MySqlCommand commandDatabase = new MySqlCommand(query, con.ObtenerConexion());
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            List<pelicula> lista = new List<pelicula>();
            try
            {
                reader = commandDatabase.ExecuteReader();


                // Si se encontraron datos
                if (reader.HasRows)
                {
                    
                    while (reader.Read())
                    {
                        pelicula pelis = new pelicula();
                        pelis.id = Int32.Parse(reader.GetString(0));
                        pelis.nombre_pelicula = reader.GetString(1);
                        pelis.descripcion = reader.GetString(2);
                        pelis.genero = reader.GetString(3);
                        lista.Add(pelis);
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