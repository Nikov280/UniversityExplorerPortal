using System.Net.Http.Json;
using UniversityExplorerPortal.Models;

namespace UniversityExplorerPortal.Services
{
    public class CountryService
    {
        private readonly HttpClient _httpClient;
        private const string CountriesApiUrl = "https://countries.dev/countries";

        public CountryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Retrieves all countries sorted alphabetically by display name
        public async Task<List<Country>> GetCountriesAsync()
        {
            var countries = await _httpClient.GetFromJsonAsync<List<Country>>(CountriesApiUrl);
            return countries?
                .Where(c => !string.IsNullOrWhiteSpace(c.DisplayName))
                .OrderBy(c => c.DisplayName)
                .ToList() ?? new List<Country>();
        }
    }
}