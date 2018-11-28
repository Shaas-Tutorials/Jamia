using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Jamia.Data.Migrations
{
    public partial class InstituteCampus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                schema: "SuperAdmin",
                table: "Institute");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "SuperAdmin",
                table: "Campus",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "CampusID",
                schema: "Admin",
                table: "Session",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Session_CampusID",
                schema: "Admin",
                table: "Session",
                column: "CampusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Session_Campus_CampusID",
                schema: "Admin",
                table: "Session",
                column: "CampusID",
                principalSchema: "SuperAdmin",
                principalTable: "Campus",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Session_Campus_CampusID",
                schema: "Admin",
                table: "Session");

            migrationBuilder.DropIndex(
                name: "IX_Session_CampusID",
                schema: "Admin",
                table: "Session");

            migrationBuilder.DropColumn(
                name: "Address",
                schema: "SuperAdmin",
                table: "Campus");

            migrationBuilder.DropColumn(
                name: "CampusID",
                schema: "Admin",
                table: "Session");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "SuperAdmin",
                table: "Institute",
                nullable: false,
                defaultValue: "");
        }
    }
}
