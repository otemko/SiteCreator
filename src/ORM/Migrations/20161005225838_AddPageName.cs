using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ORM.Migrations
{
    public partial class AddPageName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Page",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Preview",
                table: "Page",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Page");

            migrationBuilder.DropColumn(
                name: "Preview",
                table: "Page");
        }
    }
}
