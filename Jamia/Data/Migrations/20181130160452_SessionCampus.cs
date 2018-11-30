using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Jamia.Data.Migrations
{
    public partial class SessionCampus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Session_Campus_CampusID",
                schema: "Admin",
                table: "Session");

            migrationBuilder.RenameColumn(
                name: "CampusID",
                schema: "Admin",
                table: "Session",
                newName: "CampusId");

            migrationBuilder.RenameIndex(
                name: "IX_Session_CampusID",
                schema: "Admin",
                table: "Session",
                newName: "IX_Session_CampusId");

            migrationBuilder.AlterColumn<Guid>(
                name: "CampusId",
                schema: "Admin",
                table: "Session",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Session_Campus_CampusId",
                schema: "Admin",
                table: "Session",
                column: "CampusId",
                principalSchema: "SuperAdmin",
                principalTable: "Campus",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Session_Campus_CampusId",
                schema: "Admin",
                table: "Session");

            migrationBuilder.RenameColumn(
                name: "CampusId",
                schema: "Admin",
                table: "Session",
                newName: "CampusID");

            migrationBuilder.RenameIndex(
                name: "IX_Session_CampusId",
                schema: "Admin",
                table: "Session",
                newName: "IX_Session_CampusID");

            migrationBuilder.AlterColumn<Guid>(
                name: "CampusID",
                schema: "Admin",
                table: "Session",
                nullable: true,
                oldClrType: typeof(Guid));

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
    }
}
