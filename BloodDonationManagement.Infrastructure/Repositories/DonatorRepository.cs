namespace BloodDonationManagement.Infrastructure.Repositories;

public class DonatorRepository(BloodDonationManagementDbContext context) : IDonatorRepository
{
    public async Task AddAsync(Donator donator)
    {
        await context.Donators.AddAsync(donator);
    }

    public async Task<IEnumerable<Donation>> GetAllDonationsAsync(Guid donatorId)
    {
        return await context.Donators
            .SelectMany(d => d.Donations.Where(d => d.DonatorId == donatorId))
            .ToListAsync();
    }
}