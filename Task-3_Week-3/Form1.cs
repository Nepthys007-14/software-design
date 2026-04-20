namespace Task_3_Week_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void DisplayBooks(Book[] books)
        {
            foreach (Book book in books)
            {
                lstBooks.Items.Add(book.GetInfo());
            }
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            lstBooks.Items.Clear();

            Book[] books = new Book[]
            {
                new Book("The Great Gatsby", "F. Scott Fitzgerald", 10.99),
                new Magazine("National Geographic", "Various", 5.99, 202),
                new Ebook("Digital Fortress", "Dan Brown", 8.49, 2.5),
                new Textbook("Introduction to Algorithms", "Thomas H. Cormen", 89.99, "Computer Science"),
                new Textbook("Calculus: Early Transcendentals", "James Stewart", 74.50, "Mathematics"),
                new AudioBook("Becoming", "Michelle Obama", 14.99, 19.0, "Michelle Obama"),
                new AudioBook("Atomic Habits", "James Clear", 12.99, 5.5, "James Clear")
            };

            DisplayBooks(books);
        }
    }
}
