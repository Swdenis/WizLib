using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Books_BookDetail_Id",
                table: "Books");

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookDetail_Id",
                table: "Books",
                column: "BookDetail_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Books_BookDetail_Id",
                table: "Books");

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookDetail_Id",
                table: "Books",
                column: "BookDetail_Id",
                unique: true);
        }
    }
}
