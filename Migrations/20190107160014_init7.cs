using Microsoft.EntityFrameworkCore.Migrations;

namespace PdApi.Migrations
{
    public partial class init7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Course",
                table: "PublicProfileConfigs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ExtraInfo",
                table: "PublicProfileConfigs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "FacucltySection",
                table: "PublicProfileConfigs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Faculty",
                table: "PublicProfileConfigs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Group",
                table: "PublicProfileConfigs",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Course",
                table: "PublicProfileConfigs");

            migrationBuilder.DropColumn(
                name: "ExtraInfo",
                table: "PublicProfileConfigs");

            migrationBuilder.DropColumn(
                name: "FacucltySection",
                table: "PublicProfileConfigs");

            migrationBuilder.DropColumn(
                name: "Faculty",
                table: "PublicProfileConfigs");

            migrationBuilder.DropColumn(
                name: "Group",
                table: "PublicProfileConfigs");
        }
    }
}
