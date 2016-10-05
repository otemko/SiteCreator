using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ORM.Migrations
{
    public partial class PageContent_change1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Page_Layout_LayoutId",
                table: "Page");

            migrationBuilder.DropIndex(
                name: "IX_Page_LayoutId",
                table: "Page");

            migrationBuilder.DropColumn(
                name: "LayoutId",
                table: "Page");

            migrationBuilder.DropTable(
                name: "Layout");

            migrationBuilder.AddColumn<int>(
                name: "CountRated",
                table: "Page",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "Rating",
                table: "Page",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountRated",
                table: "Page");

            migrationBuilder.CreateTable(
                name: "Layout",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Html = table.Column<string>(nullable: true),
                    Image = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Layout", x => x.Id);
                });

            migrationBuilder.AddColumn<int>(
                name: "LayoutId",
                table: "Page",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "Page",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_Page_LayoutId",
                table: "Page",
                column: "LayoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Page_Layout_LayoutId",
                table: "Page",
                column: "LayoutId",
                principalTable: "Layout",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
