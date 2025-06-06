﻿namespace BloodDonationManagement.Domain.Entities;

public class BloodStock : Entity
{
    public const int MinimumBloodInStock = 5000;
    
    public BloodType BloodType { get; private set; }
    public RhFactor RhFactor { get; private set; }
    public int Quantity { get; private set; }

    protected BloodStock() { }
    
    public BloodStock(
        BloodType bloodType, 
        RhFactor rhFactor, 
        int quantity
    )
    {
        Guard.IsNotDefault(quantity);
        
        BloodType = bloodType;
        RhFactor = rhFactor;
        Quantity = quantity;
    }

    public void AddQuantity(int quantity)
    {
        Quantity += quantity;
    }
}