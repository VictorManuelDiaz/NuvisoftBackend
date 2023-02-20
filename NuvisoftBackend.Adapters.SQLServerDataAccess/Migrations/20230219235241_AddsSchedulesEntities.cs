using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NuvisoftBackend.Adapters.SQLServerDataAccess.Migrations
{
    public partial class AddsSchedulesEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_schedule",
                columns: table => new
                {
                    schedule_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    modality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    updated_by = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_schedule", x => x.schedule_id);
                });

            migrationBuilder.CreateTable(
                name: "atb_subject_schedule",
                columns: table => new
                {
                    subject_schedule_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    subject_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    schedule_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    updated_by = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_atb_subject_schedule", x => x.subject_schedule_id);
                    table.ForeignKey(
                        name: "FK_atb_subject_schedule_tb_schedule_schedule_id",
                        column: x => x.schedule_id,
                        principalTable: "tb_schedule",
                        principalColumn: "schedule_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_atb_subject_schedule_tb_subject_subject_id",
                        column: x => x.subject_id,
                        principalTable: "tb_subject",
                        principalColumn: "subject_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_atb_subject_schedule_schedule_id",
                table: "atb_subject_schedule",
                column: "schedule_id");

            migrationBuilder.CreateIndex(
                name: "IX_atb_subject_schedule_subject_id",
                table: "atb_subject_schedule",
                column: "subject_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "atb_subject_schedule");

            migrationBuilder.DropTable(
                name: "tb_schedule");
        }
    }
}
