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
    public class MetodoPagoGSController : Controller
    {
        private GeltlemenStoreEntities db = new GeltlemenStoreEntities();

        // GET: MetodoPagoGS
        public ActionResult Index()
        {
            var metodoPagoGS = db.MetodoPagoGS.Include(m => m.ProveedorPagoGS);
            return View(metodoPagoGS.ToList());
        }

        // GET: MetodoPagoGS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetodoPagoGS metodoPagoGS = db.MetodoPagoGS.Find(id);
            if (metodoPagoGS == null)
            {
                return HttpNotFound();
            }
            return View(metodoPagoGS);
        }

        // GET: MetodoPagoGS/Create
        public ActionResult Create()
        {
            ViewBag.IdProveedorPago = new SelectList(db.ProveedorPagoGS, "IdProveedorPago", "Nombre");
            return View();
        }

        // POST: MetodoPagoGS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdMetodoPago,Nombre,IdProveedorPago")] MetodoPagoGS metodoPagoGS)
        {
            if (ModelState.IsValid)
            {
                db.MetodoPagoGS.Add(metodoPagoGS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProveedorPago = new SelectList(db.ProveedorPagoGS, "IdProveedorPago", "Nombre", metodoPagoGS.IdProveedorPago);
            return View(metodoPagoGS);
        }

        // GET: MetodoPagoGS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetodoPagoGS metodoPagoGS = db.MetodoPagoGS.Find(id);
            if (metodoPagoGS == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProveedorPago = new SelectList(db.ProveedorPagoGS, "IdProveedorPago", "Nombre", metodoPagoGS.IdProveedorPago);
            return View(metodoPagoGS);
        }

        // POST: MetodoPagoGS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdMetodoPago,Nombre,IdProveedorPago")] MetodoPagoGS metodoPagoGS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(metodoPagoGS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProveedorPago = new SelectList(db.ProveedorPagoGS, "IdProveedorPago", "Nombre", metodoPagoGS.IdProveedorPago);
            return View(metodoPagoGS);
        }

        // GET: MetodoPagoGS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetodoPagoGS metodoPagoGS = db.MetodoPagoGS.Find(id);
            if (metodoPagoGS == null)
            {
                return HttpNotFound();
            }
            return View(metodoPagoGS);
        }

        // POST: MetodoPagoGS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MetodoPagoGS metodoPagoGS = db.MetodoPagoGS.Find(id);
            db.MetodoPagoGS.Remove(metodoPagoGS);
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
