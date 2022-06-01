using Microsoft.EntityFrameworkCore.Migrations;

namespace Customer_Onboarding.Migrations
{
    public partial class password_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Customers",
                maxLength: 18,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 18);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Password",
                table: "Customers",
                type: "int",
                maxLength: 18,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 18);
        }
    }
}
