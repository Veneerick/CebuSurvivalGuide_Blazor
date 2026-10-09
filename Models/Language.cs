namespace CebuSurvivalGuide.Models;

public class Language
{
    public long Id { get; set; }
    public string Category { get; set; } = "";
    public string Phrase { get; set; } = "";
    public string Translation { get; set; } = "";
    public string Pronunciation { get; set; } = "";
    public string Description { get; set; } = "";
}
