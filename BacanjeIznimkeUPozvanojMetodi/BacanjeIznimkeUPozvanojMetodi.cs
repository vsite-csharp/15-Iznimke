using System;

namespace Vsite.CSharp.Iznimke
{
    // Primjer izvođenja try-catch-finally kada je iznimka
    // bačena unutar pozvane metode
    class Program
    {
        static void Main(string[] args)
        {
            // Prije izvođenja programa pokušati predvidjeti tok programa. Pokrenuti program i provjeriti ispravnost pretpostavke.
            try
            {
                Metoda1(); // 1
            }
            // Zakomentirati donji blok catch i provjeriti što će se dogoditi ponovnim pokretanjem programa.
            //catch (Exception e)
            //{
            //    Console.WriteLine("catch(Exception) u Main");
            //}
            finally
            {
                Console.WriteLine("finally u Main");
            }
            Console.WriteLine("GOTOVO!!!");
            Console.ReadKey();
        }

        static void Metoda1()
        {
            try
            {
                Metoda2(); // 2
            }
            catch (ArgumentException)
            {
                Console.WriteLine("catch(ArgumentException) u Metoda1");
            }
            // Kako bi izgledalo izvođenje programa kada bi se izostavio donji blok hvatanja? Zakomenirajte ga i pokrenite program. 
            //catch (DivideByZeroException)
            //{
            //    Console.WriteLine("catch(DivideByZeroException) u Metoda1");
            //}
            finally
            {
                Console.WriteLine("finally u Metoda1");
            }
        }

        static void Metoda2()
        {
            int a = 5;
            int b = 0;
            try
            {
                // ovdje će biti bačen DivideByZeroException!!!
                Console.WriteLine("Bacam Exception");
                Console.WriteLine(a / b);
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("catch(NotSupportedException) u Metoda2");
            }
            finally
            {
                Console.WriteLine("finally u Metoda2");
            }

            Console.WriteLine("GOTOVO!!!");
            Console.ReadKey(false);
        }
    }
}