using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnD_Archive.Migrations
{
    /// <inheritdoc />
    public partial class aasdfas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Content",
                table: "CharacterSheets",
                newName: "CharContent");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CharContent",
                table: "CharacterSheets",
                newName: "CharContent");
        }
    }
}
