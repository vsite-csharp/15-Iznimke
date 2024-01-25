namespace Vsite.CSharp.Iznimke
{
    static class VišestrukiBlokoviCatch
    {
        public const string FormatBlokaException = "Blok Exception: {0}";
        public const string FormatBlokaArgumentException = "Blok ArgumentException: {0}";
        public const string FormatBlokaArgumentOutOfRangeException = "Blok ArgumentOutOfRangeException: {0}";

        public static void HvatanjeIznimkePremaTipu(Exception iznimka)
        {
            try
            {
                throw iznimka;
            }
            // DID_IT:040 Složiti niz blokova catch tipa Exception, ArgumentOutOfRangeException i ArgumentException.
            // DID_IT:041 U blokove catch dodati ispise koristeći gornje formate te provjeriti koja će iznimka biti uhvaćena u kojem bloku.
            // https://docs.microsoft.com/en-us/dotnet/api/system.exception
            // https://docs.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception
            // https://docs.microsoft.com/en-us/dotnet/api/system.argumentexception
            catch (ArgumentOutOfRangeException aor)
            {
                Console.WriteLine(FormatBlokaArgumentOutOfRangeException, aor.GetType().Name);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(FormatBlokaArgumentException, ae.GetType().Name);
            }
            catch (Exception e)
            {
                Console.WriteLine(FormatBlokaException, e.GetType().Name);
            }
            Console.WriteLine();
        }

        // DID_IT:042 Pokrenuti program i provjeriti ispise.
        // DID_IT:043 Pokrenuti i provjeriti testove (4 testa u grupi "VišestrukiBlokoviCatch" moraju proći).

        static void Main()
        {
            // u petlji bacamo različite tipove iznimki i pratimo tko će ih uhvatiti
            // https://docs.microsoft.com/en-us/dotnet/api/system.io.filenotfoundexception
            // https://docs.microsoft.com/en-us/dotnet/api/system.argumentnullexception
            var iznimke = new List<Exception>
            {
                new FileNotFoundException(), new ArgumentOutOfRangeException(),
                new ArgumentException(), new ArgumentNullException()
            };

            foreach (var iznimka in iznimke)
            {
                HvatanjeIznimkePremaTipu(iznimka);
            }

            Console.WriteLine("\nGOTOVO!!!");
        }
    }
}
