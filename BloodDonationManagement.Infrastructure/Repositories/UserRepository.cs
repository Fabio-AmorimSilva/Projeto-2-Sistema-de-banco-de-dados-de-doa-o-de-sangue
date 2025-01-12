namespace BloodDonationManagement.Infrastructure.Repositories;

public class UserRepository(BloodDonationManagementDbContext context, IUnitOfWork unitOfWork) : IUserRepository
{
    public async Task AddAsync(User user)
    {
        await context.Users.AddAsync(user);
        await unitOfWork.Commit();
    }

    public async Task UpdateAsync(User user)
    {
        context.Users.Update(user);
        await unitOfWork.Commit();
    }
    
    public async Task<User?> GetAsync(Guid id)
    {
        return await context.Users.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User?> GetUserByEmailAndPassword(string email, string password)
    {
        return await context.Users.FirstOrDefaultAsync(user => 
            user.Email == email && 
            user.Password == password
        );
    }
}