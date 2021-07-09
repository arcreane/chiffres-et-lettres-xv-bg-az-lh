using ChiffresEtLettres.Properties;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChiffresEtLettres
{
    public class Lettres
    {
        private int nbVoyelle;
        private int nbConsonne;

        public List<char> lVoyelle = new List<char> { 'a', 'e', 'i', 'o', 'u', 'y' };
        public List<char> lConsonne = new List<char> { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'z' };

        public Lettres(int _voyelle, int _consonne)
        {
            nbVoyelle = _voyelle;
            nbConsonne = _consonne;
            var toto = Resources.liste_francais.Split("\r\n");
        }

        public List<char> genererTabLettres()
        {
            Random rand = new Random();
            List<char> lMot = new List<char> { };

            for (int i = 0; i < nbVoyelle; i++)
            {
                int vRand = rand.Next(lVoyelle.Count);
                lMot.Add(lVoyelle[vRand]);
            }

            for (int i = 0; i < nbConsonne; i++)
            {
                int cRand = rand.Next(lConsonne.Count);
                lMot.Add(lConsonne[cRand]);
            }

            Debug.WriteLine("liste : "+lMot);

            return lMot;

        }

    }


}
