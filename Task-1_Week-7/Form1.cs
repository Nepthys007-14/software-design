using Microsoft.EntityFrameworkCore;
using Task_1_Week_7.Data;
using Task_1_Week_7.Models;

namespace Task_1_Week_7
{
    public partial class Form1 : Form
    {
        private BookstoreContext _context;
        private const int PageSize = 10;
        private int _currentPage = 1;
        private int _totalPages = 1;
        private List<Book>? _loadedPage;
        private bool _isLoading;

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
            await LoadPageAsync(1);
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

        private async Task LoadPageAsync(int page)
        {
            _isLoading = true;
            try
            {
                var totalCount = await _context.Books.CountAsync();
                _totalPages = Math.Max(1, (int)Math.Ceiling((double)totalCount / PageSize));
                _currentPage = Math.Clamp(page, 1, _totalPages);

                _loadedPage = await _context.Books
                    .AsNoTracking()
                    .Include(b => b.Author)
                    .OrderBy(b => b.Title)
                    .Skip((_currentPage - 1) * PageSize)
                    .Take(PageSize)
                    .ToListAsync();

                listBoxBooks.DataSource = null;
                listBoxBooks.DisplayMember = "DisplayText";
                listBoxBooks.ValueMember = "Id";
                listBoxBooks.DataSource = _loadedPage
                    .Select(b => new BookDisplay
                    {
                        Id = b.Id,
                        DisplayText = b.Author != null
                            ? $"{b.Title} by {b.Author.FirstName} {b.Author.LastName}"
                            : b.Title
                    })
                    .ToList();

                lblPageNumber.Text = _totalPages > 0
                    ? $"Page {_currentPage} of {_totalPages}"
                    : "Page 0 of 0";
                btnPreviousPage.Enabled = _currentPage > 1;
                btnNextPage.Enabled = _currentPage < _totalPages;
            }
            finally
            {
                _isLoading = false;
            }
        }

        private async void btnFetchBooks_Click(object sender, EventArgs e)
        {
            SetControlsEnabled(false);
            progressBarOp.Value = 30;
            toolStripStatusLabel.Text = "Loading books...";
            lblStatus.Text = "Loading...";

            try
            {
                await LoadPageAsync(1);
                progressBarOp.Value = 100;
                toolStripStatusLabel.Text = $"Loaded page 1 of {_totalPages}";
                lblStatus.Text = "Loaded";
                await Task.Delay(800);
                progressBarOp.Value = 0;
                toolStripStatusLabel.Text = "Ready";
                lblStatus.Text = "Ready";
            }
            catch (Exception ex)
            {
                progressBarOp.Value = 0;
                toolStripStatusLabel.Text = "Error";
                lblStatus.Text = "Error";
                MessageBox.Show($"Error loading books: {ex.Message}", "Error");
            }
            finally
            {
                SetControlsEnabled(true);
            }
        }

        private async void btnPreviousPage_Click(object sender, EventArgs e)
        {
            if (_isLoading || _currentPage <= 1) return;
            await LoadPageAsync(_currentPage - 1);
        }

        private async void btnNextPage_Click(object sender, EventArgs e)
        {
            if (_isLoading || _currentPage >= _totalPages) return;
            await LoadPageAsync(_currentPage + 1);
        }

        // Task 4 (Challenge): Async Search with Error Handling
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var query = txtSearch.Text.Trim();
            if (string.IsNullOrWhiteSpace(query))
            {
                MessageBox.Show("Enter a title to search for.", "Validation Error");
                return;
            }

            SetControlsEnabled(false);
            progressBarOp.Value = 10;
            toolStripStatusLabel.Text = "Searching...";
            lblStatus.Text = "Searching...";

            try
            {
                var results = await _context.Books
                    .AsNoTracking()
                    .Include(b => b.Author)
                    .Where(b => b.Title.Contains(query))
                    .OrderBy(b => b.Title)
                    .ToListAsync();

                progressBarOp.Value = 70;

                listBoxBooks.DataSource = null;
                listBoxBooks.DisplayMember = "DisplayText";
                listBoxBooks.ValueMember = "Id";
                listBoxBooks.DataSource = results
                    .Select(b => new BookDisplay
                    {
                        Id = b.Id,
                        DisplayText = b.Author != null
                            ? $"{b.Title} by {b.Author.FirstName} {b.Author.LastName}"
                            : b.Title
                    })
                    .ToList();

                lblPageNumber.Text = $"Search: {results.Count} results";

                progressBarOp.Value = 100;
                toolStripStatusLabel.Text = $"Found {results.Count} books";
                lblStatus.Text = $"Found {results.Count} books";

                await Task.Delay(1000);
                progressBarOp.Value = 0;
                toolStripStatusLabel.Text = "Ready";
                lblStatus.Text = "Ready";
            }
            catch (Exception ex)
            {
                progressBarOp.Value = 0;
                toolStripStatusLabel.Text = "Search error";
                lblStatus.Text = "Error";
                MessageBox.Show($"Error searching books: {ex.Message}", "Error");
            }
            finally
            {
                SetControlsEnabled(true);
            }
        }

        // Task 2: SaveBookAsync with proper error handling
        private async Task SaveBookAsync(Book book)
        {
            try
            {
                _context.Books.Add(book);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                _context.ChangeTracker.Clear();
                throw new InvalidOperationException(
                    $"Failed to save book '{book.Title}': {ex.InnerException?.Message ?? ex.Message}");
            }
            catch (Exception ex)
            {
                _context.ChangeTracker.Clear();
                throw new InvalidOperationException(
                    $"Unexpected error saving book '{book.Title}': {ex.Message}");
            }
        }

