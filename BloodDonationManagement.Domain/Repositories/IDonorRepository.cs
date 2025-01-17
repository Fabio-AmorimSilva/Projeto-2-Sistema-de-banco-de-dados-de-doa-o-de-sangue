namespace BloodDonationManagement.Domain.Repositories;

public interface IDonorRepository
{
    Task AddAsync(Donor donor);
    Task AddDonationAsync(Donation donation);
    Task<Donor?> GetDonorAndHisDonationsAsync(Guid donorId);
    Task<IEnumerable<Donor>> GetAllDonationsFromLast30DaysAsync();
}