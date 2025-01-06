namespace BloodDonationManagement.Domain.Repositories;

public interface IDonatorRepository
{
    Task AddAsync(Donator donator);
    Task<Donator?> GetDonatorAndHisDonationsAsync(Guid donatorId);
    Task<IEnumerable<Donator>> GetAllDonationsFromLast30DaysAsync();
}