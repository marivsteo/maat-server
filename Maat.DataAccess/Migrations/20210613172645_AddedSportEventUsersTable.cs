using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Maat.DataAccess.Migrations
{
    public partial class AddedSportEventUsersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SportEvents",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.CreateTable(
                name: "SportEventUsers",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SportEventId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportEventUsers", x => new { x.SportEventId, x.UserId });
                    table.ForeignKey(
                        name: "FK_SportEventUsers_SportEvents_SportEventId",
                        column: x => x.SportEventId,
                        principalTable: "SportEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SportEventUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SportEventUsers_UserId",
                table: "SportEventUsers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SportEventUsers");

            migrationBuilder.InsertData(
                table: "SportEvents",
                columns: new[] { "Id", "CreatedById", "EventTime", "IsPayingNeeded", "Name", "NumberOfParticipatingPlayers", "NumberOfPlayersNeeded", "Place", "SkillLevel", "SportType" },
                values: new object[] { 1L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Football", 0, 0, null, 0, 0 });
        }
    }
}
