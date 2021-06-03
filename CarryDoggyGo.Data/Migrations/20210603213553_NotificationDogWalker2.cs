using Microsoft.EntityFrameworkCore.Migrations;

namespace CarryDoggyGo.Data.Migrations
{
    public partial class NotificationDogWalker2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_notification_dogwalker_dog_walkers_DogWalkerId",
                table: "notification_dogwalker");

            migrationBuilder.RenameColumn(
                name: "DogWalkerId",
                table: "notification_dogwalker",
                newName: "dog_walker_id");

            migrationBuilder.RenameIndex(
                name: "IX_notification_dogwalker_DogWalkerId",
                table: "notification_dogwalker",
                newName: "IX_notification_dogwalker_dog_walker_id");

            migrationBuilder.AddForeignKey(
                name: "FK_notification_dogwalker_dog_walkers_dog_walker_id",
                table: "notification_dogwalker",
                column: "dog_walker_id",
                principalTable: "dog_walkers",
                principalColumn: "dog_walker_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_notification_dogwalker_dog_walkers_dog_walker_id",
                table: "notification_dogwalker");

            migrationBuilder.RenameColumn(
                name: "dog_walker_id",
                table: "notification_dogwalker",
                newName: "DogWalkerId");

            migrationBuilder.RenameIndex(
                name: "IX_notification_dogwalker_dog_walker_id",
                table: "notification_dogwalker",
                newName: "IX_notification_dogwalker_DogWalkerId");

            migrationBuilder.AddForeignKey(
                name: "FK_notification_dogwalker_dog_walkers_DogWalkerId",
                table: "notification_dogwalker",
                column: "DogWalkerId",
                principalTable: "dog_walkers",
                principalColumn: "dog_walker_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
