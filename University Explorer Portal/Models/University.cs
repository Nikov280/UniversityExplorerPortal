using System.Text.Json.Serialization;

namespace UniversityExplorerPortal.Models
{
    public class University
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("country")]
        public string Country { get; set; } = string.Empty;

        [JsonPropertyName("alpha_two_code")]
        public string AlphaTwoCode { get; set; } = string.Empty;

        [JsonPropertyName("web_pages")]
        public List<string> WebPages { get; set; } = new();

        [JsonPropertyName("domains")]
        public List<string> Domains { get; set; } = new();

        [JsonPropertyName("state-province")]
        public string? StateProvince { get; set; }

        // Convenience properties for displaying primary website and domain
        [JsonIgnore]
        public string PrimaryWebsite => WebPages.FirstOrDefault() ?? "N/A";

        [JsonIgnore]
        public string PrimaryDomain => Domains.FirstOrDefault() ?? "N/A";
    }
}