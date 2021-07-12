using Microsoft.EntityFrameworkCore.Migrations;

namespace Acme.BookStore.Migrations
{
    public partial class Status_Field : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "AppOrderedBooks",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "AppOrderedBooks");
        }
    }
}
