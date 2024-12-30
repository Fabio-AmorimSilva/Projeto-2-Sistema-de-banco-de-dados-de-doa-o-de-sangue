namespace BloodDonationManagement.Domain.Common.Interfaces;

public interface IUnitOfWork
{
    Task<bool> Commit();
}