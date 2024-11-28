using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Electronicos_MVC.Models;

namespace Electronicos_MVC.Controllers
{
    public class bitacora_categoriasController : Controller
    {
        private ElectronicaDBEntities db = new ElectronicaDBEntities();

        // GET: bitacora_categorias
        public ActionResult Index()
        {
            return View(db.bitacora_categorias.ToList());
        }

        // GET: bitacora_categorias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bitacora_categorias bitacora_categorias = db.bitacora_categorias.Find(id);
            if (bitacora_categorias == null)
            {
                return HttpNotFound();
            }
            return View(bitacora_categorias);
        }

        // GET: bitacora_categorias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: bitacora_categorias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Bitacora,Categoria_ID,Fecha,Accion")] bitacora_categorias bitacora_categorias)
        {
            if (ModelState.IsValid)
            {
                db.bitacora_categorias.Add(bitacora_categorias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bitacora_categorias);
        }

        // GET: bitacora_categorias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bitacora_categorias bitacora_categorias = db.bitacora_categorias.Find(id);
            if (bitacora_categorias == null)
            {
                return HttpNotFound();
            }
            return View(bitacora_categorias);
        }

        // POST: bitacora_categorias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Bitacora,Categoria_ID,Fecha,Accion")] bitacora_categorias bitacora_categorias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bitacora_categorias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bitacora_categorias);
        }

        // GET: bitacora_categorias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bitacora_categorias bitacora_categorias = db.bitacora_categorias.Find(id);
            if (bitacora_categorias == null)
            {
                return HttpNotFound();
            }
            return View(bitacora_categorias);
        }

        // POST: bitacora_categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bitacora_categorias bitacora_categorias = db.bitacora_categorias.Find(id);
            db.bitacora_categorias.Remove(bitacora_categorias);
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
