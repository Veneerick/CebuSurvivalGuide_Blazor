using CebuSurvivalGuide.Components;
using CebuSurvivalGuide.Data;
using CebuSurvivalGuide.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddSingleton<IGuideDataService, GuideDataService>();

var connectionString = builder.Configuration.GetConnectionString("Default") ?? "Data Source=cebu.db";
builder.Services.AddDbContextFactory<AppDbContext>(o => o.UseSqlite(connectionString));

var app = builder.Build();

// Create or update the SQLite database on startup.
using (var db = app.Services.GetRequiredService<IDbContextFactory<AppDbContext>>().CreateDbContext())
{
    db.Database.Migrate();
}

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
app.Run();
