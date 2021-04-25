using peliculas.Models.peliculas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace peliculas.Controllers
{
    public class peliculasController : Controller
    {
        // GET: peliculas
        public ActionResult Index()
        {
            pelicula pel = new pelicula();
            List<pelicula> lista = pel.consultar_pelicula();
            ViewBag.lista_peliculas = lista;
            return View();
        }

        // GET: peliculas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: peliculas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: peliculas/Create
        [HttpPost]
        public ActionResult Create(int id)
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

        // GET: peliculas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: peliculas/Edit/5
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

        // GET: peliculas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: peliculas/Delete/5
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
