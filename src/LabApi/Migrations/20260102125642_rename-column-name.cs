using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabApi.Migrations
{
    /// <inheritdoc />
    public partial class renamecolumnname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "NormalValue",
                newName: "MeasurementName");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "NormalValue",
                newName: "MeasurementCode");

            migrationBuilder.AddColumn<int>(
                name: "AgeFrom",
                table: "NormalValue",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgeFrom",
                table: "NormalValue");

            migrationBuilder.RenameColumn(
                name: "MeasurementName",
                table: "NormalValue",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "MeasurementCode",
                table: "NormalValue",
                newName: "Code");
        }
    }
}
