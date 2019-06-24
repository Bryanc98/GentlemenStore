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
    public class ProductosGSController : Controller
    {
        private GeltlemenStoreEntities db = new GeltlemenStoreEntities();

        // GET: ProductosGS
        public ActionResult Index()
        {
            var productosGS = db.ProductosGS.Include(p => p.CategoriaGS).Include(p => p.SubCategoriaGS).Include(p => p.SuplidoresGS);
            return View(productosGS.ToList());
        }

        // GET: ProductosGS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductosGS productosGS = db.ProductosGS.Find(id);
            if (productosGS == null)
            {
                return HttpNotFound();
            }
            return View(productosGS);
        }

        // GET: ProductosGS/Create
        public ActionResult Create()
        {
            ViewBag.IdCategoria = new SelectList(db.CategoriaGS, "Id_Categoria", "Nombre");
            ViewBag.IdSubCategoria = new SelectList(db.SubCategoriaGS, "Id_SubCategoria", "NombreSubcategoria");
            ViewBag.Suplidor_P = new SelectList(db.SuplidoresGS, "ID_Suplidor", "Nom_Suplidor");
            return View();
        }

        // POST: ProductosGS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Productos,Nom_Producto,Tipo_Producto,Cantidad_Producto,CostoU_Producto,Suplidor_P,IdCategoria,IdSubCategoria")] ProductosGS productosGS)
        {
            if (ModelState.IsValid)
            {
                db.ProductosGS.Add(productosGS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCategoria = new SelectList(db.CategoriaGS, "Id_Categoria", "Nombre", productosGS.IdCategoria);
            ViewBag.IdSubCategoria = new SelectList(db.SubCategoriaGS, "Id_SubCategoria", "NombreSubcategoria", productosGS.IdSubCategoria);
            ViewBag.Suplidor_P = new SelectList(db.SuplidoresGS, "ID_Suplidor", "Nom_Suplidor", productosGS.Suplidor_P);
            return View(productosGS);
        }

        // GET: ProductosGS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductosGS productosGS = db.ProductosGS.Find(id);
            if (productosGS == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCategoria = new SelectList(db.CategoriaGS, "Id_Categoria", "Nombre", productosGS.IdCategoria);
            ViewBag.IdSubCategoria = new SelectList(db.SubCategoriaGS, "Id_SubCategoria", "NombreSubcategoria", productosGS.IdSubCategoria);
            ViewBag.Suplidor_P = new SelectList(db.SuplidoresGS, "ID_Suplidor", "Nom_Suplidor", productosGS.Suplidor_P);
            return View(productosGS);
        }

        // POST: ProductosGS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Productos,Nom_Producto,Tipo_Producto,Cantidad_Producto,CostoU_Producto,Suplidor_P,IdCategoria,IdSubCategoria")] ProductosGS productosGS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productosGS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCategoria = new SelectList(db.CategoriaGS, "Id_Categoria", "Nombre", productosGS.IdCategoria);
            ViewBag.IdSubCategoria = new SelectList(db.SubCategoriaGS, "Id_SubCategoria", "NombreSubcategoria", productosGS.IdSubCategoria);
            ViewBag.Suplidor_P = new SelectList(db.SuplidoresGS, "ID_Suplidor", "Nom_Suplidor", productosGS.Suplidor_P);
            return View(productosGS);
        }

        // GET: ProductosGS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductosGS productosGS = db.ProductosGS.Find(id);
            if (productosGS == null)
            {
                return HttpNotFound();
            }
            return View(productosGS);
        }

        // POST: ProductosGS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductosGS productosGS = db.ProductosGS.Find(id);
            db.ProductosGS.Remove(productosGS);
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
