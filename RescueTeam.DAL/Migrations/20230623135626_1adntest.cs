using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RescueTeam.DAL.Migrations
{
    /// <inheritdoc />
    public partial class _1adntest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamMembers_Teams_TeamId",
                table: "TeamMembers");

            migrationBuilder.RenameColumn(
                name: "TeamId",
                table: "TeamMembers",
                newName: "CurrentTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamMembers_TeamId",
                table: "TeamMembers",
                newName: "IX_TeamMembers_CurrentTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMembers_Teams_CurrentTeamId",
                table: "TeamMembers",
                column: "CurrentTeamId",
                principalTable: "Teams",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamMembers_Teams_CurrentTeamId",
                table: "TeamMembers");

            migrationBuilder.RenameColumn(
                name: "CurrentTeamId",
                table: "TeamMembers",
                newName: "TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamMembers_CurrentTeamId",
                table: "TeamMembers",
                newName: "IX_TeamMembers_TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMembers_Teams_TeamId",
                table: "TeamMembers",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
