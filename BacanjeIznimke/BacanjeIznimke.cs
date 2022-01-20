﻿using System;

namespace Vsite.CSharp.Iznimke
{
    public static class Math
    {
        public static int Faktorjel(int broj)
        {
            if (broj < 0)
                throw new ArgumentOutOfRangeException("Argument ne smije biti negativni broj");
            //  Dodati u metodu provjeru je li argument manji od 0 i u tom slučaju baciti iznimku tipa ArgumentOutOfRangeException s porukom: "Argument ne smije biti negativni broj"
            // Pokrenuti program i provjeriti što će se dogoditi.
            int rezultat = 1;
            for (int i = 2; i <= broj; ++i)
            {
                try
                {
                    rezultat *= i;
                }
                catch (OverflowException e)
                {
                    throw new ArgumentOutOfRangeException("broj", broj, "broj je prevelik");
                }
            }
                
            return rezultat;
        }
        // ova funkcija se koristi kasnije
        public static int Povrh(int n, int k)
        {
            return Faktorjel(n) / (Faktorjel(k) * Faktorjel(n - k));
        }
    }

    class BacanjeIznimke
    {
        static void IspišiFaktorjel(int n)
        {
            Console.WriteLine($"{n}! = {Math.Faktorjel(n)}");
        }

        static void Main(string[] args)
        {
            // Pokrenuti program i provjeriti ispravnost ispisanih rezultata.
            //  Provjeriti u postavkama projekta (Properties-Build-Advanced) da se radi provjera na brojčani preljev (tj. da je uključena opcija "check for arithmetic overflow/underflow").
            // Provjeriti opciju i za Debug i za Release!
            //  Pokrenuti program i provjeriti ispravnost ispisanih rezultata prije bacanja iznimke.

            //  Donje pozive funkcije Faktorjel staviti u blok try i iza njega hvatati iznimke tipa ArgumentOutOfRangeException.
            // U bloku catch ispisati neka interesantna svojstva klase ArgumentOutOfRangeException.
            //  Provjeriti vraćaju li nakon promjena donji pozivi metode očekivane rezultate.
            try
            {
                IspišiFaktorjel(0); // trebalo bi ispisati: 0! = 1
                IspišiFaktorjel(3); // trebalo bi ispisati: 3! = 6
                IspišiFaktorjel(5); // trebalo bi ispisati: 5! = 120
                IspišiFaktorjel(-1); // trebalo bi baciti iznimku!
                IspišiFaktorjel(17); // trebalo bi baciti iznimku zbog preljeva!
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e);
            }
            

            // Pokrenuti testove (svi testovi u grupi "BacanjeIznimke" moraju proći)

            Console.WriteLine("GOTOVO!!!");
            Console.ReadKey(false);
        }
    }
}
