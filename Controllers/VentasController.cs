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
    public class VentasController : Controller
    {
        private ElectronicaDBEntities db = new ElectronicaDBEntities();

        // GET: Ventas
        public ActionResult Index()
        {
            var ventas = db.Ventas.Include(v => v.Productos).Include(v => v.Sucursales);
            return View(ventas.ToList());
        }

        // GET: Ventas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ventas ventas = db.Ventas.Find(id);
            if (ventas == null)
            {
                return HttpNotFound();
            }
            return View(ventas);
        }

        // GET: Ventas/Create
        public ActionResult Create()
        {
            ViewBag.Producto_ID = new SelectList(db.Productos, "ID_Producto", "Nombre_Producto");
            ViewBag.Sucursal_ID = new SelectList(db.Sucursales, "ID_Sucursal", "Nombre_Sucursal");
            return View();
        }

        // POST: Ventas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Venta,Producto_ID,Ganancia,Fecha_Venta,Sucursal_ID,Cantidad")] Ventas ventas)
        {
            if (ModelState.IsValid)
            {
                db.Ventas.Add(ventas);
                db.SaveChanges();
                SweetAlert("Creado", "Venta creada con exito", NotificationType.success);
                return RedirectToAction("Index");
            }

            ViewBag.Producto_ID = new SelectList(db.Productos, "ID_Producto", "Nombre_Producto", ventas.Producto_ID);
            ViewBag.Sucursal_ID = new SelectList(db.Sucursales, "ID_Sucursal", "Nombre_Sucursal", ventas.Sucursal_ID);
            return View(ventas);
        }

        // GET: Ventas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ventas ventas = db.Ventas.Find(id);
            if (ventas == null)
            {
                return HttpNotFound();
            }
            ViewBag.Producto_ID = new SelectList(db.Productos, "ID_Producto", "Nombre_Producto", ventas.Producto_ID);
            ViewBag.Sucursal_ID = new SelectList(db.Sucursales, "ID_Sucursal", "Nombre_Sucursal", ventas.Sucursal_ID);
            return View(ventas);
        }

        // POST: Ventas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Venta,Producto_ID,Ganancia,Fecha_Venta,Sucursal_ID,Cantidad")] Ventas ventas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ventas).State = EntityState.Modified;
                db.SaveChanges();
                SweetAlert("Actualizado", "Venta Actualizada con exito", NotificationType.success);
                return RedirectToAction("Index");
            }
            SweetAlert("Actualizado", "Venta Actualizada con exito", NotificationType.success);
            ViewBag.Producto_ID = new SelectList(db.Productos, "ID_Producto", "Nombre_Producto", ventas.Producto_ID);
            ViewBag.Sucursal_ID = new SelectList(db.Sucursales, "ID_Sucursal", "Nombre_Sucursal", ventas.Sucursal_ID);
            return View(ventas);
        }

        // GET: Ventas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ventas ventas = db.Ventas.Find(id);
            if (ventas == null)
            {
                return HttpNotFound();
            }
            return View(ventas);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ventas ventas = db.Ventas.Find(id);
            db.Ventas.Remove(ventas);
            db.SaveChanges();
            SweetAlert("Eliminado", "Venta eliminada con exito", NotificationType.success);
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
