using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TalentTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlcoholEntitesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Containers",
                schema: "tt",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContainerGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Containers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                schema: "tt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeasurementUnitTypes",
                schema: "tt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementUnitTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkProcesses",
                schema: "tt",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkProcessGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContainerId = table.Column<long>(type: "bigint", nullable: false),
                    WorkProcessCount = table.Column<int>(type: "int", nullable: false),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkProcesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkProcesses_Containers_ContainerId",
                        column: x => x.ContainerId,
                        principalSchema: "tt",
                        principalTable: "Containers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkProcessDetails",
                schema: "tt",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkProcessDetailGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkProcessID = table.Column<long>(type: "bigint", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAlcohol = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WaterChangeCount = table.Column<int>(type: "int", nullable: false),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkProcessDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkProcessDetails_WorkProcesses_WorkProcessID",
                        column: x => x.WorkProcessID,
                        principalSchema: "tt",
                        principalTable: "WorkProcesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkProcessIngredients",
                schema: "tt",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkProcessIngredientGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkProcessID = table.Column<long>(type: "bigint", nullable: false),
                    IngredientID = table.Column<int>(type: "int", nullable: false),
                    MeasurementUnit_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeasurementUnit_Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WorkProcessId = table.Column<long>(type: "bigint", nullable: false),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkProcessIngredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkProcessIngredients_Ingredients_IngredientID",
                        column: x => x.IngredientID,
                        principalSchema: "tt",
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkProcessIngredients_WorkProcesses_WorkProcessID",
                        column: x => x.WorkProcessID,
                        principalSchema: "tt",
                        principalTable: "WorkProcesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkProcessIngredients_WorkProcesses_WorkProcessId",
                        column: x => x.WorkProcessId,
                        principalSchema: "tt",
                        principalTable: "WorkProcesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkProcessDetails_WorkProcessID",
                schema: "tt",
                table: "WorkProcessDetails",
                column: "WorkProcessID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkProcesses_ContainerId",
                schema: "tt",
                table: "WorkProcesses",
                column: "ContainerId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkProcessIngredients_IngredientID",
                schema: "tt",
                table: "WorkProcessIngredients",
                column: "IngredientID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkProcessIngredients_WorkProcessId",
                schema: "tt",
                table: "WorkProcessIngredients",
                column: "WorkProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkProcessIngredients_WorkProcessID",
                schema: "tt",
                table: "WorkProcessIngredients",
                column: "WorkProcessID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeasurementUnitTypes",
                schema: "tt");

            migrationBuilder.DropTable(
                name: "WorkProcessDetails",
                schema: "tt");

            migrationBuilder.DropTable(
                name: "WorkProcessIngredients",
                schema: "tt");

            migrationBuilder.DropTable(
                name: "Ingredients",
                schema: "tt");

            migrationBuilder.DropTable(
                name: "WorkProcesses",
                schema: "tt");

            migrationBuilder.DropTable(
                name: "Containers",
                schema: "tt");
        }
    }
}
