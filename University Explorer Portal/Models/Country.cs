using System.Text.Json.Serialization;

namespace UniversityExplorerPortal.Models
{
    public class Country
    {
        [JsonPropertyName("name")]
        public object? NameRaw { get; set; }

        [JsonPropertyName("capital")]
        public object? CapitalRaw { get; set; }

        [JsonPropertyName("region")]
        public string Region { get; set; } = string.Empty;

        [JsonPropertyName("population")]
        public long Population { get; set; }

        [JsonPropertyName("flag")]
        public string Flag { get; set; } = string.Empty;

        [JsonPropertyName("flags")]
        public CountryFlags? Flags { get; set; }

        // Helper property to safely extract the country name regardless of JSON structure
        [JsonIgnore]
        public string DisplayName
        {
            get
            {
                if (NameRaw is System.Text.Json.JsonElement element)
                {
                    if (element.ValueKind == System.Text.Json.JsonValueKind.String)
                        return element.GetString() ?? string.Empty;

                    if (element.ValueKind == System.Text.Json.JsonValueKind.Object &&
                        element.TryGetProperty("common", out var commonProp))
                        return commonProp.GetString() ?? string.Empty;
                }
                return NameRaw?.ToString() ?? string.Empty;
            }
        }

        // Helper property to safely extract the capital city
        [JsonIgnore]
        public string DisplayCapital
        {
            get
            {
                if (CapitalRaw is System.Text.Json.JsonElement element)
                {
                    if (element.ValueKind == System.Text.Json.JsonValueKind.String)
                        return element.GetString() ?? "N/A";

                    if (element.ValueKind == System.Text.Json.JsonValueKind.Array && element.GetArrayLength() > 0)
                        return element[0].GetString() ?? "N/A";
                }
                return CapitalRaw?.ToString() ?? "N/A";
            }
        }
    }

    public class CountryFlags
    {
        [JsonPropertyName("png")]
        public string Png { get; set; } = string.Empty;

        [JsonPropertyName("svg")]
        public string Svg { get; set; } = string.Empty;
    }
}
