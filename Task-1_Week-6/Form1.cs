using Microsoft.EntityFrameworkCore;
using Task_1_Week_6.Data;
using Task_1_Week_6.Models;

namespace Task_1_Week_6
{
    public partial class Form1 : Form
    {
        private BookstoreContext _context;
        private int? _selectedBookId;
        private bool _isLoading;
        private List<Book>? _loadedBooks;

        public Form1()
        {
            InitializeComponent();
            _context = new BookstoreContext();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            await LoadAuthorsAsync();
            await LoadBooksAsync();
            toolStripStatusLabel.Text = "Ready";
        }

        private async Task LoadAuthorsAsync()
        {
            _isLoading = true;
            var authors = await _context.Authors.OrderBy(a => a.LastName).ToListAsync();
            cmbAuthors.DataSource = authors;
            cmbAuthors.DisplayMember = "FullName";
            cmbAuthors.ValueMember = "Id";
            _isLoading = false;
        }

        private async Task LoadBooksAsync()
        {
            _loadedBooks = await _context.Books
                .AsNoTracking()
                .Include(b => b.Author)
                .OrderBy(b => b.Title)
                .ToListAsync();

            var displayData = _loadedBooks.Select(b => new
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

            var book = _loadedBooks?.FirstOrDefault(b => b.Id == bookId);
            if (book == null) return;

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

        private void SetControlsEnabled(bool enabled)
        {
            btnAddBook.Enabled = enabled;
            btnAddAuthor.Enabled = enabled;
            btnUpdate.Enabled = enabled;
            btnDelete.Enabled = enabled;
            btnRefresh.Enabled = enabled;
            btnSearch.Enabled = enabled;
        }

        private async void btnAddAuthor_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("First Name and Last Name are required.", "Validation Error");
                return;
            }

            SetControlsEnabled(false);
            progressBarOp.Value = 10;
            toolStripStatusLabel.Text = "Adding author...";
            lblProgressStatus.Text = "Adding author...";

            try
            {
                var author = new Author
                {
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    Bio = txtBio.Text.Trim()
                };

                _context.Authors.Add(author);
                await _context.SaveChangesAsync();

                progressBarOp.Value = 60;
                toolStripStatusLabel.Text = "Refreshing authors...";

                await LoadAuthorsAsync();
                cmbAuthors.SelectedValue = author.Id;

                progressBarOp.Value = 100;
                toolStripStatusLabel.Text = "Author added successfully";
                lblProgressStatus.Text = "Author added successfully";

                await Task.Delay(1000);
                progressBarOp.Value = 0;
                toolStripStatusLabel.Text = "Ready";
                lblProgressStatus.Text = "Ready";
            }
            catch (Exception ex)
            {
                _context.ChangeTracker.Clear();
                progressBarOp.Value = 0;
                toolStripStatusLabel.Text = "Error";
                lblProgressStatus.Text = "Error";
                MessageBox.Show($"Error adding author: {ex.Message}", "Error");
            }
            finally
            {
                SetControlsEnabled(true);
            }
        }

        private async void btnAddBook_Click(object sender, EventArgs e)
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

            SetControlsEnabled(false);
            progressBarOp.Value = 10;
            toolStripStatusLabel.Text = "Adding book...";
            lblProgressStatus.Text = "Adding book...";

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
                await _context.SaveChangesAsync();

                progressBarOp.Value = 60;
                toolStripStatusLabel.Text = "Refreshing data...";

                await LoadBooksAsync();
                ClearFields();

                progressBarOp.Value = 100;
                toolStripStatusLabel.Text = "Book added successfully";
                lblProgressStatus.Text = "Book added successfully";

