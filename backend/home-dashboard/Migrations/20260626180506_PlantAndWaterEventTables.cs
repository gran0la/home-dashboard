using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace home_dashboard.Migrations
{
    /// <inheritdoc />
    public partial class PlantAndWaterEventTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoistureReadings_Plant_PlantId",
                table: "MoistureReadings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Plant",
                table: "Plant");

            migrationBuilder.RenameTable(
                name: "Plant",
                newName: "Plants");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plants",
                table: "Plants",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "WaterEvents",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PlantId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WateredAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DurationSeconds = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterEvents", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_MoistureReadings_Plants_PlantId",
                table: "MoistureReadings",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoistureReadings_Plants_PlantId",
                table: "MoistureReadings");

            migrationBuilder.DropTable(
                name: "WaterEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Plants",
                table: "Plants");

            migrationBuilder.RenameTable(
                name: "Plants",
                newName: "Plant");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plant",
                table: "Plant",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MoistureReadings_Plant_PlantId",
                table: "MoistureReadings",
                column: "PlantId",
                principalTable: "Plant",
                principalColumn: "Id");
        }
    }
}
