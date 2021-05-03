using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarryDoggyGo.Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dog_owners",
                columns: table => new
                {
                    dog_owner_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    lastname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    phone = table.Column<string>(type: "varchar(9)", unicode: false, maxLength: 9, nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    resgister_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dog_owners", x => x.dog_owner_id);
                });

            migrationBuilder.CreateTable(
                name: "dog_walkers",
                columns: table => new
                {
                    dog_walker_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    payment_amount = table.Column<int>(type: "int", unicode: false, nullable: false),
                    calification = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    lastname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    phone = table.Column<string>(type: "varchar(9)", unicode: false, maxLength: 9, nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    resgister_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dog_walkers", x => x.dog_walker_id);
                });

            migrationBuilder.CreateTable(
                name: "dogs",
                columns: table => new
                {
                    dog_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    race = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    diseases = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    DogOwnerId = table.Column<int>(type: "int", nullable: false),
                    medical_information = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dogs", x => x.dog_id);
                    table.ForeignKey(
                        name: "FK_dogs_dog_owners_DogOwnerId",
                        column: x => x.DogOwnerId,
                        principalTable: "dog_owners",
                        principalColumn: "dog_owner_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DogWalk",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hours = table.Column<int>(type: "int", nullable: false),
                    AditionalInformation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentAmount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Calification = table.Column<int>(type: "int", nullable: false),
                    DogWalkerId = table.Column<int>(type: "int", nullable: false),
                    DogOwnerId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogWalk", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DogWalk_dog_owners_DogOwnerId",
                        column: x => x.DogOwnerId,
                        principalTable: "dog_owners",
                        principalColumn: "dog_owner_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DogWalk_dog_walkers_DogWalkerId",
                        column: x => x.DogWalkerId,
                        principalTable: "dog_walkers",
                        principalColumn: "dog_walker_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CareItem",
                columns: table => new
                {
                    CareItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DogId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareItem", x => x.CareItemId);
                    table.ForeignKey(
                        name: "FK_CareItem_dogs_DogId",
                        column: x => x.DogId,
                        principalTable: "dogs",
                        principalColumn: "dog_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DogCareItems",
                columns: table => new
                {
                    DogId = table.Column<int>(type: "int", nullable: false),
                    CareItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogCareItems", x => new { x.DogId, x.CareItemId });
                    table.ForeignKey(
                        name: "FK_DogCareItems_CareItem_CareItemId",
                        column: x => x.CareItemId,
                        principalTable: "CareItem",
                        principalColumn: "CareItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DogCareItems_dogs_DogId",
                        column: x => x.DogId,
                        principalTable: "dogs",
                        principalColumn: "dog_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CareItem_DogId",
                table: "CareItem",
                column: "DogId");

            migrationBuilder.CreateIndex(
                name: "IX_DogCareItems_CareItemId",
                table: "DogCareItems",
                column: "CareItemId");

            migrationBuilder.CreateIndex(
                name: "IX_dogs_DogOwnerId",
                table: "dogs",
                column: "DogOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_DogWalk_DogOwnerId",
                table: "DogWalk",
                column: "DogOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_DogWalk_DogWalkerId",
                table: "DogWalk",
                column: "DogWalkerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DogCareItems");

            migrationBuilder.DropTable(
                name: "DogWalk");

            migrationBuilder.DropTable(
                name: "CareItem");

            migrationBuilder.DropTable(
                name: "dog_walkers");

            migrationBuilder.DropTable(
                name: "dogs");

            migrationBuilder.DropTable(
                name: "dog_owners");
        }
    }
}
