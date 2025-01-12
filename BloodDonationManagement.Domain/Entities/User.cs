namespace BloodDonationManagement.Domain.Entities;

public class User : Entity
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }

    protected User() { }
    
    public User(
        string name,
        string email,
        string password
    )
    {
        Name = name;
        Email = email;
        Password = password;
    }

    public void Update(
        string name,
        string email)
    {
        Name = name;
        Email = email;
    }

    public void UpdatePassword(string password)
    {
        Password = password;
    }
}