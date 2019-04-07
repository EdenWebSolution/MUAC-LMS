using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MUAC_LMS.Data.Migrations
{
    public partial class addedBooktable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "SubCategories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EditedById",
                table: "SubCategories",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "EditedOn",
                table: "SubCategories",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SubCategories",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    CreatedById = table.Column<string>(nullable: true),
                    EditedById = table.Column<string>(nullable: true),
                    EditedOn = table.Column<DateTimeOffset>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Identity = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    SubCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_SubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_Identity",
                table: "Books",
                column: "Identity",
                unique: true,
                filter: "[Identity] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Books_SubCategoryId",
                table: "Books",
                column: "SubCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "SubCategories");

            migrationBuilder.DropColumn(
                name: "EditedById",
                table: "SubCategories");

            migrationBuilder.DropColumn(
                name: "EditedOn",
                table: "SubCategories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SubCategories");
        }
    }
}
