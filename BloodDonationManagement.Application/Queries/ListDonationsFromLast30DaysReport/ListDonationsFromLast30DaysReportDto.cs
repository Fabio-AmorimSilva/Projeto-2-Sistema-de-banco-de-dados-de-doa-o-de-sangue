namespace BloodDonationManagement.Application.Queries.ListDonationsFromLast30DaysReport;

public record ListDonationsFromLast30DaysReportDto
{
    public required IEnumerable<DonatorDto> Donators { get; init; }
}