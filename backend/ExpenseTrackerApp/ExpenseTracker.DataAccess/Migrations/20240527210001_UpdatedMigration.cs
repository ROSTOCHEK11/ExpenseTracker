using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseTracker.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SavedAmount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SavedAmount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SavingEntityId = table.Column<int>(type: "int", nullable: true),
                    SavingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedAmount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SavedAmount_Savings_SavingEntityId",
                        column: x => x.SavingEntityId,
                        principalTable: "Savings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SavedAmount_SavingEntityId",
                table: "SavedAmount",
                column: "SavingEntityId");
        }
    }
}
