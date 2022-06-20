using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBlog.Migrations
{
    public partial class postChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PostCreate",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UserPostId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserPostId",
                table: "Posts",
                column: "UserPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_UserPostId",
                table: "Posts",
                column: "UserPostId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_UserPostId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_UserPostId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PostCreate",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "UserPostId",
                table: "Posts");
        }
    }
}
