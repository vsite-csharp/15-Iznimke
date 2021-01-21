using System;
using System.Diagnostics;

namespace Vsite.CSharp.Iznimke
{
    // Pogledati što rade donje dvije metode
    class EfikasnostIznimke
    {
        public static bool Dodaj1(ref int broj)
        {
            ++broj;
            return broj % 100 != 0;
        }

        public static void Dodaj1Iznimno(ref int broj)
        {
            ++broj;
            if (broj % 100 == 0)
                throw new Exception();
        }

        // Usporediti pozive metoda u donje tri petlje
        // Pokrenuti program i usporediti vremena izvođenja triju petlji
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            int zbroj = 0;
            int brojRegularnih = 0;

            sw.Start();

            for (int i = 0; i < 100000; ++i)
            {
                if (Dodaj1(ref zbroj))
                    ++brojRegularnih;
            }

            sw.Stop();
            Console.WriteLine(sw.ElapsedTicks);
            sw.Restart();

            zbroj = 0;
            brojRegularnih = 0;
            for (int i = 0; i < 100000; ++i)
            {
                try
                {
                    Dodaj1Iznimno(ref zbroj);
                    ++brojRegularnih;
                }
                catch (Exception)
                {

                }
            }

            sw.Stop();
            Console.WriteLine(sw.ElapsedTicks);
            sw.Restart();

            zbroj = 0;
            brojRegularnih = 0;
            for (int i = 0; i < 100000; ++i)
            {
                try
                {
                    Dodaj1(ref zbroj);
                    ++brojRegularnih;
                }
                catch (Exception)
                {

                }
            }

            sw.Stop();
            Console.WriteLine(sw.ElapsedTicks);

            Console.WriteLine("GOTOVO!!!");
            Console.ReadKey(false);
        }
    }
}
