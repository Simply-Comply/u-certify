using UCertify.Modules.Applications.Domain.Common;

namespace UCertify.Modules.Applications.Domain.Application;

public class ApplicationNumber : ValueObject
{
    public int Value { get; init; }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}