using CebuSurvivalGuide.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CebuSurvivalGuide.Data.Configurations;

public class EmergencyContactConfiguration : IEntityTypeConfiguration<EmergencyContact>
{
    public void Configure(EntityTypeBuilder<EmergencyContact> b)
    {
        b.Property(x => x.ServiceName).IsRequired().HasMaxLength(150);
        b.Property(x => x.ServiceType).IsRequired().HasMaxLength(50);
        b.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(50);
        b.Property(x => x.Address).IsRequired().HasMaxLength(255).HasDefaultValue("");
        b.Property(x => x.WebsiteUrl).IsRequired().HasMaxLength(500).HasDefaultValue("");
        b.Property(x => x.Description).IsRequired().HasDefaultValue("");
        b.HasIndex(x => x.ServiceType);
    }
}
