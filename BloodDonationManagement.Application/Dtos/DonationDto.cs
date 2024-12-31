namespace BloodDonationManagement.Application.Dtos;

public record DonationDto
{
    public required DonatorDto Donator { get; init; }
    public required DateTime DonationDate { get; init; }
    public required int Quantity { get; init; }
}