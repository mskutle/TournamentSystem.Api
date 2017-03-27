using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TournamentSystem.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Tournaments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_TeamId",
                table: "Tournaments",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_Teams_TeamId",
                table: "Tournaments",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_Teams_TeamId",
                table: "Tournaments");

            migrationBuilder.DropIndex(
                name: "IX_Tournaments_TeamId",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Tournaments");
        }
    }
}
