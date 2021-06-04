using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarryDoggyGo.Data.Migrations
{
    public partial class NotificationDogWalker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "notification_dogwalker",
                columns: table => new
                {
                    notification_dogwalker_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DogWalkerId = table.Column<int>(type: "int", nullable: false),
                    shipping_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    accept_deny = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notification_dogwalker", x => x.notification_dogwalker_id);
                    table.ForeignKey(
                        name: "FK_notification_dogwalker_dog_walkers_DogWalkerId",
                        column: x => x.DogWalkerId,
                        principalTable: "dog_walkers",
                        principalColumn: "dog_walker_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_notification_dogwalker_DogWalkerId",
                table: "notification_dogwalker",
                column: "DogWalkerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "notification_dogwalker");
        }
    }
}
