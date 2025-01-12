namespace BloodDonationManagement.Domain.Entities;

public class Donation : Entity
{
    public Guid DonatorId { get; private set; }
    public Donator Donator { get; private set; }
    public DateTime DonationDate { get; private set; }
    public int Quantity { get; private set; }

    protected Donation(){}
    
    public Donation( 
        Donator donator, 
        DateTime donationDate, 
        int quantity
    )
    {
        Guard.IsNotDefault(donationDate);
        Guard.IsNotDefault(quantity);
        
        DonatorId = donator.Id;
        Donator = donator;
        DonationDate = donationDate;
        Quantity = quantity;
    }
}