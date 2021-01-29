using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class AddOneToManyBookPublisherFluent1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FluentBook_FluentPublisher_Publisher_Id",
                table: "FluentBook");

            migrationBuilder.RenameColumn(
                name: "Publisher_Id",
                table: "FluentBook",
                newName: "Publisher_IdBook");

            migrationBuilder.RenameIndex(
                name: "IX_FluentBook_Publisher_Id",
                table: "FluentBook",
                newName: "IX_FluentBook_Publisher_IdBook");

            migrationBuilder.AddForeignKey(
                name: "FK_FluentBook_FluentPublisher_Publisher_IdBook",
                table: "FluentBook",
                column: "Publisher_IdBook",
                principalTable: "FluentPublisher",
                principalColumn: "Publisher_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FluentBook_FluentPublisher_Publisher_IdBook",
                table: "FluentBook");

            migrationBuilder.RenameColumn(
                name: "Publisher_IdBook",
                table: "FluentBook",
                newName: "Publisher_Id");

            migrationBuilder.RenameIndex(
                name: "IX_FluentBook_Publisher_IdBook",
                table: "FluentBook",
                newName: "IX_FluentBook_Publisher_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FluentBook_FluentPublisher_Publisher_Id",
                table: "FluentBook",
                column: "Publisher_Id",
                principalTable: "FluentPublisher",
                principalColumn: "Publisher_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
