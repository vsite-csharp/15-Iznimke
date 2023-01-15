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
            Iznimke.TijekIzvođenja.IspisTryCatchFinally(djeljenik, djeljitelj);
            Assert.AreEqual(6, cw?.Count);
            Assert.AreEqual(Iznimke.TijekIzvođenja.ZapočinjeBlokTry, cw?.GetString());
            Assert.AreEqual(string.Format($"{djeljenik} dijelim s {djeljitelj}"), cw?.GetString());
            Assert.AreEqual(3, cw?.GetInt());
            Assert.AreEqual(string.Format($"{djeljenik} sam podijelio s {djeljitelj}"), cw?.GetString());
            Assert.AreEqual(Iznimke.TijekIzvođenja.ZavršavaBlokTry, cw?.GetString());
            Assert.AreEqual(Iznimke.TijekIzvođenja.BlokFinally, cw?.GetString());
        }

        [TestMethod]
        public void AkoJeBačenaIznimkaPrekidaSeTryBlokTeSeIzvodeBlokoviCatchIFinally()
        {
            int djeljenik = 3;
            int djeljitelj = 0;
            Iznimke.TijekIzvođenja.IspisTryCatchFinally(djeljenik, djeljitelj);
            Assert.AreEqual(4, cw?.Count);
            Assert.AreEqual(Iznimke.TijekIzvođenja.ZapočinjeBlokTry, cw?.GetString());
            Assert.AreEqual(string.Format($"{djeljenik} dijelim s {djeljitelj}"), cw?.GetString());
            Assert.AreEqual(Iznimke.TijekIzvođenja.BlokCatch, cw?.GetString());
            Assert.AreEqual(Iznimke.TijekIzvođenja.BlokFinally, cw?.GetString());
        }
    }
}
