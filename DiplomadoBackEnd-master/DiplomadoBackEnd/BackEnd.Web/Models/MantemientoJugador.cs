using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BackEnd.Web.Models
{
    public class MantemientoJugador
    {
        string conexionString = Models.ConexionDB.MiConexionString();
        SqlConnection cnn;
        public MantemientoJugador()
        {
            //constructor....
            cnn = new SqlConnection(conexionString);  
        }

        /// <summary>
        /// Permite obtener un listado de jugadores
        /// </summary>
        /// <returns>Listado de Jugadores</returns>
        public List<Jugador> JugadoresAll()
        {
            string sqlString =
                "SELECT IdJugador, Nombre, Apellido, Posicion, Equipo FROM Jugadores";
            SqlCommand comando = new SqlCommand(sqlString, cnn);

            //Podemos mejorar el codigo, utilizando un try....

            cnn.Open(); //Abrimos la conexion a la DB.
            SqlDataReader reader = comando.ExecuteReader();
            
            //Definimos la lista de jugadores vamos a retornar.
            List<Jugador> jugadores = new List<Jugador>();

            while (reader.Read())
            {
                Jugador jugador = new Jugador
                {
                    ID = int.Parse(reader[0].ToString()),
                    Nombre = reader[1].ToString(),
                    Apellidos = reader[2].ToString(),
                    Posicion = reader[3].ToString(),
                    Equipo = reader["Equipo"].ToString()
                };

                jugadores.Add(jugador);
            }

            cnn.Close();  //Cerramos la conexión.      

            return jugadores;
        }

        public int AgregarJugador(Jugador jugador)
        {
            SqlCommand comando = new SqlCommand("INSERT INTO Jugadores (Nombre, Apellido, Posicion, Equipo) VALUES (@nombre, @apellido, @posicion, @equipo)", cnn);

            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters.Add("@apellido", SqlDbType.VarChar);
            comando.Parameters.Add("@posicion", SqlDbType.VarChar);
            comando.Parameters.Add("@equipo", SqlDbType.VarChar);

            comando.Parameters["@nombre"].Value = jugador.Nombre;
            comando.Parameters["@apellido"].Value = jugador.Apellidos;
            comando.Parameters["@posicion"].Value = jugador.Posicion;
            comando.Parameters["@equipo"].Value = jugador.Equipo;

            cnn.Open();
            int i = comando.ExecuteNonQuery(); //Retorno int de la fila afectada.
            cnn.Close();
         

            return i;
        }

        public int EditarJugador(Jugador jugador)
        {
            SqlCommand comando = new SqlCommand($"UPDATE Jugadores SET Nombre=@nombre, Apellido=@apellido, Posicion=@posicion, Equipo=@equipo WHERE IdJugador={jugador.ID}", cnn);

            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters.Add("@apellido", SqlDbType.VarChar);
            comando.Parameters.Add("@posicion", SqlDbType.VarChar);
            comando.Parameters.Add("@equipo", SqlDbType.VarChar);

            comando.Parameters["@nombre"].Value = jugador.Nombre;
            comando.Parameters["@apellido"].Value = jugador.Apellidos;
            comando.Parameters["@posicion"].Value = jugador.Posicion;
            comando.Parameters["@equipo"].Value = jugador.Equipo;

            cnn.Open();
            int i = comando.ExecuteNonQuery();
            cnn.Close();

            return i;
        }

        /// <summary>
        /// Obtiene un jugador por su ID
        /// </summary>
        /// <param name="id">ID del jugador.</param>
        /// <returns>Jugador</returns>
        public Jugador JugadorByID(int id)
        {
            SqlCommand comando = new SqlCommand("SELECT IdJugador, Nombre, Apellido, Posicion, Equipo FROM Jugadores WHERE IdJugador=@id", cnn);

            comando.Parameters.Add("@id", SqlDbType.Int);
            comando.Parameters["@id"].Value = id;
            cnn.Open();
            SqlDataReader reader = comando.ExecuteReader();

            Jugador jugador = new Jugador();

            if (reader.Read())
            {
                //Podemos utilizar el indice de la fila o el nombre del campo.
                jugador.ID = int.Parse(reader[0].ToString());
                jugador.Nombre = reader[1].ToString();
                jugador.Apellidos = reader[2].ToString();
                jugador.Posicion = reader[3].ToString();
                jugador.Equipo = reader[4].ToString();
            }

            cnn.Close();

            return jugador;
        }

        /// <summary>
        /// Permite eliminar un jugador...
        /// </summary>
        /// <param name="id">ID del Jugador</param>
        /// <returns></returns>
        public int Eliminar(int id)
        {
            SqlCommand comando = new SqlCommand("DELETE FROM Jugadores WHERE IdJugador=@id", cnn);

            comando.Parameters.Add("@id", SqlDbType.Int);
            comando.Parameters["@id"].Value = id;
            cnn.Open();
            int i = comando.ExecuteNonQuery();

            cnn.Close();

            return i;
        }
    }
}