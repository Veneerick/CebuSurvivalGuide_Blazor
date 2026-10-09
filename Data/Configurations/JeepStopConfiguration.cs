using CebuSurvivalGuide.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CebuSurvivalGuide.Data.Configurations;

public class JeepStopConfiguration : IEntityTypeConfiguration<JeepStop>
{
    public void Configure(EntityTypeBuilder<JeepStop> b)
    {
        b.Property(x => x.StopName).IsRequired().HasMaxLength(200);
        b.HasIndex(x => new { x.RouteId, x.StopOrder }).IsUnique();
        b.ToTable(t => t.HasCheckConstraint("CK_JeepStops_StopOrder", "StopOrder >= 0"));
    }
}
