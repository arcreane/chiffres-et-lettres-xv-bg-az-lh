using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChiffresEtLettres.Controllers
{
    public class ChiffresController : Controller
    {
        Chiffres NouveauChiffre = new Chiffres();
        public ActionResult Index()
        {
            //NouveauChiffre = new Chiffres();
            string listNombre = "";
            foreach (var item in NouveauChiffre.listChiffre)
            {
                listNombre += item + ",";
            }

            ViewBag.ListChiffre = listNombre;
            ViewBag.NombreACalc = NouveauChiffre.ChiffreACalc;
            return View();
        }
        public void VerifCalc(string CalcUser)
        {
            List<int> sauvPourVerif = new List<int>();
            sauvPourVerif = NouveauChiffre.listChiffre;
            string[] test = { "+", "*", "-", "/" };
            string[] ChiffreUsers = Regex.Split(CalcUser, @"\D+");
            foreach (var item in ChiffreUsers)
            {
                if (sauvPourVerif.Contains(int.Parse(item)))
                {
                    sauvPourVerif.Remove(int.Parse(item));
                }
                else
                {
                    // traitement car l'utilisateur a utiliser un nombre non données par le programme
                    MauvaitCalcul();
                }

            }
            // Traitement quand l'utilisateur a utilisé le nombre a sa disposition
            CalculeFormule(CalcUser);
        }

        public void CalculeFormule(string p_CalcUser)
        {
            string[] elemCalc = { "(,),+,-,*,/" };
             while (elemCalc.Any(p_CalcUser.Contains))
            {
                if (p_CalcUser.Contains("("))
                {
                    TraitementPar(p_CalcUser);
                }
            }
        }

        private void TraitementPar(string p_CalcPar)
        {
            int premièrePar = 0;
            int DeuxiemePar = 0;
            premièrePar = p_CalcPar.IndexOf("(");
            DeuxiemePar = p_CalcPar.IndexOf(")");
            while (DeuxiemePar > p_CalcPar.IndexOf("(", premièrePar) && p_CalcPar.IndexOf("(", premièrePar) != -1)
            {
                DeuxiemePar = p_CalcPar.IndexOf(")", DeuxiemePar);
            }

        }

        public void MauvaitCalcul()
        {

        }
    }
}
