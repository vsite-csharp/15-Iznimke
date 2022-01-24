﻿using System;
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
        public const string FormatPogreške = "Nedozvoljena vrijednost parametra '{0}': {1}";

        public static void IspišiLogaritamBroja1(double broj, double baza)
        {
            // Pokrenuti program i provjeriti ispis.
            // Dodati blok hvatanja s filtrom koji će hvatati ArgumentOutOfRangeException samo za broj <= 0 i u tom slučaju ispisati gornju poruku NedozvoljeniBroj.

            // Pokrenuti program i provjeriti ispis.
            // Donji ispis staviti u blok pokušaja te dodati blok koji će hvatati iznimku tipa ArgumentOutOfRangeException.
            //          Unutar bloka provjeriti je li broj <= 0 i u tom slučaju ispisati poruku NedozvoljeniBroj a u protivnom ponovno baciti iznimku.
            // Postaviti točku prekida (breakpoint) u blok hvatanja i pratiti izvođenje naredbi u tom bloku nakon pokretanja programa.
            // Dodati bloku hvatanja filter koji će hvatati ArgumentOutOfRangeException samo za broj <= 0 te maknuti ispitivanje unutar bloka (ostaviti samo naredbu za ispis).
            // Provjeriti tijek izvođenja programa u slučaju bačene iznimke.
            Console.WriteLine(FormatIspisa, broj, baza, Math.Logaritam(broj, baza));
        }

        public static void IspišiLogaritamBroja2(double broj, double baza)
        {
            try
            {
                IspišiLogaritamBroja1(broj, baza);
            }
            catch (ArgumentOutOfRangeException e) when (broj <= 0)
            {
                Console.WriteLine(NedozvoljeniBroj, e.ParamName, e.ActualValue);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(FormatPogreške, e.ParamName, e.ActualValue);
            }
        }

        // Pokrenuti program i provjeriti ispis.
        // Pokrenuti i provjeriti testove (3 testa iz grupe "FiltriranjeIznimkiPredikatom" moraju proći)


        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            IspišiLogaritamBroja2(100, 10);
            IspišiLogaritamBroja2(-100, 10);
            IspišiLogaritamBroja2(100, -10);

            Console.WriteLine("GOTOVO!!!");
            Console.ReadKey(false);
        }
    }
}
