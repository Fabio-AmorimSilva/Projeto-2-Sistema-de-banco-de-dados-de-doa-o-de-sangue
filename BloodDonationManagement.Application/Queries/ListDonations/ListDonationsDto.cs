namespace BloodDonationManagement.Application.Queries.ListDonations;

public record ListDonationsDto
{
    public required DonatorDto Donator { get; init; }
}