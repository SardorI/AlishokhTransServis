using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlishoxTransServisDB.Migrations
{
    public partial class created_database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AutoBase",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    LicenseDate = table.Column<DateTime>(nullable: true),
                    InsuranceDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoBase", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutoBase");
        }
    }
}
