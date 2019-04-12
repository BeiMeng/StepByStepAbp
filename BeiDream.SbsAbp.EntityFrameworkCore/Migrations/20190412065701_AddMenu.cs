using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeiDream.SbsAbp.Migrations
{
    public partial class AddMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    ParentId = table.Column<Guid>(nullable: true),
                    Url = table.Column<string>(maxLength: 100, nullable: true),
                    DisplayName = table.Column<string>(maxLength: 50, nullable: true),
                    IconClass = table.Column<string>(maxLength: 20, nullable: true),
                    Order = table.Column<int>(nullable: false),
                    Group = table.Column<bool>(nullable: false),
                    Default = table.Column<bool>(nullable: false),
                    IsHome = table.Column<bool>(nullable: false),
                    NotClose = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menus_Menus_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menus_ParentId",
                table: "Menus",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Menus");
        }
    }
}
