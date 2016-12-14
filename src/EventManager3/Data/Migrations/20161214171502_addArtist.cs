using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventManager3.Migrations
{
    public partial class addArtist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "ArtistName",
                table: "Events",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Events",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Events",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Genre",
                table: "Events",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArtistName",
                table: "Events");

            migrationBuilder.AddColumn<string>(
                name: "Event",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Events",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Events",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Genre",
                table: "Events",
                nullable: true);
        }
    }
}
