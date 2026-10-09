using CebuSurvivalGuide.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CebuSurvivalGuide.Data.Configurations;

public class NewsArticleConfiguration : IEntityTypeConfiguration<NewsArticle>
{
    public void Configure(EntityTypeBuilder<NewsArticle> b)
    {
        b.Property(x => x.Title).IsRequired().HasMaxLength(255);
        b.Property(x => x.Content).IsRequired();
        b.Property(x => x.Source).IsRequired().HasMaxLength(150);
        b.Property(x => x.SourceUrl).IsRequired().HasMaxLength(500);
        b.HasIndex(x => x.PublishedAt);
    }
}
