using System.Reflection;

namespace Vsite.CSharp.Iznimke.Testovi
{
    [TestClass]
    public class BacanjeIznimkeUPozvanojMetodi : ConsoleTest
    {
        [TestMethod]
        public void Metoda1ImaSamoBlokFinally()
        {
            Assert.IsTrue(ExceptionTest.CheckExceptionHandling<Iznimke.BacanjeIznimkeUPozvanojMetodi>("Metoda1", new ExceptionHandlingInfo[] { new ExceptionHandlingInfo(ExceptionHandlingClauseOptions.Finally, null) }));
        }

        [TestMethod]
        public void Metoda2ImaDvaBlokaCatchIBlokFinally()
        {
            Assert.IsTrue(ExceptionTest.CheckExceptionHandling<Iznimke.BacanjeIznimkeUPozvanojMetodi>("Metoda2", new ExceptionHandlingInfo[] { new ExceptionHandlingInfo(ExceptionHandlingClauseOptions.Clause, typeof(ArgumentException)), new ExceptionHandlingInfo(ExceptionHandlingClauseOptions.Finally, null) }));
        }

        [TestMethod]
        public void Metoda3ImaBlokCatchIBlokFinally()
        {
            Assert.IsTrue(ExceptionTest.CheckExceptionHandling<Iznimke.BacanjeIznimkeUPozvanojMetodi>("Metoda3", new ExceptionHandlingInfo[] { new ExceptionHandlingInfo(ExceptionHandlingClauseOptions.Clause, typeof(NotSupportedException)), new ExceptionHandlingInfo(ExceptionHandlingClauseOptions.Finally, null) }));
        }

        [TestMethod]
        public void PozivMetode1ZaDjeljiteljRazličitOd0IspisujeRezultat()
        {
            Vsite.CSharp.Iznimke.BacanjeIznimkeUPozvanojMetodi.Metoda1(5, 2);
            Assert.AreEqual(4, cw?.Count);
            Assert.AreEqual("5 / 2 = 2", cw?.GetString());
            Assert.AreEqual("finally u Metoda3", cw?.GetString());
            Assert.AreEqual("finally u Metoda2", cw?.GetString());
            Assert.AreEqual("finally u Metoda1", cw?.GetString());
        }

        [TestMethod]
        public void PozivMetodeZaDjeljitelj0BacaNobrađenuIznimkuTipaDivideByZeroException()
        {
            Assert.IsTrue(ExceptionTest.CheckExceptionHandling<Iznimke.BacanjeIznimkeUPozvanojMetodi>("Metoda3", new ExceptionHandlingInfo[] { new ExceptionHandlingInfo(ExceptionHandlingClauseOptions.Clause, typeof(NotSupportedException)), new ExceptionHandlingInfo(ExceptionHandlingClauseOptions.Finally, null) }));

            try
            {
                Vsite.CSharp.Iznimke.BacanjeIznimkeUPozvanojMetodi.Metoda1(5, 0);
                Assert.Fail();
            }
            catch (DivideByZeroException e)
            {
                Assert.AreEqual("Metoda3", e?.TargetSite?.Name);
                Assert.AreEqual(3, cw?.Count);
                Assert.AreEqual("finally u Metoda3", cw?.GetString());
                Assert.AreEqual("finally u Metoda2", cw?.GetString());
                Assert.AreEqual("finally u Metoda1", cw?.GetString());
            }
        }
    }
}
