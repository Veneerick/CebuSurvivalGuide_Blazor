using CebuSurvivalGuide.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CebuSurvivalGuide.Data.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> b)
    {
        b.Property(x => x.Name).IsRequired().HasMaxLength(100);
        b.Property(x => x.Description).IsRequired().HasDefaultValue("");
        b.HasIndex(x => x.Name).IsUnique();
        b.HasMany(x => x.Guides).WithOne(g => g.Category).HasForeignKey(g => g.CategoryId).OnDelete(DeleteBehavior.Restrict);
    }
}
