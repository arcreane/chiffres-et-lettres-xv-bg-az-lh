using ChiffresEtLettres.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChiffresEtLettres
{
    public class Lettres
    {
        private int voyelle;
        private int consonne;

        public List<char> lVoyelle = new List<char> { 'a', 'e', 'i', 'o', 'u', 'y' };
        public List<char> lConsonne = new List<char> { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'z' };

        public Lettres(int _voyelle, int _consonne)
        {
            voyelle = _voyelle;
            consonne = _consonne;
            var toto = Resources.liste_francais.Split("\r\n");
            
        }


    }
}
