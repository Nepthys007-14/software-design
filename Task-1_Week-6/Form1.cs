using Microsoft.EntityFrameworkCore;
using Task_1_Week_6.Data;
using Task_1_Week_6.Models;

namespace Task_1_Week_6
{
    public partial class Form1 : Form
    {
        private BookstoreContext _context;

        public Form1()
        {
            InitializeComponent();
            _context = new BookstoreContext();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _context.Database.EnsureCreated();
        }

        private async void btnFetchBooks_Click(object sender, EventArgs e)
        {
            btnFetchBooks.Enabled = false;
            try
            {
                IProgress<int> progress = new Progress<int>(p =>
                {
                    progressBarOp.Value = p;
                    lblFetchStatus.Text = $"{p}%";
                });

                progress.Report(10);

                var books = await Task.Run(async () =>
                {
                    await Task.Delay(300);
                    progress.Report(40);

                    using var ctx = new BookstoreContext();
                    var result = await ctx.Books
                        .AsNoTracking()
                        .Include(b => b.Author)
                        .OrderBy(b => b.Title)
                        .ToListAsync();

                    progress.Report(80);
                    await Task.Delay(200);

                    return result;
                });

                progress.Report(100);

                listBoxBooks.DataSource = null;
                listBoxBooks.DisplayMember = "DisplayText";
                listBoxBooks.ValueMember = "Id";
                listBoxBooks.DataSource = books
                    .Select(b => new BookDisplay
                    {
                        Id = b.Id,
                        DisplayText = b.Author != null
                            ? $"{b.Title} by {b.Author.FirstName}"
                            : b.Title
                    })
                    .ToList();

                await Task.Delay(500);
                progress.Report(0);
                lblFetchStatus.Text = $"Loaded {books.Count} books";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching books: {ex.Message}", "Error");
                lblFetchStatus.Text = "Error";
            }
            finally
            {
                btnFetchBooks.Enabled = true;
            }
        }

        private async void btnAddBook_Click(object sender, EventArgs e)
        {
            var authorName = txtAuthorName.Text.Trim();
            var bookTitle = txtBookTitle.Text.Trim();

            if (string.IsNullOrWhiteSpace(authorName) || string.IsNullOrWhiteSpace(bookTitle))
            {
                MessageBox.Show("Author name and book title are required.", "Validation Error");
                return;
            }

            btnAddBook.Enabled = false;
            try
            {
                IProgress<int> progress = new Progress<int>(p =>
                {
                    progressBarOp.Value = p;
                    lblFetchStatus.Text = $"{p}%";
                });

                progress.Report(20);

                var author = new Author { FirstName = authorName };

                _context.Authors.Add(author);
                await _context.SaveChangesAsync();
                progress.Report(50);

                var book = new Book
                {
                    Title = bookTitle,
                    AuthorId = author.Id
                };

                _context.Books.Add(book);
                await _context.SaveChangesAsync();
                progress.Report(100);

                txtAuthorName.Clear();
                txtBookTitle.Clear();
                lblFetchStatus.Text = "Book added successfully";

                await Task.Delay(500);
                progress.Report(0);
            }
            catch (Exception ex)
            {
                _context.ChangeTracker.Clear();
                MessageBox.Show($"Error adding book: {ex.Message}", "Error");
            }
            finally
            {
                btnAddBook.Enabled = true;
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtUpdateBookId.Text.Trim(), out var bookId))
            {
                MessageBox.Show("Enter a valid Book ID.", "Validation Error");
                return;
            }

            var newTitle = txtUpdateTitle.Text.Trim();
            var newAuthorName = txtUpdateAuthorName.Text.Trim();

            if (string.IsNullOrWhiteSpace(newTitle) && string.IsNullOrWhiteSpace(newAuthorName))
            {
                MessageBox.Show("Enter a new title or author name.", "Validation Error");
                return;
            }

            btnUpdate.Enabled = false;
            try
            {
                IProgress<int> progress = new Progress<int>(p =>
                {
                    progressBarOp.Value = p;
                    lblFetchStatus.Text = $"{p}%";
                });

                progress.Report(30);

                var book = await _context.Books
                    .Include(b => b.Author)
                    .FirstOrDefaultAsync(b => b.Id == bookId);

                if (book == null)
                {
                    MessageBox.Show("Book not found.", "Not Found");
                    return;
                }

                progress.Report(60);

                if (!string.IsNullOrWhiteSpace(newTitle))
                    book.Title = newTitle;

                if (!string.IsNullOrWhiteSpace(newAuthorName) && book.Author != null)
                    book.Author.FirstName = newAuthorName;

                await _context.SaveChangesAsync();
                progress.Report(100);

                txtUpdateBookId.Clear();
                txtUpdateTitle.Clear();
                txtUpdateAuthorName.Clear();
                lblFetchStatus.Text = "Book updated successfully";

                await Task.Delay(500);
                progress.Report(0);
            }
            catch (Exception ex)
            {
                _context.ChangeTracker.Clear();
                MessageBox.Show($"Error updating book: {ex.Message}", "Error");
            }
            finally
            {
                btnUpdate.Enabled = true;
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtDeleteBookId.Text.Trim(), out var bookId))
            {
                MessageBox.Show("Enter a valid Book ID.", "Validation Error");
                return;
            }

            var confirm = MessageBox.Show(
                $"Delete book with ID {bookId}?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            btnDelete.Enabled = false;
            try
            {
                IProgress<int> progress = new Progress<int>(p =>
                {
                    progressBarOp.Value = p;
                    lblFetchStatus.Text = $"{p}%";
                });

                progress.Report(30);

                var book = await _context.Books.FindAsync(bookId);

                if (book == null)
                {
                    MessageBox.Show("Book not found.", "Not Found");
                    return;
                }

                progress.Report(60);

                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
                progress.Report(100);

                txtDeleteBookId.Clear();
                lblFetchStatus.Text = "Book deleted successfully";

                await Task.Delay(500);
                progress.Report(0);
            }
            catch (Exception ex)
            {
                _context.ChangeTracker.Clear();
                MessageBox.Show($"Error deleting book: {ex.Message}", "Error");
            }
            finally
            {
                btnDelete.Enabled = true;
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var query = txtSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(query))
            {
                MessageBox.Show("Enter a title to search for.", "Validation Error");
                return;
            }

            btnSearch.Enabled = false;
            try
            {
                IProgress<int> progress = new Progress<int>(p =>
                {
                    progressBarOp.Value = p;
                    lblFetchStatus.Text = $"{p}%";
                });

                progress.Report(30);

                var results = await _context.Books
                    .AsNoTracking()
                    .Include(b => b.Author)
                    .Where(b => b.Title.Contains(query))
                    .OrderBy(b => b.Title)
                    .ToListAsync();

                progress.Report(80);

                listBoxBooks.DataSource = null;
                listBoxBooks.DisplayMember = "DisplayText";
                listBoxBooks.ValueMember = "Id";
                listBoxBooks.DataSource = results
                    .Select(b => new BookDisplay
                    {
                        Id = b.Id,
                        DisplayText = b.Author != null
                            ? $"{b.Title} by {b.Author.FirstName}"
                            : b.Title
                    })
                    .ToList();

                progress.Report(100);
                lblFetchStatus.Text = $"Found {results.Count} books";

                await Task.Delay(500);
                progress.Report(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching books: {ex.Message}", "Error");
            }
            finally
            {
                btnSearch.Enabled = true;
            }
        }
    }

    public class BookDisplay
    {
        public int Id { get; set; }
        public string DisplayText { get; set; } = string.Empty;
    }
}
