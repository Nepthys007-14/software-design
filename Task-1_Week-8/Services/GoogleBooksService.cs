using System.Collections.Concurrent;
using System.Text.Json;
using Task_1_Week_8.Models;

namespace Task_1_Week_8.Services
{
    public class GoogleBooksService
    {
        private readonly HttpClient _httpClient;
        private static readonly ConcurrentDictionary<string, (object? Data, DateTime Expiry)> _cache = new();
        private static readonly TimeSpan CacheDuration = TimeSpan.FromMinutes(5);
        private const int MaxRetries = 3;

        public GoogleBooksService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://www.googleapis.com/books/v1/"),
                Timeout = TimeSpan.FromSeconds(15)
            };
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Task-1_Week-8/1.0");
        }

        public static void ClearCache()
        {
            _cache.Clear();
        }

        public async Task<GoogleVolumeInfo?> GetBookByIsbnAsync(string isbn, CancellationToken ct = default)
        {
            var cleanIsbn = new string(isbn.Where(char.IsDigit).ToArray());
            if (string.IsNullOrWhiteSpace(cleanIsbn))
                throw new ArgumentException("Invalid ISBN. Must contain digits.");

            var cacheKey = $"isbn:{cleanIsbn}";
            if (_cache.TryGetValue(cacheKey, out var cached) && cached.Expiry > DateTime.UtcNow)
                return cached.Data as GoogleVolumeInfo;

            for (int attempt = 1; attempt <= MaxRetries; attempt++)
            {
                ct.ThrowIfCancellationRequested();

                var response = await _httpClient.GetAsync(
                    $"volumes?q=isbn:{cleanIsbn}",
                    HttpCompletionOption.ResponseContentRead,
                    ct);

                if (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
                {
                    if (attempt < MaxRetries)
                    {
                        var delay = TimeSpan.FromSeconds(Math.Pow(3, attempt));
                        await Task.Delay(delay, ct);
                        continue;
                    }
                    throw new HttpRequestException("Google Books API rate limit exceeded. Please wait a moment and try again.");
                }

                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync(ct);
                var result = JsonSerializer.Deserialize<GoogleBookResponse>(json);

                var item = result?.Items?.FirstOrDefault();
                var volumeInfo = item?.VolumeInfo;

                _cache[cacheKey] = (volumeInfo, DateTime.UtcNow.Add(CacheDuration));
                return volumeInfo;
            }

            return null;
        }

        public async Task<(List<GoogleBookDisplay> Items, int TotalItems)> SearchBooksByAuthorAsync(
            string author, int startIndex = 0, int maxResults = 10, CancellationToken ct = default)
        {
            var cacheKey = $"author:{author.ToLowerInvariant()}:{startIndex}:{maxResults}";
            if (_cache.TryGetValue(cacheKey, out var cached) && cached.Expiry > DateTime.UtcNow)
                return ((List<GoogleBookDisplay>, int))cached.Data!;

            var encodedQuery = Uri.EscapeDataString(author);

            for (int attempt = 1; attempt <= MaxRetries; attempt++)
            {
                ct.ThrowIfCancellationRequested();

                var response = await _httpClient.GetAsync(
                    $"volumes?q=inauthor:{encodedQuery}&startIndex={startIndex}&maxResults={maxResults}",
                    HttpCompletionOption.ResponseContentRead,
                    ct);

                if (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
                {
                    if (attempt < MaxRetries)
                    {
                        var delay = TimeSpan.FromSeconds(Math.Pow(3, attempt));
                        await Task.Delay(delay, ct);
                        continue;
                    }
                    throw new HttpRequestException("Google Books API rate limit exceeded. Please wait a moment and try again.");
                }

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

                var tuple = (items, totalItems);
                _cache[cacheKey] = (tuple, DateTime.UtcNow.Add(CacheDuration));
                return tuple;
            }

            return (new List<GoogleBookDisplay>(), 0);
        }
    }
}
