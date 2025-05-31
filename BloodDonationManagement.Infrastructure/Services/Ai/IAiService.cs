namespace BloodDonationManagement.Infrastructure.Services.Ai;

public interface IAiService
{
    Task<string> Create(string systemPrompt, string userPrompt);
}