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
    public class SubCategoriaGSController : Controller
    {
        private GeltlemenStoreEntities db = new GeltlemenStoreEntities();

        // GET: SubCategoriaGS
        public ActionResult Index()
        {
            var subCategoriaGS = db.SubCategoriaGS.Include(s => s.CategoriaGS);
            return View(subCategoriaGS.ToList());
        }

        // GET: SubCategoriaGS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategoriaGS subCategoriaGS = db.SubCategoriaGS.Find(id);
            if (subCategoriaGS == null)
            {
                return HttpNotFound();
            }
            return View(subCategoriaGS);
        }

        // GET: SubCategoriaGS/Create
        public ActionResult Create()
        {
            ViewBag.IdCategoria = new SelectList(db.CategoriaGS, "Id_Categoria", "Nombre");
            return View();
        }

        // POST: SubCategoriaGS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_SubCategoria,NombreSubcategoria,IdCategoria")] SubCategoriaGS subCategoriaGS)
        {
            if (ModelState.IsValid)
            {
                db.SubCategoriaGS.Add(subCategoriaGS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCategoria = new SelectList(db.CategoriaGS, "Id_Categoria", "Nombre", subCategoriaGS.IdCategoria);
            return View(subCategoriaGS);
        }

        // GET: SubCategoriaGS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategoriaGS subCategoriaGS = db.SubCategoriaGS.Find(id);
            if (subCategoriaGS == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCategoria = new SelectList(db.CategoriaGS, "Id_Categoria", "Nombre", subCategoriaGS.IdCategoria);
            return View(subCategoriaGS);
        }

        // POST: SubCategoriaGS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_SubCategoria,NombreSubcategoria,IdCategoria")] SubCategoriaGS subCategoriaGS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subCategoriaGS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCategoria = new SelectList(db.CategoriaGS, "Id_Categoria", "Nombre", subCategoriaGS.IdCategoria);
            return View(subCategoriaGS);
        }

        // GET: SubCategoriaGS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategoriaGS subCategoriaGS = db.SubCategoriaGS.Find(id);
            if (subCategoriaGS == null)
            {
                return HttpNotFound();
            }
            return View(subCategoriaGS);
        }

        // POST: SubCategoriaGS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubCategoriaGS subCategoriaGS = db.SubCategoriaGS.Find(id);
            db.SubCategoriaGS.Remove(subCategoriaGS);
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
