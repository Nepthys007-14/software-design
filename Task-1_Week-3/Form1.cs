namespace Task_1_Week_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            lstBooks.Items.Clear();

            // Create Book objects
            Book book1 = new Book("The Great Gatsby", "F. Scott Fitzgerald", 10.99);
            Magazine mag1 = new Magazine("National Geographic", "Various", 5.99, 202);
            Ebook ebook1 = new Ebook("Digital Fortress", "Dan Brown", 8.49, 2.5);

            // Display information in the ListBox
            lstBooks.Items.Add(book1.GetInfo());
            lstBooks.Items.Add(mag1.GetInfo());
            lstBooks.Items.Add(ebook1.GetInfo());
        }
    }
}
