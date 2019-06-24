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
    public class SuplidoresGSController : Controller
    {
        private GeltlemenStoreEntities db = new GeltlemenStoreEntities();

        // GET: SuplidoresGS
        public ActionResult Index()
        {
            return View(db.SuplidoresGS.ToList());
        }

        // GET: SuplidoresGS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuplidoresGS suplidoresGS = db.SuplidoresGS.Find(id);
            if (suplidoresGS == null)
            {
                return HttpNotFound();
            }
            return View(suplidoresGS);
        }

        // GET: SuplidoresGS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuplidoresGS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Suplidor,Nom_Suplidor,RNC_Suplidor,Dirrec_Suplidor,Tel_Suplidor,Email_Suplidor")] SuplidoresGS suplidoresGS)
        {
            if (ModelState.IsValid)
            {
                db.SuplidoresGS.Add(suplidoresGS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(suplidoresGS);
        }

        // GET: SuplidoresGS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuplidoresGS suplidoresGS = db.SuplidoresGS.Find(id);
            if (suplidoresGS == null)
            {
                return HttpNotFound();
            }
            return View(suplidoresGS);
        }

        // POST: SuplidoresGS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Suplidor,Nom_Suplidor,RNC_Suplidor,Dirrec_Suplidor,Tel_Suplidor,Email_Suplidor")] SuplidoresGS suplidoresGS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suplidoresGS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(suplidoresGS);
        }

        // GET: SuplidoresGS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuplidoresGS suplidoresGS = db.SuplidoresGS.Find(id);
            if (suplidoresGS == null)
            {
                return HttpNotFound();
            }
            return View(suplidoresGS);
        }

        // POST: SuplidoresGS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SuplidoresGS suplidoresGS = db.SuplidoresGS.Find(id);
            db.SuplidoresGS.Remove(suplidoresGS);
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
