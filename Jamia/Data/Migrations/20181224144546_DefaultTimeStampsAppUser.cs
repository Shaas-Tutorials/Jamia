using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Jamia.Data.Migrations
{
    public partial class DefaultTimeStampsAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTimeStamp",
                schema: "Identity",
                table: "Users",
                nullable: false,
                defaultValueSql: "GetDate()");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedTimeStamp",
                schema: "Identity",
                table: "Users",
                nullable: false,
                defaultValueSql: "GetDate()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedTimeStamp",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModifiedTimeStamp",
                schema: "Identity",
                table: "Users");
        }
    }
}
