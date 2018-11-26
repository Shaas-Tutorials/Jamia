using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Jamia.Data.Migrations
{
    public partial class CampusModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Institute_Users_ApplicationUserId",
                schema: "SuperAdmin",
                table: "Institute");

            migrationBuilder.DropIndex(
                name: "IX_Institute_ApplicationUserId",
                schema: "SuperAdmin",
                table: "Institute");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "SuperAdmin",
                table: "Institute");

            migrationBuilder.AddColumn<Guid>(
                name: "InstituteID",
                schema: "Identity",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "Identity",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Campus",
                schema: "SuperAdmin",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    InstituteID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campus", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Campus_Institute_InstituteID",
                        column: x => x.InstituteID,
                        principalSchema: "SuperAdmin",
                        principalTable: "Institute",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_InstituteID",
                schema: "Identity",
                table: "Users",
                column: "InstituteID");

            migrationBuilder.CreateIndex(
                name: "IX_Campus_InstituteID",
                schema: "SuperAdmin",
                table: "Campus",
                column: "InstituteID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Institute_InstituteID",
                schema: "Identity",
                table: "Users",
                column: "InstituteID",
                principalSchema: "SuperAdmin",
                principalTable: "Institute",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Institute_InstituteID",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Campus",
                schema: "SuperAdmin");

            migrationBuilder.DropIndex(
                name: "IX_Users_InstituteID",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "InstituteID",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "Identity",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "SuperAdmin",
                table: "Institute",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Institute_ApplicationUserId",
                schema: "SuperAdmin",
                table: "Institute",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Institute_Users_ApplicationUserId",
                schema: "SuperAdmin",
                table: "Institute",
                column: "ApplicationUserId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
