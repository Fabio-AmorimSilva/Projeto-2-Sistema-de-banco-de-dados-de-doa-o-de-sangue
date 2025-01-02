namespace BloodDonationManagement.Infrastructure.Repositories;

public class DonatorRepository(BloodDonationManagementDbContext context) : IDonatorRepository
{
    public async Task AddAsync(Donator donator)
    {
        await context.Donators.AddAsync(donator);
    }

    public async Task<Donator?> GetDonatorAndHisDonationsAsync(Guid donatorId)
    {
        return await context.Donators
            .Include(d => d.Donations.Where(donation => donation.DonatorId == donatorId))
            .FirstOrDefaultAsync();
    }
    
    public async Task<IEnumerable<Donation>> GetAllDonationsFromLast30DaysAsync()
    {
        var last30Days = DateTime.Now.AddDays(-30);

        return await context.Donators
            .Include(d => d.Donations)
            .SelectMany(donator => donator.Donations.Where(donation => donation.DonationDate.Date >= last30Days))
            .ToListAsync();
    }
}