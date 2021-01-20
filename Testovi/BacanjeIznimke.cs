using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Vsite.CSharp.Iznimke.Testovi
{
    [TestClass]
    public class BacanjeIznimke
    {
        [TestMethod]
        public void FaktorijelVraća1ZaArgument1()
        {
            Assert.AreEqual(1, Math.Faktorjel(1));
        }

        [TestMethod]
        public void Faktorije2Vraća1ZaArgument2()
        {
            Assert.AreEqual(2, Math.Faktorjel(2));
        }

        [TestMethod]
        public void Faktorije24Vraća1ZaArgument4()
        {
            Assert.AreEqual(24, Math.Faktorjel(4));
        }

        [TestMethod]
        public void FaktorijelVraća1ZaArgument0()
        {
            Assert.AreEqual(1, Math.Faktorjel(0));
        }

        [TestMethod]
        public void FaktorijelBacaIznimkuTipaArgumentOutOfRangeExceptionZaNegativneArgumente()
        {
            try
            {
                Math.Faktorjel(-1);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ArgumentOutOfRangeException));
            }
        }

        [TestMethod]
        public void FaktorijelBacaIznimkuZaPrevelikeArgumente()
        {
            try
            {
                Math.Faktorjel(17);
                Assert.Fail("Nije bacio iznimku za preveliki argument");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Assert.AreEqual("broj", e.ParamName);
                Assert.AreEqual(17, (int)e.ActualValue);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(OverflowException));
            }
        }
    }
}
