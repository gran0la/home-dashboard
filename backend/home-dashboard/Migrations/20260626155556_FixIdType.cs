using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace home_dashboard.Migrations
{
    /// <inheritdoc />
    public partial class FixIdType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoistureReadings_Plant_PlantId",
                table: "MoistureReadings");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Plant",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "PlantId",
                table: "MoistureReadings",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_MoistureReadings_Plant_PlantId",
                table: "MoistureReadings",
                column: "PlantId",
                principalTable: "Plant",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoistureReadings_Plant_PlantId",
                table: "MoistureReadings");

            migrationBuilder.UpdateData(
                table: "Plant",
                keyColumn: "Name",
                keyValue: null,
                column: "Name",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Plant",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "MoistureReadings",
                keyColumn: "PlantId",
                keyValue: null,
                column: "PlantId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "PlantId",
                table: "MoistureReadings",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_MoistureReadings_Plant_PlantId",
                table: "MoistureReadings",
                column: "PlantId",
                principalTable: "Plant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
