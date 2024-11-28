﻿using System;
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
    public class ProductoSucursalesController : Controller
    {
        private ElectronicaDBEntities db = new ElectronicaDBEntities();

        // GET: ProductoSucursales
        public ActionResult Index()
        {
            var productoSucursales = db.ProductoSucursales.Include(p => p.Productos).Include(p => p.Sucursales);
            return View(productoSucursales.ToList());
        }

        // GET: ProductoSucursales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoSucursales productoSucursales = db.ProductoSucursales.Find(id);
            if (productoSucursales == null)
            {
                return HttpNotFound();
            }
            return View(productoSucursales);
        }

        // GET: ProductoSucursales/Create
        public ActionResult Create()
        {
            ViewBag.ID_Producto = new SelectList(db.Productos, "ID_Producto", "Nombre_Producto");
            ViewBag.ID_Sucursal = new SelectList(db.Sucursales, "ID_Sucursal", "Nombre_Sucursal");
            return View();
        }

        // POST: ProductoSucursales/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Existencia_Sucursal,ID_Producto,ID_Sucursal,Existencia")] ProductoSucursales productoSucursales)
        {
            if (ModelState.IsValid)
            {
                db.ProductoSucursales.Add(productoSucursales);
                db.SaveChanges();
                SweetAlert("Creado", "creado con exito", NotificationType.success);
                return RedirectToAction("Index");
            }

            ViewBag.ID_Producto = new SelectList(db.Productos, "ID_Producto", "Nombre_Producto", productoSucursales.ID_Producto);
            ViewBag.ID_Sucursal = new SelectList(db.Sucursales, "ID_Sucursal", "Nombre_Sucursal", productoSucursales.ID_Sucursal);
            return View(productoSucursales);
        }

        // GET: ProductoSucursales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoSucursales productoSucursales = db.ProductoSucursales.Find(id);
            if (productoSucursales == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Producto = new SelectList(db.Productos, "ID_Producto", "Nombre_Producto", productoSucursales.ID_Producto);
            ViewBag.ID_Sucursal = new SelectList(db.Sucursales, "ID_Sucursal", "Nombre_Sucursal", productoSucursales.ID_Sucursal);
            return View(productoSucursales);
        }

        // POST: ProductoSucursales/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Existencia_Sucursal,ID_Producto,ID_Sucursal,Existencia")] ProductoSucursales productoSucursales)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productoSucursales).State = EntityState.Modified;
                db.SaveChanges();
                SweetAlert("Editado", "Editado con exito", NotificationType.success);
                return RedirectToAction("Index");
            }
            ViewBag.ID_Producto = new SelectList(db.Productos, "ID_Producto", "Nombre_Producto", productoSucursales.ID_Producto);
            ViewBag.ID_Sucursal = new SelectList(db.Sucursales, "ID_Sucursal", "Nombre_Sucursal", productoSucursales.ID_Sucursal);
            return View(productoSucursales);
        }

        // GET: ProductoSucursales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoSucursales productoSucursales = db.ProductoSucursales.Find(id);
            if (productoSucursales == null)
            {
                return HttpNotFound();
            }
            return View(productoSucursales);
        }

        // POST: ProductoSucursales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductoSucursales productoSucursales = db.ProductoSucursales.Find(id);
            db.ProductoSucursales.Remove(productoSucursales);
            db.SaveChanges();
            SweetAlert("Eliminado", "eliminado con exito", NotificationType.success);
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