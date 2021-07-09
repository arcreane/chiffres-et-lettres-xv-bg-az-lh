using ChiffresEtLettres.Properties;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
            int NbreVoyelle = Int32.Parse(HttpContext.Request.Query["NbreVoyelle"].ToString());

            int NbreConsonne = 10 - NbreVoyelle;

            ViewBag.Consonne = NbreConsonne;
            ViewBag.Voyelle = NbreVoyelle;

            Lettres m_lettre = new Lettres(NbreVoyelle, NbreConsonne);

            ViewBag.Proposition = m_lettre.genererTabLettres();

            return View();
        }

        //[HttpPost]
        //public ActionResult Enter()
        //{
        //    return View();
        //}



        public ActionResult Confirm()
        {
            string ChaineMot = HttpContext.Request.Query["Lettre"].ToString().Replace(",", "");

            List<char> ChaineLettre = ChaineMot.ToList();

            ViewBag.Enter = ChaineLettre;

            string MotUtilisateur = HttpContext.Request.Query["MotEntrer"].ToString();

            List<char> ChaineMotsUtilisateur = MotUtilisateur.ToList();

            ViewBag.Mot = MotUtilisateur;

            //for (int i = 0; i < ChaineMotsUtilisateur.Count; i++)
            //{
            //    for (int j = 0; j < ChaineLettre.Count; j++)
            //    {
            //        if (ChaineMotsUtilisateur[i] == ChaineLettre[j])
            //        {
            //            // Remplacement si la lettre est utiliser
            //            ChaineLettre.RemoveAt(j);
            //            break;
            //        }
            //        return RedirectToAction("Defaite");
            //    }
            //}

            int flag;

            for (int i = 0; i < ChaineMotsUtilisateur.Count; i++)
            {
                flag = 0;
                for (int j = 0; j < ChaineLettre.Count; j++)
                {
                    if (ChaineMotsUtilisateur[i] == ChaineLettre[j])
                    {
                        // Remplacement si la lettre est utiliser
                        ChaineLettre.RemoveAt(j);
                        flag = 1;
                    }
                }
                if (flag == 0)
                {
                    return RedirectToAction("Defaite");
                }
            }

            var Dictionnaire = Resources.liste_francais.Split("\r\n");

            foreach (var item in Dictionnaire)
            {
                if (item.Contains(MotUtilisateur))
                {
                    return RedirectToAction("Victoire");
                }
            }

            return RedirectToAction("Defaite");
        }


        public ActionResult Victoire()
        {
            return View();
        }

        public ActionResult Defaite()
        {
            return View();
        }
    }
}
