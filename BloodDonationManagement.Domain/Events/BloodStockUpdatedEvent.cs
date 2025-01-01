namespace BloodDonationManagement.Domain.Events;

public class BloodStockUpdatedEvent : Event
{
    public BloodType BloodType { get; set; }
    public RhFactor RhFactor { get; set; }
    public int Quantity { get; set; }
}