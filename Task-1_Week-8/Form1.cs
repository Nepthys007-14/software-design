using Microsoft.EntityFrameworkCore;
using Task_1_Week_8.Data;
using Task_1_Week_8.Models;
using Task_1_Week_8.Services;

namespace Task_1_Week_8
{
    public partial class Form1 : Form
    {
        private BookstoreContext _context;
        private int? _selectedBookId;
        private bool _isLoading;
        private List<Book>? _loadedBooks;

        private readonly GoogleBooksService _googleApi = new();
        private int _apiStartIndex = 0;
        private int _apiTotalItems = 0;
        private string _apiLastAuthor = "";
        private const int ApiPageSize = 10;

        public Form1()
        {
            InitializeComponent();
            _context = new BookstoreContext();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            await SeedDataAsync();
            await LoadAuthorsAsync();
            await LoadBooksAsync();
            toolStripStatusLabel.Text = "Ready";
        }

        private async Task SeedDataAsync()
        {
            if (await _context.Books.AnyAsync()) return;

            var authors = new[]
            {
                new Author { FirstName = "J.K.", LastName = "Rowling", Bio = "British author" },
                new Author { FirstName = "George", LastName = "Orwell", Bio = "English novelist" },
                new Author { FirstName = "Jane", LastName = "Austen", Bio = "English novelist" },
                new Author { FirstName = "Ernest", LastName = "Hemingway", Bio = "American author" },
                new Author { FirstName = "Harper", LastName = "Lee", Bio = "American novelist" },
            };
            _context.Authors.AddRange(authors);
            await _context.SaveChangesAsync();

            var titles = new[]
            {
                "Harry Potter and the Sorcerer's Stone", "1984", "Pride and Prejudice",
                "The Old Man and the Sea", "To Kill a Mockingbird", "Harry Potter and the Chamber of Secrets",
                "Animal Farm", "Sense and Sensibility", "For Whom the Bell Tolls", "Go Set a Watchman",
                "Harry Potter and the Prisoner of Azkaban", "Down and Out in Paris and London",
                "Emma", "A Farewell to Arms", "The Catcher in the Rye",
                "Harry Potter and the Goblet of Fire", "Homage to Catalonia",
                "Mansfield Park", "The Sun Also Rises", "Lord of the Flies",
                "Harry Potter and the Order of the Phoenix", "The Road to Wigan Pier",
                "Northanger Abbey", "Death in the Afternoon", "Brave New World",
                "Harry Potter and the Half-Blood Prince", "Burmese Days",
                "Persuasion", "The Green Hills of Africa", "Fahrenheit 451",
            };

            var rng = new Random();
            var books = new List<Book>();
            for (int i = 0; i < titles.Length; i++)
            {
                books.Add(new Book
                {
                    Title = titles[i],
                    ISBN = $"978-0-{rng.Next(100, 999)}-{rng.Next(10000, 99999)}",
                    Price = Math.Round((decimal)(rng.NextDouble() * 50 + 5), 2),
                    AuthorId = authors[i % authors.Length].Id
                });
            }
            _context.Books.AddRange(books);
            await _context.SaveChangesAsync();
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

        private void cmbAuthors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoading || cmbAuthors.SelectedItem is not Author author) return;
            txtFirstName.Text = author.FirstName;
            txtLastName.Text = author.LastName;
            txtBio.Text = author.Bio;
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
            btnFetchBook.Enabled = enabled;
            btnAuthorSearch.Enabled = enabled;
            btnClearCache.Enabled = enabled;
        }

        // ========== CRUD Operations (Week 6 style) ==========

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
                await LoadAuthorsAsync();
                cmbAuthors.SelectedValue = author.Id;

                progressBarOp.Value = 100;
                toolStripStatusLabel.Text = "Author added";
                lblProgressStatus.Text = "Author added";
                await Task.Delay(800);
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
                MessageBox.Show("Select an author first.", "Validation Error");
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
                await LoadBooksAsync();
                ClearFields();

                progressBarOp.Value = 100;
                toolStripStatusLabel.Text = "Book added";
                lblProgressStatus.Text = "Book added";
                await Task.Delay(800);
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
                MessageBox.Show("Select a book to update.", "No Selection");
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
            toolStripStatusLabel.Text = "Updating...";
            lblProgressStatus.Text = "Updating...";

