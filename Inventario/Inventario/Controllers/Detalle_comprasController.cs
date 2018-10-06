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
    public class Detalle_comprasController : Controller
    {
        private Modelo db = new Modelo();

        // GET: Detalle_compras
        public ActionResult Index()
        {
            var detalle_compras = db.Detalle_compras.Include(d => d.Compras).Include(d => d.Productos);
            return View(detalle_compras.ToList());
        }

        // GET: Detalle_compras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_compras detalle_compras = db.Detalle_compras.Find(id);
            if (detalle_compras == null)
            {
                return HttpNotFound();
            }
            return View(detalle_compras);
        }

        // GET: Detalle_compras/Create
        public ActionResult Create()
        {
            ViewBag.id_compras = new SelectList(db.Compras, "id", "id");
            ViewBag.id_productos = new SelectList(db.Productos, "id", "nombre");
            return View();
        }

        // POST: Detalle_compras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,cantidad,id_productos,id_compras")] Detalle_compras detalle_compras)
        {
            if (ModelState.IsValid)
            {
                db.Detalle_compras.Add(detalle_compras);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_compras = new SelectList(db.Compras, "id", "id", detalle_compras.id_compras);
            ViewBag.id_productos = new SelectList(db.Productos, "id", "nombre", detalle_compras.id_productos);
            return View(detalle_compras);
        }

        // GET: Detalle_compras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_compras detalle_compras = db.Detalle_compras.Find(id);
            if (detalle_compras == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_compras = new SelectList(db.Compras, "id", "id", detalle_compras.id_compras);
            ViewBag.id_productos = new SelectList(db.Productos, "id", "nombre", detalle_compras.id_productos);
            return View(detalle_compras);
        }

        // POST: Detalle_compras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,cantidad,id_productos,id_compras")] Detalle_compras detalle_compras)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalle_compras).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_compras = new SelectList(db.Compras, "id", "id", detalle_compras.id_compras);
            ViewBag.id_productos = new SelectList(db.Productos, "id", "nombre", detalle_compras.id_productos);
            return View(detalle_compras);
        }

        // GET: Detalle_compras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_compras detalle_compras = db.Detalle_compras.Find(id);
            if (detalle_compras == null)
            {
                return HttpNotFound();
            }
            return View(detalle_compras);
        }

        // POST: Detalle_compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Detalle_compras detalle_compras = db.Detalle_compras.Find(id);
            db.Detalle_compras.Remove(detalle_compras);
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
