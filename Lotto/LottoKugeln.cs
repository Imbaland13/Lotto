using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lotto
{
    internal class LottoKugeln
    {
        int zahl;       
        public int Zahl { set; get; }
        public List<int> list { set; get; }
        public List<int> Spiel()
        {
            List<int> list = new List<int>();
            Random rng = new Random();
            for (int i = 0; i < 6; i++)
            {
                zahl =  rng.Next(1, 50);
                if (list.Contains(zahl))
                {
                    i--;
                }
                else
                {
                    list.Add(zahl);
                }
            }
            foreach (var item in list)
            {
                Console.Write(item + " ");               
            }
            Console.WriteLine();
            Console.WriteLine("==================================================");
            return list;
        }
    }
}
