using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CebuSurvivalGuide.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmergencyContacts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ServiceName = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    ServiceType = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false, defaultValue: ""),
                    WebsiteUrl = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false, defaultValue: ""),
                    Description = table.Column<string>(type: "TEXT", nullable: false, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyContacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JeepRoutes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RouteName = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    VehicleType = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    StartingPoint = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Destination = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Fare = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false, defaultValue: ""),
                    OperatingHours = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false, defaultValue: ""),
                    Description = table.Column<string>(type: "TEXT", nullable: false, defaultValue: ""),
                    SourceUrl = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false, defaultValue: ""),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JeepRoutes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Category = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Phrase = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Translation = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Pronunciation = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false, defaultValue: ""),
                    Description = table.Column<string>(type: "TEXT", nullable: false, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewsArticles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    Source = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    SourceUrl = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    PublishedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsArticles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Role = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false, defaultValue: "member"),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Guides",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryId = table.Column<long>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guides", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Guides_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JeepStops",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RouteId = table.Column<long>(type: "INTEGER", nullable: false),
                    StopName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    StopOrder = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JeepStops", x => x.Id);
                    table.CheckConstraint("CK_JeepStops_StopOrder", "StopOrder >= 0");
                    table.ForeignKey(
                        name: "FK_JeepStops_JeepRoutes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "JeepRoutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommunityMadePages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<long>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    SourceUrl = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false, defaultValue: ""),
                    Status = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false, defaultValue: "pending"),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityMadePages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommunityMadePages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sources",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GuideId = table.Column<long>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Url = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sources_Guides_GuideId",
                        column: x => x.GuideId,
                        principalTable: "Guides",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1L, "Transport basics for visitors.", "Getting Around" },
                    { 2L, "Staying safe in Cebu.", "Safety" }
                });

            migrationBuilder.InsertData(
                table: "EmergencyContacts",
                columns: new[] { "Id", "Address", "Description", "PhoneNumber", "ServiceName", "ServiceType", "WebsiteUrl" },
                values: new object[,]
                {
                    { 1L, "", "Crime, theft, or immediate danger.", "911", "Police", "police", "" },
                    { 2L, "", "Fires, explosions, and rescue situations.", "911", "Fire Department", "fire", "" },
                    { 3L, "", "Serious injury or sudden illness needing urgent care.", "911", "Ambulance / Medical Emergency", "medical", "" },
                    { 4L, "", "First aid, blood services, and disaster response.", "143", "Philippine Red Cross", "disaster", "https://redcross.org.ph" }
                });

            migrationBuilder.InsertData(
                table: "JeepRoutes",
                columns: new[] { "Id", "CreatedAt", "Description", "Destination", "Fare", "OperatingHours", "RouteName", "SourceUrl", "StartingPoint", "UpdatedAt", "VehicleType" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Via Mango Avenue (sample data)", "Colon", "", "", "04L", "", "Lahug", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Jeepney" },
                    { 2L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Via Osmeña Blvd (sample data)", "Carbon Market", "", "", "17B", "", "Ayala Center", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Jeepney" },
                    { 3L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Via Escario Street (sample data)", "SM City", "", "", "01K", "", "Talamban", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Jeepney" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Category", "Description", "Phrase", "Pronunciation", "Translation" },
                values: new object[,]
                {
                    { 1L, "Greetings", "", "Salamat", "sah-LAH-maht", "Thank you" },
                    { 2L, "Greetings", "", "Palihug", "pah-lee-HOOG", "Please" },
                    { 3L, "Shopping", "", "Pila ni?", "PEE-lah nee", "How much is this?" }
                });

            migrationBuilder.InsertData(
                table: "Guides",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedAt", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, 1L, "Flag the jeepney down, pass your fare forward, and say 'para' when you want to get off. (Sample content)", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Riding a jeepney", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 2L, 2L, "Save 911 in your phone and know the nearest hospital before you travel. (Sample content)", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Emergency basics", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "JeepStops",
                columns: new[] { "Id", "RouteId", "StopName", "StopOrder" },
                values: new object[,]
                {
                    { 1L, 1L, "Lahug", 0 },
                    { 2L, 1L, "JY Square", 1 },
                    { 3L, 1L, "Mango Avenue", 2 },
                    { 4L, 1L, "Fuente Osmeña", 3 },
                    { 5L, 1L, "Colon", 4 },
                    { 6L, 2L, "Ayala Center", 0 },
                    { 7L, 2L, "Cebu Business Park", 1 },
                    { 8L, 2L, "Osmeña Blvd", 2 },
                    { 9L, 2L, "Carbon Market", 3 },
                    { 10L, 3L, "Talamban", 0 },
                    { 11L, 3L, "Gorordo Avenue", 1 },
                    { 12L, 3L, "Escario Street", 2 },
                    { 13L, 3L, "SM City", 3 }
                });

            migrationBuilder.InsertData(
                table: "Sources",
                columns: new[] { "Id", "Description", "GuideId", "Name", "Url" },
                values: new object[,]
                {
                    { 1L, "Replace with a real reference.", 1L, "Placeholder source", "https://example.com/jeepney" },
                    { 2L, "Replace with a real reference.", 2L, "Placeholder source", "https://example.com/safety" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommunityMadePages_Status",
                table: "CommunityMadePages",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityMadePages_UserId",
                table: "CommunityMadePages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyContacts_ServiceType",
                table: "EmergencyContacts",
                column: "ServiceType");

            migrationBuilder.CreateIndex(
                name: "IX_Guides_CategoryId",
                table: "Guides",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_JeepRoutes_VehicleType",
                table: "JeepRoutes",
                column: "VehicleType");

            migrationBuilder.CreateIndex(
                name: "IX_JeepStops_RouteId_StopOrder",
                table: "JeepStops",
                columns: new[] { "RouteId", "StopOrder" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Languages_Category",
                table: "Languages",
                column: "Category");

            migrationBuilder.CreateIndex(
                name: "IX_NewsArticles_PublishedAt",
                table: "NewsArticles",
                column: "PublishedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Sources_GuideId",
                table: "Sources",
                column: "GuideId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommunityMadePages");

            migrationBuilder.DropTable(
                name: "EmergencyContacts");

            migrationBuilder.DropTable(
                name: "JeepStops");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "NewsArticles");

            migrationBuilder.DropTable(
                name: "Sources");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "JeepRoutes");

            migrationBuilder.DropTable(
                name: "Guides");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
