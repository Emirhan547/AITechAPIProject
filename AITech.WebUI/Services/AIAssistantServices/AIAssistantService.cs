
using AITech.WebUI.DTOs.AIDtos;

namespace AITech.WebUI.Services.AIAssistantServices
{
    public class AIAssistantService : IAIAssistantService
    {
        private readonly HttpClient _client;
        private readonly ILogger<AIAssistantService> _logger;

        public AIAssistantService(HttpClient client, ILogger<AIAssistantService> logger)
        {
            client.BaseAddress = new Uri("https://localhost:7149/api/");
            _client = client;
            _logger = logger;
        }

        public async Task<string> AskQuestionAsync(string question)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(question))
                {
                    throw new ArgumentException("Soru boş olamaz");
                }

                var response = await _client.PostAsJsonAsync("AIAssistants/ask", new
                {
                    question = question
                });

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    _logger.LogError($"API Error: {errorContent}");
                    throw new Exception("AI servisi şu anda kullanılamıyor");
                }

                var result = await response.Content.ReadFromJsonAsync<AIResponse>();
                return result?.Answer ?? "Cevap alınamadı";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "AI Assistant service error");
                throw;
            }
        }
    }
}