using CebuSurvivalGuide.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CebuSurvivalGuide.Data.Configurations;

public class GuideConfiguration : IEntityTypeConfiguration<Guide>
{
    public void Configure(EntityTypeBuilder<Guide> b)
    {
        b.Property(x => x.Title).IsRequired().HasMaxLength(200);
        b.Property(x => x.Content).IsRequired();
        b.HasMany(x => x.Sources).WithOne(s => s.Guide).HasForeignKey(s => s.GuideId).OnDelete(DeleteBehavior.Cascade);
    }
}
