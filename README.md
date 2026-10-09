# Cebu Survival Guide (Blazor + Tailwind)

Requires the .NET SDK and Node.js.

    npm install
    npm run css        (or: npm run css:watch while editing)
    dotnet run

Tailwind input is Styles/app.css and the generated output is wwwroot/tailwind.css.

## Database (SQLite + EF Core)

The database file `cebu.db` is created automatically on first run (it is git-ignored).

    dotnet tool install --global dotnet-ef
    dotnet ef migrations add <MigrationName>     (after changing models)
    dotnet ef database update                    (optional, the app also migrates on startup)

Entity classes are in Models/, their mapping is in Data/Configurations/, and sample data is in Data/SeedData.cs.
