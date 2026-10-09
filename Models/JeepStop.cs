namespace CebuSurvivalGuide.Models;

public class JeepStop
{
    public long Id { get; set; }
    public long RouteId { get; set; }
    public string StopName { get; set; } = "";
    public int StopOrder { get; set; }

    public JeepRoute Route { get; set; } = null!;
}
