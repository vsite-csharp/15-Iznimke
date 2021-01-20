using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Vsite.CSharp.Iznimke.Testovi
{
    [TestClass]
    public class FiltarIznimki : ConsoleTest
    {
        bool ProvjeriFiltereIznimki()
        {
            MethodInfo mi = typeof(FilteriIznimki).GetMethod("IspišiLogaritamBroja");
            MethodBody mb = mi.GetMethodBody();
            if (mb.ExceptionHandlingClauses.Count != 1)
                return false;
            if (mb.ExceptionHandlingClauses[0].Flags != ExceptionHandlingClauseOptions.Filter)
                return false;
            return true;
        }

        [TestMethod]
        public void IspišiLogaritamZaIspravneArgumenteIspisujeRezultat()
        {
            Assert.IsTrue(ProvjeriFiltereIznimki());

            FilteriIznimki.IspišiLogaritamBroja(1000, 10);
            Assert.AreEqual(string.Format(FilteriIznimki.FormatIspisa, 1000, 10, 3), cw.GetString());
        }

        [TestMethod]
        public void IspišiLogaritamZaNegativniBrojIspisujePogrešku()
        {
            FilteriIznimki.IspišiLogaritamBroja(-1000, 10);
            Assert.AreEqual(FilteriIznimki.NedozvoljeniBroj, cw.GetString());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IspišiLogaritamZaNegativnuBazuBacaIznimku()
        {
            FilteriIznimki.IspišiLogaritamBroja(1000, -10);
        }
    }
}
