using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChiffresEtLettres
{
    public class Chiffres
    {
        public List<int> listChiffre { get; set; }
        public int ChiffreACalc { get; set; }

        private int[] ChiffreDispo = { 1,2,3,4,5,6,7,8,9,10,25,50,75,100 };
        public Chiffres()
        {
            listChiffre = new List<int>();
            Random rand = new Random();
            for (int i = 0; i < 7; i++)
            {
                listChiffre.Add(ChiffreDispo[rand.Next(0, ChiffreDispo.Length)]);
            }
            ChiffreACalc = rand.Next(101, 1000);
        }


    }
}
