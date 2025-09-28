using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentospectWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class demo02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "ID", "CreatedAt", "CreatedBy", "IsActive", "Name", "Symbol", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1, new DateTime(2025, 9, 27, 22, 8, 31, 881, DateTimeKind.Local).AddTicks(2572), "Muhannad Damaj", true, "US Dollar", "USD", new DateTime(2025, 9, 27, 22, 8, 31, 886, DateTimeKind.Local).AddTicks(177), "Muhannad Damaj" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "ID",
                keyValue: 1);
        }
    }
}
