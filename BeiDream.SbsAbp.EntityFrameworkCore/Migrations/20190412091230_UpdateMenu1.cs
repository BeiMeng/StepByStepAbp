using Microsoft.EntityFrameworkCore.Migrations;

namespace BeiDream.SbsAbp.Migrations
{
    public partial class UpdateMenu1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Menus",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PermissionName",
                table: "Menus",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PermissionName",
                table: "Menus");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Menus",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
