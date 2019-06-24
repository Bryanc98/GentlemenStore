using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GentlemanStore.Models;

namespace GentlemanStore.Controllers
{
    public class EmpleadoCargoGSController : Controller
    {
        private GeltlemenStoreEntities db = new GeltlemenStoreEntities();

        // GET: EmpleadoCargoGS
        public ActionResult Index()
        {
            return View(db.EmpleadoCargoGS.ToList());
        }

        // GET: EmpleadoCargoGS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpleadoCargoGS empleadoCargoGS = db.EmpleadoCargoGS.Find(id);
            if (empleadoCargoGS == null)
            {
                return HttpNotFound();
            }
            return View(empleadoCargoGS);
        }

        // GET: EmpleadoCargoGS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpleadoCargoGS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEmpCargo,NombreCargo")] EmpleadoCargoGS empleadoCargoGS)
        {
            if (ModelState.IsValid)
            {
                db.EmpleadoCargoGS.Add(empleadoCargoGS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empleadoCargoGS);
        }

        // GET: EmpleadoCargoGS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpleadoCargoGS empleadoCargoGS = db.EmpleadoCargoGS.Find(id);
            if (empleadoCargoGS == null)
            {
                return HttpNotFound();
            }
            return View(empleadoCargoGS);
        }

        // POST: EmpleadoCargoGS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEmpCargo,NombreCargo")] EmpleadoCargoGS empleadoCargoGS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleadoCargoGS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empleadoCargoGS);
        }

        // GET: EmpleadoCargoGS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpleadoCargoGS empleadoCargoGS = db.EmpleadoCargoGS.Find(id);
            if (empleadoCargoGS == null)
            {
                return HttpNotFound();
            }
            return View(empleadoCargoGS);
        }

        // POST: EmpleadoCargoGS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmpleadoCargoGS empleadoCargoGS = db.EmpleadoCargoGS.Find(id);
            db.EmpleadoCargoGS.Remove(empleadoCargoGS);
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