                await Task.Delay(1000);
                progressBarOp.Value = 0;
                toolStripStatusLabel.Text = "Ready";
                lblProgressStatus.Text = "Ready";
            }
            catch (Exception ex)
            {
                _context.ChangeTracker.Clear();
                progressBarOp.Value = 0;
                toolStripStatusLabel.Text = "Error";
                lblProgressStatus.Text = "Error";
                MessageBox.Show($"Error adding book: {ex.Message}", "Error");
            }
            finally
            {
                SetControlsEnabled(true);
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
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

            SetControlsEnabled(false);
            progressBarOp.Value = 10;
            toolStripStatusLabel.Text = "Updating book...";
            lblProgressStatus.Text = "Updating book...";

            try
            {
                var book = await _context.Books
                    .Include(b => b.Author)
                    .FirstOrDefaultAsync(b => b.Id == _selectedBookId.Value);

                if (book == null)
                {
                    MessageBox.Show("Book no longer exists in the database.", "Not Found");
                    ClearFields();
                    await LoadBooksAsync();
                    progressBarOp.Value = 0;
                    toolStripStatusLabel.Text = "Ready";
                    lblProgressStatus.Text = "Ready";
                    return;
                }

                book.Title = txtTitle.Text.Trim();
                book.ISBN = txtISBN.Text.Trim();
                book.Price = price;

                if (cmbAuthors.SelectedValue is int selectedAuthorId)
                    book.AuthorId = selectedAuthorId;

                var author = await _context.Authors.FindAsync(book.AuthorId);
                if (author != null)
                {
                    author.FirstName = txtFirstName.Text.Trim();
                    author.LastName = txtLastName.Text.Trim();
                    author.Bio = txtBio.Text.Trim();
                }

                await _context.SaveChangesAsync();

                progressBarOp.Value = 60;
                toolStripStatusLabel.Text = "Refreshing data...";

                await LoadBooksAsync();
                await LoadAuthorsAsync();
                ClearFields();

                progressBarOp.Value = 100;
                toolStripStatusLabel.Text = "Book updated successfully";
                lblProgressStatus.Text = "Book updated successfully";

                await Task.Delay(1000);
                progressBarOp.Value = 0;
                toolStripStatusLabel.Text = "Ready";
                lblProgressStatus.Text = "Ready";
            }
            catch (Exception ex)
            {
                _context.ChangeTracker.Clear();
                progressBarOp.Value = 0;
                toolStripStatusLabel.Text = "Error";
                lblProgressStatus.Text = "Error";
                MessageBox.Show($"Error updating book: {ex.Message}", "Error");
            }
            finally
            {
                SetControlsEnabled(true);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedBookId == null)
            {
                MessageBox.Show("Please select a book to delete.", "No Selection");
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete this book?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;

            SetControlsEnabled(false);
            progressBarOp.Value = 10;
            toolStripStatusLabel.Text = "Deleting book...";
            lblProgressStatus.Text = "Deleting book...";

            try
            {
                var bookToDelete = await _context.Books.FindAsync(_selectedBookId.Value);
                if (bookToDelete == null)
                {
                    MessageBox.Show("Book no longer exists in the database.", "Not Found");
                    ClearFields();
                    await LoadBooksAsync();
                    progressBarOp.Value = 0;
                    toolStripStatusLabel.Text = "Ready";
                    lblProgressStatus.Text = "Ready";
                    return;
                }

                _context.Books.Remove(bookToDelete);
                await _context.SaveChangesAsync();

                progressBarOp.Value = 60;
                toolStripStatusLabel.Text = "Refreshing data...";

                ClearFields();
                await LoadAuthorsAsync();
                await LoadBooksAsync();

                progressBarOp.Value = 100;
                toolStripStatusLabel.Text = "Book deleted successfully";
                lblProgressStatus.Text = "Book deleted successfully";

                await Task.Delay(1000);
                progressBarOp.Value = 0;
                toolStripStatusLabel.Text = "Ready";
                lblProgressStatus.Text = "Ready";
            }
            catch (Exception ex)
            {
                _context.ChangeTracker.Clear();
                progressBarOp.Value = 0;
                toolStripStatusLabel.Text = "Error";
                lblProgressStatus.Text = "Error";
                MessageBox.Show($"Error deleting book: {ex.Message}", "Error");
            }
            finally
            {
                SetControlsEnabled(true);
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            SetControlsEnabled(false);
            progressBarOp.Value = 30;
            toolStripStatusLabel.Text = "Refreshing...";
            lblProgressStatus.Text = "Refreshing...";

            try
            {
                _context.ChangeTracker.Clear();
                await LoadAuthorsAsync();

                progressBarOp.Value = 60;

                await LoadBooksAsync();
                ClearFields();

                progressBarOp.Value = 100;
                toolStripStatusLabel.Text = "Data refreshed";
                lblProgressStatus.Text = "Data refreshed";

                await Task.Delay(800);
                progressBarOp.Value = 0;
                toolStripStatusLabel.Text = "Ready";
                lblProgressStatus.Text = "Ready";
            }
            catch (Exception ex)
            {
                progressBarOp.Value = 0;
                toolStripStatusLabel.Text = "Error";
                lblProgressStatus.Text = "Error";
                MessageBox.Show($"Error refreshing data: {ex.Message}", "Error");
            }
            finally
            {
                SetControlsEnabled(true);
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var query = txtSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(query))
            {
                await LoadBooksAsync();
                toolStripStatusLabel.Text = "Showing all books";
                return;
            }

            SetControlsEnabled(false);
            progressBarOp.Value = 20;
            toolStripStatusLabel.Text = "Searching...";
            lblProgressStatus.Text = "Searching...";

            try
            {
                var results = await _context.Books
                    .AsNoTracking()
                    .Include(b => b.Author)
                    .Where(b => b.Title.Contains(query))
                    .OrderBy(b => b.Title)
                    .ToListAsync();

                progressBarOp.Value = 70;

                var displayData = results.Select(b => new
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

                progressBarOp.Value = 100;
                toolStripStatusLabel.Text = $"Found {results.Count} books";
                lblProgressStatus.Text = $"Found {results.Count} books";

                await Task.Delay(1000);
                progressBarOp.Value = 0;
                toolStripStatusLabel.Text = "Ready";
                lblProgressStatus.Text = "Ready";
            }
            catch (Exception ex)
            {
                progressBarOp.Value = 0;
                toolStripStatusLabel.Text = "Error";
                lblProgressStatus.Text = "Error";
                MessageBox.Show($"Error searching books: {ex.Message}", "Error");
            }
            finally
            {
                SetControlsEnabled(true);
            }
        }
    }
}
