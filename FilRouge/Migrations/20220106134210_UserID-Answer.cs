using Microsoft.EntityFrameworkCore.Migrations;

namespace FilRouge.Migrations
{
    public partial class UserIDAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Answers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Answers_UserId",
                table: "Answers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Users_UserId",
                table: "Answers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Users_UserId",
                table: "Answers");

            migrationBuilder.DropIndex(
                name: "IX_Answers_UserId",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Answers");
        }
    }
}
