using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class AddManyToManyBookAuthorCorrected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FluentBookAuthor_FluentAuthor_FluentAuthorAuthor_Id",
                table: "FluentBookAuthor");

            migrationBuilder.DropForeignKey(
                name: "FK_FluentBookAuthor_FluentBook_Author_Id",
                table: "FluentBookAuthor");

            migrationBuilder.DropIndex(
                name: "IX_FluentBookAuthor_FluentAuthorAuthor_Id",
                table: "FluentBookAuthor");

            migrationBuilder.DropColumn(
                name: "FluentAuthorAuthor_Id",
                table: "FluentBookAuthor");

            migrationBuilder.CreateIndex(
                name: "IX_FluentBookAuthor_Book_Id",
                table: "FluentBookAuthor",
                column: "Book_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FluentBookAuthor_FluentAuthor_Author_Id",
                table: "FluentBookAuthor",
                column: "Author_Id",
                principalTable: "FluentAuthor",
                principalColumn: "Author_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FluentBookAuthor_FluentBook_Book_Id",
                table: "FluentBookAuthor",
                column: "Book_Id",
                principalTable: "FluentBook",
                principalColumn: "Book_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FluentBookAuthor_FluentAuthor_Author_Id",
                table: "FluentBookAuthor");

            migrationBuilder.DropForeignKey(
                name: "FK_FluentBookAuthor_FluentBook_Book_Id",
                table: "FluentBookAuthor");

            migrationBuilder.DropIndex(
                name: "IX_FluentBookAuthor_Book_Id",
                table: "FluentBookAuthor");

            migrationBuilder.AddColumn<int>(
                name: "FluentAuthorAuthor_Id",
                table: "FluentBookAuthor",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FluentBookAuthor_FluentAuthorAuthor_Id",
                table: "FluentBookAuthor",
                column: "FluentAuthorAuthor_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FluentBookAuthor_FluentAuthor_FluentAuthorAuthor_Id",
                table: "FluentBookAuthor",
                column: "FluentAuthorAuthor_Id",
                principalTable: "FluentAuthor",
                principalColumn: "Author_Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FluentBookAuthor_FluentBook_Author_Id",
                table: "FluentBookAuthor",
                column: "Author_Id",
                principalTable: "FluentBook",
                principalColumn: "Book_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
