using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TalentTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "tt");

            migrationBuilder.CreateSequence(
                name: "candidateseq",
                schema: "tt",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "eventlogseq",
                schema: "tt",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "Candidates",
                schema: "tt",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CandidateGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeIntervalToCall = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreeTextComment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SocialMediaLinks_LinkedinProfileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialMediaLinks_GithubProfileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventTypes",
                schema: "tt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventLogs",
                schema: "tt",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    EventLogGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventTypeId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventLogs_EventTypes_EventTypeId",
                        column: x => x.EventTypeId,
                        principalSchema: "tt",
                        principalTable: "EventTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventLogs_EventLogGUID",
                schema: "tt",
                table: "EventLogs",
                column: "EventLogGUID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventLogs_EventTypeId",
                schema: "tt",
                table: "EventLogs",
                column: "EventTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidates",
                schema: "tt");

            migrationBuilder.DropTable(
                name: "EventLogs",
                schema: "tt");

            migrationBuilder.DropTable(
                name: "EventTypes",
                schema: "tt");

            migrationBuilder.DropSequence(
                name: "candidateseq",
                schema: "tt");

            migrationBuilder.DropSequence(
                name: "eventlogseq",
                schema: "tt");
        }
    }
}
