using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NuvisoftBackend.Adapters.SQLServerDataAccess.Migrations
{
    public partial class AddsGroupModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_group",
                columns: table => new
                {
                    group_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    year = table.Column<int>(type: "int", nullable: false),
                    school_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    updated_by = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_group", x => x.group_id);
                    table.ForeignKey(
                        name: "FK_tb_group_tb_school_school_id",
                        column: x => x.school_id,
                        principalTable: "tb_school",
                        principalColumn: "school_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "atb_group_subject",
                columns: table => new
                {
                    group_subject_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    group_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    subject_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    updated_by = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_atb_group_subject", x => x.group_subject_id);
                    table.ForeignKey(
                        name: "FK_atb_group_subject_tb_group_group_id",
                        column: x => x.group_id,
                        principalTable: "tb_group",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_atb_group_subject_tb_subject_subject_id",
                        column: x => x.subject_id,
                        principalTable: "tb_subject",
                        principalColumn: "subject_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_atb_group_subject_group_id",
                table: "atb_group_subject",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "IX_atb_group_subject_subject_id",
                table: "atb_group_subject",
                column: "subject_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_group_school_id",
                table: "tb_group",
                column: "school_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "atb_group_subject");

            migrationBuilder.DropTable(
                name: "tb_group");
        }
    }
}
