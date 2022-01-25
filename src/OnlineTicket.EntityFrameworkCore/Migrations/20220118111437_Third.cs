using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineTicket.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RegistrationNumber",
                table: "StudentData",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldMaxLength: 20);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "RegistrationNumber",
                table: "StudentData",
                type: "float",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20);
        }
    }
}
