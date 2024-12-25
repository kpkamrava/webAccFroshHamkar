using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webDb.Migrations
{
    /// <inheritdoc />
    public partial class a1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblSeller",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "NVARCHAR(200)", nullable: false),
                    Darsad = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSeller", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblSales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tblSellerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Des = table.Column<string>(type: "NVARCHAR(200)", nullable: false),
                    MabFrosh = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MabH = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Darsad = table.Column<double>(type: "float", nullable: true),
                    Bed = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Bes = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Mande = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblSales_tblSeller_tblSellerId",
                        column: x => x.tblSellerId,
                        principalTable: "tblSeller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblSales_tblSellerId",
                table: "tblSales",
                column: "tblSellerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblSales");

            migrationBuilder.DropTable(
                name: "tblSeller");
        }
    }
}
