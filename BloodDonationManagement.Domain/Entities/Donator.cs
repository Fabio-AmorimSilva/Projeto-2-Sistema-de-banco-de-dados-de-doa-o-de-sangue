namespace BloodDonationManagement.Domain.Entities;

public class Donator : Entity
{
    public const int MinimumWeight = 50;
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

    private readonly List<Donation> _donations = [];
    public IReadOnlyCollection<Donation> Donations => _donations;
    private List<Donation> _donations = [];

    protected Donator() { }
    
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
        Guard.IsGreaterThan(weight, MinimumWeight, nameof(weight));
        
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
        if (DateTime.Now.Year - donation.Donator.Birth.Year < 18)
            return;

        if (donation.Quantity is < MinimumBloodQuantity or > MaximumBloodQuantity)
            return;

        if (_donations.Any())
        {
            var lastDonationDate = _donations.LastOrDefault()!.DonationDate.Date;

            if (Gender == Gender.Female && donation.DonationDate.Date < lastDonationDate.AddDays(90))
            {
                return;
            }

            if (Gender == Gender.Male && donation.DonationDate.Date < lastDonationDate.AddDays(60))
            {
                return;
            }
        }

        _donations.Add(donation);
    }
}