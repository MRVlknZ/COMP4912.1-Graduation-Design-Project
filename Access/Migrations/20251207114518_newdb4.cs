using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Access.Migrations
{
    /// <inheritdoc />
    public partial class newdb4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DrillColors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrillColors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CColorDrills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TotalDurationSec = table.Column<int>(type: "int", nullable: false),
                    ColorCount = table.Column<int>(type: "int", nullable: false),
                    SelectedColorIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SwitchIntervalSec = table.Column<double>(type: "float", nullable: false),
                    IsRandomOrder = table.Column<bool>(type: "bit", nullable: false),
                    ActionsPerColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DifficultyLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CColorDrills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CColorDrills_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CCombDrills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CommandCount = table.Column<int>(type: "int", nullable: false),
                    CommandList = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommandsPerCombination = table.Column<int>(type: "int", nullable: false),
                    CombinationDisplaySec = table.Column<double>(type: "float", nullable: false),
                    TransitionSec = table.Column<double>(type: "float", nullable: false),
                    IsRandomOrder = table.Column<bool>(type: "bit", nullable: false),
                    AllowRepetition = table.Column<bool>(type: "bit", nullable: false),
                    TotalDurationSec = table.Column<int>(type: "int", nullable: false),
                    DifficultyLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCombDrills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CCombDrills_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CFocusDrills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TargetColors = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionsForTargetColors = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SwitchIntervalSec = table.Column<double>(type: "float", nullable: false),
                    TotalDurationSec = table.Column<int>(type: "int", nullable: false),
                    DifficultyLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AutoIncreaseDifficulty = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CFocusDrills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CFocusDrills_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CSoundDrills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    VoiceCommandCount = table.Column<int>(type: "int", nullable: false),
                    VoiceCommandList = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommandIntervalSec = table.Column<double>(type: "float", nullable: false),
                    IsRandomOrder = table.Column<bool>(type: "bit", nullable: false),
                    TotalDurationSec = table.Column<int>(type: "int", nullable: false),
                    HasBreaks = table.Column<bool>(type: "bit", nullable: false),
                    BreakIntervalSec = table.Column<double>(type: "float", nullable: false),
                    DifficultyLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AutoIncreaseDifficulty = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CSoundDrills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CSoundDrills_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CTextDrills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ExNames = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExDurationsSec = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSequential = table.Column<bool>(type: "bit", nullable: false),
                    HasBreakBtwExs = table.Column<bool>(type: "bit", nullable: false),
                    BreakBtwExsSec = table.Column<int>(type: "int", nullable: false),
                    RepeatCount = table.Column<int>(type: "int", nullable: false),
                    HasBreakBtwRepeats = table.Column<bool>(type: "bit", nullable: false),
                    BreakBtwRepeatsSec = table.Column<int>(type: "int", nullable: false),
                    DemonstrationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalDurationSec = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTextDrills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CTextDrills_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "P4ColorDrills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TotalDurationSec = table.Column<int>(type: "int", nullable: false),
                    SwitchIntervalSec = table.Column<double>(type: "float", nullable: false),
                    IsRandomOrder = table.Column<bool>(type: "bit", nullable: false),
                    DifficultyLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionsPerColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_P4ColorDrills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_P4ColorDrills_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PCombDrills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CommandCount = table.Column<int>(type: "int", nullable: false),
                    CommandList = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommandsPerCombination = table.Column<int>(type: "int", nullable: false),
                    CombinationDisplaySec = table.Column<double>(type: "float", nullable: false),
                    TransitionSec = table.Column<double>(type: "float", nullable: false),
                    IsRandomOrder = table.Column<bool>(type: "bit", nullable: false),
                    AllowRepetition = table.Column<bool>(type: "bit", nullable: false),
                    TotalDurationSec = table.Column<int>(type: "int", nullable: false),
                    DifficultyLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PCombDrills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PCombDrills_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PFocusDrills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TargetColorCount = table.Column<int>(type: "int", nullable: false),
                    TargetColors = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionsForTargetColors = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SwitchIntervalSec = table.Column<double>(type: "float", nullable: false),
                    TotalDurationSec = table.Column<int>(type: "int", nullable: false),
                    DifficultyLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRandomOrder = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PFocusDrills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PFocusDrills_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PSoundDrills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    VoiceCommandCount = table.Column<int>(type: "int", nullable: false),
                    VoiceCommandList = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommandIntervalSec = table.Column<double>(type: "float", nullable: false),
                    TotalDurationSec = table.Column<int>(type: "int", nullable: false),
                    IsRandomOrder = table.Column<bool>(type: "bit", nullable: false),
                    HasBreaks = table.Column<bool>(type: "bit", nullable: false),
                    BreakIntervalSec = table.Column<double>(type: "float", nullable: false),
                    DifficultyLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PSoundDrills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PSoundDrills_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PTextDrills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExNames = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExDurationsSec = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRandomOrder = table.Column<bool>(type: "bit", nullable: false),
                    HasBreakBtwExs = table.Column<bool>(type: "bit", nullable: false),
                    BreakBtwExsSec = table.Column<int>(type: "int", nullable: false),
                    RepeatCount = table.Column<int>(type: "int", nullable: false),
                    HasBreakBtwRepeats = table.Column<bool>(type: "bit", nullable: false),
                    BreakBtwRepeatsSec = table.Column<int>(type: "int", nullable: false),
                    DemonstrationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalDurationSec = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PTextDrills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PTextDrills_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CColorDrills_UserId",
                table: "CColorDrills",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CCombDrills_UserId",
                table: "CCombDrills",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CFocusDrills_UserId",
                table: "CFocusDrills",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CSoundDrills_UserId",
                table: "CSoundDrills",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CTextDrills_UserId",
                table: "CTextDrills",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_P4ColorDrills_UserId",
                table: "P4ColorDrills",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PCombDrills_UserId",
                table: "PCombDrills",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PFocusDrills_UserId",
                table: "PFocusDrills",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PSoundDrills_UserId",
                table: "PSoundDrills",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PTextDrills_UserId",
                table: "PTextDrills",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CColorDrills");

            migrationBuilder.DropTable(
                name: "CCombDrills");

            migrationBuilder.DropTable(
                name: "CFocusDrills");

            migrationBuilder.DropTable(
                name: "CSoundDrills");

            migrationBuilder.DropTable(
                name: "CTextDrills");

            migrationBuilder.DropTable(
                name: "DrillColors");

            migrationBuilder.DropTable(
                name: "P4ColorDrills");

            migrationBuilder.DropTable(
                name: "PCombDrills");

            migrationBuilder.DropTable(
                name: "PFocusDrills");

            migrationBuilder.DropTable(
                name: "PSoundDrills");

            migrationBuilder.DropTable(
                name: "PTextDrills");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
