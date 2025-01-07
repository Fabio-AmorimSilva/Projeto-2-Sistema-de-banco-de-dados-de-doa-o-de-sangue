namespace BloodDonationManagement.WebApi.ExceptionHandling;

public class Error
{
    public int StatusCode { get; set; }
    public string Message { get; set; } = null!;
}