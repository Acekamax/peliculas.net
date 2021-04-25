using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace peliculas.Models.alquiler
{
    public class alquiler
    {
        public int id { get; set; }
        public string estado { get; set; }
        public DateTime fecha_alquiler { get; set; }
        public DateTime fecha_entrega { get; set; }
        public int id_pelicula { get; set; }
        public int id_cliente { get; set; }
        public string nombre_pelicula { get; set; }
        public string nombre_cliente { get; set; }
        public bool crearalquiler(alquiler alqui)
        {
            string query = "INSERT INTO alquiler(estado,fecha_alquiler,fecha_entrega,id_pelicula,id_cliente) VALUES('Prestado',NOW(),NOW() + INTERVAL 7 day,'" + alqui.id_pelicula + "','" + alqui.id_cliente + "')";
            conexion con = new conexion();
            MySqlCommand commandDatabase = new MySqlCommand(query, con.ObtenerConexion());
            commandDatabase.CommandTimeout = 60;


            try
            {
                commandDatabase.ExecuteScalar();
            }
            catch (Exception ex)
            {

            }
            return true;
        }
        public List<alquiler> consultar_alquiler()
        {
            string query = "select alquiler.id,alquiler.estado,alquiler.fecha_alquiler,alquiler.fecha_entrega,peliculas.nombre_pelicula,cliente.nombre from alquiler inner join cliente on cliente.id = alquiler.id_cliente inner join peliculas on peliculas.id = alquiler.id_pelicula where alquiler.estado = 'prestado'";
            conexion con = new conexion();
            MySqlCommand commandDatabase = new MySqlCommand(query, con.ObtenerConexion());
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            List<alquiler> lista = new List<alquiler>();

            try
            {
                reader = commandDatabase.ExecuteReader();


                // Si se encontraron datos
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        alquiler alqui = new alquiler();
                        alqui.estado= reader.GetString(1);
                        alqui.nombre_cliente = reader.GetString(5);
                        alqui.nombre_pelicula = reader.GetString(4);
                        alqui.id = reader.GetInt32(0);
                        alqui.fecha_alquiler = reader.GetDateTime(2);
                        alqui.fecha_entrega = reader.GetDateTime(3);
                        lista.Add(alqui);
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

        public bool editaralquiler(int id)
        {
            string query = "UPDATE alquiler set estado='Entregado' WHERE id="+id;
            conexion con = new conexion();
            MySqlCommand commandDatabase = new MySqlCommand(query, con.ObtenerConexion());
            commandDatabase.CommandTimeout = 60;


            try
            {
                commandDatabase.ExecuteScalar();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}