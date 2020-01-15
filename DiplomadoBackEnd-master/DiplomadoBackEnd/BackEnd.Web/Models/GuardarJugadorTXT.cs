using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace BackEnd.Web.Models
{
    public class GuardarJugadorTXT
    {
        public GuardarJugadorTXT()
        {
            //constructor...
        }

        public void GuardarJugador(Jugador jugador)
        {
            //Ruta donde se encuentra el archivo...
            string ruta = System.Web.HttpContext.Current.Server.MapPath("/app_data/datos.txt");
            FileInfo file = new FileInfo(ruta); //FileInfo, nos ofrece informaciones sobre el archivo.
                        
            //Validar si existe o no para crearlo.
            if (!file.Exists)
                file.Create();
            

            //Trabajos con el archivo, para escribir información.            
            StreamWriter stream = new StreamWriter(System.Web.HttpContext.Current.Server.MapPath("/app_data/datos.txt"), true);            
            stream.WriteLine($"Nombre: {jugador.Nombre} <br> Apellidos: {jugador.Apellidos} <br> Equipo: {jugador.Equipo} <hr>");
            stream.Close();
        }

        public string LeerJugadores()
        {
            string datos = string.Empty;

            //Nos permite leer el contenido del archivo...
            StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("/app_data/datos.txt"));
            datos = reader.ReadToEnd();
            reader.Close();

            return datos;
        }
    }
}