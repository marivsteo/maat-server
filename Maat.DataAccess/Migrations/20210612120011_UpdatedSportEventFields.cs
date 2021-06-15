using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Maat.DataAccess.Migrations
{
    public partial class UpdatedSportEventFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "SportEvents",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EventTime",
                table: "SportEvents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsPayingNeeded",
                table: "SportEvents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfParticipatingPlayers",
                table: "SportEvents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfPlayersNeeded",
                table: "SportEvents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Place",
                table: "SportEvents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SkillLevel",
                table: "SportEvents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SportType",
                table: "SportEvents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SportEvents_CreatedById",
                table: "SportEvents",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_SportEvents_Users_CreatedById",
                table: "SportEvents",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SportEvents_Users_CreatedById",
                table: "SportEvents");

            migrationBuilder.DropIndex(
                name: "IX_SportEvents_CreatedById",
                table: "SportEvents");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "SportEvents");

            migrationBuilder.DropColumn(
                name: "EventTime",
                table: "SportEvents");

            migrationBuilder.DropColumn(
                name: "IsPayingNeeded",
                table: "SportEvents");

            migrationBuilder.DropColumn(
                name: "NumberOfParticipatingPlayers",
                table: "SportEvents");

            migrationBuilder.DropColumn(
                name: "NumberOfPlayersNeeded",
                table: "SportEvents");

            migrationBuilder.DropColumn(
                name: "Place",
                table: "SportEvents");

            migrationBuilder.DropColumn(
                name: "SkillLevel",
                table: "SportEvents");

            migrationBuilder.DropColumn(
                name: "SportType",
                table: "SportEvents");
        }
    }
}
