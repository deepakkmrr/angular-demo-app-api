using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Database.Migrations
{
    public partial class studentmodelmodified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDateTime",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateTime",
                table: "Students",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LogId",
                table: "Students",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedDateTime",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DeletedDateTime",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LogId",
                table: "Students");
        }
    }
}
