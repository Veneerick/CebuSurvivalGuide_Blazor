namespace CebuSurvivalGuide.Models;

public class NewsArticle
{
    public long Id { get; set; }
    public string Title { get; set; } = "";
    public string Content { get; set; } = "";
    public string Source { get; set; } = "";
    public string SourceUrl { get; set; } = "";
    public DateTime PublishedAt { get; set; }
}
