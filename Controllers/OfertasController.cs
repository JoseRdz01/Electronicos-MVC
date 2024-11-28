using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Electronicos_MVC.Models;
using static Electronicos_MVC.Models.Enum;

namespace Electronicos_MVC.Controllers
{
    public class OfertasController : Controller
    {
        private ElectronicaDBEntities db = new ElectronicaDBEntities();

        // GET: Ofertas
        public ActionResult Index()
        {
            var ofertas = db.Ofertas.Include(o => o.Productos);
            return View(ofertas.ToList());
        }

        // GET: Ofertas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ofertas ofertas = db.Ofertas.Find(id);
            if (ofertas == null)
            {
                return HttpNotFound();
            }
            return View(ofertas);
        }

        // GET: Ofertas/Create
        public ActionResult Create()
        {
            ViewBag.Producto_ID = new SelectList(db.Productos, "ID_Producto", "Nombre_Producto");
            return View();
        }

        // POST: Ofertas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Oferta,Producto_ID,Porcentaje_Desc,Fecha_inicio,Fecha_fin")] Ofertas ofertas)
        {
            if (ModelState.IsValid)
            {
                db.Ofertas.Add(ofertas);
                db.SaveChanges();
                SweetAlert("Creacion", "Creacion con exito", NotificationType.success);
                return RedirectToAction("Index");
            }

            ViewBag.Producto_ID = new SelectList(db.Productos, "ID_Producto", "Nombre_Producto", ofertas.Producto_ID);
            return View(ofertas);
        }

        // GET: Ofertas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ofertas ofertas = db.Ofertas.Find(id);
            if (ofertas == null)
            {
                return HttpNotFound();
            }
            ViewBag.Producto_ID = new SelectList(db.Productos, "ID_Producto", "Nombre_Producto", ofertas.Producto_ID);
            return View(ofertas);
        }

        // POST: Ofertas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Oferta,Producto_ID,Porcentaje_Desc,Fecha_inicio,Fecha_fin")] Ofertas ofertas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ofertas).State = EntityState.Modified;
                db.SaveChanges();
                SweetAlert("Actualizacion", "Actualizacion con exito", NotificationType.success);
                return RedirectToAction("Index");
            }
            ViewBag.Producto_ID = new SelectList(db.Productos, "ID_Producto", "Nombre_Producto", ofertas.Producto_ID);
            return View(ofertas);
        }

        // GET: Ofertas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ofertas ofertas = db.Ofertas.Find(id);
            if (ofertas == null)
            {
                return HttpNotFound();
            }
            return View(ofertas);
        }

        // POST: Ofertas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ofertas ofertas = db.Ofertas.Find(id);
            db.Ofertas.Remove(ofertas);
            db.SaveChanges();
            SweetAlert("Eliminado", "eliminada con exito", NotificationType.success);
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


        #region Sweet Alert

        private void SweetAlert(string title, string msg, NotificationType type)
        {
            var script = "<script languaje='javascript'> " +
                         "Swal.fire({" +
                         "title: '" + title + "'," +
                         "text: '" + msg + "'," +
                         "icon: '" + type + "'" +
                         "});" +
                         "</script>";

            //TempData funciona como un viewBag, pasando información del controlador a cualquier parte de mi proyecto, siendo este más observable y con un tiempo de vida similar
            TempData["sweetalert"] = script;
        }

        private void SweetAlert_Eliminar(int id)
        {
            var script = "<script languaje='javascript'>" +
                "Swal.fire({" +
                "title: '¿Estás Seguro?'," +
                "text: 'Estás apunto de Eliminar el Camión: " + id.ToString() + "'," +
                "icon: 'info'," +
                "showDenyButton: true," +
                "showCancelButton: true," +
                "confirmButtonText: 'Eliminar'," +
                "denyButtonText: 'Cancelar'" +
                "}).then((result) => {" +
                "if (result.isConfirmed) {  " +
                "window.location.href = '/Camiones/Eliminar_Camion/" + id + "';" +
                "} else if (result.isDenied) {  " +
                "Swal.fire('Se ha cancelado la operación','','info');" +
                "}" +
                "});" +
                "</script>";

            TempData["sweetalert"] = script;
        }

        #endregion
    }
}
