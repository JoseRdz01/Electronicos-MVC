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
    public class ProductosController : Controller
    {
        private ElectronicaDBEntities db = new ElectronicaDBEntities();

        // GET: Productos
        public ActionResult Index()
        {
            var productos = db.Productos.Include(p => p.Categorias).Include(p => p.Marcas);
            return View(productos.ToList());
            //List<Productos> lista_productos = new List<Productos>();
            //using (ElectronicaDBEntities context = new ElectronicaDBEntities())
            //{
            //    lista_productos = (from producto in context.Productos select producto).ToList();
            //}

            //ViewBag.Titulo = "Listado de productos";
            //ViewBag.Subtitulo = "xdxd";

            //return View(lista_productos);

        }

        // GET: Productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            ViewBag.Categoria_ID = new SelectList(db.Categorias, "ID_Categoria", "Nombre_Categoria");
            ViewBag.Marca_ID = new SelectList(db.Marcas, "ID_Marca", "Nombre_Marca");

            return View();
        }

        // POST: Productos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Producto,Nombre_Producto,Marca_ID,Categoria_ID,Existencia,Descripcion,Precio,URL_Imagen,Procesador,RAM,DiscoDuro")] Productos productos)
        {
            if (ModelState.IsValid)
            {
                db.Productos.Add(productos);
                db.SaveChanges();
                SweetAlert("Creado", "Creado con exito", NotificationType.success);
                return RedirectToAction("Index");
            }

            ViewBag.Categoria_ID = new SelectList(db.Categorias, "ID_Categoria", "Nombre_Categoria", productos.Categoria_ID);
            ViewBag.Marca_ID = new SelectList(db.Marcas, "ID_Marca", "Nombre_Marca", productos.Marca_ID);
            return View(productos);
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categoria_ID = new SelectList(db.Categorias, "ID_Categoria", "Nombre_Categoria", productos.Categoria_ID);
            ViewBag.Marca_ID = new SelectList(db.Marcas, "ID_Marca", "Nombre_Marca", productos.Marca_ID);
            return View(productos);
        }

        // POST: Productos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Producto,Nombre_Producto,Marca_ID,Categoria_ID,Existencia,Descripcion,Precio,URL_Imagen,Procesador,RAM,DiscoDuro")] Productos productos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productos).State = EntityState.Modified;
                db.SaveChanges();
                SweetAlert("Actualizado", "actualizado con exito", NotificationType.success);
                return RedirectToAction("Index");
            }
            ViewBag.Categoria_ID = new SelectList(db.Categorias, "ID_Categoria", "Nombre_Categoria", productos.Categoria_ID);
            ViewBag.Marca_ID = new SelectList(db.Marcas, "ID_Marca", "Nombre_Marca", productos.Marca_ID);
            return View(productos);
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Productos productos = db.Productos.Find(id);
            db.Productos.Remove(productos);
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
