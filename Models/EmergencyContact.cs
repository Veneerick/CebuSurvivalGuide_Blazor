namespace CebuSurvivalGuide.Models;

public class EmergencyContact
{
    public long Id { get; set; }
    public string ServiceName { get; set; } = "";
    public string ServiceType { get; set; } = "";
    public string PhoneNumber { get; set; } = "";
    public string Address { get; set; } = "";
    public string WebsiteUrl { get; set; } = "";
    public string Description { get; set; } = "";
}
