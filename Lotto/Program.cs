using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace Lotto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LottoKugeln kugeln = new LottoKugeln();
            List<List<int>> ziehungsliste;
            ziehungsliste = Ziehungen(kugeln);
            Console.WriteLine();
            HaeufigsteZahl(ziehungsliste);
            NieGezogen(ziehungsliste);
            Console.ReadLine();
        }
        static List<List<int>> Ziehungen(LottoKugeln kugel)
        {
            List<List<int>> ziehungsliste = new List<List<int>>();
            for (int i = 0; i < 20; i++)
            {
                Thread.Sleep(3);
                ziehungsliste.Add(kugel.Spiel());
            }
            foreach (var list in ziehungsliste)
            {
                Console.WriteLine();
                Console.WriteLine("=============List In List===========");
                foreach (var number in list)
                {
                    Console.Write(number + " ");
                }
            }
            return ziehungsliste;
        }
        static List<int> HaeufigsteZahl(List<List<int>> Ziehungsliste)
        {
            int[] ergebnis = new int[50];
            int wert;
            int max = 0;
            List<int> maxwerte = new List<int>();
            foreach (List<int> list in Ziehungsliste)
            {
                foreach (int number in list)
                {
                    wert = number;
                    ergebnis[wert] += 1;
                }
            }
            Console.WriteLine();
            Console.WriteLine("Zahlenverteilung");
            for(int i = 0; i < ergebnis.Length; i++)
            {
                Console.Write($"{i} {ergebnis[i]} ");
                Console.WriteLine();
            }
            for (int i = 0;i < ergebnis.Length; i++)
            {
                if (ergebnis[i] == max)
                {
                    maxwerte.Add(i);
                }
                else if (ergebnis[i] > max)
                {
                    maxwerte.Clear();
                    maxwerte.Add(i);
                    max = ergebnis[i];
                }
            }
            Console.WriteLine("Häufigste Zahl/en:");
            foreach(int i in maxwerte)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("========================================" +
                "===========================================");
            return maxwerte;
        }
        static void NieGezogen(List<List<int>> liste)
        {
            int[] ergebnis = new int[50];
            int wert;
            foreach (List<int> list in liste)
            {
                foreach (int number in list)
                {
                    wert = number;
                    ergebnis[wert] += 1;
                }
            }
            for (int i = 1; i < 50; i++)
            {
                if (ergebnis[i] == 0)
                {
                    Console.WriteLine($"Nicht vorhandene Zahlen: {i} ");
                }
            }
        }
    }
}
