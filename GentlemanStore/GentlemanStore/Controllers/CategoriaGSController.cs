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
    public class CategoriaGSController : Controller
    {
        private GeltlemenStoreEntities db = new GeltlemenStoreEntities();

        // GET: CategoriaGS
        public ActionResult Index()
        {
            return View(db.CategoriaGS.ToList());
        }

        // GET: CategoriaGS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CategoriaGS categoriaGS = db.CategoriaGS.Find(id);
            if (categoriaGS == null)
            {
                return HttpNotFound();
            }
            return View(categoriaGS);
        }

        // GET: CategoriaGS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaGS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Categoria,Nombre")] CategoriaGS categoriaGS)
        {
            if (ModelState.IsValid)
            {
                db.CategoriaGS.Add(categoriaGS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoriaGS);
        }

        // GET: CategoriaGS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaGS categoriaGS = db.CategoriaGS.Find(id);
            if (categoriaGS == null)
            {
                return HttpNotFound();
            }
            return View(categoriaGS);
        }

        // POST: CategoriaGS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Categoria,Nombre")] CategoriaGS categoriaGS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoriaGS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoriaGS);
        }

        // GET: CategoriaGS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaGS categoriaGS = db.CategoriaGS.Find(id);
            if (categoriaGS == null)
            {
                return HttpNotFound();
            }
            return View(categoriaGS);
        }

        // POST: CategoriaGS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoriaGS categoriaGS = db.CategoriaGS.Find(id);
            db.CategoriaGS.Remove(categoriaGS);
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
