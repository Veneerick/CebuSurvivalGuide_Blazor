using CebuSurvivalGuide.Models;

namespace CebuSurvivalGuide.Services;

public interface IGuideDataService
{
    IReadOnlyList<JeepneyRoute> Routes { get; }
    IReadOnlyList<Landmark> Landmarks { get; }
    IReadOnlyList<TransportType> TransportTypes { get; }
    IReadOnlyList<EmergencyService> EmergencyServices { get; }
    IReadOnlyList<OtherService> OtherServices { get; }
    IReadOnlyList<Tip> Tips { get; }
    JeepneyRoute? GetRoute(string code);
    IEnumerable<JeepneyRoute> SearchRoutes(string? query);
}

// Sample data only. Replace with a database or API later (EF Core, HttpClient, etc.).
public class GuideDataService : IGuideDataService
{
    public IReadOnlyList<JeepneyRoute> Routes { get; } = new List<JeepneyRoute>
    {
        new("04L", "Lahug", "Colon", "Mango Avenue", "#1C90F7", "M470 90 L400 140 L330 190 L270 240 L200 290"){ Stops = new[] { "Lahug", "JY Square", "Mango Avenue", "Fuente Osmeña", "Colon" } },
        new("17B", "Ayala Center", "Carbon Market", "Osmeña Blvd", "#D61ADC", "M470 90 L520 190 L470 260 L350 320 L270 330"){ Stops = new[] { "Ayala Center", "Cebu Business Park", "Osmeña Blvd", "Carbon Market" } },
        new("01K", "Talamban", "SM City", "Escario Street", "#A6D619", "M120 350 L200 290 L330 250 L400 210 L560 160"){ Stops = new[] { "Talamban", "Gorordo Avenue", "Escario Street", "SM City" } },
    };

    public IReadOnlyList<Tip> Tips { get; } = new List<Tip>
    {
        new("Transport", "Carry small bills", "Jeepney drivers rarely have change for large notes. Keep coins and small bills ready."),
        new("Transport", "Say 'para' to get off", "Call out 'para' or tap the roof or rail when you want the driver to stop."),
        new("Transport", "Ask for the meter", "In a taxi, ask the driver to use the meter before you ride."),
        new("Safety", "Guard your phone and wallet", "Keep valuables in front pockets or a zipped bag in crowded areas and on jeepneys."),
        new("Safety", "Save emergency numbers offline", "Store 911 and the Red Cross number in your phone before you need them."),
        new("Safety", "Share your trip", "Tell someone your route when you travel at night or to unfamiliar areas."),
        new("Weather", "Check typhoon advisories", "Follow official weather bulletins before long trips during typhoon season."),
        new("Weather", "Know your evacuation spot", "Ask your hotel or host where the nearest evacuation center is."),
        new("Weather", "Expect flooded streets", "Heavy rain can flood low areas quickly. Allow extra travel time."),
    };

    public IReadOnlyList<Landmark> Landmarks { get; } = new List<Landmark>
    {
        new("Lahug", 470, 90), new("Colon", 200, 290), new("IT Park", 520, 190),
        new("Carbon", 270, 330), new("Ayala", 400, 210),
    };

    public IReadOnlyList<TransportType> TransportTypes { get; } = new List<TransportType>
    {
        new("Jeepney", "Cheapest option. Flag down, pay the driver.", "jeep"),
        new("Bus", "Best for longer city-to-city trips.", "bus"),
        new("Taxi", "Metered. Ask the driver to use the meter.", "taxi"),
        new("Modern Jeepney", "Air-conditioned, fixed stops.", "modern"),
    };

    public IReadOnlyList<EmergencyService> EmergencyServices { get; } = new List<EmergencyService>
    {
        new("Police", "911", "Crime, theft, or immediate danger. Stay on the line.", "shield"),
        new("Fire Department", "911", "Fires, explosions, and rescue situations.", "flame"),
        new("Ambulance / Medical Emergency", "911", "Serious injury or sudden illness needing urgent care.", "medical"),
        new("Philippine Red Cross", "143", "First aid, blood services, and disaster response.", "cross"),
    };

    public IReadOnlyList<OtherService> OtherServices { get; } = new List<OtherService>
    {
        new("Hospitals", "Find nearby hospitals and clinics", "hospital"),
        new("Government Offices", "City Hall and public services", "building"),
        new("Tourist Assistance", "Help for visitors", "compass"),
        new("Disaster Information", "Typhoon and earthquake updates", "storm"),
    };

    public JeepneyRoute? GetRoute(string code) =>
        Routes.FirstOrDefault(r => r.Code.Equals(code, StringComparison.OrdinalIgnoreCase));

    public IEnumerable<JeepneyRoute> SearchRoutes(string? query)
    {
        if (string.IsNullOrWhiteSpace(query)) return Routes;
        var q = query.Trim();
        return Routes.Where(r =>
            new[] { r.Code, r.From, r.To, r.Via }.Any(s => s.Contains(q, StringComparison.OrdinalIgnoreCase)));
    }
}
