using System.Text;

namespace Vsite.CSharp.Iznimke
{
    class KritičneIznimke
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

        // TODO:080 Pokrenuti program i provjeriti kada će biti uhvaćena iznimka.
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            PokreniRekurziju();

            Console.WriteLine("/nGOTOVO!!!");
        }
    }
}
