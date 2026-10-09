using CebuSurvivalGuide.Models;
using Microsoft.EntityFrameworkCore;

namespace CebuSurvivalGuide.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // DbSets
    public DbSet<NewsArticle> NewsArticles => Set<NewsArticle>();
    public DbSet<Language> Languages => Set<Language>();
    public DbSet<User> Users => Set<User>();
    public DbSet<CommunityMadePage> CommunityMadePages => Set<CommunityMadePage>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Guide> Guides => Set<Guide>();
    public DbSet<Source> Sources => Set<Source>();
    public DbSet<EmergencyContact> EmergencyContacts => Set<EmergencyContact>();
    public DbSet<JeepRoute> JeepRoutes => Set<JeepRoute>();
    public DbSet<JeepStop> JeepStops => Set<JeepStop>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        modelBuilder.Seed();
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        Stamp();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        Stamp();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    private void Stamp()
    {
        var now = DateTime.UtcNow;
        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.State == EntityState.Added && entry.Entity is IHasCreatedAt created)
                created.CreatedAt = now;
            if (entry.State is EntityState.Added or EntityState.Modified && entry.Entity is IHasUpdatedAt updated)
                updated.UpdatedAt = now;
        }
    }
}
