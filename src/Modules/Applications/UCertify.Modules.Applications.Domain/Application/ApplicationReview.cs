using UCertify.Modules.Applications.Domain.Common;

namespace UCertify.Modules.Applications.Domain.Application;

public class ApplicationReview : Entity
{
    public DateTime ReviewedAt { get; private set; }
    public string ReviewedBy { get; private set; }
    public ApplicationStatus Decision { get; private set; }
    public string Comments { get; private set; }
    public string? RejectionReason { get; private set; }
    
    public ApplicationReview(
        string reviewedBy,
        ApplicationStatus decision,
        string comments,
        string? rejectionReason = null) : base(Guid.NewGuid())
    {
        ReviewedAt = DateTime.UtcNow;
        ReviewedBy = reviewedBy;
        Decision = decision;
        Comments = comments;
        RejectionReason = rejectionReason;
    }
    
    private ApplicationReview() { }
}
