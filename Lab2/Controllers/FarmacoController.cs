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
        public ActionResult Basica(string nombre)
        {
            return View(Data.Instance.Buscar(0, nombre));
        }
        public ActionResult Index()
        {
            Data.Instance.lVentas.Clear();

            Data.Instance.CustomSplit();

            return View(Data.Instance.pos);
        }
        public ActionResult Avanzada(string nombre)
        {
            return View(Data.Instance.Buscar(0, nombre));
        }
        public ActionResult Avanzada1()
        {
            return View(Data.Instance.Buscar(0, Data.Instance.busqueda));
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
            catch { return View("Index"); }
        }
        public ActionResult Factura()
        {
            return View(Data.Instance.Factura);
        }
        public ActionResult Usuario()
        {
            return View();
        }

       

        [HttpPost]
        public ActionResult Usuario(FormCollection collection)
        {

            try
            {
                //Asignaciones
                var nuevo = new Factura();

                nuevo.Nombre = collection["Nombre"];

                nuevo.NIT = collection["NIT"];

                nuevo.Direccion = collection["Direccion"];

                nuevo.Pagar = Data.Instance.Pagar();


                Data.Instance.Factura.Add(nuevo);
                // Pushs//aqui decidimos a que lista queremos agregar

                return RedirectToAction("Factura");

            }
            catch { return View("Index"); }
        }
        
        public ActionResult Entregar(int id)
        {
            return View("Index");
        }


    }
}
