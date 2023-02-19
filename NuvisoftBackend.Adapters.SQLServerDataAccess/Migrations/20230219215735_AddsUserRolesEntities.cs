using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NuvisoftBackend.Adapters.SQLServerDataAccess.Migrations
{
    public partial class AddsUserRolesEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_role",
                columns: table => new
                {
                    role_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    role_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    updated_by = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_role", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "atb_privilege",
                columns: table => new
                {
                    privilege_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    role_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    updated_by = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_atb_privilege", x => x.privilege_id);
                    table.ForeignKey(
                        name: "FK_atb_privilege_tb_role_role_id",
                        column: x => x.role_id,
                        principalTable: "tb_role",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_atb_privilege_tb_user_user_id",
                        column: x => x.user_id,
                        principalTable: "tb_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "atb_privilege_subject",
                columns: table => new
                {
                    privilege_subject_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    privilege_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    subject_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    updated_by = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_atb_privilege_subject", x => x.privilege_subject_id);
                    table.ForeignKey(
                        name: "FK_atb_privilege_subject_atb_privilege_privilege_id",
                        column: x => x.privilege_id,
                        principalTable: "atb_privilege",
                        principalColumn: "privilege_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_atb_privilege_subject_tb_subject_subject_id",
                        column: x => x.subject_id,
                        principalTable: "tb_subject",
                        principalColumn: "subject_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_atb_privilege_role_id",
                table: "atb_privilege",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_atb_privilege_user_id",
                table: "atb_privilege",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_atb_privilege_subject_privilege_id",
                table: "atb_privilege_subject",
                column: "privilege_id");

            migrationBuilder.CreateIndex(
                name: "IX_atb_privilege_subject_subject_id",
                table: "atb_privilege_subject",
                column: "subject_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "atb_privilege_subject");

            migrationBuilder.DropTable(
                name: "atb_privilege");

            migrationBuilder.DropTable(
                name: "tb_role");
        }
    }
}
