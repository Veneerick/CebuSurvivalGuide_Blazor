using CebuSurvivalGuide.Models;
using Microsoft.EntityFrameworkCore;

namespace CebuSurvivalGuide.Data;

// Sample data so the app has something to show. Ids are fixed so migrations stay stable.
internal static class SeedData
{
    private static readonly DateTime Stamp = new(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    public static void Seed(this ModelBuilder mb)
    {
        mb.Entity<JeepRoute>().HasData(
            new JeepRoute { Id = 1, RouteName = "04L", VehicleType = "Jeepney", StartingPoint = "Lahug", Destination = "Colon", Description = "Via Mango Avenue (sample data)", CreatedAt = Stamp, UpdatedAt = Stamp },
            new JeepRoute { Id = 2, RouteName = "17B", VehicleType = "Jeepney", StartingPoint = "Ayala Center", Destination = "Carbon Market", Description = "Via Osmeña Blvd (sample data)", CreatedAt = Stamp, UpdatedAt = Stamp },
            new JeepRoute { Id = 3, RouteName = "01K", VehicleType = "Jeepney", StartingPoint = "Talamban", Destination = "SM City", Description = "Via Escario Street (sample data)", CreatedAt = Stamp, UpdatedAt = Stamp });

        var stops = new List<JeepStop>();
        long id = 1;
        void AddStops(long routeId, params string[] names)
        {
            for (var i = 0; i < names.Length; i++)
                stops.Add(new JeepStop { Id = id++, RouteId = routeId, StopName = names[i], StopOrder = i });
        }
        AddStops(1, "Lahug", "JY Square", "Mango Avenue", "Fuente Osmeña", "Colon");
        AddStops(2, "Ayala Center", "Cebu Business Park", "Osmeña Blvd", "Carbon Market");
        AddStops(3, "Talamban", "Gorordo Avenue", "Escario Street", "SM City");
        mb.Entity<JeepStop>().HasData(stops);

        mb.Entity<EmergencyContact>().HasData(
            new EmergencyContact { Id = 1, ServiceName = "Police", ServiceType = "police", PhoneNumber = "911", Description = "Crime, theft, or immediate danger." },
            new EmergencyContact { Id = 2, ServiceName = "Fire Department", ServiceType = "fire", PhoneNumber = "911", Description = "Fires, explosions, and rescue situations." },
            new EmergencyContact { Id = 3, ServiceName = "Ambulance / Medical Emergency", ServiceType = "medical", PhoneNumber = "911", Description = "Serious injury or sudden illness needing urgent care." },
            new EmergencyContact { Id = 4, ServiceName = "Philippine Red Cross", ServiceType = "disaster", PhoneNumber = "143", WebsiteUrl = "https://redcross.org.ph", Description = "First aid, blood services, and disaster response." });

        mb.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Getting Around", Description = "Transport basics for visitors." },
            new Category { Id = 2, Name = "Safety", Description = "Staying safe in Cebu." });

        mb.Entity<Guide>().HasData(
            new Guide { Id = 1, CategoryId = 1, Title = "Riding a jeepney", Content = "Flag the jeepney down, pass your fare forward, and say 'para' when you want to get off. (Sample content)", CreatedAt = Stamp, UpdatedAt = Stamp },
            new Guide { Id = 2, CategoryId = 2, Title = "Emergency basics", Content = "Save 911 in your phone and know the nearest hospital before you travel. (Sample content)", CreatedAt = Stamp, UpdatedAt = Stamp });

        mb.Entity<Source>().HasData(
            new Source { Id = 1, GuideId = 1, Name = "Placeholder source", Url = "https://example.com/jeepney", Description = "Replace with a real reference." },
            new Source { Id = 2, GuideId = 2, Name = "Placeholder source", Url = "https://example.com/safety", Description = "Replace with a real reference." });

        mb.Entity<Language>().HasData(
            new Language { Id = 1, Category = "Greetings", Phrase = "Salamat", Translation = "Thank you", Pronunciation = "sah-LAH-maht" },
            new Language { Id = 2, Category = "Greetings", Phrase = "Palihug", Translation = "Please", Pronunciation = "pah-lee-HOOG" },
            new Language { Id = 3, Category = "Shopping", Phrase = "Pila ni?", Translation = "How much is this?", Pronunciation = "PEE-lah nee" });
    }
}
