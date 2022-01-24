﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vsite.CSharp.Iznimke
{
    // Program generira iznimke u određenim vremenskim intervalima da bismo
    // ih mogli pratiti u PERFMON aplikaciji
    // Pokrenuti program izvan Visual Studija
    // Pokrenuti program PerfMon i u njemu uključiti praćenje .NET CLR Exceptions:
    //          - kliknuti na crveni + i u popisu brojača potražiti .NET CLR Exceptions
    //          - proširiti stavku .NET CLR Exceptions i u njoj odabrati "# of Exceps Thrown"
    //          - u popisu objekata potražiti i selektirati "IznimkePerfMon" te pritisnuti tipku Add.
    // Kliknuti na tipku u formi naše aplikacije da počne bacati iznimke te pratiti graf u programu PerfMon.
    static class IznimkePerfMon
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
