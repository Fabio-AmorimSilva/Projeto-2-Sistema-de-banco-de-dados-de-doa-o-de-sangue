namespace BloodDonationManagement.Domain.Repositories;

public interface IDonatorRepository
{
    Task AddAsync(Donator donator);
    Task<IEnumerable<Donation>> GetAllDonationsAsync(Guid donatorId);
}