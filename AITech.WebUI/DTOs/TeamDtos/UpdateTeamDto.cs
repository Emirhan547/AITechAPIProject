namespace AITech.WebUI.DTOs.TeamDtos
{
    public class UpdateTeamDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? ImageUrl { get; set; }
        public int SocialId { get; set; }
    }
}
