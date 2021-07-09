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

        public string CalculeFormule(string p_CalcUser)
        {
            string[] elemCalc = { "(,),+,-,*,/" };
             while (elemCalc.Any(p_CalcUser.Contains))
            {
                if (p_CalcUser.Contains("("))
                {
                   p_CalcUser = TraitementPar(p_CalcUser);
                }
                else if (p_CalcUser.Contains("*") || p_CalcUser.Contains("/"))
                {
                    p_CalcUser = TraitementProduit(p_CalcUser);
                }
                else
                {
                    p_CalcUser = TraitementSomme(p_CalcUser);
                    return p_CalcUser;
                }
            }

            return p_CalcUser;
        }

        private string TraitementSomme(string p_CalcUser)
        {
            string[] elemCalc = { "+,-" };
            while (elemCalc.Any(p_CalcUser.Contains))
            {
                

            }
        }

        private string TraitementProduit(string p_CalcUser)
        {
            throw new NotImplementedException();
        }

        private string TraitementPar(string p_CalcPar)
        {
            int premièrePar = p_CalcPar.IndexOf("(");
            int DeuxiemePar = p_CalcPar.IndexOf(")");
            int internPar = p_CalcPar.IndexOf("(", premièrePar + 1);
            while (DeuxiemePar > internPar && internPar != -1)
            {
                DeuxiemePar = p_CalcPar.IndexOf(")", DeuxiemePar+1);
                internPar = p_CalcPar.IndexOf("(", internPar + 1);
            }

            string ChaineACalcule = p_CalcPar.Substring(premièrePar+1, DeuxiemePar - premièrePar);
            string ChaineCalcule = CalculeFormule(ChaineACalcule);

            return p_CalcPar.Replace(ChaineACalcule, ChaineCalcule);


        }

        public void MauvaitCalcul()
        {

        }
    }
}
