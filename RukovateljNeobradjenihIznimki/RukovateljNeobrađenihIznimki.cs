﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Vsite.CSharp.Iznimke
{
    // Primjer definiranja obrade UnhandledException događaja.To omogućava da registriramo neuhvaćenu iznimku (npr. 
    // zapišemo ju u datoteku), no program će i nakon toga prekinuti izvođenje s neobrađenom iznimkom!
    class RukovateljNeobrađenihIznimki
    {
        public const string NeuhvaćenaIznimka = "Neuhvaćena iznimka: {0}";

        private static void EvidentirajNeuhvaćenuIznimku(UnhandledExceptionEventArgs e)
        {
            // Odkomentirati donju naredbu te događaju UnhandledException pridružiti rukovatelja koji će ispisati podatke o neuhvaćenoj iznimci te pozvati Console.ReadKey() da privremeno zaustavi izvođenje. Pokrenuti program i provjeriti ponašanje.
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(Neuhvaceni);
            Console.Error.WriteLine(NeuhvaćenaIznimka, e.ExceptionObject.GetType());

            using (StreamWriter sw = new StreamWriter("NeuhvaćenaIznimka.txt"))
            {
                sw.WriteLine(NeuhvaćenaIznimka, e.ExceptionObject.GetType());
            }
        }

        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            // TODO:070 Pogledati što program radi, pokrenuti ga bez Debuggiranja (Ctrl + F5) i provjeriti ispis.
            // TODO:071 Odkomentirati donju naredbu te događaju UnhandledException pridružiti rukovatelja (handlera) koji će pozvati gornju metodu ZapišiNeuhvaćenuIznimku.
            //          Pokrenuti program i provjeriti rezultat.
            // AppDomain.CurrentDomain.UnhandledException += 
            Exception[] iznimke = { new ArgumentOutOfRangeException(), new ArgumentNullException(), new DivideByZeroException() };

            foreach (var iznimka in iznimke)
            {
                try
                {
                    throw iznimka;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Uhvaćena iznimka: {e.GetType()}");
                }
            }
        }

        static void Neuhvaceni(object posiljatelj, UnhandledExceptionEventArgs a)
        {
            Exception e = (Exception)a.ExceptionObject;
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
