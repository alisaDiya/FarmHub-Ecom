using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ST10037089__prog3ap2_Final_.Data.Migrations
{
    /// <inheritdoc />
    public partial class _1stmigg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "farmers",
                columns: table => new
                {
                    farmerid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    farmername = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    farmersurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    farmeremail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    farmerType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    farmerLocation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_farmers", x => x.farmerid);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    productid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    farmerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.productid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "farmers");

            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
