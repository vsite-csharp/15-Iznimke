using System;
using System.Collections.Generic;
using System.Text;

namespace Vsite.CSharp.Iznimke
{
    // Primjer definiranja obrade UnhandledException događaja
    // Ovo omogućava da zapišemo sve neuhvaćene iznimke (npr. 
    // u log datoteku), no program će još uvijek imati
    // unhandled exception!
    class RukovateljNeobrađenihIznimki
    {
        public static void Main()
        {
            // TODO:070 Odkomentirati donju naredbu te događaju UnhandledException pridružiti rukovatelja koji će ispisati podatke o neuhvaćenoj iznimci te pozvati Console.ReadKey() da privremeno zaustavi izvođenje. Pokrenuti program i provjeriti ponašanje.
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            try
            {
                throw new Exception("1");
            }
            catch (Exception e)
            {
                Console.WriteLine("Uhvaćena iznimka: " + e.Message);
            }
            throw new Exception("2");
           
        }
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine(e.ExceptionObject);
            Console.ReadKey();
        }
    }
}
