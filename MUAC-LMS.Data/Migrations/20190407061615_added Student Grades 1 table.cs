using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MUAC_LMS.Data.Migrations
{
    public partial class addedStudentGrades1table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentGrades",
                columns: table => new
                {
                    CreatedById = table.Column<string>(nullable: true),
                    EditedById = table.Column<string>(nullable: true),
                    EditedOn = table.Column<DateTimeOffset>(nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentGrades = table.Column<int>(nullable: false),
                    StoreUserId1 = table.Column<string>(nullable: true),
                    StoreUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentGrades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentGrades_AspNetUsers_StoreUserId1",
                        column: x => x.StoreUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentGrades_StoreUserId1",
                table: "StudentGrades",
                column: "StoreUserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentGrades");
        }
    }
}
