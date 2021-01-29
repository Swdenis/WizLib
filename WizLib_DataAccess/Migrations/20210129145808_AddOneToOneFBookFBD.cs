using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class AddOneToOneFBookFBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookDetail_Id",
                table: "FluentBook",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FluentBook_BookDetail_Id",
                table: "FluentBook",
                column: "BookDetail_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FluentBook_FluentBookDetails_BookDetail_Id",
                table: "FluentBook",
                column: "BookDetail_Id",
                principalTable: "FluentBookDetails",
                principalColumn: "BookDetail_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FluentBook_FluentBookDetails_BookDetail_Id",
                table: "FluentBook");

            migrationBuilder.DropIndex(
                name: "IX_FluentBook_BookDetail_Id",
                table: "FluentBook");

            migrationBuilder.DropColumn(
                name: "BookDetail_Id",
                table: "FluentBook");
        }
    }
}
