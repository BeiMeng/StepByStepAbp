using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeiDream.SbsAbp.Migrations
{
    public partial class UpdateMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Menus",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "Menus",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "Menus",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "Menus",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Menus",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "Menus",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "Menus",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "Menus");
        }
    }
}
