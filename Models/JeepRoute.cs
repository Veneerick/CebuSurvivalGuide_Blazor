namespace CebuSurvivalGuide.Models;

public class JeepRoute : IHasCreatedAt, IHasUpdatedAt
{
    public long Id { get; set; }
    public string RouteName { get; set; } = "";
    public string VehicleType { get; set; } = "";
    public string StartingPoint { get; set; } = "";
    public string Destination { get; set; } = "";
    public string Fare { get; set; } = "";
    public string OperatingHours { get; set; } = "";
    public string Description { get; set; } = "";
    public string SourceUrl { get; set; } = "";
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public ICollection<JeepStop> Stops { get; set; } = new List<JeepStop>();
}
