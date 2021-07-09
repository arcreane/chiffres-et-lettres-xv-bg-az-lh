using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChiffresEtLettres.Controllers
{
    public class LettresController : Controller
    {
        // GET: LettresController
        public ActionResult Index()
        {
            return RedirectToAction("Voyelle");
        }

        public ActionResult Voyelle()
        {
            return View();
        }

        public ActionResult Enter()
        {
            int NbreVoyelle = Int32.Parse(Request.QueryString.Value.Substring(13).ToString());

            int NbreConsonne = 10 - NbreVoyelle;

            //ViewBag.Consonne = NbreConsonne;
            //ViewBag.Voyelle = NbreVoyelle;

            Lettres m_lettre = new Lettres(NbreVoyelle, NbreConsonne);

            return View();
        }

        public ActionResult Confirm()
        {
            string MotEntrer = Request.QueryString.Value.Substring(11).ToString().ToLower();

            

            return View();
        }
    }
}
