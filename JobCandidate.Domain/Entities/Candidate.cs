using JobCandidate.Domain.Common.Audit;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace JobCandidate.Domain.Entities
{
    public class Candidate : IDateTimeSignature, IEntityUserSignature, IDeletionSignature
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

        #region DeletionSignature
        public bool IsDeleted { get; set; }
        public DateTime? DeletionDate { get; set; }
        public long? DeletedByUserId { get; set; }
        public bool? MustDeletedPhysical { get; set; }
        #endregion

        #region DateTimeSignature
        public DateTime? FirstModificationDate { get; set; }
        public DateTime? LastModificationDate { get; set; }
        public DateTime CreationDate { get; set; }
        #endregion

        #region UserSignature
        public long? FirstModifiedByUserId { get; set; }
        public long? LastModifiedByUserId { get; set; }
        public long? CreatedByUserId { get; set; }
        #endregion

    }
}
