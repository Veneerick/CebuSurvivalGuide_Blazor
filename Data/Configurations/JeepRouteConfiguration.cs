using CebuSurvivalGuide.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CebuSurvivalGuide.Data.Configurations;

public class JeepRouteConfiguration : IEntityTypeConfiguration<JeepRoute>
{
    public void Configure(EntityTypeBuilder<JeepRoute> b)
    {
        b.Property(x => x.RouteName).IsRequired().HasMaxLength(150);
        b.Property(x => x.VehicleType).IsRequired().HasMaxLength(50);
        b.Property(x => x.StartingPoint).IsRequired().HasMaxLength(200);
        b.Property(x => x.Destination).IsRequired().HasMaxLength(200);
        b.Property(x => x.Fare).IsRequired().HasMaxLength(100).HasDefaultValue("");
        b.Property(x => x.OperatingHours).IsRequired().HasMaxLength(100).HasDefaultValue("");
        b.Property(x => x.Description).IsRequired().HasDefaultValue("");
        b.Property(x => x.SourceUrl).IsRequired().HasMaxLength(500).HasDefaultValue("");
        b.HasIndex(x => x.VehicleType);
        b.HasMany(x => x.Stops).WithOne(s => s.Route).HasForeignKey(s => s.RouteId).OnDelete(DeleteBehavior.Cascade);
    }
}
