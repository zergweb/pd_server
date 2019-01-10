using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PdApi.Migrations
{
    public partial class init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "PublicProfileConfigs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    About = table.Column<string>(nullable: true),
                    UserInfoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_Students_UserInfoId",
                        column: x => x.UserInfoId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PublicProfileConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    About = table.Column<bool>(nullable: false),
                    Certificates = table.Column<bool>(nullable: false),
                    City = table.Column<bool>(nullable: false),
                    DOB = table.Column<bool>(nullable: false),
                    LastProjects = table.Column<bool>(nullable: false),
                    LkStudentId = table.Column<int>(nullable: false),
                    Portfolio = table.Column<bool>(nullable: false),
                    Skills = table.Column<bool>(nullable: false)
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
                name: "IX_Profiles_UserInfoId",
                table: "Profiles",
                column: "UserInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicProfileConfigs_LkStudentId",
                table: "PublicProfileConfigs",
                column: "LkStudentId",
                unique: true);
        }
    }
}
