namespace BloodDonationManagement.Application.Queries.ListDonations;

public record ListDonationsDto
{
    public required DonorDto Donor { get; init; }
}