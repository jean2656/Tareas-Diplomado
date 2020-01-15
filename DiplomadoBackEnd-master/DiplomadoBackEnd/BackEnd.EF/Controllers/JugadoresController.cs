using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BackEnd.EF.Models;

namespace BackEnd.EF.Controllers
{
    public class JugadoresController : Controller
    {
        private DiplomadoCurneDBEntities db = new DiplomadoCurneDBEntities();

        // GET: Jugadores
        public ActionResult Index()
        {
            var jugadores1 = db.Jugadores1.Include(j => j.Equipos);
            return View(jugadores1.ToList());
        }

        // GET: Jugadores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jugadores jugadores = db.Jugadores1.Find(id);
            if (jugadores == null)
            {
                return HttpNotFound();
            }
            return View(jugadores);
        }

        // GET: Jugadores/Create
        public ActionResult Create()
        {
            ViewBag.IdEquipo = new SelectList(db.Equipos, "IdEquipo", "Nombre");
            return View();
        }

        // POST: Jugadores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdJugador,Nombre,Apellido,Posicion,IdEquipo")] Jugadores jugadores)
        {
            if (ModelState.IsValid)
            {
                db.Jugadores1.Add(jugadores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEquipo = new SelectList(db.Equipos, "IdEquipo", "Nombre", jugadores.IdEquipo);
            return View(jugadores);
        }

        // GET: Jugadores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jugadores jugadores = db.Jugadores1.Find(id);
            if (jugadores == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEquipo = new SelectList(db.Equipos, "IdEquipo", "Nombre", jugadores.IdEquipo);
            return View(jugadores);
        }

        // POST: Jugadores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdJugador,Nombre,Apellido,Posicion,IdEquipo")] Jugadores jugadores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jugadores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEquipo = new SelectList(db.Equipos, "IdEquipo", "Nombre", jugadores.IdEquipo);
            return View(jugadores);
        }

        // GET: Jugadores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jugadores jugadores = db.Jugadores1.Find(id);
            if (jugadores == null)
            {
                return HttpNotFound();
            }
            return View(jugadores);
        }

        // POST: Jugadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jugadores jugadores = db.Jugadores1.Find(id);
            db.Jugadores1.Remove(jugadores);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
