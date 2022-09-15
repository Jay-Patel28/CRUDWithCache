using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUDWithCache.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorsOfBooks_Authors_RelatedAuthorId",
                table: "AuthorsOfBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorsOfBooks_Books_RelatedBookId",
                table: "AuthorsOfBooks");

            migrationBuilder.DropIndex(
                name: "IX_AuthorsOfBooks_RelatedAuthorId",
                table: "AuthorsOfBooks");

            migrationBuilder.DropIndex(
                name: "IX_AuthorsOfBooks_RelatedBookId",
                table: "AuthorsOfBooks");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorsOfBooks_Authors_Id",
                table: "AuthorsOfBooks",
                column: "Id",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorsOfBooks_Books_Id",
                table: "AuthorsOfBooks",
                column: "Id",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorsOfBooks_Authors_Id",
                table: "AuthorsOfBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorsOfBooks_Books_Id",
                table: "AuthorsOfBooks");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorsOfBooks_RelatedAuthorId",
                table: "AuthorsOfBooks",
                column: "RelatedAuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorsOfBooks_RelatedBookId",
                table: "AuthorsOfBooks",
                column: "RelatedBookId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorsOfBooks_Authors_RelatedAuthorId",
                table: "AuthorsOfBooks",
                column: "RelatedAuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorsOfBooks_Books_RelatedBookId",
                table: "AuthorsOfBooks",
                column: "RelatedBookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
