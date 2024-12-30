namespace BloodDonationManagement.Infrastructure.Repositories;

public class BloodStockRepository(BloodDonationManagementDbContext context) : IBloodStockRepository
{
    public async Task AddAsync(BloodStock bloodStock)
    {
        await context.BloodStocks.AddAsync(bloodStock);
    }

    public Task UpdateAsync(BloodStock bloodStock)
    {
        context.BloodStocks.Update(bloodStock);
        return Task.CompletedTask;
    }

    public async Task<IEnumerable<BloodStock>> GetAsync()
    {
        return await context.BloodStocks.ToListAsync();
    }
}