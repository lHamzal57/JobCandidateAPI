using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace JobCandidate.Domain.Entities
{
    public class Candidate 
    {
        #region Properties

      
        #region IEntityIdentity<Guid>
        public Guid Id { get; set; }
        #endregion

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Phone { get; set; }       
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public TimeInterval BestTimeToCall { get; set; }

        [Url]
        public string LinkedInProfileUrl { get; set; }

        [Url]
        public string GitHubProfileUrl { get; set; }

        [Required]
        public string FreeTextComment { get; set; }

     
        #endregion
    }
}
