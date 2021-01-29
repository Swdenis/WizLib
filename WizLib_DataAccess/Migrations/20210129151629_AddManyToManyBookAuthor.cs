using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class AddManyToManyBookAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FluentBookAuthor",
                columns: table => new
                {
                    Book_Id = table.Column<int>(type: "int", nullable: false),
                    Author_Id = table.Column<int>(type: "int", nullable: false),
                    FluentAuthorAuthor_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FluentBookAuthor", x => new { x.Author_Id, x.Book_Id });
                    table.ForeignKey(
                        name: "FK_FluentBookAuthor_FluentAuthor_FluentAuthorAuthor_Id",
                        column: x => x.FluentAuthorAuthor_Id,
                        principalTable: "FluentAuthor",
                        principalColumn: "Author_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FluentBookAuthor_FluentBook_Author_Id",
                        column: x => x.Author_Id,
                        principalTable: "FluentBook",
                        principalColumn: "Book_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FluentBookAuthor_FluentAuthorAuthor_Id",
                table: "FluentBookAuthor",
                column: "FluentAuthorAuthor_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FluentBookAuthor");
        }
    }
}
