namespace BloodDonationManagement.Infrastructure.UnitWork;

public class UnitOfWork(BloodDonationManagementDbContext context) : IUnitOfWork
{
    public async Task<bool> Commit()
    {
        return await context.SaveChangesAsync() > 0; 
    }

    public void Dispose()
    {
        context.Dispose();
    }
}