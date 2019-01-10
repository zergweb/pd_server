using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PdApi.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FacultySectionId",
                table: "Groups",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FacultySections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    NumberName = table.Column<string>(nullable: true),
                    FacultyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultySections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacultySections_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Groups_FacultySectionId",
                table: "Groups",
                column: "FacultySectionId");

            migrationBuilder.CreateIndex(
                name: "IX_FacultySections_FacultyId",
                table: "FacultySections",
                column: "FacultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_FacultySections_FacultySectionId",
                table: "Groups",
                column: "FacultySectionId",
                principalTable: "FacultySections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_FacultySections_FacultySectionId",
                table: "Groups");

            migrationBuilder.DropTable(
                name: "FacultySections");

            migrationBuilder.DropTable(
                name: "Faculties");

            migrationBuilder.DropIndex(
                name: "IX_Groups_FacultySectionId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "FacultySectionId",
                table: "Groups");
        }
    }
}
