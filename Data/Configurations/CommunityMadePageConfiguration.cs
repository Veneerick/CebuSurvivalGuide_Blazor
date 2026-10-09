using CebuSurvivalGuide.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CebuSurvivalGuide.Data.Configurations;

public class CommunityMadePageConfiguration : IEntityTypeConfiguration<CommunityMadePage>
{
    public void Configure(EntityTypeBuilder<CommunityMadePage> b)
    {
        b.Property(x => x.Title).IsRequired().HasMaxLength(200);
        b.Property(x => x.Content).IsRequired();
        b.Property(x => x.SourceUrl).IsRequired().HasMaxLength(500).HasDefaultValue("");
        b.Property(x => x.Status).IsRequired().HasMaxLength(20).HasDefaultValue("pending");
        b.HasIndex(x => x.Status);
    }
}
