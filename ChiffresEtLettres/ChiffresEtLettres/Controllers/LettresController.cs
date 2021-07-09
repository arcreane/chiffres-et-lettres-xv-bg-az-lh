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

            ViewBag.Consonne = NbreConsonne;
            ViewBag.Voyelle = NbreVoyelle;

            Lettres m_lettre = new Lettres(NbreVoyelle, NbreConsonne);

            ViewBag.Proposition = m_lettre.genererTabLettres();

            return View();
        }

        public ActionResult Confirm()
        {
            string MotEntrer = Request.QueryString.Value.Substring(11).ToString().ToLower();

            ViewBag.Enter = MotEntrer;

            string[] Alphabet = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O",
            "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};

            return View();
        }
    }
}
