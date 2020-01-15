using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackEnd.Web.Controllers
{
    public class JugadoresController : Controller
    {
        // GET: Jugadores
        public ActionResult Index()
        {
            //instanciamos clase...
            Models.MantemientoJugador mantenimientoJugador = new Models.MantemientoJugador();

            var result = mantenimientoJugador.JugadoresAll(); //Llamamos metodo retorna lista.          

            return View(result);
        }

        public ActionResult Agregar()
        {                        

            return View();
        }

        public ActionResult Editar(int id)
        {
            Models.MantemientoJugador mantenimientoJugador = new Models.MantemientoJugador();
            var result = mantenimientoJugador.JugadorByID(id);

            return View(result);
        }
        
        [HttpPost]
        public ActionResult Agregar(FormCollection formCollection)
        {
            Models.Jugador jugador = new Models.Jugador
            {
                ID = 0,
                Nombre = formCollection["nombre"],
                Apellidos = formCollection["apellidos"],
                Posicion = formCollection["posicion"],
                Equipo = formCollection["equipo"]
            };

            Models.MantemientoJugador mantenimientoJugador = new Models.MantemientoJugador();
            mantenimientoJugador.AgregarJugador(jugador);

            return RedirectToAction("../Jugadores");
        }

        [HttpPost]
        public ActionResult Editar(FormCollection formCollection)
        {
            Models.Jugador jugador = new Models.Jugador
            {
                ID = int.Parse(formCollection["idJugador"]),
                Nombre = formCollection["nombre"],
                Apellidos = formCollection["apellidos"],
                Posicion = formCollection["posicion"],
                Equipo = formCollection["equipo"]
            };

            Models.MantemientoJugador mantenimientoJugador = new Models.MantemientoJugador();
            mantenimientoJugador.EditarJugador(jugador);

            return RedirectToAction("../Jugadores");
        }

        public ActionResult Eliminar(int id)
        {
            Models.MantemientoJugador mantenimientoJugador = new Models.MantemientoJugador();
            mantenimientoJugador.Eliminar(id);

            return RedirectToAction("../Jugadores");
        }

        public ActionResult GuardarTXT()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GuardarTXT(FormCollection formCollection)
        {
            //Obtenemos los datos recibimos desde el formulario.
            Models.Jugador jugador = new Models.Jugador
            {
                ID = 0,
                Nombre = formCollection["nombre"],
                Apellidos = formCollection["apellidos"],
                Posicion = formCollection["posicion"],
                Equipo = formCollection["equipo"]
            };

            //Instanciamos la clase, para llamar el metodo para escribir en el archivo.
            Models.GuardarJugadorTXT guardarTXT = new Models.GuardarJugadorTXT();
            guardarTXT.GuardarJugador(jugador);

            return View();
        }

        public string LeerTXT()
        {
            Models.GuardarJugadorTXT guardarTXT = new Models.GuardarJugadorTXT();
            string listadoJugadores = guardarTXT.LeerJugadores();

            return listadoJugadores;

        }
    }
}