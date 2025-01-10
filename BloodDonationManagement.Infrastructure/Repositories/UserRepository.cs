namespace BloodDonationManagement.Infrastructure.Repositories;

public class UserRepository(BloodDonationManagementDbContext context) : IUserRepository
{
    public async Task CreateAsync(User user)
    {
        await context.Users.AddAsync(user);
    }

    public async void UpdateAsync(User user)
    {
        context.Users.Update(user);
    }

    public void DeleteAsync(User user)
    {
        context.Users.Remove(user);
    }
}