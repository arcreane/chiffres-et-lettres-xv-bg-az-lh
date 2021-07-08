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

        public List<string> lVoyelle = new List<string>('a','e','i','o','u','y' );
        public Lettres(int _voyelle, int _consonne)
        {
            voyelle = _voyelle;
            consonne = _consonne;
            var toto = Resources.liste_francais.Split("\r\n");
            
        }


    }
}
