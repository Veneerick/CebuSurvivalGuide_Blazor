namespace CebuSurvivalGuide.Models;

public class Guide : IHasCreatedAt, IHasUpdatedAt
{
    public long Id { get; set; }
    public long CategoryId { get; set; }
    public string Title { get; set; } = "";
    public string Content { get; set; } = "";
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public Category Category { get; set; } = null!;
    public ICollection<Source> Sources { get; set; } = new List<Source>();
}
