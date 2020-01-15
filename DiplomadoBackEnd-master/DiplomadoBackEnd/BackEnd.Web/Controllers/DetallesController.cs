using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackEnd.Web.Controllers
{
    public class DetallesController : Controller
    {
        //Participantes crean un controlador y agregan VIEWs de cada action.
        // GET: Detalles
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Autos()
        {
            return View();
        }
    }
}