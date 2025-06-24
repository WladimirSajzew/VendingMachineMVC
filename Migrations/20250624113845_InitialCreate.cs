using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendingMachineMVC.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GoodBase",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    ExpiryDate = table.Column<DateOnly>(type: "date", nullable: true),
                    CurrentSlotId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodBase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SlotBase",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Positions = table.Column<int>(type: "int", nullable: false),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Position = table.Column<int>(type: "int", nullable: true),
                    CurrentGoodId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlotBase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SlotBase_GoodBase_CurrentGoodId",
                        column: x => x.CurrentGoodId,
                        principalTable: "GoodBase",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GoodBase_CurrentSlotId",
                table: "GoodBase",
                column: "CurrentSlotId");

            migrationBuilder.CreateIndex(
                name: "IX_SlotBase_CurrentGoodId",
                table: "SlotBase",
                column: "CurrentGoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_GoodBase_SlotBase_CurrentSlotId",
                table: "GoodBase",
                column: "CurrentSlotId",
                principalTable: "SlotBase",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoodBase_SlotBase_CurrentSlotId",
                table: "GoodBase");

            migrationBuilder.DropTable(
                name: "Coins");

            migrationBuilder.DropTable(
                name: "SlotBase");

            migrationBuilder.DropTable(
                name: "GoodBase");
        }
    }
}
