using System.Text.Json.Serialization;

namespace Task_1_Week_8.Models
{
    public class GoogleBookResponse
    {
        [JsonPropertyName("kind")]
        public string? Kind { get; set; }

        [JsonPropertyName("totalItems")]
        public int TotalItems { get; set; }

        [JsonPropertyName("items")]
        public List<GoogleBookItem>? Items { get; set; }
    }

    public class GoogleBookItem
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("volumeInfo")]
        public GoogleVolumeInfo? VolumeInfo { get; set; }
    }

    public class GoogleVolumeInfo
    {
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("authors")]
        public List<string>? Authors { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("publishedDate")]
        public string? PublishedDate { get; set; }

        [JsonPropertyName("industryIdentifiers")]
        public List<GoogleIndustryIdentifier>? IndustryIdentifiers { get; set; }

        [JsonPropertyName("pageCount")]
        public int? PageCount { get; set; }

        [JsonPropertyName("categories")]
        public List<string>? Categories { get; set; }

        public string AuthorsDisplay => Authors != null ? string.Join(", ", Authors) : "Unknown";
        public string Isbn13 => IndustryIdentifiers?.FirstOrDefault(i => i.Type == "ISBN_13")?.Identifier
                             ?? IndustryIdentifiers?.FirstOrDefault(i => i.Type == "ISBN_10")?.Identifier
                             ?? "N/A";
    }

    public class GoogleIndustryIdentifier
    {
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("identifier")]
        public string? Identifier { get; set; }
    }

    public class GoogleBookDisplay
    {
        public string? GoogleId { get; set; }
        public string DisplayText { get; set; } = string.Empty;
    }
}
