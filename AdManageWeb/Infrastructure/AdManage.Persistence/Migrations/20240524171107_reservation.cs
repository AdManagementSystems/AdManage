using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdManage.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class reservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_BronzePackages_BronzePackagesId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_GoldPackages_GoldPackagesId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_SilverPackages_SilverPackagesId",
                table: "Reservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "PersonCount",
                table: "Reservation");

            migrationBuilder.RenameTable(
                name: "Reservation",
                newName: "Reservations");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Reservations",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "DestinationId",
                table: "Reservations",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_SilverPackagesId",
                table: "Reservations",
                newName: "IX_Reservations_SilverPackagesId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_GoldPackagesId",
                table: "Reservations",
                newName: "IX_Reservations_GoldPackagesId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_BronzePackagesId",
                table: "Reservations",
                newName: "IX_Reservations_BronzePackagesId");

            migrationBuilder.AlterColumn<int>(
                name: "SilverPackagesId",
                table: "Reservations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GoldPackagesId",
                table: "Reservations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BronzePackagesId",
                table: "Reservations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_AppUserId",
                table: "Reservations",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_AppUserId",
                table: "Reservations",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_BronzePackages_BronzePackagesId",
                table: "Reservations",
                column: "BronzePackagesId",
                principalTable: "BronzePackages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_GoldPackages_GoldPackagesId",
                table: "Reservations",
                column: "GoldPackagesId",
                principalTable: "GoldPackages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_SilverPackages_SilverPackagesId",
                table: "Reservations",
                column: "SilverPackagesId",
                principalTable: "SilverPackages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_AppUserId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_BronzePackages_BronzePackagesId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_GoldPackages_GoldPackagesId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_SilverPackages_SilverPackagesId",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_AppUserId",
                table: "Reservations");

            migrationBuilder.RenameTable(
                name: "Reservations",
                newName: "Reservation");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Reservation",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Reservation",
                newName: "DestinationId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_SilverPackagesId",
                table: "Reservation",
                newName: "IX_Reservation_SilverPackagesId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_GoldPackagesId",
                table: "Reservation",
                newName: "IX_Reservation_GoldPackagesId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_BronzePackagesId",
                table: "Reservation",
                newName: "IX_Reservation_BronzePackagesId");

            migrationBuilder.AlterColumn<int>(
                name: "SilverPackagesId",
                table: "Reservation",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GoldPackagesId",
                table: "Reservation",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BronzePackagesId",
                table: "Reservation",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonCount",
                table: "Reservation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_BronzePackages_BronzePackagesId",
                table: "Reservation",
                column: "BronzePackagesId",
                principalTable: "BronzePackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_GoldPackages_GoldPackagesId",
                table: "Reservation",
                column: "GoldPackagesId",
                principalTable: "GoldPackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_SilverPackages_SilverPackagesId",
                table: "Reservation",
                column: "SilverPackagesId",
                principalTable: "SilverPackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
