namespace BloodDonationManagement.Application.Dtos;

public record DonationDto
{
    public required DateTime DonationDate { get; init; }
    public required int Quantity { get; init; }
}