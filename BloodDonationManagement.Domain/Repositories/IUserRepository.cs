namespace BloodDonationManagement.Domain.Repositories;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task<User?> GetAsync(Guid id);
    Task<User?> GetUserByEmailAndPassword(string email, string password);
}