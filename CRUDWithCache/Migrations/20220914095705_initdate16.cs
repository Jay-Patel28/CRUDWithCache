using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUDWithCache.Migrations
{
    public partial class initdate16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthorsOfBooks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RelatedAuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RelatedBookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorsOfBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthorsOfBooks_Authors_RelatedAuthorId",
                        column: x => x.RelatedAuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorsOfBooks_Books_RelatedBookId",
                        column: x => x.RelatedBookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorsOfBooks_RelatedAuthorId",
                table: "AuthorsOfBooks",
                column: "RelatedAuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorsOfBooks_RelatedBookId",
                table: "AuthorsOfBooks",
                column: "RelatedBookId");

            migrationBuilder.CreateIndex(
                name: "PRICE",
                table: "Books",
                column: "Price");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorsOfBooks");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