        // Task 3: Asynchronous File Export
        private async void btnExportBooks_Click(object sender, EventArgs e)
        {
            SetControlsEnabled(false);
            progressBarOp.Value = 10;
            toolStripStatusLabel.Text = "Exporting books...";
            lblStatus.Text = "Exporting...";

            try
            {
                var books = await _context.Books
                    .AsNoTracking()
                    .Include(b => b.Author)
                    .OrderBy(b => b.Title)
                    .ToListAsync();

                progressBarOp.Value = 50;

                var exportPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    "books_export.txt");

                using var writer = new StreamWriter(exportPath, false);
                await writer.WriteLineAsync("ID|Title|ISBN|Price|Author");

                foreach (var book in books)
                {
                    var authorName = book.Author != null
                        ? $"{book.Author.FirstName} {book.Author.LastName}"
                        : "Unknown";
                    var line = $"{book.Id}|{book.Title}|{book.ISBN}|{book.Price:F2}|{authorName}";
                    await writer.WriteLineAsync(line);
                }

                progressBarOp.Value = 100;
                toolStripStatusLabel.Text = $"Exported {books.Count} books";
                lblStatus.Text = $"Exported {books.Count} books";

                MessageBox.Show(
                    $"Successfully exported {books.Count} books to:\n{exportPath}",
                    "Export Complete");
            }
            catch (Exception ex)
            {
                progressBarOp.Value = 0;
                toolStripStatusLabel.Text = "Export error";
                lblStatus.Text = "Export error";
                MessageBox.Show($"Error exporting books: {ex.Message}", "Error");
            }
            finally
            {
                await Task.Delay(1000);
                progressBarOp.Value = 0;
                toolStripStatusLabel.Text = "Ready";
                lblStatus.Text = "Ready";
                SetControlsEnabled(true);
            }
        }

        // Task 4 (Challenge): Asynchronous Data Import
        private async void btnImportBooks_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                Title = "Select a book data file to import"
            };

            if (dialog.ShowDialog() != DialogResult.OK) return;

            SetControlsEnabled(false);
            progressBarOp.Value = 10;
            toolStripStatusLabel.Text = "Importing books...";
            lblStatus.Text = "Importing...";

            var importedCount = 0;
            var errorCount = 0;

            try
            {
                var lines = await File.ReadAllLinesAsync(dialog.FileName);
                var totalLines = lines.Length;

                for (int i = 0; i < lines.Length; i++)
                {
                    var line = lines[i].Trim();
                    if (string.IsNullOrWhiteSpace(line) || line.StartsWith("ID|")) continue;

                    try
                    {
                        var parts = line.Split('|');
                        if (parts.Length < 2)
                        {
                            errorCount++;
                            continue;
                        }

                        var title = parts[1].Trim();
                        var isbn = parts.Length > 2 ? parts[2].Trim() : null;
                        var authorName = parts.Length > 4 ? parts[4].Trim() : "Unknown Author";

                        var nameParts = authorName.Split(' ', 2);
                        var firstName = nameParts[0];
                        var lastName = nameParts.Length > 1 ? nameParts[1] : "";

                        var author = await _context.Authors
                            .FirstOrDefaultAsync(a => a.FirstName == firstName && a.LastName == lastName);

                        if (author == null)
                        {
                            author = new Author { FirstName = firstName, LastName = lastName };
                            _context.Authors.Add(author);
                            await _context.SaveChangesAsync();
                        }

                        decimal price = 0;
                        if (parts.Length > 3 && decimal.TryParse(parts[3], out var parsedPrice))
                            price = parsedPrice;

                        var book = new Book
                        {
                            Title = title,
                            ISBN = isbn,
                            Price = price,
                            AuthorId = author.Id
                        };

                        await SaveBookAsync(book);
                        importedCount++;
                    }
                    catch
                    {
                        errorCount++;
                    }

                    var progress = 10 + (int)((double)(i + 1) / totalLines * 70);
                    progressBarOp.Value = Math.Min(progress, 80);
                    toolStripStatusLabel.Text = $"Importing... {importedCount} OK, {errorCount} errors";
                }

                progressBarOp.Value = 90;
                await LoadPageAsync(1);

                progressBarOp.Value = 100;
                toolStripStatusLabel.Text = $"Import done: {importedCount} imported, {errorCount} errors";
                lblStatus.Text = $"{importedCount} imported, {errorCount} errors";

                MessageBox.Show(
                    $"Import complete!\nSuccessfully imported: {importedCount}\nErrors: {errorCount}",
                    "Import Complete");
            }
            catch (Exception ex)
            {
                progressBarOp.Value = 0;
                toolStripStatusLabel.Text = "Import error";
                lblStatus.Text = "Import error";
                MessageBox.Show($"Error importing books: {ex.Message}", "Error");
            }
            finally
            {
                await Task.Delay(1000);
                progressBarOp.Value = 0;
                toolStripStatusLabel.Text = "Ready";
                lblStatus.Text = "Ready";
                SetControlsEnabled(true);
            }
        }

        private void SetControlsEnabled(bool enabled)
        {
            btnFetchBooks.Enabled = enabled;
            btnPreviousPage.Enabled = enabled && _currentPage > 1;
            btnNextPage.Enabled = enabled && _currentPage < _totalPages;
            btnSearch.Enabled = enabled;
            btnExportBooks.Enabled = enabled;
            btnImportBooks.Enabled = enabled;
        }
    }
}
