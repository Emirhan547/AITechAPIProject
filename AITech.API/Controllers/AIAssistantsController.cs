using AITech.DTO.DTOs.AIDtos;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Linq;

namespace AITech.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AIAssistantsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly ILogger<AIAssistantsController> _logger;

        public AIAssistantsController(
            IConfiguration configuration,
            IHttpClientFactory httpClientFactory,
            ILogger<AIAssistantsController> logger)
        {
            _configuration = configuration;
            _httpClient = httpClientFactory.CreateClient();
            _logger = logger;
        }

        [HttpPost("ask")]
        public async Task<IActionResult> AskQuestion([FromBody] QuestionRequest request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.Question))
                    return BadRequest(new { error = "Soru boş olamaz" });

                if (request.Question.Length > 500)
                    return BadRequest(new { error = "Soru çok uzun (max 500 karakter)" });

                var apiKey = _configuration["OpenAI:ApiKey"];
                if (string.IsNullOrEmpty(apiKey))
                    return StatusCode(500, new { error = "OpenAI yapılandırması eksik" });

                var openAiRequest = new
                {
                    model = "gpt-4o-mini",
                    input = request.Question,
                    max_output_tokens = 150
                };

                var json = JsonSerializer.Serialize(openAiRequest);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                _httpClient.DefaultRequestHeaders.Clear();
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", apiKey);

                var response = await _httpClient.PostAsync(
                    "https://api.openai.com/v1/responses",
                    content
                );

                var responseBody = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError($"OpenAI ERROR => {response.StatusCode} | {responseBody}");
                    return StatusCode(500, new { error = "AI servisi şu anda kullanılamıyor" });
                }

                _logger.LogInformation("RAW OPENAI RESPONSE => " + responseBody);

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var openAiResponse =
                    JsonSerializer.Deserialize<OpenAIResponsesResult>(responseBody, options);

                var answer = openAiResponse?.Output?
                    .SelectMany(o => o.Content ?? new())
                    .FirstOrDefault(c => c.Type == "output_text")
                    ?.Text;

                if (string.IsNullOrWhiteSpace(answer))
                    return StatusCode(500, new { error = "AI cevap üretemedi" });

                if (answer.Length > 250)
                    answer = answer[..247] + "...";

                return Ok(new { answer });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "AI Assistant fatal error");
                return StatusCode(500, new { error = "Bir hata oluştu" });
            }
        }
    }
}
