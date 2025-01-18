namespace BloodDonationManagement.Application.Queries.ListDonationsFromLast30DaysReport;

public record ListDonationsFromLast30DaysReportDto
{
    public required IEnumerable<DonorDto> Donators { get; init; }
}