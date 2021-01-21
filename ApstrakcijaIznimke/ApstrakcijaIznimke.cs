using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vsite.CSharp.Iznimke
{
    class ApstrakcijaIznimke
    {
        static void Main(string[] args)
        {
            // Provjeriti koju iznimku će baciti metoda Faktorjel u donjem kodu.
            //  Promijeniti implementaciju metode Faktorjel tako da za slučaj preljeva baca iznimku tipa ArgumentOutOfRangeException s imenom parametra i vrijednošću argumenta.
            // Pokrenuti program i provjeriti tijek izvođenja

            try
            {
                Math.Faktorjel(30);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine($"Parametar '{e.ParamName}' ima nedozvoljenu vrijednost {e.ActualValue}");
                Console.WriteLine(e);
            }

            // Pokrenuti i provjeriti testove (test u grupi "ApstrakcijeIznimke" mora proći)

            Console.WriteLine("GOTOVO!!!");
            Console.ReadKey(false);
        }
    }
}
