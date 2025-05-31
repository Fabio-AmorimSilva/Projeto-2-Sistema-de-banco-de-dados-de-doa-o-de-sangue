namespace BloodDonationManagement.Domain.ValueObjects;

public class Address(
    string publicArea,
    string city,
    string state,
    string cep,
    string complement
)
{
    public string PublicArea { get; private set; } = publicArea;
    public string City { get; private set; } = city;
    public string State { get; private set; } = state;
    public string Cep { get; private set; } = cep;
    public string Complement { get; private set; } = complement;
}