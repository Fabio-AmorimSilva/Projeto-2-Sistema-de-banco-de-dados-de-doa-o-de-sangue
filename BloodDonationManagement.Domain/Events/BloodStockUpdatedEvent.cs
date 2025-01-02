namespace BloodDonationManagement.Domain.Events;

public class BloodStockUpdatedEvent : Event
{
    public BloodType BloodType { get; init; }
    public RhFactor RhFactor { get; init; }
    public int Quantity { get; init; }
}