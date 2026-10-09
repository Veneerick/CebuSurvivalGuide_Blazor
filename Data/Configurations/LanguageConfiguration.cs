using CebuSurvivalGuide.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CebuSurvivalGuide.Data.Configurations;

public class LanguageConfiguration : IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> b)
    {
        b.Property(x => x.Category).IsRequired().HasMaxLength(50);
        b.Property(x => x.Phrase).IsRequired().HasMaxLength(255);
        b.Property(x => x.Translation).IsRequired().HasMaxLength(255);
        b.Property(x => x.Pronunciation).IsRequired().HasMaxLength(255).HasDefaultValue("");
        b.Property(x => x.Description).IsRequired().HasDefaultValue("");
        b.HasIndex(x => x.Category);
    }
}
