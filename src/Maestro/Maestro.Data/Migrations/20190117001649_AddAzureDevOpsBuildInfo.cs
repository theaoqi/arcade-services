using Microsoft.EntityFrameworkCore.Migrations;

namespace Maestro.Data.Migrations
{
    public partial class AddAzureDevOpsBuildInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AzureDevOpsAccount",
                table: "Builds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AzureDevOpsBuildId",
                table: "Builds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AzureDevOpsProject",
                table: "Builds",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AzureDevOpsAccount",
                table: "Builds");

            migrationBuilder.DropColumn(
                name: "AzureDevOpsBuildId",
                table: "Builds");

            migrationBuilder.DropColumn(
                name: "AzureDevOpsProject",
                table: "Builds");
        }
    }
}
