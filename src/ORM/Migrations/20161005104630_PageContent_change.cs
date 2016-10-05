using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ORM.Migrations
{
    public partial class PageContent_change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Page_Content_ContentId",
                table: "Page");

            migrationBuilder.DropIndex(
                name: "IX_Page_ContentId",
                table: "Page");

            migrationBuilder.DropColumn(
                name: "ContentId",
                table: "Page");

            migrationBuilder.DropTable(
                name: "Content");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Page",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Page");

            migrationBuilder.CreateTable(
                name: "Content",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Html = table.Column<string>(nullable: true),
                    PageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content", x => x.Id);
                });

            migrationBuilder.AddColumn<int>(
                name: "ContentId",
                table: "Page",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Page_ContentId",
                table: "Page",
                column: "ContentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Page_Content_ContentId",
                table: "Page",
                column: "ContentId",
                principalTable: "Content",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
