using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
namespace com.Sapient
{
    [TestClass]
    public class LibraryTest
    {
        private IBook NormalBook=new NormalBook("Helloween","Hency Chronia");
        private Library Library=new Library();    
        [TestMethod]
        public void TestSearchBook()
        {
            Library.books.Add(NormalBook);    
            
            List<IBook>ExpectedOutput=new List<IBook>();
            ExpectedOutput.Add(NormalBook);
            CollectionAsser.AreEqual(ExpectedOutput,Library.SearchBook("Helloween","title"));  
          }
    }
}
