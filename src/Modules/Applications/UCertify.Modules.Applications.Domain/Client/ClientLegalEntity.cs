namespace UCertify.Modules.Applications.Domain.Client;

using UCertify.Modules.Applications.Domain.Common;

public class ClientLegalEntity : Entity
{
    public string LegalStatus { get; private set; }
    public string TaxId { get; private set; }

    public ClientLegalEntity(string name, string taxId)
    {
        LegalStatus = name;
        TaxId = taxId;
    }
}
