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
    public class ProveedorPagoGSController : Controller
    {
        private GeltlemenStoreEntities db = new GeltlemenStoreEntities();

        // GET: ProveedorPagoGS
        public ActionResult Index()
        {
            return View(db.ProveedorPagoGS.ToList());
        }

        // GET: ProveedorPagoGS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProveedorPagoGS proveedorPagoGS = db.ProveedorPagoGS.Find(id);
            if (proveedorPagoGS == null)
            {
                return HttpNotFound();
            }
            return View(proveedorPagoGS);
        }

        // GET: ProveedorPagoGS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProveedorPagoGS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProveedorPago,Nombre")] ProveedorPagoGS proveedorPagoGS)
        {
            if (ModelState.IsValid)
            {
                db.ProveedorPagoGS.Add(proveedorPagoGS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(proveedorPagoGS);
        }

        // GET: ProveedorPagoGS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProveedorPagoGS proveedorPagoGS = db.ProveedorPagoGS.Find(id);
            if (proveedorPagoGS == null)
            {
                return HttpNotFound();
            }
            return View(proveedorPagoGS);
        }

        // POST: ProveedorPagoGS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProveedorPago,Nombre")] ProveedorPagoGS proveedorPagoGS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proveedorPagoGS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(proveedorPagoGS);
        }

        // GET: ProveedorPagoGS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProveedorPagoGS proveedorPagoGS = db.ProveedorPagoGS.Find(id);
            if (proveedorPagoGS == null)
            {
                return HttpNotFound();
            }
            return View(proveedorPagoGS);
        }

        // POST: ProveedorPagoGS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProveedorPagoGS proveedorPagoGS = db.ProveedorPagoGS.Find(id);
            db.ProveedorPagoGS.Remove(proveedorPagoGS);
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
