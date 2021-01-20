using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Vsite.CSharp.Iznimke.Testovi
{
    [TestClass]
    public class ApstrakcijaIznimke
    {
        [TestMethod]
        public void FaktorjelZaPrevelikArgumentBacaIznimkuTipaArgumentOutOfRangeException()
        {
            try
            {
                Math.Faktorjel(20);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ArgumentOutOfRangeException));
                ArgumentOutOfRangeException e1 = (ArgumentOutOfRangeException)e;
                Assert.AreEqual("broj", e1.ParamName);
                Assert.AreEqual(20, e1.ActualValue);
            }
        }
    }
}
