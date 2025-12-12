
using AITech.WebUI.DTOs.OpenaiDtos;
using Newtonsoft.Json;
using System.Text;

namespace AITech.WebUI.Services.OpenAIServices
{
    public class Openaiservice : IOpenaiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _openaiApiKey;
        private const string Model= "gemini-2.5-flash";
        private const string BaseUrl= "https://generativelanguage.googleapis.com/v1beta/models/";

        public Openaiservice(HttpClient httpClient,IConfiguration configuration)
        {
            _httpClient = httpClient;
            _openaiApiKey = configuration["Gemini:ApiKey"];
        }

        public async Task<string> GetGeminiDataAsync(string prompt)
        {
            var requestBody = new OpenaiRequestDto
            {
                Contents = new List<Content>
         {
             new Content
             {
                 Role ="user",
                 Parts= new List<Part>
                 {
                     new Part
                     {
                         Text = prompt
                     }
                 }
             }
         },
            };

            var jsonContent = JsonConvert.SerializeObject(requestBody);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var url = $"{BaseUrl}{Model}:generateContent?key={_openaiApiKey}";
            var response = await _httpClient.PostAsync(url, httpContent);
            if(response.IsSuccessStatusCode)
            {
                var message = await response.Content.ReadAsStringAsync();
                return message ;
             
            }
            var responseString= await response.Content.ReadAsStringAsync();
            var geminiResponse=JsonConvert.DeserializeObject<OpenaiResponseDto>(responseString);
            var resultText= geminiResponse?.Candidates?.FirstOrDefault()?.Content?.Parts?.FirstOrDefault()?.Text;
            return resultText ?? "Yanıt Alınamadı.";


        }
    }
}
