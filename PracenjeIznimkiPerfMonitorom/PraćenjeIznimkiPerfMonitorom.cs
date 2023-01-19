namespace Vsite.CSharp.Iznimke
{
    // Program generira iznimke u određenim vremenskim intervalima da bismo
    // ih mogli pratiti u PERFMON aplikaciji

    // 110 Pokrenuti program izvan Visual Studija
    // 111 Pokrenuti program PerfMon i u njemu uključiti praćenje .NET CLR Exceptions:
    //          - kliknuti na crveni + i u popisu brojača potražiti .NET CLR Exceptions
    //          - proširiti stavku .NET CLR Exceptions i u njoj odabrati "# of Exceps Thrown"
    //          - u popisu objekata potražiti i selektirati "IznimkePerfMon" te pritisnuti tipku Add.
    // 112 Kliknuti na tipku u formi naše aplikacije da počne bacati iznimke te pratiti graf u programu PerfMon.
    static class PraćenjeIznimkiPerfMonitorom
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PeriodičniBacačIznimki());
        }
    }
}
