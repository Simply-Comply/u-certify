using UCertify.Modules.Applications.Domain.Common;

namespace UCertify.Modules.Applications.Domain.Client;

public class Name : ValueObject
{
    public string Value { get; init; }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}