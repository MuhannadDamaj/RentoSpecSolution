using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentospectWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class car01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarCategories_CarCategoryID",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarMakes_CarMakeID",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarModels_CarModelID",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CarCategoryID",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CarMakeID",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CarModelID",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarCategoryID",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarMakeID",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarModelID",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ChassisNumber",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "EngineNumber",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "CarMake",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CarMode",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarMake",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarMode",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "CarCategoryID",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CarMakeID",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CarModelID",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ChassisNumber",
                table: "Cars",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EngineNumber",
                table: "Cars",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarCategoryID",
                table: "Cars",
                column: "CarCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarMakeID",
                table: "Cars",
                column: "CarMakeID");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarModelID",
                table: "Cars",
                column: "CarModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarCategories_CarCategoryID",
                table: "Cars",
                column: "CarCategoryID",
                principalTable: "CarCategories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarMakes_CarMakeID",
                table: "Cars",
                column: "CarMakeID",
                principalTable: "CarMakes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarModels_CarModelID",
                table: "Cars",
                column: "CarModelID",
                principalTable: "CarModels",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
