using Microsoft.EntityFrameworkCore.Migrations;

namespace CarryDoggyGo.Data.Migrations
{
    public partial class AddPaymentType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentTypeId",
                table: "dog_walk",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    PaymentTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.PaymentTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dog_walk_PaymentTypeId",
                table: "dog_walk",
                column: "PaymentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_dog_walk_PaymentTypes_PaymentTypeId",
                table: "dog_walk",
                column: "PaymentTypeId",
                principalTable: "PaymentTypes",
                principalColumn: "PaymentTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dog_walk_PaymentTypes_PaymentTypeId",
                table: "dog_walk");

            migrationBuilder.DropTable(
                name: "PaymentTypes");

            migrationBuilder.DropIndex(
                name: "IX_dog_walk_PaymentTypeId",
                table: "dog_walk");

            migrationBuilder.DropColumn(
                name: "PaymentTypeId",
                table: "dog_walk");
        }
    }
}
