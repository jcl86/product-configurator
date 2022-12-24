namespace ProductConfigurator.Core.Modules.Administration.Users;

public record EmailAddress
{
    private readonly string email;

    public EmailAddress(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new DomainException("Email of username can not be empty");
        }

        this.email = email.Trim();
        
        if (!IsValidEmail())
        {
            throw new DomainException($"{email} is not a valid email address");
        }
    }

    public override string ToString() => email;

    private bool IsValidEmail()
    {
        if (email.EndsWith("."))
        {
            return false;
        }
        
        try
        {
            System.Net.Mail.MailAddress address = new(email);
            return address.Address == email;
        }
        catch
        {
            return false;
        }
    }
}
