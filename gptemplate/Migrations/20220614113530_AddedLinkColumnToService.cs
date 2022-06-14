using Microsoft.EntityFrameworkCore.Migrations;

namespace gptemplate.Migrations
{
    public partial class AddedLinkColumnToService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Services",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "Services");
        }
    }
}
