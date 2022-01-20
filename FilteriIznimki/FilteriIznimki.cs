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

        public const string NedozvoljeniBroj = "Nije moguće odrediti logaritam negativnog broja ili nule";
        public const string FormatIspisa = "Logaritam broja {0} po bazi {1} = {2}";
        public const string FormatPogreške = "Nedozvoljena vrijednost parametra {0}: {1}";

        public static void IspišiLogaritamBroja(double broj, double baza)
        {
            // 050 Pokrenuti program i provjeriti ispis.
            // 051 Dodati blok hvatanja s filtrom koji će hvatati ArgumentOutOfRangeException samo za broj <= 0 i u tom slučaju ispisati gornju poruku NedozvoljeniBroj.
            try
            {
                Console.WriteLine(FormatIspisa, broj, baza, Math.Logaritam(broj, baza));
            }
            catch (ArgumentOutOfRangeException e) when (broj < 0)
            {
                Console.WriteLine(NedozvoljeniBroj);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(FormatPogreške, e.ParamName, e.ActualValue);
            }
        }

        // 052 Pokrenuti program i provjeriti ispis.
        // 053 Pokrenuti i provjeriti testove (3 testa iz grupe "FiltriranjeIznimkiPredikatom" moraju proći)

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            IspišiLogaritamBroja(100, 10);
            IspišiLogaritamBroja(-100, 10);
            IspišiLogaritamBroja(100, -10);

            Console.WriteLine("GOTOVO!!!");
            Console.ReadKey(false);
        }
    }
}
