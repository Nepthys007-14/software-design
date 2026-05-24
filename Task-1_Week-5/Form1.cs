using Microsoft.EntityFrameworkCore;
using Task_1_Week_5.Data;
using Task_1_Week_5.Models;

namespace Task_1_Week_5
{
    public partial class Form1 : Form
    {
        private BookstoreContext _context;
        private int? _selectedBookId;
        private bool _isLoading;

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
            _isLoading = true;
            var authors = _context.Authors.OrderBy(a => a.LastName).ToList();
            cmbAuthors.DataSource = authors;
            cmbAuthors.DisplayMember = "FullName";
            cmbAuthors.ValueMember = "Id";
            _isLoading = false;
        }

        private void LoadBooks()
        {
            var books = _context.Books
                .AsNoTracking()
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

        private void cmbAuthors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoading || cmbAuthors.SelectedItem is not Author author) return;

            txtFirstName.Text = author.FirstName;
            txtLastName.Text = author.LastName;
            txtBio.Text = author.Bio;
        }

        private void dgvBooks_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBooks.CurrentRow?.Cells["Id"].Value is not int bookId) return;

            var book = _context.Books
                .AsNoTracking()
                .Include(b => b.Author)
                .FirstOrDefault(b => b.Id == bookId);

            if (book == null) return;

            _isLoading = true;
            _selectedBookId = bookId;

            txtTitle.Text = book.Title;
            txtISBN.Text = book.ISBN;
            txtPrice.Text = book.Price.ToString();

            if (book.Author != null)
            {
                cmbAuthors.SelectedValue = book.AuthorId;
                txtFirstName.Text = book.Author.FirstName;
                txtLastName.Text = book.Author.LastName;
                txtBio.Text = book.Author.Bio;
            }

            _isLoading = false;
        }

        private void ClearFields()
        {
            txtTitle.Clear();
            txtISBN.Clear();
            txtPrice.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtBio.Clear();
            _selectedBookId = null;
            if (cmbAuthors.Items.Count > 0)
                cmbAuthors.SelectedIndex = 0;
        }

        private void btnAddAuthor_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("First Name and Last Name are required.", "Validation Error");
                return;
            }

            try
            {
                var author = new Author
                {
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    Bio = txtBio.Text.Trim()
                };

                _context.Authors.Add(author);
                _context.SaveChanges();

                LoadAuthors();
                cmbAuthors.SelectedValue = author.Id;

                MessageBox.Show("Author added successfully.", "Success");
            }
            catch (Exception ex)
            {
                _context.ChangeTracker.Clear();
                MessageBox.Show($"Error adding author: {ex.Message}", "Error");
            }
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Title is required.", "Validation Error");
                return;
            }

            if (cmbAuthors.SelectedItem is not Author selectedAuthor)
            {
                MessageBox.Show("Select an existing author or add a new one first.", "Validation Error");
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out var price))
                price = 0;

            try
            {
                var book = new Book
                {
                    Title = txtTitle.Text.Trim(),
                    ISBN = txtISBN.Text.Trim(),
                    Price = price,
                    AuthorId = selectedAuthor.Id
                };

                _context.Books.Add(book);
                _context.SaveChanges();

                LoadBooks();
                ClearFields();
                MessageBox.Show("Book added successfully.", "Success");
            }
            catch (Exception ex)
            {
                _context.ChangeTracker.Clear();
                MessageBox.Show($"Error adding book: {ex.Message}", "Error");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedBookId == null)
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

            try
            {
                var book = _context.Books
                    .Include(b => b.Author)
                    .FirstOrDefault(b => b.Id == _selectedBookId.Value);

                if (book == null)
                {
                    MessageBox.Show("Book no longer exists in the database.", "Not Found");
                    ClearFields();
                    LoadBooks();
                    return;
                }

                book.Title = txtTitle.Text.Trim();
                book.ISBN = txtISBN.Text.Trim();
                book.Price = price;

                if (cmbAuthors.SelectedValue is int selectedAuthorId)
                    book.AuthorId = selectedAuthorId;

                var author = _context.Authors.Find(book.AuthorId);
                if (author != null)
                {
                    author.FirstName = txtFirstName.Text.Trim();
                    author.LastName = txtLastName.Text.Trim();
                    author.Bio = txtBio.Text.Trim();
                }

                _context.SaveChanges();
                LoadBooks();
                LoadAuthors();
                ClearFields();
                MessageBox.Show("Book updated successfully.", "Success");
            }
            catch (Exception ex)
            {
                _context.ChangeTracker.Clear();
                MessageBox.Show($"Error updating book: {ex.Message}", "Error");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedBookId == null)
            {
                MessageBox.Show("Please select a book to delete.", "No Selection");
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete this book?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;

            try
            {
                var bookToDelete = _context.Books.Find(_selectedBookId.Value);
                if (bookToDelete == null)
                {
                    MessageBox.Show("Book no longer exists in the database.", "Not Found");
                    ClearFields();
                    LoadBooks();
                    return;
                }

                _context.Books.Remove(bookToDelete);
                _context.SaveChanges();

                ClearFields();
                LoadAuthors();
                LoadBooks();
                MessageBox.Show("Book deleted successfully.", "Success");
            }
            catch (Exception ex)
            {
                _context.ChangeTracker.Clear();
                MessageBox.Show($"Error deleting book: {ex.Message}", "Error");
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