            try
            {
                var book = await _context.Books
                    .Include(b => b.Author)
                    .FirstOrDefaultAsync(b => b.Id == _selectedBookId.Value);

                if (book == null)
                {
                    MessageBox.Show("Book not found.", "Not Found");
                    ClearFields();
                    await LoadBooksAsync();
                    return;
                }

                book.Title = txtTitle.Text.Trim();
                book.ISBN = txtISBN.Text.Trim();
                book.Price = price;
                if (cmbAuthors.SelectedValue is int aid)
                    book.AuthorId = aid;

                var author = await _context.Authors.FindAsync(book.AuthorId);
                if (author != null)
                {
                    author.FirstName = txtFirstName.Text.Trim();
                    author.LastName = txtLastName.Text.Trim();
                    author.Bio = txtBio.Text.Trim();
                }

                await _context.SaveChangesAsync();
                progressBarOp.Value = 60;
                await LoadBooksAsync();
                await LoadAuthorsAsync();
                ClearFields();

                progressBarOp.Value = 100;
                toolStripStatusLabel.Text = "Book updated";
                lblProgressStatus.Text = "Book updated";
                await Task.Delay(800);
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
                MessageBox.Show($"Error updating: {ex.Message}", "Error");
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
                MessageBox.Show("Select a book to delete.", "No Selection");
                return;
            }

            var confirm = MessageBox.Show("Delete this book?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            SetControlsEnabled(false);
            progressBarOp.Value = 10;
            toolStripStatusLabel.Text = "Deleting...";
            lblProgressStatus.Text = "Deleting...";

            try
            {
                var book = await _context.Books.FindAsync(_selectedBookId.Value);
                if (book == null)
                {
                    MessageBox.Show("Book not found.", "Not Found");
                    ClearFields();
                    await LoadBooksAsync();
                    return;
                }
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();

                progressBarOp.Value = 60;
                ClearFields();
                await LoadAuthorsAsync();
                await LoadBooksAsync();

                progressBarOp.Value = 100;
                toolStripStatusLabel.Text = "Book deleted";
                lblProgressStatus.Text = "Book deleted";
                await Task.Delay(800);
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
                MessageBox.Show($"Error deleting: {ex.Message}", "Error");
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
                toolStripStatusLabel.Text = "Refreshed";
                lblProgressStatus.Text = "Refreshed";
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
                MessageBox.Show($"Error: {ex.Message}", "Error");
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
                var display = results.Select(b => new
                {
                    b.Id, b.Title, b.ISBN, b.Price,
                    Author = b.Author != null ? $"{b.Author.FirstName} {b.Author.LastName}" : ""
                }).ToList();

                dgvBooks.DataSource = null;
                dgvBooks.DataSource = display;
                if (dgvBooks.Columns["Id"] != null)
                    dgvBooks.Columns["Id"]!.Visible = false;

                progressBarOp.Value = 100;
                toolStripStatusLabel.Text = $"Found {results.Count} books";
                lblProgressStatus.Text = $"Found {results.Count} books";
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
                MessageBox.Show($"Error: {ex.Message}", "Error");
            }
            finally
            {
                SetControlsEnabled(true);
            }
        }

        // ========== Google Books API (Tasks 1-3) ==========

        private async void btnFetchBook_Click(object sender, EventArgs e)
        {
            var isbn = txtApiIsbn.Text.Trim();
            if (string.IsNullOrWhiteSpace(isbn))
            {
                MessageBox.Show("Enter an ISBN.", "Validation Error");
                return;
            }

            txtBookDetails.Clear();
            SetControlsEnabled(false);
            progressBarOp.Value = 10;
            toolStripStatusLabel.Text = "Fetching from Google Books...";
            lblProgressStatus.Text = "Fetching...";

            try
            {
                var book = await _googleApi.GetBookByIsbnAsync(isbn);

                if (book == null)
                {
                    txtBookDetails.Text = "No book found for this ISBN.";
                    progressBarOp.Value = 0;
                    toolStripStatusLabel.Text = "No results";
                    lblProgressStatus.Text = "No results";
                    return;
                }

                progressBarOp.Value = 70;

                var details = $"Title: {book.Title}\r\n"
                    + $"Author(s): {book.AuthorsDisplay}\r\n"
                    + $"ISBN-13: {book.Isbn13}\r\n"
                    + $"Published: {book.PublishedDate ?? "N/A"}\r\n"
                    + $"Pages: {book.PageCount?.ToString() ?? "N/A"}\r\n"
                    + $"Categories: {(book.Categories != null ? string.Join(", ", book.Categories) : "N/A")}\r\n"
                    + $"\r\nDescription:\r\n{book.Description ?? "No description available."}";

                txtBookDetails.Text = details;

                progressBarOp.Value = 100;
                toolStripStatusLabel.Text = $"Fetched: {book.Title}";
                lblProgressStatus.Text = "Fetched successfully";
                await Task.Delay(800);
                progressBarOp.Value = 0;
                toolStripStatusLabel.Text = "Ready";
                lblProgressStatus.Text = "Ready";
            }
            catch (ArgumentException ex)
            {
                txtBookDetails.Text = $"Validation error: {ex.Message}";
                progressBarOp.Value = 0;
                toolStripStatusLabel.Text = "Invalid input";
                lblProgressStatus.Text = "Error";
                MessageBox.Show(ex.Message, "Invalid Input");
            }
            catch (TaskCanceledException)
            {
                txtBookDetails.Text = "Request timed out. The Google Books API did not respond within 10 seconds.";
                progressBarOp.Value = 0;
                toolStripStatusLabel.Text = "Timeout";
                lblProgressStatus.Text = "Timeout";
                MessageBox.Show("The request timed out. Please check your internet connection and try again.", "Timeout");
            }
            catch (HttpRequestException ex)
            {
                txtBookDetails.Text = $"Network error: {ex.Message}";
                progressBarOp.Value = 0;
                toolStripStatusLabel.Text = "Network error";
                lblProgressStatus.Text = "Network error";
                MessageBox.Show($"Could not reach Google Books API.\n{ex.Message}", "Network Error");
            }
            catch (Exception ex)
            {
                txtBookDetails.Text = $"Unexpected error: {ex.Message}";
                progressBarOp.Value = 0;
                toolStripStatusLabel.Text = "Error";
                lblProgressStatus.Text = "Error";
                MessageBox.Show($"Error fetching book: {ex.Message}", "Error");
            }
            finally
            {
                SetControlsEnabled(true);
            }
        }

