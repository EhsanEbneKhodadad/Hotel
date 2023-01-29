using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel.Migrations
{
    public partial class AddRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2a5c9696-5b22-4236-a245-866d2a73e3ca", "f0bde3a7-341e-4d8c-a7fd-ba46f2ae0699", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "601fad72-a1d7-4a7b-92b3-b017b4b78a0c", "7d92e2cb-b8ba-4ebf-9b80-788fc61ade90", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a5c9696-5b22-4236-a245-866d2a73e3ca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "601fad72-a1d7-4a7b-92b3-b017b4b78a0c");
        }
    }
}
