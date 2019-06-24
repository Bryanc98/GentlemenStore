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
    public class DepartamentoGSController : Controller
    {
        private GeltlemenStoreEntities db = new GeltlemenStoreEntities();

        // GET: DepartamentoGS
        public ActionResult Index()
        {
            return View(db.DepartamentoGS.ToList());
        }

        // GET: DepartamentoGS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartamentoGS departamentoGS = db.DepartamentoGS.Find(id);
            if (departamentoGS == null)
            {
                return HttpNotFound();
            }
            return View(departamentoGS);
        }

        // GET: DepartamentoGS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartamentoGS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDepartamento,NombreDep")] DepartamentoGS departamentoGS)
        {
            if (ModelState.IsValid)
            {
                db.DepartamentoGS.Add(departamentoGS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(departamentoGS);
        }

        // GET: DepartamentoGS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartamentoGS departamentoGS = db.DepartamentoGS.Find(id);
            if (departamentoGS == null)
            {
                return HttpNotFound();
            }
            return View(departamentoGS);
        }

        // POST: DepartamentoGS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDepartamento,NombreDep")] DepartamentoGS departamentoGS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departamentoGS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(departamentoGS);
        }

        // GET: DepartamentoGS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartamentoGS departamentoGS = db.DepartamentoGS.Find(id);
            if (departamentoGS == null)
            {
                return HttpNotFound();
            }
            return View(departamentoGS);
        }

        // POST: DepartamentoGS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DepartamentoGS departamentoGS = db.DepartamentoGS.Find(id);
            db.DepartamentoGS.Remove(departamentoGS);
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
