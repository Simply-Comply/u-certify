using UCertify.Modules.Applications.Domain.Common;

namespace UCertify.Modules.Applications.Domain.Certification;

// Entity within Application aggregate - represents the certification being requested
public class Certification : Entity
{
    public CertificationScope Scope { get; private set; }
    public CertificationStandard Standard { get; private set; }
    public CertificationType Type { get; private set; }
    
    // Constructor
    public Certification(
        CertificationScope scope, 
        CertificationStandard standard,
        CertificationType type) : base(Guid.NewGuid())
    {
        Scope = scope;
        Standard = standard;
        Type = type;
    }
    
    // Required for EF Core
    private Certification() { }
    
    // Methods to modify certification details (called by Application aggregate)
    internal void UpdateScope(CertificationScope newScope)
    {
        Scope = newScope;
    }
    
    internal void UpdateStandard(CertificationStandard newStandard)
    {
        Standard = newStandard;
    }
}