using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task_3_Week_4
{
    [TestClass]
    public class EdgeCaseTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Book_EmptyTitle_ThrowsArgumentException()
        {
            Book book = new Book("", "Author", 19.99);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Book_WhitespaceTitle_ThrowsArgumentException()
        {
            Book book = new Book("   ", "Author", 19.99);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Book_NullTitle_ThrowsArgumentException()
        {
            Book book = new Book(null!, "Author", 19.99);
        }

        [TestMethod]
        public void Book_ValidTitle_CreatesSuccessfully()
        {
            Book book = new Book("Valid Title", "Author", 19.99);

            Assert.AreEqual("Valid Title", book.Title);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Magazine_NegativeIssueNumber_ThrowsArgumentException()
        {
            Magazine magazine = new Magazine("Tech Weekly", "Editor", 9.99, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Magazine_LargeNegativeIssueNumber_ThrowsArgumentException()
        {
            Magazine magazine = new Magazine("Tech Weekly", "Editor", 9.99, -100);
        }

        [TestMethod]
        public void Magazine_ZeroIssueNumber_CreatesSuccessfully()
        {
            Magazine magazine = new Magazine("Tech Weekly", "Editor", 9.99, 0);

            Assert.AreEqual(0, magazine.IssueNumber);
        }

        [TestMethod]
        public void Magazine_ValidIssueNumber_CreatesSuccessfully()
        {
            Magazine magazine = new Magazine("Tech Weekly", "Editor", 9.99, 50);

            Assert.AreEqual(50, magazine.IssueNumber);
        }
    }

    [TestClass]
    public class TextbookValidationTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Textbook_EmptySubject_ThrowsArgumentException()
        {
            Textbook textbook = new Textbook("Math Book", "Author", 49.99, "");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Textbook_WhitespaceSubject_ThrowsArgumentException()
        {
            Textbook textbook = new Textbook("Math Book", "Author", 49.99, "   ");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Textbook_NullSubject_ThrowsArgumentException()
        {
            Textbook textbook = new Textbook("Math Book", "Author", 49.99, null!);
        }

        [TestMethod]
        public void Textbook_ValidSubject_CreatesSuccessfully()
        {
            Textbook textbook = new Textbook("Math Book", "Author", 49.99, "Mathematics");

            Assert.AreEqual("Mathematics", textbook.Subject);
        }

        [TestMethod]
        public void Textbook_GetInfo_ReturnsCorrectFormat()
        {
            Textbook textbook = new Textbook("Physics 101", "Dr. Smith", 59.99, "Physics");

            string result = textbook.GetInfo();

            Assert.AreEqual("Textbook: Physics 101 by Dr. Smith, Price: $59.99, Subject: Physics", result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Textbook_EmptyTitle_ThrowsArgumentException()
        {
            Textbook textbook = new Textbook("", "Author", 49.99, "Science");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Textbook_NegativePrice_ThrowsArgumentException()
        {
            Textbook textbook = new Textbook("Math Book", "Author", -10.00, "Mathematics");
        }
    }
}
