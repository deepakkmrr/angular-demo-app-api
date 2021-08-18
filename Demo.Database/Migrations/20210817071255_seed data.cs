using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Database.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password" },
                values: new object[] { new Guid("23c2ccb8-bc71-4f20-94da-02bbc1cc7066"), "deepak@gmail.com", "Deepak", "Kumar", "8C6976E5B5410415BDE908BD4DEE15DFB167A9C873FC4BB8A81F6F2AB448A918" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("23c2ccb8-bc71-4f20-94da-02bbc1cc7066"));
        }
    }
}
