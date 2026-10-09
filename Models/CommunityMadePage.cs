namespace CebuSurvivalGuide.Models;

public class CommunityMadePage : IHasCreatedAt, IHasUpdatedAt
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public string Title { get; set; } = "";
    public string Content { get; set; } = "";
    public string SourceUrl { get; set; } = "";
    public string Status { get; set; } = "pending";
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public User User { get; set; } = null!;

    public void Approve() => Status = "approved";
    public void Reject() => Status = "rejected";
}
