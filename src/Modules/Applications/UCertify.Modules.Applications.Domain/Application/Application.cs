using UCertify.Modules.Applications.Domain.Common;

namespace UCertify.Modules.Applications.Domain.Application;

public class Application : AggregateRoot
{
    public ApplicationDate ApplicationDate { get; private set; }

    public Guid ClientId { get; private set; }
}