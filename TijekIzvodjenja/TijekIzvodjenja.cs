using System;

namespace Vsite.CSharp.Iznimke
{
    // ispis tijeka izvođenja try-catch-finally bloka
    class TijekIzvodjenja
    {
        public const string ZapočinjeBlokTry = "Blok try - početak";
        public const string ZavršavaBlokTry = "Blok try - kraj";
        public const string BlokCatch = "Blok catch";
        public const string BlokFinally = "Blok finally";

        public static void IspisTryCatchFinally(int djeljenjik, int djeljitelj)
        {
            // Donje naredbu umetnuti u try-blok te dodati catch blok za hvatanje iznimke u slučaju dijeljenja s 0 i finally blok. 
            // Dodati kontrolne ispise gornjih poruka u svaki od tih blokova.
            // Pokrenuti program i provjeriti što će se ispisati.
            try
            {
                Console.WriteLine(ZapočinjeBlokTry);

                Console.WriteLine($"{djeljenjik} dijelim s {djeljitelj}");
                Console.WriteLine(djeljenjik / djeljitelj);
                Console.WriteLine($"{djeljenjik} sam podijelio s {djeljitelj}");

                Console.WriteLine(ZavršavaBlokTry);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(BlokCatch);

                //Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine(BlokFinally);
            }

        }

        // Pokrenuti i provjeriti rezultate testova (2 testa iz grupe "TijekIzvođenja" moraju proći).

        static void Main(string[] args)
        {
            int[] djeljitelji = new int[] { 1, 2, 0 };

            for (int i = 0; i < djeljitelji.Length; ++i)
            {
                IspisTryCatchFinally(3, djeljitelji[i]);

                Console.WriteLine();
            }

            Console.WriteLine("GOTOVO!!!");
            Console.ReadKey(false);
        }
    }
}
