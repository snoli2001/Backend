using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarryDoggyGo.Data.Migrations
{
    public partial class Add190621 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "care_item",
                columns: table => new
                {
                    care_item_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_care_item", x => x.care_item_id);
                });

            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cities", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "dog_walkers",
                columns: table => new
                {
                    dog_walker_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    payment_amount = table.Column<int>(type: "int", unicode: false, nullable: false),
                    Qualification = table.Column<int>(type: "int", nullable: false),
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
                name: "locations",
                columns: table => new
                {
                    location_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    address = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    position_x = table.Column<int>(type: "int", nullable: false),
                    position_y = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locations", x => x.location_id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    PaymentTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.PaymentTypeId);
                });

            migrationBuilder.CreateTable(
                name: "districts",
                columns: table => new
                {
                    DistrictId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_districts", x => x.DistrictId);
                    table.ForeignKey(
                        name: "FK_districts_cities_CityId",
                        column: x => x.CityId,
                        principalTable: "cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "notification_dogwalker",
                columns: table => new
                {
                    notification_dogwalker_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dog_walker_id = table.Column<int>(type: "int", nullable: false),
                    shipping_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    accept_deny = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notification_dogwalker", x => x.notification_dogwalker_id);
                    table.ForeignKey(
                        name: "FK_notification_dogwalker_dog_walkers_dog_walker_id",
                        column: x => x.dog_walker_id,
                        principalTable: "dog_walkers",
                        principalColumn: "dog_walker_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dog_owners",
                columns: table => new
                {
                    dog_owner_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_dog_owners_districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "districts",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dog_walk",
                columns: table => new
                {
                    dog_walk_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hours = table.Column<int>(type: "int", nullable: false),
                    aditional_information = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    payment_amount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DogWalkerId = table.Column<int>(type: "int", nullable: false),
                    QualificationId = table.Column<int>(type: "int", nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    address = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    state = table.Column<int>(type: "int", nullable: false),
                    PaymentTypeId = table.Column<int>(type: "int", nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dog_walk", x => x.dog_walk_id);
                    table.ForeignKey(
                        name: "FK_dog_walk_districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "districts",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dog_walk_dog_walkers_DogWalkerId",
                        column: x => x.DogWalkerId,
                        principalTable: "dog_walkers",
                        principalColumn: "dog_walker_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dog_walk_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentTypes",
                        principalColumn: "PaymentTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DogWalkerDistricts",
                columns: table => new
                {
                    DogWalkerkId = table.Column<int>(type: "int", nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogWalkerDistricts", x => new { x.DogWalkerkId, x.DistrictId });
                    table.ForeignKey(
                        name: "FK_DogWalkerDistricts_districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "districts",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DogWalkerDistricts_dog_walkers_DogWalkerkId",
                        column: x => x.DogWalkerkId,
                        principalTable: "dog_walkers",
                        principalColumn: "dog_walker_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DogOwnerNotifications",
                columns: table => new
                {
                    DogOwnerNotificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "dogwalk_location",
                columns: table => new
                {
                    dogwalk_id = table.Column<int>(type: "int", nullable: false),
                    location_id = table.Column<int>(type: "int", nullable: false),
                    date_register = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dogwalk_location", x => new { x.dogwalk_id, x.location_id });
                    table.ForeignKey(
                        name: "FK_dogwalk_id",
                        column: x => x.dogwalk_id,
                        principalTable: "dog_walk",
                        principalColumn: "dog_walk_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_location_id",
                        column: x => x.location_id,
                        principalTable: "locations",
                        principalColumn: "location_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsImportant = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DogWalkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Messages_dog_walk_DogWalkId",
                        column: x => x.DogWalkId,
                        principalTable: "dog_walk",
                        principalColumn: "dog_walk_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "qualification",
                columns: table => new
                {
                    qualification_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    starts = table.Column<int>(type: "int", unicode: false, nullable: false),
                    description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    DogWalkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qualification", x => x.qualification_id);
                    table.ForeignKey(
                        name: "FK_qualification_dog_walk_DogWalkId",
                        column: x => x.DogWalkId,
                        principalTable: "dog_walk",
                        principalColumn: "dog_walk_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    ReportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    DogWalkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.ReportId);
                    table.ForeignKey(
                        name: "FK_Reports_dog_walk_DogWalkId",
                        column: x => x.DogWalkId,
                        principalTable: "dog_walk",
                        principalColumn: "dog_walk_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dog_care_items",
                columns: table => new
                {
                    DogId = table.Column<int>(type: "int", nullable: false),
                    CareItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dog_care_items", x => new { x.DogId, x.CareItemId });
                    table.ForeignKey(
                        name: "FK_dog_care_items_care_item_CareItemId",
                        column: x => x.CareItemId,
                        principalTable: "care_item",
                        principalColumn: "care_item_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dog_care_items_dogs_DogId",
                        column: x => x.DogId,
                        principalTable: "dogs",
                        principalColumn: "dog_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dog_walk_dog",
                columns: table => new
                {
                    dog_walk_id = table.Column<int>(type: "int", nullable: false),
                    dog_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dog_walk_dog", x => new { x.dog_id, x.dog_walk_id });
                    table.ForeignKey(
                        name: "FK_dog_id",
                        column: x => x.dog_id,
                        principalTable: "dogs",
                        principalColumn: "dog_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dog_walk_id",
                        column: x => x.dog_walk_id,
                        principalTable: "dog_walk",
                        principalColumn: "dog_walk_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_districts_CityId",
                table: "districts",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_dog_care_items_CareItemId",
                table: "dog_care_items",
                column: "CareItemId");

            migrationBuilder.CreateIndex(
                name: "IX_dog_owners_DistrictId",
                table: "dog_owners",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_dog_walk_DistrictId",
                table: "dog_walk",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_dog_walk_DogWalkerId",
                table: "dog_walk",
                column: "DogWalkerId");

            migrationBuilder.CreateIndex(
                name: "IX_dog_walk_PaymentTypeId",
                table: "dog_walk",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_dog_walk_dog_dog_walk_id",
                table: "dog_walk_dog",
                column: "dog_walk_id");

            migrationBuilder.CreateIndex(
                name: "IX_DogOwnerNotifications_DogOwnerId",
                table: "DogOwnerNotifications",
                column: "DogOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_dogs_DogOwnerId",
                table: "dogs",
                column: "DogOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_dogwalk_location_location_id",
                table: "dogwalk_location",
                column: "location_id");

            migrationBuilder.CreateIndex(
                name: "IX_DogWalkerDistricts_DistrictId",
                table: "DogWalkerDistricts",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_DogWalkId",
                table: "Messages",
                column: "DogWalkId");

            migrationBuilder.CreateIndex(
                name: "IX_notification_dogwalker_dog_walker_id",
                table: "notification_dogwalker",
                column: "dog_walker_id");

            migrationBuilder.CreateIndex(
                name: "IX_qualification_DogWalkId",
                table: "qualification",
                column: "DogWalkId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reports_DogWalkId",
                table: "Reports",
                column: "DogWalkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dog_care_items");

            migrationBuilder.DropTable(
                name: "dog_walk_dog");

            migrationBuilder.DropTable(
                name: "DogOwnerNotifications");

            migrationBuilder.DropTable(
                name: "dogwalk_location");

            migrationBuilder.DropTable(
                name: "DogWalkerDistricts");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "notification_dogwalker");

            migrationBuilder.DropTable(
                name: "qualification");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "care_item");

            migrationBuilder.DropTable(
                name: "dogs");

            migrationBuilder.DropTable(
                name: "locations");

            migrationBuilder.DropTable(
                name: "dog_walk");

            migrationBuilder.DropTable(
                name: "dog_owners");

            migrationBuilder.DropTable(
                name: "dog_walkers");

            migrationBuilder.DropTable(
                name: "PaymentTypes");

            migrationBuilder.DropTable(
                name: "districts");

            migrationBuilder.DropTable(
                name: "cities");
        }
    }
}
