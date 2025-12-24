using AITech.WebUI.DTOs.SocialDtos;

namespace AITech.WebUI.DTOs.TeamDtos
{
    public class ResultTeamDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int SocialId { get; set; }
        public ResultSocialDto Social { get; set; }
    }
}
