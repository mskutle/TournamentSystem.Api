using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TournamentSystem.Migrations
{
    public partial class TeamOnPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Teams_TeamId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Tournaments_TournamentId",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_Teams_TeamId",
                table: "Tournaments");

            migrationBuilder.DropIndex(
                name: "IX_Tournaments_TeamId",
                table: "Tournaments");

            migrationBuilder.DropIndex(
                name: "IX_Teams_TournamentId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "TournamentId",
                table: "Teams");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Persons",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Teams_TeamId",
                table: "Persons",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Teams_TeamId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Persons");

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Tournaments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TournamentId",
                table: "Teams",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_TeamId",
                table: "Tournaments",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_TournamentId",
                table: "Teams",
                column: "TournamentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Teams_TeamId",
                table: "Persons",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Tournaments_TournamentId",
                table: "Teams",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_Teams_TeamId",
                table: "Tournaments",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
