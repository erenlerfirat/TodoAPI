using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class TodoNewColumnImportanceLevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImportanceLevel",
                table: "Todos",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
                migrationBuilder.DropColumn(
                name: "ImportanceLevel",
                table: "Todos");
        }
    }
}
