using UCertify.Modules.Applications.Domain.Common;
using UCertify.Modules.Applications.Domain.Certification;

namespace UCertify.Modules.Applications.Domain.Application;

public class Application : AggregateRoot
{
    public ApplicationDate ApplicationDate { get; private set; }
    public ApplicationStatus Status { get; private set; }
    public Guid ClientId { get; private set; }
    
    // Certification is an entity within Application aggregate
    public Certification.Certification Certification { get; private set; }
    
    // Other entities within the aggregate
    private readonly List<ApplicationDocument> _documents = new();
    public IReadOnlyList<ApplicationDocument> Documents => _documents.AsReadOnly();
    
    public ApplicationReview? Review { get; private set; }

    // Constructor and methods...
}