using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChiffresEtLettres
{
    public class Chiffres
    {
        private int nombreAlea;
        private int nombreAlea_Un;
        private int nombreAlea_Deux;

        public Chiffres()
        {
            Random rand = new Random();
            int ChiffresRand = rand.Next(100);

            int ChiffresRand_Un = ChiffresRand / 2;
            int ChiffresRand_Deux = ChiffresRand / 2;

            nombreAlea = ChiffresRand;
        }

        public int GetNombreAlea()
        {
            return nombreAlea;
        }

        public int GetNombre_Un()
        {
            return nombreAlea_Un;
        }

        public int GetNombre_Deux()
        {
            return nombreAlea_Deux;
        }
    }
}
