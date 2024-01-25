using System.Text;

namespace Vsite.CSharp.Iznimke
{
    // Primjer definiranja obrade UnhandledException događaja.To omogućava da registriramo neuhvaćenu iznimku (npr. 
    // zapišemo ju u datoteku), no program će i nakon toga prekinuti izvođenje s neobrađenom iznimkom!
    static class RukovateljNeobrađenihIznimki
    {
        public const string NeuhvaćenaIznimka = "Neuhvaćena iznimka: {0}";

        private static void EvidentirajNeuhvaćenuIznimku(UnhandledExceptionEventArgs e)
        {
            Console.Error.WriteLine(NeuhvaćenaIznimka, e.ExceptionObject.GetType());

            using (StreamWriter sw = new StreamWriter("NeuhvaćenaIznimka.txt"))
            {
                sw.WriteLine(NeuhvaćenaIznimka, e.ExceptionObject.GetType());
            }
        }

        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            // 070 Pogledati što program radi, pokrenuti ga bez Debuggiranja (Ctrl + F5) i provjeriti ispis.
            // 071 Odkomentirati donju naredbu te događaju UnhandledException pridružiti rukovatelja (handlera) koji će pozvati gornju metodu ZapišiNeuhvaćenuIznimku.
            //          Pokrenuti program i provjeriti rezultat.
            // 072 Provjeriti prolazi li test RukovateljNeobrađenihIznimki.
            AppDomain.CurrentDomain.UnhandledException += ZapisiNeuhvaćenuIznimku;
            Exception[] iznimke = { new ArgumentOutOfRangeException(), new ArgumentNullException(), new DivideByZeroException() };

            foreach (var iznimka in iznimke)
            {
                try
                {
                    if (iznimka != null)
                        throw iznimka;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Uhvaćena iznimka: {e.GetType()}");
                }
            }

            Console.WriteLine("\nGOTOVO!!!");
        }

        public static void ZapisiNeuhvaćenuIznimku(object sender,  UnhandledExceptionEventArgs e)
        {
            EvidentirajNeuhvaćenuIznimku(e);
        }
    }
}
