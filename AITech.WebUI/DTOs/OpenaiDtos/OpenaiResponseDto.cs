namespace AITech.WebUI.DTOs.OpenaiDtos
{
    public class OpenaiResponseDto
    {
        public List<Candidate>? Candidates { get; set; }
    }
    public class Candidate
    {
        public Content? Content { get; set; }
        public string? FinishReason { get; set; }
        public int? Index { get; set; }
    }
}
