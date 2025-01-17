namespace BloodDonationManagement.Application.Services;

public record GetAddressViaCepDto
{
    public string Cep { get; init; } = null!;
    public string Logradouro { get; init; } = null!;
    public string Localidade { get; init; } = null!;
    public string Estado { get; init; } = null!;
}