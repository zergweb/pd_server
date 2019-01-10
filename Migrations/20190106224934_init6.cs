using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PdApi.Migrations
{
    public partial class init6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PublicProfileConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LkStudentId = table.Column<int>(nullable: false),
                    Skills = table.Column<bool>(nullable: false),
                    DOB = table.Column<bool>(nullable: false),
                    Certificates = table.Column<bool>(nullable: false),
                    LastProjects = table.Column<bool>(nullable: false),
                    Portfolio = table.Column<bool>(nullable: false),
                    City = table.Column<bool>(nullable: false),
                    About = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicProfileConfigs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublicProfileConfigs_Students_LkStudentId",
                        column: x => x.LkStudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PublicProfileConfigs_LkStudentId",
                table: "PublicProfileConfigs",
                column: "LkStudentId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PublicProfileConfigs");
        }
    }
}
