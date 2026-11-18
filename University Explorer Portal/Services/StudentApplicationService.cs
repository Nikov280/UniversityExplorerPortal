using System.Net.Http.Json;
using UniversityExplorerPortal.Models;

namespace UniversityExplorerPortal.Services
{
    public class StudentApplicationService
    {
        private readonly HttpClient _httpClient;
        private const string BaseApiUrl = "https://edutots.net/api/studentapplication";

        public StudentApplicationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: Retrieve all student applications
        public async Task<List<StudentApplication>> GetApplicationsAsync()
        {
            var applications = await _httpClient.GetFromJsonAsync<List<StudentApplication>>(BaseApiUrl);
            return applications ?? new List<StudentApplication>();
        }

        // GET: Retrieve a single student application by ID
        public async Task<StudentApplication?> GetApplicationByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<StudentApplication>($"{BaseApiUrl}/{id}");
        }

        // POST: Create a new student application
        public async Task<(bool Success, string ErrorMessage)> CreateApplicationAsync(StudentApplication application)
        {
            var payload = new
            {
                studentName = application.StudentName,
                email = application.Email,
                country = application.Country,
                university = application.UniversityName,
                course = application.CourseName,
                personalStatement = application.PersonalStatement,
                applicationDate = application.ApplicationDate.ToString("yyyy-MM-ddTHH:mm:ss")
            };

            var response = await _httpClient.PostAsJsonAsync(BaseApiUrl, payload);
            if (response.IsSuccessStatusCode)
            {
                return (true, string.Empty);
            }

            var errorContent = await response.Content.ReadAsStringAsync();
            return (false, $"Status {(int)response.StatusCode}: {errorContent}");
        }

        // PUT: Update an existing student application
        public async Task<bool> UpdateApplicationAsync(int id, StudentApplication application)
        {
            var payload = new
            {
                id = id,
                studentName = application.StudentName,
                email = application.Email,
                country = application.Country,
                university = application.UniversityName,
                course = application.CourseName,
                personalStatement = application.PersonalStatement,
                applicationDate = application.ApplicationDate.ToString("yyyy-MM-ddTHH:mm:ss")
            };

            var response = await _httpClient.PutAsJsonAsync($"{BaseApiUrl}/{id}", payload);
            return response.IsSuccessStatusCode;
        }

        // DELETE: Delete a student application by ID
        public async Task<bool> DeleteApplicationAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{BaseApiUrl}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
