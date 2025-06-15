namespace UCertify.Modules.Applications.Domain.Certification;

using UCertify.Modules.Applications.Domain.Common;
public class CertificationStandard : ValueObject
{
    public string Value { get; init; }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}