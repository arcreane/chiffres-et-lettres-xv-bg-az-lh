using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChiffresEtLettres.Controllers
{
    public class ChiffresController : Controller
    {
        // GET: ChiffresController
        public ActionResult Chiffre()
        {
            Chiffres NouveauChiffre = new Chiffres();
            string listNombre ="";
            foreach (var item in NouveauChiffre.listChiffre)
            {
                listNombre += item + ",";
            }

            ViewBag.ListChiffre = listNombre;
            ViewBag.NombreACalc = NouveauChiffre.ChiffreACalc;
            return View();
        }

        // GET: ChiffresController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ChiffresController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChiffresController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ChiffresController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ChiffresController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ChiffresController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ChiffresController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
