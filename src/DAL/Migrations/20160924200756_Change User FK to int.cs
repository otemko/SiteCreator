using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class ChangeUserFKtoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Language_LanguageId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Style_StyleId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "StyleId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LanguageId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Language_LanguageId",
                table: "AspNetUsers",
                column: "LanguageId",
                principalTable: "Language",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Style_StyleId",
                table: "AspNetUsers",
                column: "StyleId",
                principalTable: "Style",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Language_LanguageId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Style_StyleId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "StyleId",
                table: "AspNetUsers",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "LanguageId",
                table: "AspNetUsers",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Language_LanguageId",
                table: "AspNetUsers",
                column: "LanguageId",
                principalTable: "Language",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Style_StyleId",
                table: "AspNetUsers",
                column: "StyleId",
                principalTable: "Style",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
