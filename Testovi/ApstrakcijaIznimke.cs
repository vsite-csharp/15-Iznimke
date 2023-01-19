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
            catch (ArgumentOutOfRangeException e)
            {
                ArgumentOutOfRangeException e1 = (ArgumentOutOfRangeException)e;
            }
        }
    }
}
