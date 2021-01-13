using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace com.Sapient
{
    [TestClass]
    public class NormalBookTest
    {
        private static IBook NormalBook=new NormalBook();
            
        [TestMethod]
        public void TestSetPrice()
        {
            NormalBook.setPrice(100);
            Assert.AreEqual(100,NormalBook.getPrice());
        }
    }
}
