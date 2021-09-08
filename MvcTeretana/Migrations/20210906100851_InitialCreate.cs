using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcTeretana.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GodinaRodenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Spol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RazinaClanarine = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClanarinaVrijediDo = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clan", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clan");
        }
    }
}
