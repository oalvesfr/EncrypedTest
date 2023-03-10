using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EncrypedTest.Migrations
{
    public partial class chave : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Chave",
                table: "TestJson",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Chave",
                table: "TestJson");
        }
    }
}
