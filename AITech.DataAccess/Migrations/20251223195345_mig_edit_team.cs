using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AITech.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_edit_team : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FacebookUrl",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "InstagramUrl",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "LinkedinUrl",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Teams");

            migrationBuilder.RenameColumn(
                name: "TwitterUrl",
                table: "Teams",
                newName: "Title");

            migrationBuilder.AddColumn<int>(
                name: "SocialId",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_SocialId",
                table: "Teams",
                column: "SocialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Socials_SocialId",
                table: "Teams",
                column: "SocialId",
                principalTable: "Socials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Socials_SocialId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_SocialId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "SocialId",
                table: "Teams");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Teams",
                newName: "TwitterUrl");

            migrationBuilder.AddColumn<string>(
                name: "FacebookUrl",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InstagramUrl",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LinkedinUrl",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
