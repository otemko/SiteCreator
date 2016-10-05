using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ORM.Migrations
{
    public partial class Table_for_page_content : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Page");

            migrationBuilder.AddColumn<int>(
                name: "PageContentId",
                table: "Page",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PageContentId",
                table: "Page");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Page",
                nullable: true);
        }
    }
}
