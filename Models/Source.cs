namespace CebuSurvivalGuide.Models;

public class Source
{
    public long Id { get; set; }
    public long GuideId { get; set; }
    public string Name { get; set; } = "";
    public string Url { get; set; } = "";
    public string Description { get; set; } = "";

    public Guide Guide { get; set; } = null!;
}
