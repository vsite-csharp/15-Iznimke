using System.Text;

namespace Vsite.CSharp.Iznimke
{
    static class KritičneIznimke
    {
        static void RekurzivniPoziv()
        {
            RekurzivniPoziv();
        }

        static void PokreniRekurziju()
        {
            for (int i = 0; i < 3; ++i)
            {
                Console.WriteLine($"Pokušaj {i}:");
                try
                {
                    RekurzivniPoziv();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Uhvatio iznimku tipa: {e.GetType()}!");
                }
            }
        }

        // Pokrenuti program i provjeriti kada će biti uhvaćena iznimka.
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            PokreniRekurziju();

            Console.WriteLine("\nGOTOVO!!!");
        }
    }
}
