using UCertify.Modules.Applications.Domain.Common;

namespace UCertify.Modules.Applications.Domain.Application;

public class ApplicationDate : ValueObject
{
    public DateTime Value { get; init; }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}