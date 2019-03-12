using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Library;
using Lab2.Singleton;
using Lab2.Models;
using System.Web.Mvc;

namespace Lab2.Controllers
{
    public class FarmacoController : Controller
    {
        
        public ActionResult Index()
        {
            Data.Instance.CustomSplit();

            return View(Data.Instance.pos);
        }

        public ActionResult Avanzada(string nombre)
        {
           
            return View(Data.Instance.Buscar(0,nombre));
        }
        public ActionResult Ventas(string nombre)
        {
            Data.Instance.Venta(0,nombre);
            return View(Data.Instance.pos);
        }

        public ActionResult Quitar(string nombre)
        {
            Data.Instance.Quitar(0, nombre);
            return View(Data.Instance.lVentas);
        }
        public ActionResult Carrito()
            {
                return View(Data.Instance.lVentas);
            }

        // GET: Farmacia/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Farmacia/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Farmacia/Delete/5
        public ActionResult Basica(string nombre)
        {
            return View(Data.Instance.Buscar(0, nombre));
        }

        // POST: Farmacia/Delete/5
        [HttpPost]
        public ActionResult Basica(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
