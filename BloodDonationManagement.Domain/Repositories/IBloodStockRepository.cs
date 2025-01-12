namespace BloodDonationManagement.Domain.Repositories;

public interface IBloodStockRepository
{
    Task UpdateAsync(BloodStock bloodStock);
    Task<BloodStock?> GetAsync(RhFactor rhFactor, BloodType bloodType);
    Task<IEnumerable<BloodStock?>> ListAsync();
    Task<int> VerifyStockAsync();
}