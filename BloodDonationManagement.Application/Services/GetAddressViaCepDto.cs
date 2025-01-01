namespace BloodDonationManagement.Application.Services;

public record GetAddressViaCepDto
{
    public string Cep { get; init; } = null!;
    public string Logradouro { get; init; } = null!;
    public string Complemento { get; init; } = null!;
    public string Unidade { get; init; } = null!;
    public string Bairro { get; init; } = null!;
    public string Localidade { get; init; } = null!;
    public string Uf { get; init; } = null!;
    public string Estado { get; init; } = null!;
    public string Regiao { get; init; } = null!;
    public string Ibge { get; init; } = null!;
    public string Gia { get; init; } = null!;
    public string DDD { get; init; } = null!;
    public string Siafi { get; init; } = null!;
}