namespace BloodDonationManagement.Domain.ValueObjects;

public class Address
{
    public string PublicArea { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Cep { get; private set; }

    public Address(
        string publicArea, 
        string city, 
        string state, 
        string cep
    )
    {
        PublicArea = publicArea;
        City = city;
        State = state;
        Cep = cep;
    }
}