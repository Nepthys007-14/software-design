using System.Text.Json;
using Task_1_Week_8.Models;

namespace Task_1_Week_8.Services
{
    public class GoogleBooksService
    {
        private readonly HttpClient _httpClient;

        public GoogleBooksService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://www.googleapis.com/books/v1/"),
                Timeout = TimeSpan.FromSeconds(10)
            };
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Task-1_Week-8/1.0");
        }

        public async Task<GoogleVolumeInfo?> GetBookByIsbnAsync(string isbn, CancellationToken ct = default)
        {
            var cleanIsbn = new string(isbn.Where(char.IsDigit).ToArray());
            if (string.IsNullOrWhiteSpace(cleanIsbn))
                throw new ArgumentException("Invalid ISBN. Must contain digits.");

            var response = await _httpClient.GetAsync(
                $"volumes?q=isbn:{cleanIsbn}",
                HttpCompletionOption.ResponseContentRead,
                ct);

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync(ct);
            var result = JsonSerializer.Deserialize<GoogleBookResponse>(json);

            var item = result?.Items?.FirstOrDefault();
            return item?.VolumeInfo;
        }

        public async Task<(List<GoogleBookDisplay> Items, int TotalItems)> SearchBooksByAuthorAsync(
            string author, int startIndex = 0, int maxResults = 10, CancellationToken ct = default)
        {
            var encodedQuery = Uri.EscapeDataString(author);
            var response = await _httpClient.GetAsync(
                $"volumes?q=inauthor:{encodedQuery}&startIndex={startIndex}&maxResults={maxResults}",
                HttpCompletionOption.ResponseContentRead,
                ct);

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync(ct);
            var result = JsonSerializer.Deserialize<GoogleBookResponse>(json);

            var totalItems = result?.TotalItems ?? 0;
            var items = result?.Items?
                .Where(i => i?.VolumeInfo?.Title != null)
                .Select(i => new GoogleBookDisplay
                {
                    GoogleId = i?.Id,
                    DisplayText = $"{i?.VolumeInfo?.Title} ({i?.VolumeInfo?.PublishedDate?.Substring(0, 4) ?? "N/A"})"
                })
                .ToList() ?? new List<GoogleBookDisplay>();

            return (items, totalItems);
        }
    }
}
