using Microsoft.EntityFrameworkCore.Migrations;

namespace MUAC_LMS.Data.Migrations
{
    public partial class removeStoreUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentGrades_AspNetUsers_StoreUserId1",
                table: "StudentGrades");

            migrationBuilder.DropIndex(
                name: "IX_StudentGrades_StoreUserId1",
                table: "StudentGrades");

            migrationBuilder.DropColumn(
                name: "StoreUserId1",
                table: "StudentGrades");

            migrationBuilder.AlterColumn<string>(
                name: "StoreUserId",
                table: "StudentGrades",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_StudentGrades_StoreUserId",
                table: "StudentGrades",
                column: "StoreUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentGrades_AspNetUsers_StoreUserId",
                table: "StudentGrades",
                column: "StoreUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentGrades_AspNetUsers_StoreUserId",
                table: "StudentGrades");

            migrationBuilder.DropIndex(
                name: "IX_StudentGrades_StoreUserId",
                table: "StudentGrades");

            migrationBuilder.AlterColumn<int>(
                name: "StoreUserId",
                table: "StudentGrades",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StoreUserId1",
                table: "StudentGrades",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentGrades_StoreUserId1",
                table: "StudentGrades",
                column: "StoreUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentGrades_AspNetUsers_StoreUserId1",
                table: "StudentGrades",
                column: "StoreUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
