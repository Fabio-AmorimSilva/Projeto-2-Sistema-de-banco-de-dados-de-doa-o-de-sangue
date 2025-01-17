namespace BloodDonationManagement.Domain.Entities;

public class Donation : Entity
{
    public Guid DonorId { get; private set; }
    public Donor Donor { get; private set; }
    public DateTime DonationDate { get; private set; }
    public int Quantity { get; private set; }

    protected Donation(){}
    
    public Donation( 
        Donor donor, 
        DateTime donationDate, 
        int quantity
    )
    {
        Guard.IsNotDefault(donationDate);
        Guard.IsNotDefault(quantity);
        
        DonorId = donor.Id;
        Donor = donor;
        DonationDate = donationDate;
        Quantity = quantity;
    }
}