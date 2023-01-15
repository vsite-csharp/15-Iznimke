using System.Reflection;

namespace Vsite.CSharp.Iznimke.Testovi
{
    [TestClass]
    public class RukovateljNeobrađenihIznimki : ConsoleTest
    {
        bool HasValidHandler()
        {
            MethodInfo[] mis = typeof(Iznimke.RukovateljNeobrađenihIznimki).GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            if (mis.Length < 3)
                return false;
            foreach (MethodInfo mi in mis)
            {
                if (mi.Name != "Main" && mi.Name != "EvidentirajNeuhvaćenuIznimku")
                {
                    var pars = mi.GetParameters();
                    if (pars.Length != 2 || pars[0].ParameterType != typeof(object) || pars[1].ParameterType != typeof(UnhandledExceptionEventArgs))
                        continue;
                    var exception = new DivideByZeroException();
                    mi.Invoke(null, new object[] { this, new UnhandledExceptionEventArgs(exception, false) });
                    if (ew?.Count == 1 && string.Format(Iznimke.RukovateljNeobrađenihIznimki.NeuhvaćenaIznimka, exception.GetType()) == ew?.GetString())
                        return true;
                }
            }
            return false;
        }
        [TestMethod]
        public void NeobrađenaIznimkaPozivaRukovateljaKojiIspisujeTipNeobrađeneIznimke()
        {
            Assert.IsTrue(HasValidHandler());

            try
            {
                Iznimke.RukovateljNeobrađenihIznimki.Main();
                Assert.Fail();
            }
            catch (DivideByZeroException)
            {
                Assert.AreEqual(2, cw?.Count);
            }
        }
    }
}
