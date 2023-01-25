using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel.Migrations
{
    public partial class AddData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "ShortName" },
                values: new object[] { 1, "Country 1", "C1" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "ShortName" },
                values: new object[] { 2, "Country 2", "C2" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "ShortName" },
                values: new object[] { 3, "Country 3", "C3" });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "CountryId", "Name" },
                values: new object[] { 1, "A 1", 1, "Hotel 1" });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "CountryId", "Name" },
                values: new object[] { 2, "A 2", 2, "Hotel 2" });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "CountryId", "Name" },
                values: new object[] { 3, "A 3", 3, "Hotel 3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
