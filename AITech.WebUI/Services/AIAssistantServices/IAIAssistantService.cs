namespace AITech.WebUI.Services.AIAssistantServices
{
    public interface IAIAssistantService
    {
        Task<string> AskQuestionAsync(string question);
    }
}
