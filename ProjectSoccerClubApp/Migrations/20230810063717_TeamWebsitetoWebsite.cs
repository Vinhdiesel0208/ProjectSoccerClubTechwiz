using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectSoccerClubApp.Migrations
{
    /// <inheritdoc />
    public partial class TeamWebsitetoWebsite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TeamWebsite",
                table: "Team",
                newName: "Website");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Website",
                table: "Team",
                newName: "TeamWebsite");
        }
    }
}
