using System.Reflection;

namespace Vsite.CSharp.Iznimke.Testovi
{
    [TestClass]
    public class VišestrukiBlokoviCatch : ConsoleTest
    {
        bool ProvjeriCatchBlokove()
        {
            MethodInfo? mi = typeof(Iznimke.VišestrukiBlokoviCatch)?.GetMethod("HvatanjeIznimkePremaTipu");
            MethodBody? mb = mi?.GetMethodBody();
            if (mb?.ExceptionHandlingClauses.Count != 3)
                return false;
            if (mb?.ExceptionHandlingClauses.FirstOrDefault(ehc => ehc.CatchType == typeof(ArgumentOutOfRangeException)) == null)
                return false;
            if (mb?.ExceptionHandlingClauses.FirstOrDefault(ehc => ehc.CatchType == typeof(ArgumentException)) == null)
                return false;
            return mb?.ExceptionHandlingClauses.FirstOrDefault(ehc => ehc.CatchType == typeof(Exception)) != null;
        }

        [TestMethod]
        public void FileNotFoundExceptionĆeBitiUhvaćenKaoException()
        {
            Assert.IsTrue(ProvjeriCatchBlokove());

            Exception e = new System.IO.FileNotFoundException();
            Iznimke.VišestrukiBlokoviCatch.HvatanjeIznimkePremaTipu(e);
            Assert.AreEqual(string.Format(Iznimke.VišestrukiBlokoviCatch.FormatFiltraException, e.GetType().Name), cw?.GetString());
        }

        [TestMethod]
        public void ArgumentOutOfRangeExceptionĆeBitiUhvaćenKaoArgumentOutOfRangeException()
        {
            Assert.IsTrue(ProvjeriCatchBlokove());

            Exception e = new ArgumentOutOfRangeException();
            Iznimke.VišestrukiBlokoviCatch.HvatanjeIznimkePremaTipu(e);
            Assert.AreEqual(string.Format(Iznimke.VišestrukiBlokoviCatch.FormatFiltraArgumentOutOfRangeException, e.GetType().Name), cw?.GetString());
        }

        [TestMethod]
        public void ArgumentExceptionĆeBitiUhvaćenKaoArgumentException()
        {
            Assert.IsTrue(ProvjeriCatchBlokove());

            Exception e = new ArgumentException();
            Iznimke.VišestrukiBlokoviCatch.HvatanjeIznimkePremaTipu(e);
            Assert.AreEqual(string.Format(Iznimke.VišestrukiBlokoviCatch.FormatFiltraArgumentException, e.GetType().Name), cw?.GetString());
        }

        [TestMethod]
        public void ArgumentNullExceptionĆeBitiUhvaćenKaoArgumentException()
        {
            Assert.IsTrue(ProvjeriCatchBlokove());

            Exception e = new ArgumentNullException();
            Iznimke.VišestrukiBlokoviCatch.HvatanjeIznimkePremaTipu(e);
            Assert.AreEqual(string.Format(Iznimke.VišestrukiBlokoviCatch.FormatFiltraArgumentException, e.GetType().Name), cw?.GetString());
        }
    }
}
