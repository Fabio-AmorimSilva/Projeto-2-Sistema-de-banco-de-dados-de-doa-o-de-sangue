﻿namespace BloodDonationManagement.Domain.Entities;

public class Donation : Entity
{
    public const int MinimumAgeToDonate = 18;
    
    public Guid DonatorId { get; private set; }
    public Donator Donator { get; private set; }
    public DateTime DonationDate { get; private set; }
    public int Quantity { get; private set; }

    public Donation(
        Guid donatorId, 
        Donator donator, 
        DateTime donationDate, 
        int quantity
    )
    {
        Guard.IsNotDefault(donationDate);
        Guard.IsNotDefault(quantity);
        
        DonatorId = donatorId;
        Donator = donator;
        DonationDate = donationDate;
        Quantity = quantity;
    }
}