using Microsoft.EntityFrameworkCore.Migrations;

namespace CarryDoggyGo.Data.Migrations
{
    public partial class updtMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "state",
                table: "dog_walk",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "state",
                table: "dog_walk");
        }
    }
}
