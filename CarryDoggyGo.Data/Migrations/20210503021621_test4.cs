using Microsoft.EntityFrameworkCore.Migrations;

namespace CarryDoggyGo.Data.Migrations
{
    public partial class test4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_care_item_dogs_DogId",
                table: "care_item");

            migrationBuilder.DropIndex(
                name: "IX_care_item_DogId",
                table: "care_item");

            migrationBuilder.DropColumn(
                name: "DogId",
                table: "care_item");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DogId",
                table: "care_item",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_care_item_DogId",
                table: "care_item",
                column: "DogId");

            migrationBuilder.AddForeignKey(
                name: "FK_care_item_dogs_DogId",
                table: "care_item",
                column: "DogId",
                principalTable: "dogs",
                principalColumn: "dog_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
