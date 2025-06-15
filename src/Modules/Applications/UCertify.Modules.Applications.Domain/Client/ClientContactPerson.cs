namespace UCertify.Modules.Applications.Domain.Certification;

using UCertify.Modules.Applications.Domain.Common;

public class ClientContactPerson : Entity
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }
    public string JobTitle { get; private set; }

    public ClientContactPerson(string firstName, string lastName, string email, string phoneNumber, string jobTitle)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        JobTitle = jobTitle;
    }
}