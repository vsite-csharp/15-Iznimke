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
            if (mb.ExceptionHandlingClauses.Count != 2)
                return false;
            if (mb.ExceptionHandlingClauses[0].Flags != ExceptionHandlingClauseOptions.Filter)
                return false;
            if (mb.ExceptionHandlingClauses[1].Flags != ExceptionHandlingClauseOptions.Clause)
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
        public void IspišiLogaritamZaNegativnuBazuIspisujePogrešku()
        {
            Assert.IsTrue(ProvjeriFiltereIznimki());
            FilteriIznimki.IspišiLogaritamBroja(1000, -10);
            Assert.AreEqual(string.Format(FilteriIznimki.FormatPogreške, "baza", -10), cw.GetString());
        }
    }
}
