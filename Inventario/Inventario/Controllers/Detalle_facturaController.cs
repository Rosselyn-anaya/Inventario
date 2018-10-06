using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Inventario.Models;

namespace Inventario.Controllers
{
    public class Detalle_facturaController : Controller
    {
        private Modelo db = new Modelo();

        // GET: Detalle_factura
        public ActionResult Index()
        {
            var detalle_factura = db.Detalle_factura.Include(d => d.Factura).Include(d => d.Productos);
            return View(detalle_factura.ToList());
        }

        // GET: Detalle_factura/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_factura detalle_factura = db.Detalle_factura.Find(id);
            if (detalle_factura == null)
            {
                return HttpNotFound();
            }
            return View(detalle_factura);
        }

        // GET: Detalle_factura/Create
        public ActionResult Create()
        {
            ViewBag.id_factura = new SelectList(db.Factura, "id", "id");
            ViewBag.id_productos = new SelectList(db.Productos, "id", "nombre");
            return View();
        }

        // POST: Detalle_factura/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,cantidad,descripcion,id_productos,id_factura,precio,descuento,iva,total")] Detalle_factura detalle_factura)
        {
            if (ModelState.IsValid)
            {
                db.Detalle_factura.Add(detalle_factura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_factura = new SelectList(db.Factura, "id", "id", detalle_factura.id_factura);
            ViewBag.id_productos = new SelectList(db.Productos, "id", "nombre", detalle_factura.id_productos);
            return View(detalle_factura);
        }

        // GET: Detalle_factura/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_factura detalle_factura = db.Detalle_factura.Find(id);
            if (detalle_factura == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_factura = new SelectList(db.Factura, "id", "id", detalle_factura.id_factura);
            ViewBag.id_productos = new SelectList(db.Productos, "id", "nombre", detalle_factura.id_productos);
            return View(detalle_factura);
        }

        // POST: Detalle_factura/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,cantidad,descripcion,id_productos,id_factura,precio,descuento,iva,total")] Detalle_factura detalle_factura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalle_factura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_factura = new SelectList(db.Factura, "id", "id", detalle_factura.id_factura);
            ViewBag.id_productos = new SelectList(db.Productos, "id", "nombre", detalle_factura.id_productos);
            return View(detalle_factura);
        }

        // GET: Detalle_factura/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_factura detalle_factura = db.Detalle_factura.Find(id);
            if (detalle_factura == null)
            {
                return HttpNotFound();
            }
            return View(detalle_factura);
        }

        // POST: Detalle_factura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Detalle_factura detalle_factura = db.Detalle_factura.Find(id);
            db.Detalle_factura.Remove(detalle_factura);
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
