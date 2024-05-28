using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnD_Archive.Migrations
{
    /// <inheritdoc />
    public partial class DND : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterSheets_Users_UserID",
                table: "CharacterSheets");

            migrationBuilder.DropIndex(
                name: "IX_CharacterSheets_UserID",
                table: "CharacterSheets");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "CharacterSheets",
                newName: "UserdId");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "CharacterSheets",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "CharacterSheets");

            migrationBuilder.RenameColumn(
                name: "UserdId",
                table: "CharacterSheets",
                newName: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSheets_UserID",
                table: "CharacterSheets",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterSheets_Users_UserID",
                table: "CharacterSheets",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
