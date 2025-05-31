namespace BloodDonationManagement.Infrastructure.Services.Ai;

public class AiService(
    HttpClient httpClient,
    IOptions<AiModel> config
) : IAiService
{
    public async Task<string> Create(string systemPrompt, string userPrompt)
    {
        var apikey = config.Value.ApiKey;

        var chatClient = new ChatClient("gpt-4.1-nano", apikey);

        var messages = new List<ChatMessage>
        {
            new SystemChatMessage(systemPrompt),
            new UserChatMessage(userPrompt)
        };

        var response = await chatClient.CompleteChatAsync(messages);

        var content = response.Value.Content?.First()?.Text;

        return content ?? string.Empty;
    }
}