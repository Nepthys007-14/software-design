using Microsoft.EntityFrameworkCore;
using lab5.Data;
using lab5.Models;

namespace lab5
{
    public partial class Form1 : Form
    {
        private BookstoreContext _context;
        private Book? _selectedBook;

        public Form1()
        {
            InitializeComponent();
            _context = new BookstoreContext();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _context.Database.EnsureCreated();
            LoadAuthors();
            LoadBooks();
        }

        private void LoadAuthors()
        {
            var authors = _context.Authors.OrderBy(a => a.LastName).ToList();
            cmbAuthors.DataSource = authors;
            cmbAuthors.DisplayMember = "FullName";
            cmbAuthors.ValueMember = "Id";
        }

        private void LoadBooks()
        {
            var books = _context.Books
                .Include(b => b.Author)
                .OrderBy(b => b.Title)
                .ToList();

            var displayData = books.Select(b => new
            {
                b.Id,
                b.Title,
                b.ISBN,
                b.Price,
                Author = b.Author != null ? $"{b.Author.FirstName} {b.Author.LastName}" : ""
            }).ToList();

            dgvBooks.DataSource = null;
            dgvBooks.DataSource = displayData;
            if (dgvBooks.Columns["Id"] != null)
                dgvBooks.Columns["Id"]!.Visible = false;
        }

        private void dgvBooks_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBooks.CurrentRow?.Cells["Id"].Value is not int bookId) return;

            _selectedBook = _context.Books
                .Include(b => b.Author)
                .FirstOrDefault(b => b.Id == bookId);

            if (_selectedBook?.Author != null)
            {
                txtTitle.Text = _selectedBook.Title;
                txtISBN.Text = _selectedBook.ISBN;
                txtPrice.Text = _selectedBook.Price.ToString();
                cmbAuthors.SelectedValue = _selectedBook.AuthorId;
                txtFirstName.Text = _selectedBook.Author.FirstName;
                txtLastName.Text = _selectedBook.Author.LastName;
                txtBio.Text = _selectedBook.Author.Bio;
            }
        }

        private void ClearFields()
        {
            txtTitle.Clear();
            txtISBN.Clear();
            txtPrice.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtBio.Clear();
            _selectedBook = null;
            if (cmbAuthors.Items.Count > 0)
                cmbAuthors.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text) ||
                string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Title, First Name, and Last Name are required.", "Validation Error");
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out var price))
                price = 0;

            var author = new Author
            {
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                Bio = txtBio.Text.Trim()
            };

            var book = new Book
            {
                Title = txtTitle.Text.Trim(),
                ISBN = txtISBN.Text.Trim(),
                Price = price,
                Author = author
            };

            _context.Books.Add(book);
            _context.SaveChanges();

            LoadAuthors();
            LoadBooks();
            ClearFields();
            MessageBox.Show("Book added successfully.", "Success");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedBook == null)
            {
                MessageBox.Show("Please select a book to update.", "No Selection");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Title is required.", "Validation Error");
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out var price))
                price = 0;

            _selectedBook.Title = txtTitle.Text.Trim();
            _selectedBook.ISBN = txtISBN.Text.Trim();
            _selectedBook.Price = price;
            _selectedBook.AuthorId = cmbAuthors.SelectedValue is int authorId ? authorId : 0;

            var author = _context.Authors.Find(_selectedBook.AuthorId);
            if (author != null)
            {
                author.FirstName = txtFirstName.Text.Trim();
                author.LastName = txtLastName.Text.Trim();
                author.Bio = txtBio.Text.Trim();
            }

            _context.SaveChanges();
            LoadBooks();
            ClearFields();
            MessageBox.Show("Book updated successfully.", "Success");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedBook == null)
            {
                MessageBox.Show("Please select a book to delete.", "No Selection");
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete this book?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                _context.Books.Remove(_selectedBook);
                _context.SaveChanges();
                LoadBooks();
                ClearFields();
                MessageBox.Show("Book deleted successfully.", "Success");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _context.ChangeTracker.Clear();
            LoadAuthors();
            LoadBooks();
            ClearFields();
        }
    }
}
