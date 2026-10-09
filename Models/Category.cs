namespace CebuSurvivalGuide.Models;

public class Category
{
    public long Id { get; set; }
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";

    public ICollection<Guide> Guides { get; set; } = new List<Guide>();
}
