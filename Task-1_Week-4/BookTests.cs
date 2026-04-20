using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task_1_Week_4
{
    [TestClass]
    public class BookTests
    {
        [TestMethod]
        public void Book_GetInfo_ReturnsCorrectFormat()
        {
            Book book = new Book("Generic Book", "John Smith", 19.99);

            string result = book.GetInfo();

            Assert.AreEqual("Book: Generic Book by John Smith, Price: $19.99", result);
        }

        [TestMethod]
        public void Book_Properties_AreSetCorrectly()
        {
            Book book = new Book("Test Title", "Test Author", 25.50);

            Assert.AreEqual("Test Title", book.Title);
            Assert.AreEqual("Test Author", book.Author);
            Assert.AreEqual(25.50, book.Price);
        }

        [TestMethod]
        public void Magazine_GetInfo_ReturnsCorrectFormat()
        {
            Magazine magazine = new Magazine("Tech Weekly", "Editor", 9.99, 12);

            string result = magazine.GetInfo();

            Assert.AreEqual("Magazine: Tech Weekly by Editor, Price: $9.99, Issue #: 12", result);
        }

        [TestMethod]
        public void Magazine_Properties_AreSetCorrectly()
        {
            Magazine magazine = new Magazine("Tech Weekly", "Editor", 9.99, 12);

            Assert.AreEqual("Tech Weekly", magazine.Title);
            Assert.AreEqual("Editor", magazine.Author);
            Assert.AreEqual(9.99, magazine.Price);
            Assert.AreEqual(12, magazine.IssueNumber);
        }

        [TestMethod]
        public void Ebook_GetInfo_ReturnsCorrectFormat()
        {
            Ebook ebook = new Ebook("Learn C#", "Jane Doe", 29.99, 5);

            string result = ebook.GetInfo();

            Assert.AreEqual("Ebook: Learn C# by Jane Doe, Price: $29.99, File Size: 5 MB", result);
        }

        [TestMethod]
        public void Ebook_Properties_AreSetCorrectly()
        {
            Ebook ebook = new Ebook("Learn C#", "Jane Doe", 29.99, 5);

            Assert.AreEqual("Learn C#", ebook.Title);
            Assert.AreEqual("Jane Doe", ebook.Author);
            Assert.AreEqual(29.99, ebook.Price);
            Assert.AreEqual(5.0, ebook.FileSize);
        }
    }

    [TestClass]
    public class PolymorphismTests
    {
        [TestMethod]
        public void Polymorphism_BookArray_CallsCorrectGetInfo()
        {
            Book[] books = new Book[]
            {
                new Book("Generic Book", "John Smith", 19.99),
                new Magazine("Tech Weekly", "Editor", 9.99, 12),
                new Ebook("Learn C#", "Jane Doe", 29.99, 5)
            };

            string bookInfo = books[0].GetInfo();
            string magazineInfo = books[1].GetInfo();
            string ebookInfo = books[2].GetInfo();

            Assert.AreEqual("Book: Generic Book by John Smith, Price: $19.99", bookInfo);
            Assert.AreEqual("Magazine: Tech Weekly by Editor, Price: $9.99, Issue #: 12", magazineInfo);
            Assert.AreEqual("Ebook: Learn C# by Jane Doe, Price: $29.99, File Size: 5 MB", ebookInfo);
        }

        [TestMethod]
        public void Polymorphism_MagazineAsBook_CallsMagazineGetInfo()
        {
            Book book = new Magazine("Science Daily", "Editor", 12.99, 45);

            string result = book.GetInfo();

            Assert.IsTrue(result.StartsWith("Magazine:"));
        }

        [TestMethod]
        public void Polymorphism_EbookAsBook_CallsEbookGetInfo()
        {
            Book book = new Ebook("Digital World", "Author", 15.99, 10);

            string result = book.GetInfo();

            Assert.IsTrue(result.StartsWith("Ebook:"));
        }
    }
}
