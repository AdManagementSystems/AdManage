using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdManage.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migfirst : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BronzePackages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image2 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BronzePackages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GoldPackages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image2 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoldPackages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SilverPackages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image2 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SilverPackages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonCount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DestinationId = table.Column<int>(type: "int", nullable: false),
                    BronzePackagesId = table.Column<int>(type: "int", nullable: false),
                    GoldPackagesId = table.Column<int>(type: "int", nullable: false),
                    SilverPackagesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservation_BronzePackages_BronzePackagesId",
                        column: x => x.BronzePackagesId,
                        principalTable: "BronzePackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_GoldPackages_GoldPackagesId",
                        column: x => x.GoldPackagesId,
                        principalTable: "GoldPackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_SilverPackages_SilverPackagesId",
                        column: x => x.SilverPackagesId,
                        principalTable: "SilverPackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_BronzePackagesId",
                table: "Reservation",
                column: "BronzePackagesId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_GoldPackagesId",
                table: "Reservation",
                column: "GoldPackagesId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_SilverPackagesId",
                table: "Reservation",
                column: "SilverPackagesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "BronzePackages");

            migrationBuilder.DropTable(
                name: "GoldPackages");

            migrationBuilder.DropTable(
                name: "SilverPackages");
        }
    }
}
