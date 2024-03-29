﻿namespace Vsite.CSharp.Iznimke
{
    public static class Math
    {
        public static int Faktorjel(int broj)
        {
            // TODO:003 Dodati u metodu provjeru je li argument manji od 0 i u tom slučaju baciti iznimku tipa ArgumentOutOfRangeException s porukom: "Argument ne smije biti negativni broj"
            // TODO:004 Pokrenuti program i provjeriti što će se dogoditi.
            int rezultat = 1;
            for (int i = 2; i <= broj; ++i)
                rezultat *= i;
            return rezultat;
        }
        // ova funkcija se koristi kasnije
        public static int Povrh(int n, int k)
        {
            return Faktorjel(n) / (Faktorjel(k) * Faktorjel(n - k));
        }
    }

    static class BacanjeIznimke
    {
        static void IspišiFaktorjel(int n)
        {
            Console.WriteLine($"{n}! = {Math.Faktorjel(n)}");
        }

        static void Main()
        {
            // TODO:000 Pokrenuti program i provjeriti ispravnost ispisanih rezultata.
            // TODO:001 Provjeriti u postavkama projekta (Properties-Build-Advanced) da se radi provjera na brojčani preljev (tj. da je uključena opcija "check for arithmetic overflow/underflow").
            // Provjeriti opciju i za Debug i za Release!
            // TODO:002 Pokrenuti program i provjeriti ispravnost ispisanih rezultata prije bacanja iznimke.

            // TODO:005 Donje pozive funkcije Faktorjel staviti u blok try i iza njega hvatati iznimke tipa ArgumentOutOfRangeException.
            // TODO:006 U bloku catch ispisati neka interesantna svojstva klase ArgumentOutOfRangeException.
            // TODO:007 Provjeriti vraćaju li nakon promjena donji pozivi metode očekivane rezultate.

            IspišiFaktorjel(0); // trebalo bi ispisati: 0! = 1
            IspišiFaktorjel(3); // trebalo bi ispisati: 3! = 6
            IspišiFaktorjel(5); // trebalo bi ispisati: 5! = 120
            IspišiFaktorjel(-1); // trebalo bi baciti iznimku!
            IspišiFaktorjel(17); // trebalo bi baciti iznimku zbog preljeva!

            // TODO:008 Pokrenuti testove (svi testovi u grupi "BacanjeIznimke" moraju proći)

            Console.WriteLine("\nGOTOVO!!!");
        }
    }
}
