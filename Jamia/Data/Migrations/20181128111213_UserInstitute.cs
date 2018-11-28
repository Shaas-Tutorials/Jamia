using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Jamia.Data.Migrations
{
    public partial class UserInstitute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Institute_InstituteID",
                schema: "Identity",
                table: "Users");

            migrationBuilder.AlterColumn<Guid>(
                name: "InstituteID",
                schema: "Identity",
                table: "Users",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Institute_InstituteID",
                schema: "Identity",
                table: "Users",
                column: "InstituteID",
                principalSchema: "SuperAdmin",
                principalTable: "Institute",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Institute_InstituteID",
                schema: "Identity",
                table: "Users");

            migrationBuilder.AlterColumn<Guid>(
                name: "InstituteID",
                schema: "Identity",
                table: "Users",
                nullable: true,
                oldClrType: typeof(Guid));

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
    }
}
