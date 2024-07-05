using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TalentTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EmailUniqueConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "tt",
                table: "Candidates",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_Email",
                schema: "tt",
                table: "Candidates",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Candidates_Email",
                schema: "tt",
                table: "Candidates");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "tt",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
