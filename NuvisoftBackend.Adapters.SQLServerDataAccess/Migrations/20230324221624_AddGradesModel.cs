using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NuvisoftBackend.Adapters.SQLServerDataAccess.Migrations
{
    public partial class AddGradesModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_grade",
                columns: table => new
                {
                    grade_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    score = table.Column<int>(type: "int", nullable: false),
                    job_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    updated_by = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_grade", x => x.grade_id);
                    table.ForeignKey(
                        name: "FK_tb_grade_tb_job_job_id",
                        column: x => x.job_id,
                        principalTable: "tb_job",
                        principalColumn: "job_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_grade_tb_user_user_id",
                        column: x => x.user_id,
                        principalTable: "tb_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_grade_job_id",
                table: "tb_grade",
                column: "job_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_grade_user_id",
                table: "tb_grade",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_grade");
        }
    }
}
