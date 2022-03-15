using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Covid.Migrations
{
    public partial class ContactNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactNumber",
                table: "employeeDatas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactNumber",
                table: "employeeDatas");
        }
    }
}
