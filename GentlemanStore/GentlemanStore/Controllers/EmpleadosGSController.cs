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
    public class EmpleadosGSController : Controller
    {
        private GeltlemenStoreEntities db = new GeltlemenStoreEntities();

        // GET: EmpleadosGS
        public ActionResult Index()
        {
            var empleadosGS = db.EmpleadosGS.Include(e => e.DepartamentoGS).Include(e => e.EmpleadoCargoGS);
            return View(empleadosGS.ToList());
        }

        // GET: EmpleadosGS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpleadosGS empleadosGS = db.EmpleadosGS.Find(id);
            if (empleadosGS == null)
            {
                return HttpNotFound();
            }
            return View(empleadosGS);
        }

        // GET: EmpleadosGS/Create
        public ActionResult Create()
        {
            ViewBag.IdDepEmp = new SelectList(db.DepartamentoGS, "IdDepartamento", "NombreDep");
            ViewBag.IdCargoEmp = new SelectList(db.EmpleadoCargoGS, "IdEmpCargo", "NombreCargo");
            return View();
        }

        // POST: EmpleadosGS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Empleado,Nom_Empleado,Cedula_Empleado,Edad,Telefono,Ocupacion_Empleado,Salario_Empleado,IdCargoEmp,IdDepEmp")] EmpleadosGS empleadosGS)
        {
            if (ModelState.IsValid)
            {
                db.EmpleadosGS.Add(empleadosGS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdDepEmp = new SelectList(db.DepartamentoGS, "IdDepartamento", "NombreDep", empleadosGS.IdDepEmp);
            ViewBag.IdCargoEmp = new SelectList(db.EmpleadoCargoGS, "IdEmpCargo", "NombreCargo", empleadosGS.IdCargoEmp);
            return View(empleadosGS);
        }

        // GET: EmpleadosGS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpleadosGS empleadosGS = db.EmpleadosGS.Find(id);
            if (empleadosGS == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDepEmp = new SelectList(db.DepartamentoGS, "IdDepartamento", "NombreDep", empleadosGS.IdDepEmp);
            ViewBag.IdCargoEmp = new SelectList(db.EmpleadoCargoGS, "IdEmpCargo", "NombreCargo", empleadosGS.IdCargoEmp);
            return View(empleadosGS);
        }

        // POST: EmpleadosGS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Empleado,Nom_Empleado,Cedula_Empleado,Edad,Telefono,Ocupacion_Empleado,Salario_Empleado,IdCargoEmp,IdDepEmp")] EmpleadosGS empleadosGS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleadosGS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdDepEmp = new SelectList(db.DepartamentoGS, "IdDepartamento", "NombreDep", empleadosGS.IdDepEmp);
            ViewBag.IdCargoEmp = new SelectList(db.EmpleadoCargoGS, "IdEmpCargo", "NombreCargo", empleadosGS.IdCargoEmp);
            return View(empleadosGS);
        }

        // GET: EmpleadosGS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpleadosGS empleadosGS = db.EmpleadosGS.Find(id);
            if (empleadosGS == null)
            {
                return HttpNotFound();
            }
            return View(empleadosGS);
        }

        // POST: EmpleadosGS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmpleadosGS empleadosGS = db.EmpleadosGS.Find(id);
            db.EmpleadosGS.Remove(empleadosGS);
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
