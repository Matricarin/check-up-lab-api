using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabApi.Migrations
{
    /// <inheritdoc />
    public partial class modelswerechanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeasurementCode",
                table: "NormalValue");

            migrationBuilder.RenameColumn(
                name: "MeasurementName",
                table: "NormalValue",
                newName: "MeasurementUnit");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MeasurementUnit",
                table: "NormalValue",
                newName: "MeasurementName");

            migrationBuilder.AddColumn<string>(
                name: "MeasurementCode",
                table: "NormalValue",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
