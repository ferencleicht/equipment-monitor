using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistoricalRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EquipmentId = table.Column<string>(type: "text", nullable: false),
                    EquipmentName = table.Column<string>(type: "text", nullable: false),
                    PreviousState = table.Column<int>(type: "integer", nullable: false),
                    NewState = table.Column<int>(type: "integer", nullable: false),
                    ChangedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricalRecords", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "LastUpdated", "Name", "State" },
                values: new object[,]
                {
                    { "1", new DateTime(2025, 4, 3, 12, 30, 0, 0, DateTimeKind.Utc), "Injection Molding Machine", 0 },
                    { "2", new DateTime(2025, 4, 3, 12, 30, 0, 0, DateTimeKind.Utc), "Conveyor Belt", 0 },
                    { "3", new DateTime(2025, 4, 3, 12, 30, 0, 0, DateTimeKind.Utc), "Quality Control Station", 0 },
                    { "4", new DateTime(2025, 4, 3, 12, 30, 0, 0, DateTimeKind.Utc), "Packaging Machine", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "HistoricalRecords");
        }
    }
}
