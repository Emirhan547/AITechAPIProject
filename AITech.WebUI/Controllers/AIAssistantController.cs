using AITech.WebUI.DTOs.AIDtos;
using AITech.WebUI.Services.AIAssistantServices;
using Microsoft.AspNetCore.Mvc;

[Route("AIAssistant")]
public class AIAssistantController : Controller
{
    private readonly IAIAssistantService _aiService;

    public AIAssistantController(IAIAssistantService aiService)
    {
        _aiService = aiService;
    }

    [HttpPost("ask")]
    public async Task<IActionResult> AskQuestion([FromBody] QuestionRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Question))
        {
            return BadRequest(new { error = "Soru boş olamaz" });
        }

        var answer = await _aiService.AskQuestionAsync(request.Question);
        return Ok(new { answer });
    }
}
