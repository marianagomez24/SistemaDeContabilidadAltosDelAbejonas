﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaContabilidadAltosDelAbejonal.Models;
using SistemaContabilidadAltosDelAbejonal.Datos;

namespace SistemaContabilidadAltosDelAbejonal.Controllers
{
    public class CompraDetallesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var compraDetalle = db.CompraDetalle.Include(c => c.Compra).Include(c => c.Producto);
            return View(compraDetalle.ToList());
        }

        // GET: CompraDetalles/Create
        public ActionResult Create()
        {
            ViewBag.IDCompra = new SelectList(db.Compra, "IDCompra", "IDCompra");
            ViewBag.IDProducto = new SelectList(db.Productos, "IDProducto", "Nombre");
            return View();
        }

        // POST: CompraDetalles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDCompra,IDProducto,Cantidad,PrecioCompra,TotalProducto")] CompraDetalle compraDetalle)
        {
            if (ModelState.IsValid)
            {
                db.CompraDetalle.Add(compraDetalle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCompra = new SelectList(db.Compra, "IDCompra", "IDCompra", compraDetalle.IDCompra);
            ViewBag.IDProducto = new SelectList(db.Productos, "IDProducto", "Nombre", compraDetalle.IDProducto);
            return View(compraDetalle);
        }

        // GET: CompraDetalles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompraDetalle compraDetalle = db.CompraDetalle.Find(id);
            if (compraDetalle == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCompra = new SelectList(db.Compra, "IDCompra", "IDCompra", compraDetalle.IDCompra);
            ViewBag.IDProducto = new SelectList(db.Productos, "IDProducto", "Nombre", compraDetalle.IDProducto);
            return View(compraDetalle);
        }

        // POST: CompraDetalles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDCompra,IDProducto,Cantidad,PrecioCompra,TotalProducto")] CompraDetalle compraDetalle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compraDetalle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCompra = new SelectList(db.Compra, "IDCompra", "IDCompra", compraDetalle.IDCompra);
            ViewBag.IDProducto = new SelectList(db.Productos, "IDProducto", "Nombre", compraDetalle.IDProducto);
            return View(compraDetalle);
        }

        // GET: CompraDetalles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompraDetalle compraDetalle = db.CompraDetalle.Find(id);
            if (compraDetalle == null)
            {
                return HttpNotFound();
            }
            return View(compraDetalle);
        }

        // POST: CompraDetalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompraDetalle compraDetalle = db.CompraDetalle.Find(id);
            db.CompraDetalle.Remove(compraDetalle);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public JsonResult ReporteCompra()
        {
            DT_Reporte objDT_Reporte = new DT_Reporte();

            List<ReporteCompra> objLista = objDT_Reporte.RetornarCompras();

            return Json(objLista, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult ReporteCompraProductos()
        {
            DT_Reporte objDT_Reporte = new DT_Reporte();

            List<ReporteCompraProductos> objLista = objDT_Reporte.RetornarProcutos();

            return Json(objLista, JsonRequestBehavior.AllowGet);
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