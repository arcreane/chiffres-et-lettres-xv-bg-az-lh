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

        // Vue : Voyelle
        public ActionResult Voyelle()
        {
            return View();
        }

        // Vue : Enter
        public ActionResult Enter()
        {
            // Transformation String en Int
            int NbreVoyelle = Int32.Parse(HttpContext.Request.Query["NbreVoyelle"].ToString());

            // Generation des consonne
            int NbreConsonne = 10 - NbreVoyelle;

            // Création d'un tableau de lettre
            Lettres m_lettre = new Lettres(NbreVoyelle, NbreConsonne);

            // Génénration d'un tableau de lettre aleatoire
            ViewBag.Proposition = m_lettre.genererTabLettres();

            return View();
        }

        public ActionResult Confirm()
        {
            // Récuperation du tableau de lettre générer aléatoirement
            string ChaineMot = HttpContext.Request.Query["Lettre"].ToString().Replace(",", "");

            List<char> ChaineLettre = ChaineMot.ToList();

            ViewBag.Enter = ChaineLettre;

            // Récuperation du mot entrer par l'utilisateur
            string MotUtilisateur = HttpContext.Request.Query["MotEntrer"].ToString();

            List<char> ChaineMotsUtilisateur = MotUtilisateur.ToList();

            ViewBag.Mot = MotUtilisateur;


            // Verification de la fideliter du mot par apport au lettre donner aléatoirement
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
                    // Retour Défaite
                    return RedirectToAction("Defaite");
                }
            }

            // Verification de la fideliter du mot par apport au dictionnaire français
            var Dictionnaire = Resources.liste_francais.Split("\r\n");

            foreach (var item in Dictionnaire)
            {
                if (item.Contains(MotUtilisateur))
                {
                    // Retour Victoire
                    return RedirectToAction("Victoire");
                }
            }

            // Retour Défaite
            return RedirectToAction("Defaite");
        }

        // Victoire
        public ActionResult Victoire()
        {
            return View();
        }

        // Défaite
        public ActionResult Defaite()
        {
            return View();
        }
    }
}
