using System;
using System.Collections.Generic;
using System.Data.SqlClient;
//using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackEnd.Web.Controllers
{
    public class HomeController : Controller
    {
        //Ejemplo creando controladores y retornando un string HTML.
        // GET: Home
        public string Index()
        {
            //construimos un cadena con la estructura html.
            string html = "<html>" +
                "<body><h1>CURNE-UASD</h1>" +
                "<h2>Estudiantes del diplomado</h2>" +
                "Fausto" +
                "<br>" +
                "Juan Pablo Duarte" +
                "<br>" +
                "David Ortiz" +
                "<br>" +
                "Pedro Martinez" +
                "</body></html>";
            
            return html;
        }

        /// <summary>
        /// Participantes crean otro metodo, mostrando marcas de vehiculos.
        /// </summary>
        /// <returns></returns>
        public string LitadoCarros()
        {
            string carrosHTML = "<html><body><h1>CARROS</h1>" +
               "<h2>Mis Carros Favoritos</h2>" +
               "Sonata" +
               "<br>" +
               "BMW" +
               "<br>" +
               "Camry" +
               "<br>" +
               "Honda" +
               "</body></html>";

            return carrosHTML;
        }

        public string TestConexionDB()
        {
            string connectionString = Models.ConexionDB.MiConexionString();
            SqlConnection cnn = new SqlConnection(connectionString);
            string conectado = "";

            try
            {
                cnn.Open();
                conectado = "Conexion exitosa";
            }
            catch (Exception ex)
            {
                conectado = $"Se produjo una excepcion {ex.Message}";
            }
            finally
            {
                cnn.Close();
            }

            string html = $"<html><body>{conectado}</body></html>";

            return html;
        }

        
    }
}