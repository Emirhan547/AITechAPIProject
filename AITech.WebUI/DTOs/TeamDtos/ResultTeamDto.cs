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
        public List<ResultSocialDto> Socials { get; set; }
    }
}