        private async void btnAuthorSearch_Click(object sender, EventArgs e)
        {
            var author = txtAuthorSearch.Text.Trim();
            if (string.IsNullOrWhiteSpace(author))
            {
                MessageBox.Show("Enter an author name.", "Validation Error");
                return;
            }

            _apiLastAuthor = author;
            _apiStartIndex = 0;
            await SearchByAuthorAsync();
        }

        private async void btnApiPrevPage_Click(object sender, EventArgs e)
        {
            if (_apiStartIndex < ApiPageSize) return;
            _apiStartIndex -= ApiPageSize;
            await SearchByAuthorAsync();
        }

        private async void btnApiNextPage_Click(object sender, EventArgs e)
        {
            _apiStartIndex += ApiPageSize;
            await SearchByAuthorAsync();
        }

        private async Task SearchByAuthorAsync()
        {
            if (string.IsNullOrWhiteSpace(_apiLastAuthor)) return;

            SetControlsEnabled(false);
            progressBarOp.Value = 10;
            toolStripStatusLabel.Text = $"Searching author: {_apiLastAuthor}...";
            lblProgressStatus.Text = "Searching API...";

            try
            {
                var (items, totalItems) = await _googleApi.SearchBooksByAuthorAsync(
                    _apiLastAuthor, _apiStartIndex, ApiPageSize);

                progressBarOp.Value = 70;

                _apiTotalItems = totalItems;
                listBoxApiResults.DataSource = null;
                listBoxApiResults.DisplayMember = "DisplayText";
                listBoxApiResults.ValueMember = "GoogleId";
                listBoxApiResults.DataSource = items;

                var currentPage = _apiTotalItems > 0 ? (_apiStartIndex / ApiPageSize) + 1 : 0;
                var totalPages = _apiTotalItems > 0
                    ? (int)Math.Ceiling((double)_apiTotalItems / ApiPageSize)
                    : 0;
                lblApiPageNumber.Text = $"Pg {currentPage}/{totalPages}";
                btnApiPrevPage.Enabled = _apiStartIndex >= ApiPageSize;
                btnApiNextPage.Enabled = _apiStartIndex + ApiPageSize < _apiTotalItems;

                progressBarOp.Value = 100;
                toolStripStatusLabel.Text = $"Found {totalItems} books";
                lblProgressStatus.Text = $"{items.Count} shown";
                await Task.Delay(800);
                progressBarOp.Value = 0;
                toolStripStatusLabel.Text = "Ready";
                lblProgressStatus.Text = "Ready";
            }
            catch (TaskCanceledException)
            {
                progressBarOp.Value = 0;
                toolStripStatusLabel.Text = "Timeout";
                lblProgressStatus.Text = "Timeout";
                MessageBox.Show("API request timed out.", "Timeout");
            }
            catch (HttpRequestException ex)
            {
                progressBarOp.Value = 0;
                toolStripStatusLabel.Text = "Network error";
                lblProgressStatus.Text = "Error";
                MessageBox.Show($"Could not reach Google Books API.\n{ex.Message}", "Network Error");
            }
            catch (Exception ex)
            {
                progressBarOp.Value = 0;
                toolStripStatusLabel.Text = "Error";
                lblProgressStatus.Text = "Error";
                MessageBox.Show($"Error: {ex.Message}", "Error");
            }
            finally
            {
                SetControlsEnabled(true);
            }
        }

        private void btnClearCache_Click(object? sender, EventArgs e)
        {
            GoogleBooksService.ClearCache();
            toolStripStatusLabel.Text = "API cache cleared";
            lblProgressStatus.Text = "Cache cleared";
            MessageBox.Show("Google Books API cache has been cleared.", "Cache Cleared");
        }
    }
}
