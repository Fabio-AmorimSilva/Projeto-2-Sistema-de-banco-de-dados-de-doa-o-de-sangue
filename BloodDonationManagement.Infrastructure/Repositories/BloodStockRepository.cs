namespace BloodDonationManagement.Infrastructure.Repositories;

public class BloodStockRepository(BloodDonationManagementDbContext context) : IBloodStockRepository
{
    public void UpdateAsync(BloodStock bloodStock)
    {
        context.BloodStocks.Update(bloodStock);
    }

    public async Task<BloodStock?> GetAsync(RhFactor rhFactor, BloodType bloodType)
    {
        var bloodStock = await context.BloodStocks
            .Where(bt => 
                bt.BloodType == bloodType && 
                bt.RhFactor == rhFactor
            ).SingleOrDefaultAsync();
        
        return bloodStock;
    }

    public async Task<IEnumerable<BloodStock?>> ListAsync()
    {
        return await context.BloodStocks.ToListAsync();
    }

    public async Task<int> VerifyStockAsync()
    {
        return await context.BloodStocks.Select(bt => bt.Quantity).SumAsync();
    }
}