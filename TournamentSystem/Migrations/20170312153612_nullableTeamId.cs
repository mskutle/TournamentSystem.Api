using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TournamentSystem.Migrations
{
    public partial class nullableTeamId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Teams_TeamId",
                table: "Persons");

            migrationBuilder.AlterColumn<string>(
                name: "Lastname",
                table: "Persons",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Firstname",
                table: "Persons",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Teams_TeamId",
                table: "Persons",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Teams_TeamId",
                table: "Persons");

            migrationBuilder.AlterColumn<string>(
                name: "Lastname",
                table: "Persons",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Firstname",
                table: "Persons",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Teams_TeamId",
                table: "Persons",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
