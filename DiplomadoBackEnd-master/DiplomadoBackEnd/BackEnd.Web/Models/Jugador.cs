using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Web.Models
{
    public class Jugador
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Posicion { get; set; }
        public string Equipo { get; set; }
    }
}