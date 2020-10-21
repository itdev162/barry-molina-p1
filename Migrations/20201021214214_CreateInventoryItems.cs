using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManager.Migrations
{
    public partial class CreateInventoryItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InventoryItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Vendor = table.Column<string>(nullable: true),
                    QuantityOnHand = table.Column<int>(nullable: false),
                    OrderAtQuantity = table.Column<int>(nullable: false),
                    LastOrderDate = table.Column<DateTime>(nullable: false),
                    NextOrderDate = table.Column<DateTime>(nullable: false),
                    OrderPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItems", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryItems");
        }
    }
}
