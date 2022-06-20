using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBlog.Migrations
{
    public partial class work1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_WhoPostedId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_WhoPostedId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "WhoPostedId",
                table: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "WhoPosted",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WhoPosted",
                table: "Posts");

            migrationBuilder.AddColumn<int>(
                name: "WhoPostedId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_WhoPostedId",
                table: "Posts",
                column: "WhoPostedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_WhoPostedId",
                table: "Posts",
                column: "WhoPostedId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
