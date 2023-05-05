using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Labb_4_API.Migrations
{
    /// <inheritdoc />
    public partial class AddDataMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "InterestId", "InterestDescription", "InterestName" },
                values: new object[,]
                {
                    { 1, "Social Media Description", "Social Media" },
                    { 2, "Music Description", "Music" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "John", "Doe", "555-1234" },
                    { 2, "Sam", "Andersson", "555-5678" }
                });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "LinkId", "InterestId", "LinkURL", "PersonId" },
                values: new object[,]
                {
                    { 1, 1, "twitter.com", 1 },
                    { 2, 1, "instagram.com", 1 },
                    { 3, 2, "spotify.com", 2 },
                    { 4, 2, "soundcloud.com", 2 },
                    { 5, 2, "soundcloud.com", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "LinkId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "LinkId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "LinkId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "LinkId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "LinkId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "PersonId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "PersonId",
                keyValue: 2);
        }
    }
}
