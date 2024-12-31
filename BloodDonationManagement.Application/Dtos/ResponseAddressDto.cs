namespace BloodDonationManagement.Application.Dtos;

public record ResponseAddressDto
{
    public required string PublicArea { get; init; }
    public required string City { get; init; }
    public required string State { get; init; }
    public required string Cep { get; init; }
}