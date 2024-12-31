namespace BloodDonationManagement.Domain.Messages;

public static class ErrorMessages
{
    public static string CannotBeEmpty(string field)
        => $"{field} cannot be empty.";
    
    public static string NotFound<T>()
        => $"{typeof(T).Name} not found.";
}