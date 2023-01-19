namespace Vsite.CSharp.Iznimke
{
    class OdvajanjeGlavneLogike
    {
        public static void IspisPovrh(int prvi, int zadnji)
        {
            // :020 Pokrenuti program i provjeriti što će se dogoditi.
            // :021 Donje petlje obuhvatiti try-catch blokom koji će prekinuti daljnje računanje kada bude bačena iznimka. Unutar bloka hvatanja ispisati poruku o pogrešci.
            try 
            {
                for (int n = prvi; n < zadnji; ++n)
                {
                    for (int k = 1; k <= n; ++k)
                    {
                        // pozivamo funkciju Povrh definiranu u projektu BacanjeIznimke
                        Console.WriteLine($"{n} povrh {k} = {Math.Povrh(n, k)}");
                    }
                }
            }
            catch (ArgumentOutOfRangeException e) 
            {
                Console.WriteLine(e.Message);
            }
        }

        // :022 Pokrenuti program i provjeriti ispis.
        // :023 Pokrenuti i provjeriti testove (test u grupi "OdvajanjaGlavneLogike" mora proći)

        static void Main(string[] args)
        {
            IspisPovrh(1, 20);

            Console.WriteLine("\nGOTOVO!!!");
        }
    }
}
