using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vsite.CSharp.Iznimke
{
    class FilteriIznimki
    {
        public static class Math
        {
            public static double Logaritam(double broj, double baza)
            {
                if (broj < 0)
                    throw new ArgumentOutOfRangeException(nameof(broj), broj, "Broj mora biti veći ili jednak 0.");
                if (baza <= 0)
                    throw new ArgumentOutOfRangeException(nameof(baza), baza, "Baza mora biti veća od 0.");
                return System.Math.Log(broj, baza);
            }
        }


        public const string NedozvoljeniBroj = "Nedozvoljeni broj";

        public const string FormatIspisa = "Logaritam broja {0} po bazi {1} = {2}";

        public static void IspišiLogaritamBroja(double broj, double baza)
        {
            // ++TODO:050 Proširiti blok hvatanja filtrom koji će hvatati iznimku samo za broj <= 0 (ali ne i bazu) i u tom slučaju ispisati gornju poruku NedozvoljeniBroj.
            try
            {
                Console.WriteLine(FormatIspisa, broj, baza, Math.Logaritam(broj, baza));
            }
            catch (ArgumentOutOfRangeException e) when(e.ParamName=="broj")
            {
                Console.WriteLine(NedozvoljeniBroj);
            }
        }

        // ++TODO:051 Pokrenuti program i provjeriti ispis.
        // ++TODO:052 Pokrenuti i provjeriti testove (3 testa iz grupe "FiltriranjeIznimkiPredikatom" moraju proći)

        static void Main(string[] args)
        {
            try
            {
                IspišiLogaritamBroja(100, 10);
                IspišiLogaritamBroja(-100, 10);
                IspišiLogaritamBroja(100, -10);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine($"*** Nedozvoljeni argument: {e.ParamName}={e.ActualValue} ***");
                Console.WriteLine(e);
            }

            Console.WriteLine("GOTOVO!!!");
            Console.ReadKey(false);
        }
    }
}
