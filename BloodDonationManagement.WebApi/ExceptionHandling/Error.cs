namespace BloodDonationManagement.WebApi.ExceptionHandling;

internal class Error
{
    public int StatusCode { get; set; }
    public string Message { get; set; } = null!;
}