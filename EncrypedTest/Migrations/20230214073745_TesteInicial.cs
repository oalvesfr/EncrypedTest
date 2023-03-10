using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EncrypedTest.Migrations
{
    public partial class TesteInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Campo1 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Campo2 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Campo3 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Campo4 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Campo5 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Campo6 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Campo7 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Campo8 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Campo9 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Campo10 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Campo11 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Campo12 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Campo13 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Campo14 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Campo15 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Campo16 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Campo17 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Campo18 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Campo19 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Campo20 = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Test");
        }
    }
}
