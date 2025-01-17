namespace BloodDonationManagement.Infrastructure.Repositories;

public class DonorRepository(BloodDonationManagementDbContext context, IUnitOfWork unitOfWork) : IDonorRepository
{
    public async Task AddAsync(Donor donor)
    {
        await context.Donors.AddAsync(donor);
        await unitOfWork.Commit();
    }
    
    public async Task AddDonationAsync(Donation donation)
    {
        await context.Donations.AddAsync(donation);
        await unitOfWork.Commit();
    }

    public async Task<Donor?> GetDonorAndHisDonationsAsync(Guid donorId)
    {
        return await context.Donors
            .Include(d => d.Donations)
            .FirstOrDefaultAsync(d => d.Id == donorId);
    }
    
    public async Task<IEnumerable<Donor>> GetAllDonationsFromLast30DaysAsync()
    {
        var last30Days = DateTime.Now.AddDays(-30);

        return await context.Donors
            .AsNoTracking()
            .Include(donator => donator.Donations.Where(donation => donation.DonationDate.Date >= last30Days))
            .ToListAsync();
    }
}