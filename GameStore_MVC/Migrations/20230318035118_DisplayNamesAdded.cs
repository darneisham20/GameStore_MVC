using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore_MVC.Migrations
{
    /// <inheritdoc />
    public partial class DisplayNamesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de9b5f4f-4c04-47b1-a9e0-0d9484e56160");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ae59be10-2a89-4ca7-8ad2-3ba1e51e0824", null, "Admin", "ADMIN" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae59be10-2a89-4ca7-8ad2-3ba1e51e0824");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "de9b5f4f-4c04-47b1-a9e0-0d9484e56160", null, "Admin", "ADMIN" });
        }
    }
}
