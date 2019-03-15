using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoMetzger.Migrations
{
    public partial class TodoRemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "TodoItems");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "TodoItems",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "TodoItems",
                nullable: true);
        }
    }
}
