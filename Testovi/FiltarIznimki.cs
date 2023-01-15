using System.Reflection;

namespace Vsite.CSharp.Iznimke.Testovi
{
    [TestClass]
    public class FiltarIznimki : ConsoleTest
    {
        [TestMethod]
        public void IspišiLogaritamZaIspravneArgumenteIspisujeRezultat()
        {
            FilteriIznimki.IspišiLogaritamBroja2(1000, 10);
            Assert.AreEqual(string.Format(FilteriIznimki.FormatIspisa, 1000, 10, 3), cw?.GetString());
        }

        [TestMethod]
        public void IspišiLogaritamZaNegativniBrojIspisujePogrešku()
        {
            FilteriIznimki.IspišiLogaritamBroja2(-1000, 10);
            Assert.AreEqual(FilteriIznimki.NedozvoljeniBroj, cw?.GetString());
        }

        [TestMethod]
        public void IspišiLogaritamZaNegativnuBazuIspisujePogrešku()
        {
            FilteriIznimki.IspišiLogaritamBroja2(1000, -10);
            Assert.AreEqual(string.Format(FilteriIznimki.FormatPogreške, "baza", -10), cw?.GetString());
        }

        [TestMethod]
        public void IspišiLogaritamBroja1SadržiFiltarIznimke()
        {
            Assert.IsTrue(ExceptionTest.CheckExceptionHandling<FilteriIznimki>("IspišiLogaritamBroja1", new ExceptionHandlingInfo[] { new ExceptionHandlingInfo(ExceptionHandlingClauseOptions.Filter, typeof(ArgumentOutOfRangeException)) }));
        }

        [TestMethod]
        public void IspišiLogaritamBroja2SadržiSamoBlokHvatanjaIspišiLogaritamBroja1SadržiFiltarIznimke()
        {
            Assert.IsTrue(ExceptionTest.CheckExceptionHandling<FilteriIznimki>("IspišiLogaritamBroja1", new ExceptionHandlingInfo[] { new ExceptionHandlingInfo(ExceptionHandlingClauseOptions.Filter, typeof(ArgumentOutOfRangeException)) }));
            Assert.IsTrue(ExceptionTest.CheckExceptionHandling<FilteriIznimki>("IspišiLogaritamBroja2", new ExceptionHandlingInfo[] { new ExceptionHandlingInfo(ExceptionHandlingClauseOptions.Clause, typeof(ArgumentOutOfRangeException)) }));
        }
    }
}
