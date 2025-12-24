namespace AITech.WebUI.DTOs.TeamDtos
{
    public class CreateTeamDto
    {
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public int SocialId { get; set; }
    }
}
