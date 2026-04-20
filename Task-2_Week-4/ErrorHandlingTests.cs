using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task_2_Week_4
{
    [TestClass]
    public class ErrorHandlingTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Book_EmptyTitle_ThrowsArgumentException()
        {
            Book book = new Book("", "Author", 19.99);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Book_NullTitle_ThrowsArgumentException()
        {
            Book book = new Book(null!, "Author", 19.99);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Book_EmptyAuthor_ThrowsArgumentException()
        {
            Book book = new Book("Title", "", 19.99);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Book_NullAuthor_ThrowsArgumentException()
        {
            Book book = new Book("Title", null!, 19.99);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Book_NegativePrice_ThrowsArgumentException()
        {
            Book book = new Book("Title", "Author", -5.00);
        }

        [TestMethod]
        public void Book_ValidData_CreatesSuccessfully()
        {
            Book book = new Book("Valid Title", "Valid Author", 10.00);

            Assert.AreEqual("Valid Title", book.Title);
            Assert.AreEqual("Valid Author", book.Author);
            Assert.AreEqual(10.00, book.Price);
        }

        [TestMethod]
        public void Book_ZeroPrice_CreatesSuccessfully()
        {
            Book book = new Book("Free Book", "Author", 0);

            Assert.AreEqual(0, book.Price);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Magazine_NegativeIssueNumber_ThrowsArgumentException()
        {
            Magazine magazine = new Magazine("Tech Weekly", "Editor", 9.99, -1);
        }

        [TestMethod]
        public void Magazine_ValidData_CreatesSuccessfully()
        {
            Magazine magazine = new Magazine("Tech Weekly", "Editor", 9.99, 12);

            Assert.AreEqual(12, magazine.IssueNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Ebook_NegativeFileSize_ThrowsArgumentException()
        {
            Ebook ebook = new Ebook("Learn C#", "Jane Doe", 29.99, -10);
        }

        [TestMethod]
        public void Ebook_ValidData_CreatesSuccessfully()
        {
            Ebook ebook = new Ebook("Learn C#", "Jane Doe", 29.99, 5);

            Assert.AreEqual(5.0, ebook.FileSize);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Magazine_EmptyTitle_ThrowsArgumentException()
        {
            Magazine magazine = new Magazine("", "Editor", 9.99, 12);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Ebook_EmptyTitle_ThrowsArgumentException()
        {
            Ebook ebook = new Ebook("", "Author", 29.99, 5);
        }
    }
}
