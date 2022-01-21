using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace Vsite.CSharp.Iznimke.Testovi
{
    [TestClass]
    public class BacanjeIznimkeUPozvanojMetodi : ConsoleTest
    {
        struct ExceptionHandlingInfo
        {
            public ExceptionHandlingInfo(ExceptionHandlingClauseOptions clauseOptions, Type catchType = null)
            {
                ClauseOptions = clauseOptions;
                CatchType = catchType;
            }

            public readonly ExceptionHandlingClauseOptions ClauseOptions;
            public readonly Type CatchType;
        }

        bool ProvjeriBlokoveHvatanja(string imeMetode, ExceptionHandlingInfo[] blokoviIznimke)
        {
            MethodInfo mi = typeof(Vsite.CSharp.Iznimke.BacanjeIznimkeUPozvanojMetodi).GetMethod(imeMetode, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            MethodBody mb = mi.GetMethodBody();

            if (mb.ExceptionHandlingClauses.Count != blokoviIznimke.Length)
                return false;

            for (int i = 0; i < mb.ExceptionHandlingClauses.Count; ++i)
            {
                if (mb.ExceptionHandlingClauses[i].Flags != blokoviIznimke[i].ClauseOptions)
                    return false;
                if (mb.ExceptionHandlingClauses[i].Flags == ExceptionHandlingClauseOptions.Clause && mb.ExceptionHandlingClauses[i].CatchType != blokoviIznimke[i].CatchType)
                    return false;
            }
            return true;
        }


        [TestMethod]
        public void Metoda1ImaSamoBlokFinally()
        {
            Assert.IsTrue(ProvjeriBlokoveHvatanja("Metoda1", new ExceptionHandlingInfo[] { new ExceptionHandlingInfo(ExceptionHandlingClauseOptions.Finally, null) }));
        }

        [TestMethod]
        public void Metoda2ImaDvaBlokaCatchIBlokFinally()
        {
            Assert.IsTrue(ProvjeriBlokoveHvatanja("Metoda2", new ExceptionHandlingInfo[] { new ExceptionHandlingInfo(ExceptionHandlingClauseOptions.Clause, typeof(ArgumentException)), new ExceptionHandlingInfo(ExceptionHandlingClauseOptions.Finally, null) }));
        }

        [TestMethod]
        public void Metoda3ImaBlokCatchIBlokFinally()
        {
            Assert.IsTrue(ProvjeriBlokoveHvatanja("Metoda3", new ExceptionHandlingInfo[] { new ExceptionHandlingInfo(ExceptionHandlingClauseOptions.Clause, typeof(NotSupportedException)), new ExceptionHandlingInfo(ExceptionHandlingClauseOptions.Finally, null) }));
        }

        [TestMethod]
        public void PozivMetode1ZaDjeljiteljRazličitOd0IspisujeRezultat()
        {
            Vsite.CSharp.Iznimke.BacanjeIznimkeUPozvanojMetodi.Metoda1(5, 2);
            Assert.AreEqual(4, cw.Count);
            Assert.AreEqual("5 / 2 = 2", cw.GetString());
            Assert.AreEqual("finally u Metoda3", cw.GetString());
            Assert.AreEqual("finally u Metoda2", cw.GetString());
            Assert.AreEqual("finally u Metoda1", cw.GetString());
        }

        [TestMethod]
        public void PozivMetodeZaDjeljitelj0BacaNobrađenuIznimkuTipaDivideByZeroException()
        {
            Assert.IsTrue(ProvjeriBlokoveHvatanja("Metoda3", new ExceptionHandlingInfo[] { new ExceptionHandlingInfo(ExceptionHandlingClauseOptions.Clause, typeof(NotSupportedException)), new ExceptionHandlingInfo(ExceptionHandlingClauseOptions.Finally, null) }));

            try
            {
                Vsite.CSharp.Iznimke.BacanjeIznimkeUPozvanojMetodi.Metoda1(5, 0);
                Assert.Fail();
            }
            catch (DivideByZeroException e)
            {
                Assert.AreEqual("Metoda3", e.TargetSite.Name);
                Assert.AreEqual(3, cw.Count);
                Assert.AreEqual("finally u Metoda3", cw.GetString());
                Assert.AreEqual("finally u Metoda2", cw.GetString());
                Assert.AreEqual("finally u Metoda1", cw.GetString());
            }
        }
    }
}
