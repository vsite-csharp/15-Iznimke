using System;
using System.IO;

namespace Vsite.CSharp.Iznimke
{
    class VišestrukiBlokoviCatch
    {
        public const string FormatFiltraException = "Filtar Exception: {0}";
        public const string FormatFiltraArgumentException = "Filtar ArgumentException: {0}";
        public const string FormatFiltraArgumentOutOfRangeException = "Filtar ArgumentOutOfRangeException: {0}";

        public static void HvatanjeIznimkePremaTipu(Exception iznimka)
        {
            try
            {
                throw iznimka;
            }
            // Složiti niz blokova catch tipa Exception, ArgumentOutOfRangeException i ArgumentException, dodati ispise koristeći gornje formate te provjeriti koja će iznimka biti uhvaćena u kojem bloku.
            // https://docs.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(FormatFiltraArgumentOutOfRangeException, e.GetType().Name);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(FormatFiltraArgumentException, e.GetType().Name);
            }
            catch (Exception e)
            {
                Console.WriteLine(FormatFiltraException, e.GetType().Name);
            }
                Console.WriteLine();
        }

        // Pokrenuti program i provjeriti ispise.
        // Pokrenuti i provjeriti testove (4 testa u grupi "VišestrukiBlokoviCatch" moraju proći)

        static void Main(string[] args)
        {
            // u petlji bacamo različite tipove iznimki i pratimo tko će ih uhvatiti
            Exception[] iznimke = new Exception[]
            {
                new FileNotFoundException(), new ArgumentOutOfRangeException(),
                new ArgumentException(), new ArgumentNullException()
            };

            for (int i = 0; i < iznimke.Length; ++i)
            {
                HvatanjeIznimkePremaTipu(iznimke[i]);
            }

            Console.WriteLine("GOTOVO!!!");
            Console.ReadKey(false);
        }
    }
}
