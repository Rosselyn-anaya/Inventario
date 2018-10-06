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
    public class FacturasController : Controller
    {
        private Modelo db = new Modelo();
        static List<Detalle_factura> LAuxDetalle = new List<Detalle_factura>();

        // GET: Facturas
        public ActionResult Index()
        {
            var factura = db.Factura.Include(f => f.Clientes).Include(f => f.usuario);
            return View(factura.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = db.Factura.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // GET: Facturas/Create
        public ActionResult Create()
        {
            ViewBag.lproductos = db.Productos.ToList();
            ViewBag.id_Cliente = new SelectList(db.Clientes, "id", "Nombre");
            ViewBag.id_usuario = new SelectList(db.usuario, "id", "Nombre");
            return View();
        }

        public ActionResult DetallesCrear(int? id_producto, int? cantidad)
        {
            if ((id_producto > 0 && id_producto != null) && (cantidad > 0 && cantidad != null))
            {

                Detalle_factura item = new Detalle_factura();
                //---------------------------------------------------------
                //producto detalle
                item.Productos = db.Productos.Find(id_producto);//se busca el producto en la base de datos por ID

                item.id_productos = id_producto;
                //cantidad de producto del detalle
                item.cantidad = cantidad;

                //AGREGAR A LA LISTA ITEM
                LAuxDetalle.Add(item);
                return PartialView(LAuxDetalle);
            }
            else
            {
                return PartialView();
            }
        }

        // POST: Facturas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fecha,id_usuario,id_Cliente")] Factura factura)
        {

            //agregar detalles al objeto de encabezado
            foreach (var item in LAuxDetalle)
            {
                factura.Detalle_factura.Add(new Detalle_factura
                {
                    cantidad = item.cantidad,
                    id_factura = factura.id,
                    id_productos = item.id_productos,
                    

                });
            }
           
            if (ModelState.IsValid)
            {
                db.Factura.Add(factura);
                db.SaveChanges();

                foreach (var item in LAuxDetalle)
                {
                    Productos productos = db.Productos.Find(item.id_productos);
                    productos.existencias = productos.existencias - item.cantidad;
                    db.Entry(productos).State = EntityState.Modified;
                    db.SaveChanges();

                }

                //resetear lista de detalles
                LAuxDetalle = new List<Detalle_factura>();
                return RedirectToAction("Index");
            }

            ViewBag.id_Cliente = new SelectList(db.Clientes, "id", "Nombre", factura.id_Cliente);
            ViewBag.id_usuario = new SelectList(db.usuario, "id", "Nombre", factura.id_usuario);
            return View(factura);
        }

        // GET: Facturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = db.Factura.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_Cliente = new SelectList(db.Clientes, "id", "Nombre", factura.id_Cliente);
            ViewBag.id_usuario = new SelectList(db.usuario, "id", "Nombre", factura.id_usuario);
            return View(factura);
        }

        // POST: Facturas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fecha,id_usuario,id_Cliente")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(factura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_Cliente = new SelectList(db.Clientes, "id", "Nombre", factura.id_Cliente);
            ViewBag.id_usuario = new SelectList(db.usuario, "id", "Nombre", factura.id_usuario);
            return View(factura);
        }

        // GET: Facturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = db.Factura.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // POST: Facturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Factura factura = db.Factura.Find(id);
            db.Factura.Remove(factura);
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
