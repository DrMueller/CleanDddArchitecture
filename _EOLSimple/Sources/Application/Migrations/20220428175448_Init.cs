using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mmu.CleanDddSimple.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Meetings");

            migrationBuilder.CreateTable(
                name: "Meeting",
                schema: "Meetings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MeetingType = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meeting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Agenda",
                schema: "Meetings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetingId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agenda_Meeting_MeetingId",
                        column: x => x.MeetingId,
                        principalSchema: "Meetings",
                        principalTable: "Meeting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Participant",
                schema: "Meetings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeetingId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participant_Meeting_MeetingId",
                        column: x => x.MeetingId,
                        principalSchema: "Meetings",
                        principalTable: "Meeting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AgendaPoint",
                schema: "Meetings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description_Text = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Index = table.Column<int>(type: "int", nullable: false),
                    AgendaId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendaPoint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgendaPoint_Agenda_AgendaId",
                        column: x => x.AgendaId,
                        principalSchema: "Meetings",
                        principalTable: "Agenda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_MeetingId",
                schema: "Meetings",
                table: "Agenda",
                column: "MeetingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AgendaPoint_AgendaId",
                schema: "Meetings",
                table: "AgendaPoint",
                column: "AgendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_MeetingId",
                schema: "Meetings",
                table: "Participant",
                column: "MeetingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgendaPoint",
                schema: "Meetings");

            migrationBuilder.DropTable(
                name: "Participant",
                schema: "Meetings");

            migrationBuilder.DropTable(
                name: "Agenda",
                schema: "Meetings");

            migrationBuilder.DropTable(
                name: "Meeting",
                schema: "Meetings");
        }
    }
}
