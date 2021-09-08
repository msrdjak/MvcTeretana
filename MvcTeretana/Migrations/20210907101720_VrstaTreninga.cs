using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcTeretana.Migrations
{
    public partial class VrstaTreninga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VrstaTreninga",
                table: "Clan",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VrstaTreninga",
                table: "Clan");
        }
    }
}
