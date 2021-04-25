using peliculas.Models.cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace peliculas.Controllers
{
    public class clienteController : Controller
    {
        // GET: cliente
        public ActionResult Index()
        {
            cliente cli = new cliente();
            List<cliente> lista = cli.consultar_clientes();
            ViewBag.lista_clientes = lista;
            return View();
        }

        // GET: cliente/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: cliente/Create
        [HttpPost]
        public ActionResult Create(cliente cli)
        {
            try
            {
                // TODO: Add insert logic here
                cli.crearcliente(cli);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: cliente/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: cliente/Edit/5
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

        // GET: cliente/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: cliente/Delete/5
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
