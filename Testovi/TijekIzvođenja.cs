using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Vsite.CSharp.Iznimke.Testovi
{
    [TestClass]
    public class TijekIzvođenja : ConsoleTest
    {
        [TestMethod]
        public void AkoNijeBačenaIznimkaIzvodiSeCijeliBlokTryIBlokFinally()
        {
            int djeljenik = 3;
            int djeljitelj = 1;
            TijekIzvodjenja.IspisTryCatchFinally(djeljenik, djeljitelj);
            Assert.AreEqual(6, cw.Count);
            Assert.AreEqual(TijekIzvodjenja.ZapočinjeBlokTry, cw.GetString());
            Assert.AreEqual(string.Format($"{djeljenik} dijelim s {djeljitelj}"), cw.GetString());
            Assert.AreEqual(3, cw.GetInt());
            Assert.AreEqual(string.Format($"{djeljenik} sam podijelio s {djeljitelj}"), cw.GetString());
            Assert.AreEqual(TijekIzvodjenja.ZavršavaBlokTry, cw.GetString());
            Assert.AreEqual(TijekIzvodjenja.BlokFinally, cw.GetString());
        }

        [TestMethod]
        public void AkoJeBačenaIznimkaPrekidaSeTryBlokTeSeIzvodeBlokoviCatchIFinally()
        {
            int djeljenik = 3;
            int djeljitelj = 0;
            TijekIzvodjenja.IspisTryCatchFinally(djeljenik, djeljitelj);
            Assert.AreEqual(4, cw.Count);
            Assert.AreEqual(TijekIzvodjenja.ZapočinjeBlokTry, cw.GetString());
            Assert.AreEqual(string.Format($"{djeljenik} dijelim s {djeljitelj}"), cw.GetString());
            Assert.AreEqual(TijekIzvodjenja.BlokCatch, cw.GetString());
            Assert.AreEqual(TijekIzvodjenja.BlokFinally, cw.GetString());
        }
    }
}
