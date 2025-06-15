using UCertify.Modules.Applications.Domain.Common;

namespace UCertify.Modules.Applications.Domain.Client;

public class Client : AggregateRoot
{
    public Name Name { get; private set; }
}