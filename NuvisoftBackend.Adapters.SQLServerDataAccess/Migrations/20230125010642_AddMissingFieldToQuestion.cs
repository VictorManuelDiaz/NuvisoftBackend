using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NuvisoftBackend.Adapters.SQLServerDataAccess.Migrations
{
    public partial class AddMissingFieldToQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_auto",
                table: "tb_question",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_auto",
                table: "tb_question");
        }
    }
}
