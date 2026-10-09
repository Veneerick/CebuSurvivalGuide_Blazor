namespace CebuSurvivalGuide.Models;

public class User : IHasUpdatedAt
{
    public long Id { get; set; }
    public string Role { get; set; } = "member";
    public DateTime UpdatedAt { get; set; }

    public ICollection<CommunityMadePage> Pages { get; set; } = new List<CommunityMadePage>();
}
