namespace BloodDonationManagement.Domain.Repositories;

public interface IBloodStockRepository
{
    Task AddAsync(BloodStock bloodStock);
    Task UpdateAsync(BloodStock bloodStock);
    Task<IEnumerable<BloodStock>> GetAsync();
}