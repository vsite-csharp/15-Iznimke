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
            // 040 Složiti niz blokova catch tipa Exception, ArgumentOutOfRangeException i ArgumentException.
            // 041 U blokove catch dodati ispise koristeći gornje formate te provjeriti koja će iznimka biti uhvaćena u kojem bloku.
            // https://docs.microsoft.com/en-us/dotnet/api/system.exception
            // https://docs.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception
            // https://docs.microsoft.com/en-us/dotnet/api/system.argumentexception
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

        // 042 Pokrenuti program i provjeriti ispise.
        // 043 Pokrenuti i provjeriti testove (4 testa u grupi "VišestrukiBlokoviCatch" moraju proći).

        static void Main(string[] args)
        {
            // u petlji bacamo različite tipove iznimki i pratimo tko će ih uhvatiti
            // https://docs.microsoft.com/en-us/dotnet/api/system.io.filenotfoundexception
            // https://docs.microsoft.com/en-us/dotnet/api/system.argumentnullexception
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
