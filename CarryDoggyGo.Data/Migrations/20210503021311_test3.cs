using Microsoft.EntityFrameworkCore.Migrations;

namespace CarryDoggyGo.Data.Migrations
{
    public partial class test3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CareItem_dogs_DogId",
                table: "CareItem");

            migrationBuilder.DropForeignKey(
                name: "FK_DogCareItems_CareItem_CareItemId",
                table: "DogCareItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CareItem",
                table: "CareItem");

            migrationBuilder.RenameTable(
                name: "CareItem",
                newName: "care_item");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "care_item",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "care_item",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "CareItemId",
                table: "care_item",
                newName: "care_item_id");

            migrationBuilder.RenameIndex(
                name: "IX_CareItem_DogId",
                table: "care_item",
                newName: "IX_care_item_DogId");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "care_item",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "care_item",
                type: "varchar(500)",
                unicode: false,
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_care_item",
                table: "care_item",
                column: "care_item_id");

            migrationBuilder.AddForeignKey(
                name: "FK_care_item_dogs_DogId",
                table: "care_item",
                column: "DogId",
                principalTable: "dogs",
                principalColumn: "dog_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DogCareItems_care_item_CareItemId",
                table: "DogCareItems",
                column: "CareItemId",
                principalTable: "care_item",
                principalColumn: "care_item_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_care_item_dogs_DogId",
                table: "care_item");

            migrationBuilder.DropForeignKey(
                name: "FK_DogCareItems_care_item_CareItemId",
                table: "DogCareItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_care_item",
                table: "care_item");

            migrationBuilder.RenameTable(
                name: "care_item",
                newName: "CareItem");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "CareItem",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "CareItem",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "care_item_id",
                table: "CareItem",
                newName: "CareItemId");

            migrationBuilder.RenameIndex(
                name: "IX_care_item_DogId",
                table: "CareItem",
                newName: "IX_CareItem_DogId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CareItem",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "CareItem",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldUnicode: false,
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CareItem",
                table: "CareItem",
                column: "CareItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_CareItem_dogs_DogId",
                table: "CareItem",
                column: "DogId",
                principalTable: "dogs",
                principalColumn: "dog_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DogCareItems_CareItem_CareItemId",
                table: "DogCareItems",
                column: "CareItemId",
                principalTable: "CareItem",
                principalColumn: "CareItemId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
