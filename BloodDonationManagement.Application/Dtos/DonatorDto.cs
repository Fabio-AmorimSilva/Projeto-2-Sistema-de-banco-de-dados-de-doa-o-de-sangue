namespace BloodDonationManagement.Application.Dtos;

public record DonatorDto
{
    public required string Name { get; init; }
    public required string Email { get; init; }
    public required DateTime Birth { get; init; }
    public required Gender Gender { get; init; }
    public required double Weight { get; init; }
    public required BloodType BloodType { get; init; }
    public required RhFactor RhFactor { get; init; }
    public required ResponseAddressDto Address { get; init; }
}