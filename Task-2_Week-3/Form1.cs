namespace Task_2_Week_3
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
                new Book("To Kill a Mockingbird", "Harper Lee", 12.50),
                new Magazine("Time", "Time Inc.", 4.99, 150),
                new Ebook("The Da Vinci Code", "Dan Brown", 9.99, 3.1)
            };

            DisplayBooks(books);
        }
    }
}
