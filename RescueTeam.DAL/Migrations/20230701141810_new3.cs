using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RescueTeam.DAL.Migrations
{
    /// <inheritdoc />
    public partial class new3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Vehicles_VehicleID",
                table: "Teams");

            migrationBuilder.RenameColumn(
                name: "VehicleID",
                table: "Teams",
                newName: "TrasportID");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_VehicleID",
                table: "Teams",
                newName: "IX_Teams_TrasportID");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Vehicles_TrasportID",
                table: "Teams",
                column: "TrasportID",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Vehicles_TrasportID",
                table: "Teams");

            migrationBuilder.RenameColumn(
                name: "TrasportID",
                table: "Teams",
                newName: "VehicleID");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_TrasportID",
                table: "Teams",
                newName: "IX_Teams_VehicleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Vehicles_VehicleID",
                table: "Teams",
                column: "VehicleID",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
