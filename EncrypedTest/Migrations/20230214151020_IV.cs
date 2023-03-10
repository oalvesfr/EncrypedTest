using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EncrypedTest.Migrations
{
    public partial class IV : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "IV",
                table: "Test",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IV",
                table: "Test");
        }
    }
}
