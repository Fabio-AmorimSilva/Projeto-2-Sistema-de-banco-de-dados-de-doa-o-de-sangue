namespace BloodDonationManagement.Domain.Messages;

public static class ErrorMessages
{
    public static string CannotBeEmpty(string field)
        => $"{field} cannot be empty.";

    public static string NotFound<T>()
        => $"{typeof(T).Name} not found.";

    public static string CannotMakeDonationByAge(int age)
        => $"You are {age} years old. Only people with more than 18 years are allowed.";
    
    public static string DonationHasToBeGreaterThan(int minimumQuantity)
        => $"Donation have to more than {minimumQuantity}";
}