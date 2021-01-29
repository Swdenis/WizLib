using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class AddOneToManyBookPublisherFluent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Publisher_Id",
                table: "FluentBook",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FluentBook_Publisher_Id",
                table: "FluentBook",
                column: "Publisher_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FluentBook_FluentPublisher_Publisher_Id",
                table: "FluentBook",
                column: "Publisher_Id",
                principalTable: "FluentPublisher",
                principalColumn: "Publisher_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FluentBook_FluentPublisher_Publisher_Id",
                table: "FluentBook");

            migrationBuilder.DropIndex(
                name: "IX_FluentBook_Publisher_Id",
                table: "FluentBook");

            migrationBuilder.DropColumn(
                name: "Publisher_Id",
                table: "FluentBook");
        }
    }
}
