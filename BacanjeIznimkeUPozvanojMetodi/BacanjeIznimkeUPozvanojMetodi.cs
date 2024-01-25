namespace Vsite.CSharp.Iznimke
{
    // Primjer izvođenja try-catch-finally kada je iznimka
    // bačena unutar pozvane metode
    class BacanjeIznimkeUPozvanojMetodi
    {
        static void Main()
        {
            // :060 Prije izvođenja programa pokušati predvidjeti tok programa. Pokrenuti program i provjeriti ispravnost pretpostavke.
            Metoda1(8, 3);
            Console.WriteLine();
            Metoda1(5, 0);

            Console.WriteLine("\nGOTOVO!!!");
        }

        public static void Metoda1(int djeljenik, int djeljitelj)
        {
            try
            {
                Metoda2(djeljenik, djeljitelj);
            }
            // :062 Kako bi izgledalo izvođenje programa kada bi se izostavio donji blok hvatanja? Zakomenirajte ga i pokrenite program.
            //catch (Exception e)
            //{
            //    Console.WriteLine($"catch(Exception) u Metoda1: {e.Message}");
            //}
            finally
            {
                Console.WriteLine("finally u Metoda1");
            }
        }

        static void Metoda2(int djeljenik, int djeljitelj)
        {
            try
            {
                Metoda3(djeljenik, djeljitelj);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"catch(ArgumentException) u Metoda2: {e.Message}");
            }
            // :061 Kako bi izgledalo izvođenje programa kada bi se izostavio donji blok hvatanja? Zakomenirajte ga i pokrenite program.
            //catch (DivideByZeroException)
            //{
            //    Console.WriteLine("catch(DivideByZeroException) u Metoda2");
            //}
            finally
            {
                Console.WriteLine($"finally u Metoda2");
            }
        }

        static void Metoda3(int djeljenik, int djeljitelj)
        {
            try
            {
                // ovdje može biti bačen DivideByZeroException!!!
                Console.WriteLine($"{djeljenik} / {djeljitelj} = {djeljenik / djeljitelj}");
            }
            catch (NotSupportedException)
            {
                Console.WriteLine($"catch(NotSupportedException) u Metoda3");
            }
            finally
            {
                Console.WriteLine($"finally u Metoda3");
            }
        }
    }
}
