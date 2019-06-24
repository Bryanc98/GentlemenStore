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
    public class ClientesGSController : Controller
    {
        private GeltlemenStoreEntities db = new GeltlemenStoreEntities();

        // GET: ClientesGS
        public ActionResult Index()
        {
            var clientesGS = db.ClientesGS.Include(c => c.MetodoPagoGS);
            return View(clientesGS.ToList());
        }

        // GET: ClientesGS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientesGS clientesGS = db.ClientesGS.Find(id);
            if (clientesGS == null)
            {
                return HttpNotFound();
            }
            return View(clientesGS);
        }

        // GET: ClientesGS/Create
        public ActionResult Create()
        {
            ViewBag.IdMetodoPago = new SelectList(db.MetodoPagoGS, "IdMetodoPago", "Nombre");
            return View();
        }

        // POST: ClientesGS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Cliente,Nom_Cliente,Identificacion_CGS,Tel_Cliente,Email_Cliente,IdMetodoPago")] ClientesGS clientesGS)
        {
            if (ModelState.IsValid)
            {
                db.ClientesGS.Add(clientesGS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdMetodoPago = new SelectList(db.MetodoPagoGS, "IdMetodoPago", "Nombre", clientesGS.IdMetodoPago);
            return View(clientesGS);
        }

        // GET: ClientesGS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientesGS clientesGS = db.ClientesGS.Find(id);
            if (clientesGS == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdMetodoPago = new SelectList(db.MetodoPagoGS, "IdMetodoPago", "Nombre", clientesGS.IdMetodoPago);
            return View(clientesGS);
        }

        // POST: ClientesGS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Cliente,Nom_Cliente,Identificacion_CGS,Tel_Cliente,Email_Cliente,IdMetodoPago")] ClientesGS clientesGS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientesGS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdMetodoPago = new SelectList(db.MetodoPagoGS, "IdMetodoPago", "Nombre", clientesGS.IdMetodoPago);
            return View(clientesGS);
        }

        // GET: ClientesGS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientesGS clientesGS = db.ClientesGS.Find(id);
            if (clientesGS == null)
            {
                return HttpNotFound();
            }
            return View(clientesGS);
        }

        // POST: ClientesGS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClientesGS clientesGS = db.ClientesGS.Find(id);
            db.ClientesGS.Remove(clientesGS);
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
