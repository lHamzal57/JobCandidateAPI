using JobCandidate.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace JobCandidate.Application.Models.ViewModel
{
    public class UpsertCandidateViewModel
    {

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public required string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public required string LastName { get; set; }

        [Phone(ErrorMessage = "Invalid phone number format.")]
        [StringLength(20, ErrorMessage = "Phone number cannot be longer than 20 characters.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; }

        public TimeInterval BestTimeToCall { get; set; }

        [Url]
        public string LinkedInProfileUrl { get; set; }

        [Url]
        public string GitHubProfileUrl { get; set; }

        [Required]
        public string FreeTextComment { get; set; }


    }
}
