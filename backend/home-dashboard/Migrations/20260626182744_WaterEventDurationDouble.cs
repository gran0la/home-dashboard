using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace home_dashboard.Migrations
{
    /// <inheritdoc />
    public partial class WaterEventDurationDouble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "DurationSeconds",
                table: "WaterEvents",
                type: "double",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DurationSeconds",
                table: "WaterEvents",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");
        }
    }
}
