using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AchievementUser_AspNetUsers_UserId1",
                table: "AchievementUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_AspNetUsers_UserId1",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Site_AspNetUsers_UserId1",
                table: "Site");

            migrationBuilder.DropIndex(
                name: "IX_Site_UserId1",
                table: "Site");

            migrationBuilder.DropIndex(
                name: "IX_Comment_UserId1",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_AchievementUser_UserId1",
                table: "AchievementUser");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Site");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "AchievementUser");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Site",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Site_UserId",
                table: "Site",
                column: "UserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Comment",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserId",
                table: "Comment",
                column: "UserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AchievementUser",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AchievementUser_UserId",
                table: "AchievementUser",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AchievementUser_AspNetUsers_UserId",
                table: "AchievementUser",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_AspNetUsers_UserId",
                table: "Comment",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Site_AspNetUsers_UserId",
                table: "Site",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AchievementUser_AspNetUsers_UserId",
                table: "AchievementUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_AspNetUsers_UserId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Site_AspNetUsers_UserId",
                table: "Site");

            migrationBuilder.DropIndex(
                name: "IX_Site_UserId",
                table: "Site");

            migrationBuilder.DropIndex(
                name: "IX_Comment_UserId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_AchievementUser_UserId",
                table: "AchievementUser");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Site",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Comment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "AchievementUser",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Site",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_Site_UserId1",
                table: "Site",
                column: "UserId1");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Comment",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserId1",
                table: "Comment",
                column: "UserId1");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "AchievementUser",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_AchievementUser_UserId1",
                table: "AchievementUser",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AchievementUser_AspNetUsers_UserId1",
                table: "AchievementUser",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_AspNetUsers_UserId1",
                table: "Comment",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Site_AspNetUsers_UserId1",
                table: "Site",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
