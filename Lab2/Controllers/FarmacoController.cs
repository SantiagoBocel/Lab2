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
        // GET: Farmacia
        public ActionResult Index()
        {
            Data.Instance.CustomSplit();

            return View(Data.Instance.Lista);
        }

        // GET: Farmacia/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Farmacia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Farmacia/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Farmacia/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
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
