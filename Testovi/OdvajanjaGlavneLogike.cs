using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Vsite.CSharp.Iznimke.Testovi
{
    [TestClass]
    public class OdvajanjaGlavneLogike : ConsoleTest
    {
        [TestMethod]
        public void PetljaSePrekidaZaBrojeveVećeOd12()
        {
            try
            {
                OdvajanjeGlavneLogike.IspisPovrh(12, 20);

                for (int i = 1; i <= 12; ++i)
                    Assert.IsTrue(cw.GetString().StartsWith(string.Format("12 povrh {0} = ", i)));
                Assert.AreEqual(1, cw.Count);
                Assert.IsFalse(cw.GetString().StartsWith("12 povrh "));
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }
    }
}
