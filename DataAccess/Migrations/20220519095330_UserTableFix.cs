using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class UserTableFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.AlterColumn<string>(name: "Status", table: "Users", type: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
