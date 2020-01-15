using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Web.Models
{
    public static class ConexionDB
    {
        //private static string cnnString = 
            
        public static string MiConexionString()
        {
            return @"Data Source=DESKTOP-OS4PIEE;Initial Catalog=DiplomadoCurneDB;Integrated Security=True";
        }
    }
}