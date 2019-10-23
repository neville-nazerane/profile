using Microsoft.EntityFrameworkCore.Migrations;

namespace Profile.AdminWebsite.Migrations
{
    public partial class IconNameLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IconName",
                table: "ProfileLinks",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IconName",
                table: "ProfileLinks",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
