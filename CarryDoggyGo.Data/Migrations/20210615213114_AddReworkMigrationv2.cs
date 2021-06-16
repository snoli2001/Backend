using Microsoft.EntityFrameworkCore.Migrations;

namespace CarryDoggyGo.Data.Migrations
{
    public partial class AddReworkMigrationv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_city_id",
                table: "locations");

            migrationBuilder.DropIndex(
                name: "IX_locations_city_id",
                table: "locations");

            migrationBuilder.DropColumn(
                name: "city_id",
                table: "locations");

            migrationBuilder.AddColumn<int>(
                name: "city_id",
                table: "districts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_districts_city_id",
                table: "districts",
                column: "city_id");

            migrationBuilder.AddForeignKey(
                name: "FK_city_id",
                table: "districts",
                column: "city_id",
                principalTable: "cities",
                principalColumn: "city_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_city_id",
                table: "districts");

            migrationBuilder.DropIndex(
                name: "IX_districts_city_id",
                table: "districts");

            migrationBuilder.DropColumn(
                name: "city_id",
                table: "districts");

            migrationBuilder.AddColumn<int>(
                name: "city_id",
                table: "locations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_locations_city_id",
                table: "locations",
                column: "city_id");

            migrationBuilder.AddForeignKey(
                name: "FK_city_id",
                table: "locations",
                column: "city_id",
                principalTable: "cities",
                principalColumn: "city_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
