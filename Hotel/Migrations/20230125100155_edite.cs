using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel.Migrations
{
    public partial class edite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_Countries_CountryId",
                table: "Hotels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hotels",
                table: "Hotels");

            migrationBuilder.RenameTable(
                name: "Hotels",
                newName: "HotelsData");

            migrationBuilder.RenameIndex(
                name: "IX_Hotels_CountryId",
                table: "HotelsData",
                newName: "IX_HotelsData_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelsData",
                table: "HotelsData",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelsData_Countries_CountryId",
                table: "HotelsData",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelsData_Countries_CountryId",
                table: "HotelsData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelsData",
                table: "HotelsData");

            migrationBuilder.RenameTable(
                name: "HotelsData",
                newName: "Hotels");

            migrationBuilder.RenameIndex(
                name: "IX_HotelsData_CountryId",
                table: "Hotels",
                newName: "IX_Hotels_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hotels",
                table: "Hotels",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_Countries_CountryId",
                table: "Hotels",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
