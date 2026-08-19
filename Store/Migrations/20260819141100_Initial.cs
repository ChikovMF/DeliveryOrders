using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    Number = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    SenderCity = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    SenderAddress = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    RecipientCity = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    RecipientAddress = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    Weight = table.Column<decimal>(type: "numeric(18,3)", precision: 18, scale: 3, nullable: false),
                    PickupDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.Number);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orders");
        }
    }
}
