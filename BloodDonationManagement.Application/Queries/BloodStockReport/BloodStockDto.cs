namespace BloodDonationManagement.Application.Queries.BloodStockReport;

public record BloodStockDto
{
    public BloodType BloodType { get; init; }
    public RhFactor RhFactor { get; init; }
    public int Quantity { get; init; }
}