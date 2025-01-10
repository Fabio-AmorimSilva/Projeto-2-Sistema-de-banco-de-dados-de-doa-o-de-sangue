namespace BloodDonationManagement.Domain.Repositories;

public interface IUserRepository
{
    Task CreateAsync(User user);
    void UpdateAsync(User user);
    void DeleteAsync(User user);
}