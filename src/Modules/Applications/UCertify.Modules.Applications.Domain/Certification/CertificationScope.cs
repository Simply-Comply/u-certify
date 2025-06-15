namespace UCertify.Modules.Applications.Domain.Certification;

using UCertify.Modules.Applications.Domain.Common;
public class CertificationScope : ValueObject
{
    public string Value { get; init; }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}