using System;
using System.Diagnostics;

namespace Vsite.CSharp.Iznimke
{
    // Pogledati što rade donje dvije metode.
    class EfikasnostIznimke
    {
        public static bool DodajBezIznimke(ref int broj)
        {
            ++broj;
            return broj % 100 != 0;
        }

        public static bool DodajSIznimkom(ref int broj)
        {
            ++broj;
            if (broj % 100 == 0)
                throw new Exception();
            return true;
        }

        private delegate bool Funkcija(ref int broj);

        // Pogledati što radi metoda Petlja i kako se poziva u metodi Main.
        static (int brojIznimnih, int brojRegularnih) Petlja(Funkcija f, int n)
        {
            int zbroj = 0;
            int brojRegularnih = 0;
            int brojIznimki = 0;

            for (int i = 0; i < n; ++i)
            {
                try
                {
                    f(ref zbroj);
                    ++brojRegularnih;
                }
                catch (Exception)
                {
                    ++brojIznimki;
                }
            }
            return (brojIznimki, brojRegularnih);
        }

        // Pokrenuti program i usporediti vremena izvođenja oba poziva metode Petlja.
        // Pokrenuti program "Start without Debugging" (Ctrl + F5) i ponovno usporediti vremena.
        static void Main(string[] args)
        {
            const int brojPonavljanja = 100000;
            // Početni dio koji poziva sve metode da aktivira JIT na njima.
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Petlja(DodajBezIznimke, 1);
            sw.Restart();
            Petlja(DodajSIznimkom, 1);
            sw.Stop();
            Console.WriteLine(sw.ElapsedTicks);

            int brojIznimki = 0;
            int brojRegularnih = 0;

            Console.WriteLine("*** DodajBezIznimke ***");
            sw.Restart();
            (brojIznimki, brojRegularnih) = Petlja(DodajBezIznimke, brojPonavljanja);
            sw.Stop();

            Console.WriteLine(sw.ElapsedTicks);
            Console.WriteLine($"Broj iznimki: {brojIznimki}, broj regularnih: {brojRegularnih}");
            Console.WriteLine();

            Console.WriteLine("*** DodajSIznimkom ***");
            sw.Restart();
            (brojIznimki, brojRegularnih) = Petlja(DodajSIznimkom, brojPonavljanja);
            sw.Stop();

            Console.WriteLine(sw.ElapsedTicks);
            Console.WriteLine($"Broj iznimki: {brojIznimki}, broj regularnih: {brojRegularnih}");
            Console.WriteLine();

            Console.WriteLine("GOTOVO!!!");
            Console.ReadKey(false);
        }
    }
}
