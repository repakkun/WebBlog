using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBlog.Migrations
{
    public partial class imFine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_UserPostId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "UserPostId",
                table: "Posts",
                newName: "WhoPostedId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_UserPostId",
                table: "Posts",
                newName: "IX_Posts_WhoPostedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_WhoPostedId",
                table: "Posts",
                column: "WhoPostedId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_WhoPostedId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "WhoPostedId",
                table: "Posts",
                newName: "UserPostId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_WhoPostedId",
                table: "Posts",
                newName: "IX_Posts_UserPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_UserPostId",
                table: "Posts",
                column: "UserPostId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
