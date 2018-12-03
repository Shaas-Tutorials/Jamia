using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Jamia.Data.Migrations
{
    public partial class UserInstituteModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Institute_InstituteID",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_InstituteID",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "InstituteID",
                schema: "Identity",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "UserInstitute",
                schema: "SuperAdmin",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(nullable: false),
                    InstituteId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInstitute", x => new { x.ApplicationUserId, x.InstituteId });
                    table.ForeignKey(
                        name: "FK_UserInstitute_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserInstitute_Institute_InstituteId",
                        column: x => x.InstituteId,
                        principalSchema: "SuperAdmin",
                        principalTable: "Institute",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserInstitute_InstituteId",
                schema: "SuperAdmin",
                table: "UserInstitute",
                column: "InstituteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserInstitute",
                schema: "SuperAdmin");

            migrationBuilder.AddColumn<Guid>(
                name: "InstituteID",
                schema: "Identity",
                table: "Users",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Users_InstituteID",
                schema: "Identity",
                table: "Users",
                column: "InstituteID");

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
    }
}
