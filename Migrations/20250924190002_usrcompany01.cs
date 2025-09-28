using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentospectWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class usrcompany01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyID",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyID",
                table: "Users");
        }
    }
}
