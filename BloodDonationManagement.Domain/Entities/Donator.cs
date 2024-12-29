namespace BloodDonationManagement.Domain.Entities;

public class Donator : Entity
{
    public const int MinimunWeight = 50;
    public const int MinimumBloodQuantity = 420;
    public const int MaximumBloodQuantity = 470;
    
    public string Name { get; private set; }
    public string Email { get; private set; }
    public DateTime Birth { get; private set; }
    public Gender Gender { get; private set; }
    public double Weight { get; private set; }
    public BloodType BloodType { get; private set; }
    public RhFactor RhFactor { get; private set; }
    public Address Address { get; private set; }

    public IReadOnlyCollection<Donation> Donations => _donations;
    private List<Donation> _donations = [];

    public Donator(
        string name,
        string email,
        DateTime birth,
        Gender gender,
        double weight,
        BloodType bloodType,
        RhFactor rhFactor,
        Address address
    )
    {
        Guard.IsNotWhiteSpace(name);
        Guard.IsNotWhiteSpace(email);
        Guard.IsNotDefault(birth);
        Guard.IsLessThanOrEqualTo(weight, MinimunWeight, nameof(weight));
        
        Name = name;
        Email = email;
        Birth = birth;
        Gender = gender;
        Weight = weight;
        BloodType = bloodType;
        RhFactor = rhFactor;
        Address = address;
    }

    public void AddDonation(Donation donation)
    {
        if (donation.Donator.Birth.Year - DateTime.Now.Year < 18)
            return;

        if (donation.Quantity is < MinimumBloodQuantity or > MaximumBloodQuantity)
            return;
        
        var lastDonationDate = _donations.LastOrDefault().DonationDate.Date;
        
        if (Gender == Gender.Female && donation.DonationDate.Date < lastDonationDate.AddDays(90))
        {
            return;
        }
        
        if (Gender == Gender.Male && donation.DonationDate.Date < lastDonationDate.AddDays(60))
        {
            return;
        }
        
        _donations.Add(donation);
    }
}