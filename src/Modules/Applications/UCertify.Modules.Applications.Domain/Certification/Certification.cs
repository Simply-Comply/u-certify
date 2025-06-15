using UCertify.Modules.Applications.Domain.Common;

namespace UCertify.Modules.Applications.Domain.Certification;

public class Certification : AggregateRoot
{
    public CertificationScope Scope { get; init; }
    public CertificationStandard Standard { get; init; }
}