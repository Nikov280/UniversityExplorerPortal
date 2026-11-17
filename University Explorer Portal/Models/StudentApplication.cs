using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UniversityExplorerPortal.Models
{
    public class StudentApplication
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Student name is required.")]
        public string StudentName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Country is required.")]
        public string Country { get; set; } = string.Empty;

        [Required(ErrorMessage = "University name is required.")]
        [JsonPropertyName("university")]
        public string UniversityName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Course name is required.")]
        [JsonPropertyName("course")]
        public string CourseName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Personal statement is required.")]
        public string PersonalStatement { get; set; } = string.Empty;

        [Required(ErrorMessage = "Application date is required.")]
        public DateTime ApplicationDate { get; set; } = DateTime.Today;
    }
}