using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentospectWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class damaegedparts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DamagedParts",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PartName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListOfDamages = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DamageSeverityScore = table.Column<double>(type: "float", nullable: false),
                    LaborOperation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfidenceScore = table.Column<double>(type: "float", nullable: false),
                    PaintLaborUnits = table.Column<double>(type: "float", nullable: false),
                    RemovalRefitUnits = table.Column<double>(type: "float", nullable: false),
                    LaborRepairUnits = table.Column<double>(type: "float", nullable: false),
                    InspectionResultID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DamagedParts", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DamagedParts");
        }
    }
}
