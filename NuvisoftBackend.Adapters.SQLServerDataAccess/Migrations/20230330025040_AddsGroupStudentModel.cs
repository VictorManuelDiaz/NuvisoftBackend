using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NuvisoftBackend.Adapters.SQLServerDataAccess.Migrations
{
    public partial class AddsGroupStudentModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "atb_group_student",
                columns: table => new
                {
                    group_student_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    group_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    student_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    updated_by = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_atb_group_student", x => x.group_student_id);
                    table.ForeignKey(
                        name: "FK_atb_group_student_tb_group_group_id",
                        column: x => x.group_id,
                        principalTable: "tb_group",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_atb_group_student_tb_user_student_id",
                        column: x => x.student_id,
                        principalTable: "tb_user",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_atb_group_student_group_id",
                table: "atb_group_student",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "IX_atb_group_student_student_id",
                table: "atb_group_student",
                column: "student_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "atb_group_student");
        }
    }
}
