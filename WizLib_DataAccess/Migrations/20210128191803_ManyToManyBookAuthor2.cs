using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class ManyToManyBookAuthor2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthors_BookAuthors_BookAuthorAuthor_Id_BookAuthorBook_Id",
                table: "BookAuthors");

            migrationBuilder.DropIndex(
                name: "IX_BookAuthors_BookAuthorAuthor_Id_BookAuthorBook_Id",
                table: "BookAuthors");

            migrationBuilder.DropColumn(
                name: "BookAuthorAuthor_Id",
                table: "BookAuthors");

            migrationBuilder.DropColumn(
                name: "BookAuthorBook_Id",
                table: "BookAuthors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookAuthorAuthor_Id",
                table: "BookAuthors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookAuthorBook_Id",
                table: "BookAuthors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_BookAuthorAuthor_Id_BookAuthorBook_Id",
                table: "BookAuthors",
                columns: new[] { "BookAuthorAuthor_Id", "BookAuthorBook_Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthors_BookAuthors_BookAuthorAuthor_Id_BookAuthorBook_Id",
                table: "BookAuthors",
                columns: new[] { "BookAuthorAuthor_Id", "BookAuthorBook_Id" },
                principalTable: "BookAuthors",
                principalColumns: new[] { "Author_Id", "Book_Id" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
