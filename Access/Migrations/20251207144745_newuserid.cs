using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Access.Migrations
{
    /// <inheritdoc />
    public partial class newuserid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PTextDrills_Users_UserId",
                table: "PTextDrills");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "PTextDrills",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PTextDrills_Users_UserId",
                table: "PTextDrills",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PTextDrills_Users_UserId",
                table: "PTextDrills");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "PTextDrills",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PTextDrills_Users_UserId",
                table: "PTextDrills",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
