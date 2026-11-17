using System.Net.Http.Json;
using UniversityExplorerPortal.Models;


namespace UniversityExplorerPortal.Services
{
    public class UniversityService
    {
        private readonly HttpClient _httpClient;
        private const string UniversitiesApiBaseUrl = "http://universities.hipolabs.com/search";

        public UniversityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Retrieves universities filtered by selected country name
        public async Task<List<University>> GetUniversitiesByCountryAsync(string countryName)
        {
            if (string.IsNullOrWhiteSpace(countryName))
                return new List<University>();

            var encodedCountry = Uri.EscapeDataString(countryName);
            var url = $"{UniversitiesApiBaseUrl}?country={encodedCountry}";

            var universities = await _httpClient.GetFromJsonAsync<List<University>>(url);
            return universities ?? new List<University>();
        }
    }
}