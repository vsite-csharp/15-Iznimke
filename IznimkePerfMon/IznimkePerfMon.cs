using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vsite.CSharp.Iznimke
{
    // Program generira iznimke u određenim vremenskim intervalima da bismo
    // ih mogli pratiti u PERFMON aplikaciji
    // 100 Pokrenuti program izvan Visual Studija
    // 101 Pokrenuti program PerfMon i u njemu uključiti praćenje .NET CLR Exceptions
    // 102 Kliknuti na tipku u formi naše aplikacije da počne bacati iznimke te pratiti graf u programu PerfMon
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
