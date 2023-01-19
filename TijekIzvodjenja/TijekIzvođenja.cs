namespace Vsite.CSharp.Iznimke
{
    // ispis tijeka izvođenja try-catch-finally bloka
    class TijekIzvođenja
    {
        public const string ZapočinjeBlokTry = "Blok try - početak";
        public const string ZavršavaBlokTry = "Blok try - kraj";
        public const string BlokCatch = "Blok catch";
        public const string BlokFinally = "Blok finally";

        public static void IspisTryCatchFinally(int djeljenik, int djeljitelj)
        {
            // :030 Donje naredbu umetnuti u try-blok te dodati catch blok za hvatanje iznimke u slučaju dijeljenja s 0 i finally blok. 
            // :031 Dodati kontrolne ispise gornjih poruka u svaki od tih blokova.
            // :032 Pokrenuti program i provjeriti što će se ispisati.

            try 
            {
                Console.WriteLine(ZapočinjeBlokTry);
                Console.WriteLine($"{djeljenik} dijelim s {djeljitelj}");
                Console.WriteLine(djeljenik / djeljitelj);
                Console.WriteLine($"{djeljenik} sam podijelio s {djeljitelj}");
                Console.WriteLine(ZavršavaBlokTry);
            } 
            catch (DivideByZeroException e) 
            {
                Console.WriteLine(BlokCatch);
            }
            finally { Console.WriteLine(BlokFinally); }

        }

        // :033 Pokrenuti i provjeriti rezultate testova (2 testa iz grupe "TijekIzvođenja" moraju proći).

        static void Main(string[] args)
        {
            int[] djeljitelji = new int[] { 1, 2, 0 };

            for (int i = 0; i < djeljitelji.Length; ++i)
            {
                IspisTryCatchFinally(3, djeljitelji[i]);

                Console.WriteLine();
            }

            Console.WriteLine("\nGOTOVO!!!");
        }
    }
}
