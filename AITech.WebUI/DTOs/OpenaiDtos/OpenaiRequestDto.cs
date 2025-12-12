namespace AITech.WebUI.DTOs.OpenaiDtos
{
    public class OpenaiRequestDto
    {
        public List<Content>? Contents { get; set; }
        public GenerationConfig? GenerationConfig { get; set; }
    }
    public class Content
    {
        public string? Role { get; set; }
        public List<Part>? Parts { get; set; }
    }
    public class Part
    {
        public string? Text { get; set; }
    }
    public class GenerationConfig
    {
        public float? Temperature { get; set; }
        public int? MaxOutPutTokens { get; set; }
    }
}
