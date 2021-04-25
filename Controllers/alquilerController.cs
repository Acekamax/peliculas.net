using peliculas.Models.alquiler;
using peliculas.Models.cliente;
using peliculas.Models.peliculas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace peliculas.Controllers
{
    public class alquilerController : Controller
    {
        // GET: alquiler
        public ActionResult Index()
        {
            alquiler alqui = new alquiler();
            List<alquiler> lista = alqui.consultar_alquiler();
            ViewBag.lista_alquiler = lista;
            return View();
        }

        // GET: alquiler/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: alquiler/Create
        public ActionResult Create(int id)
        {
            cliente cli = new cliente();
            pelicula peli = new pelicula();
            List<cliente> lista = cli.consultar_clientes();
            List<pelicula> lista1 = peli.consultar_pelicula();
            List<SelectListItem> lista2 = new List<SelectListItem> { };
            List<SelectListItem> lista3 = new List<SelectListItem> { };
            foreach (var item in lista) {
                lista2.Add(new SelectListItem { Text=item.nombre,Value=item.id.ToString()});
            }
            foreach (var item in lista1)
            {
                if (item.id==id) { 
                    lista3.Add(new SelectListItem { Text = item.nombre_pelicula, Value = item.id.ToString(),Selected=true });
                }
                else {
                    lista3.Add(new SelectListItem { Text = item.nombre_pelicula, Value = item.id.ToString() });
                }
                
                
            }
            
            ViewBag.lista_clientes = lista2;
            ViewBag.lista_peliculas = lista3;
            return View();
        }

        // POST: alquiler/Create
        [HttpPost]
        public ActionResult Create(alquiler alq)
        {
            try
            {
                // TODO: Add insert logic here
                alq.crearalquiler(alq);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: alquiler/Edit/5
        

        // POST: alquiler/Edit/5
        public ActionResult Edit(int id)
        {
            
            try
            {
                alquiler alqui = new alquiler();
                alqui.editaralquiler(id);
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: alquiler/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: alquiler/Delete/5
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
