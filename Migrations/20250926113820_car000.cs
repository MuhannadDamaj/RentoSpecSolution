using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentospectWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class car000 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CarMode",
                table: "Cars",
                newName: "CarModel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CarModel",
                table: "Cars",
                newName: "CarMode");
        }
    }
}
