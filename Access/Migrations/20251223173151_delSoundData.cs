using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Access.Migrations
{
    /// <inheritdoc />
    public partial class delSoundData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BreakIntervalSec",
                table: "PSoundDrills");

            migrationBuilder.DropColumn(
                name: "HasBreaks",
                table: "PSoundDrills");

            migrationBuilder.DropColumn(
                name: "AutoIncreaseDifficulty",
                table: "CSoundDrills");

            migrationBuilder.DropColumn(
                name: "BreakIntervalSec",
                table: "CSoundDrills");

            migrationBuilder.DropColumn(
                name: "HasBreaks",
                table: "CSoundDrills");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "BreakIntervalSec",
                table: "PSoundDrills",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "HasBreaks",
                table: "PSoundDrills",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AutoIncreaseDifficulty",
                table: "CSoundDrills",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "BreakIntervalSec",
                table: "CSoundDrills",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "HasBreaks",
                table: "CSoundDrills",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
