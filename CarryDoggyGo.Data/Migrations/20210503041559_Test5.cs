using Microsoft.EntityFrameworkCore.Migrations;

namespace CarryDoggyGo.Data.Migrations
{
    public partial class Test5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DogWalk_dog_owners_DogOwnerId",
                table: "DogWalk");

            migrationBuilder.DropForeignKey(
                name: "FK_DogWalk_dog_walkers_DogWalkerId",
                table: "DogWalk");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DogWalk",
                table: "DogWalk");

            migrationBuilder.RenameTable(
                name: "DogWalk",
                newName: "dog_walk");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "dog_walk",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "Calification",
                table: "dog_walk",
                newName: "calification");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "dog_walk",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "PaymentAmount",
                table: "dog_walk",
                newName: "payment_amount");

            migrationBuilder.RenameColumn(
                name: "Hours",
                table: "dog_walk",
                newName: "cantidad_horas");

            migrationBuilder.RenameColumn(
                name: "DogWalkerId",
                table: "dog_walk",
                newName: "dog_walker_id");

            migrationBuilder.RenameColumn(
                name: "DogOwnerId",
                table: "dog_walk",
                newName: "dog_owner_id");

            migrationBuilder.RenameColumn(
                name: "AditionalInformation",
                table: "dog_walk",
                newName: "aditional_information");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "dog_walk",
                newName: "dog_walk_id");

            migrationBuilder.RenameIndex(
                name: "IX_DogWalk_DogWalkerId",
                table: "dog_walk",
                newName: "IX_dog_walk_dog_walker_id");

            migrationBuilder.RenameIndex(
                name: "IX_DogWalk_DogOwnerId",
                table: "dog_walk",
                newName: "IX_dog_walk_dog_owner_id");

            migrationBuilder.AlterColumn<string>(
                name: "address",
                table: "dog_walk",
                type: "varchar(500)",
                unicode: false,
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "payment_amount",
                table: "dog_walk",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "aditional_information",
                table: "dog_walk",
                type: "varchar(500)",
                unicode: false,
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_dog_walk",
                table: "dog_walk",
                column: "dog_walk_id");

            migrationBuilder.AddForeignKey(
                name: "fk_dog_walk_dog_owner",
                table: "dog_walk",
                column: "dog_owner_id",
                principalTable: "dog_owners",
                principalColumn: "dog_owner_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_dog_walk_dog_walker",
                table: "dog_walk",
                column: "dog_walker_id",
                principalTable: "dog_walkers",
                principalColumn: "dog_walker_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_dog_walk_dog_owner",
                table: "dog_walk");

            migrationBuilder.DropForeignKey(
                name: "fk_dog_walk_dog_walker",
                table: "dog_walk");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dog_walk",
                table: "dog_walk");

            migrationBuilder.RenameTable(
                name: "dog_walk",
                newName: "DogWalk");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "DogWalk",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "calification",
                table: "DogWalk",
                newName: "Calification");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "DogWalk",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "payment_amount",
                table: "DogWalk",
                newName: "PaymentAmount");

            migrationBuilder.RenameColumn(
                name: "dog_walker_id",
                table: "DogWalk",
                newName: "DogWalkerId");

            migrationBuilder.RenameColumn(
                name: "dog_owner_id",
                table: "DogWalk",
                newName: "DogOwnerId");

            migrationBuilder.RenameColumn(
                name: "cantidad_horas",
                table: "DogWalk",
                newName: "Hours");

            migrationBuilder.RenameColumn(
                name: "aditional_information",
                table: "DogWalk",
                newName: "AditionalInformation");

            migrationBuilder.RenameColumn(
                name: "dog_walk_id",
                table: "DogWalk",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_dog_walk_dog_walker_id",
                table: "DogWalk",
                newName: "IX_DogWalk_DogWalkerId");

            migrationBuilder.RenameIndex(
                name: "IX_dog_walk_dog_owner_id",
                table: "DogWalk",
                newName: "IX_DogWalk_DogOwnerId");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "DogWalk",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldUnicode: false,
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PaymentAmount",
                table: "DogWalk",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "AditionalInformation",
                table: "DogWalk",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldUnicode: false,
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DogWalk",
                table: "DogWalk",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DogWalk_dog_owners_DogOwnerId",
                table: "DogWalk",
                column: "DogOwnerId",
                principalTable: "dog_owners",
                principalColumn: "dog_owner_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DogWalk_dog_walkers_DogWalkerId",
                table: "DogWalk",
                column: "DogWalkerId",
                principalTable: "dog_walkers",
                principalColumn: "dog_walker_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
