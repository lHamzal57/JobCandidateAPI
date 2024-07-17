namespace JobCandidate.Domain.Common.Audit
{
    public interface IDateTimeSignature
    {
        DateTime? FirstModificationDate { get; set; }
        DateTime? LastModificationDate { get; set; }
        DateTime CreationDate { get; set; }
    }

    public interface IEntityUserSignature
    {
        long? FirstModifiedByUserId { get; set; }
        long? LastModifiedByUserId { get; set; }
        long? CreatedByUserId { get; set; }
    }

    public interface IDeletionSignature
    {
        bool IsDeleted { get; set; }
        DateTime? DeletionDate { get; set; }
        long? DeletedByUserId { get; set; }
        bool? MustDeletedPhysical { get; set; }
    }

}
