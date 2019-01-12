using Microsoft.EntityFrameworkCore.Migrations;

namespace PdApi.Migrations
{
    public partial class init8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "ProjectDocs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocName",
                table: "ProjectDocs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desc",
                table: "ProjectDocs");

            migrationBuilder.DropColumn(
                name: "DocName",
                table: "ProjectDocs");
        }
    }
}
