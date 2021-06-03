using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarryDoggyGo.Data.Migrations
{
    public partial class AddDogOwnerNotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DogOwnerNotifications",
                columns: table => new
                {
                    DogOwnerNotificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DogOwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogOwnerNotifications", x => x.DogOwnerNotificationId);
                    table.ForeignKey(
                        name: "FK_DogOwnerNotifications_dog_owners_DogOwnerId",
                        column: x => x.DogOwnerId,
                        principalTable: "dog_owners",
                        principalColumn: "dog_owner_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DogOwnerNotifications_DogOwnerId",
                table: "DogOwnerNotifications",
                column: "DogOwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DogOwnerNotifications");
        }
    }
}
