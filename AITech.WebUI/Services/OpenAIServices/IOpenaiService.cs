namespace AITech.WebUI.Services.OpenAIServices
{
    public interface IOpenaiService
    {
        Task<string> GetGeminiDataAsync(string prompt);
    }
}
