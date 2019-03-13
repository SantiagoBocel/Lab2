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
            return View(Data.Instance.Buscar(0, nombre));
        }
        public ActionResult Ventas(string nombre)
        {
            Data.Instance.Venta(0, nombre);
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

        public ActionResult Avanzada1()
        {
            return View(Data.Instance.Buscar(0, Data.Instance.busqueda));
        }
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            //aqui se crean los metodos, la logica

            try
            {
                //Asignaciones

                var nuevo = new Farmaco();
                nuevo.Nombre = collection["Nombre"];
                //Procesos
                string lel = nuevo.Nombre;
               Data.Instance.busqueda = lel;
                // Pushs//aqui decidimos a que lista queremos agregar
                
                return RedirectToAction("Avanzada1");

            }
            catch { return View(); }
        }



        public ActionResult Basica(string nombre)
        {
            return View(Data.Instance.Buscar(0, nombre));
        }

    }
}
