using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore_MVC.Migrations
{
    /// <inheritdoc />
    public partial class DbContextChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerEditModel",
                table: "CustomerEditModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerDetailModel",
                table: "CustomerDetailModel");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8bdc058-0ad4-4d75-a482-8a147ae920ca");

            migrationBuilder.RenameTable(
                name: "CustomerEditModel",
                newName: "CustomerEdit");

            migrationBuilder.RenameTable(
                name: "CustomerDetailModel",
                newName: "CustomerDetail");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerEdit",
                table: "CustomerEdit",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerDetail",
                table: "CustomerDetail",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "de9b5f4f-4c04-47b1-a9e0-0d9484e56160", null, "Admin", "ADMIN" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerEdit",
                table: "CustomerEdit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerDetail",
                table: "CustomerDetail");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de9b5f4f-4c04-47b1-a9e0-0d9484e56160");

            migrationBuilder.RenameTable(
                name: "CustomerEdit",
                newName: "CustomerEditModel");

            migrationBuilder.RenameTable(
                name: "CustomerDetail",
                newName: "CustomerDetailModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerEditModel",
                table: "CustomerEditModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerDetailModel",
                table: "CustomerDetailModel",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e8bdc058-0ad4-4d75-a482-8a147ae920ca", null, "Admin", "ADMIN" });
        }
    }
}
