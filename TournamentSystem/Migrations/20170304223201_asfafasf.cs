using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TournamentSystem.Migrations
{
    public partial class asfafasf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfTeams",
                table: "Tournaments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfTeams",
                table: "Tournaments",
                nullable: false,
                defaultValue: 0);
        }
    }
}
