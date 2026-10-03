namespace CebuSurvivalGuide.Models;

public record JeepneyRoute(string Code, string From, string To, string Via, string Color, string PathData, bool Running = true)
{
    public IReadOnlyList<string> Stops { get; init; } = Array.Empty<string>();
}
public record Landmark(string Name, int X, int Y);
public record TransportType(string Name, string Description, string Icon);
public record EmergencyService(string Name, string Number, string Description, string Icon);
public record OtherService(string Name, string Description, string Icon);
public record Tip(string Category, string Title, string Body);
