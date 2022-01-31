using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineTicket.Migrations
{
    public partial class newFieldAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ObtainedMarks",
                table: "StudentData",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ObtainedMarks",
                table: "StudentData");
        }
    }
}
