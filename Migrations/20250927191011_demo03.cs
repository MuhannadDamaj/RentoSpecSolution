using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentospectWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class demo03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 27, 22, 8, 31, 881, DateTimeKind.Local).AddTicks(2572), new DateTime(2025, 9, 27, 22, 8, 31, 886, DateTimeKind.Local).AddTicks(177) });
        }
    }
}
