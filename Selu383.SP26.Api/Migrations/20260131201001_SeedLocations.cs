using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Selu383.SP26.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedLocations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "Id", "Address", "Name", "TableCount" },
                values: new object[,]
                {
                    { 1, "123 Main St", "Test Location 1", 10 },
                    { 2, "456 Oak Ave", "Test Location 2", 8 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
