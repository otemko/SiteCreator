using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ORM.Migrations
{
    public partial class PageContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PageContent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(nullable: true),
                    PageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageContent", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Page_PageContentId",
                table: "Page",
                column: "PageContentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Page_PageContent_PageContentId",
                table: "Page",
                column: "PageContentId",
                principalTable: "PageContent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Page_PageContent_PageContentId",
                table: "Page");

            migrationBuilder.DropIndex(
                name: "IX_Page_PageContentId",
                table: "Page");

            migrationBuilder.DropTable(
                name: "PageContent");
        }
    }
}
