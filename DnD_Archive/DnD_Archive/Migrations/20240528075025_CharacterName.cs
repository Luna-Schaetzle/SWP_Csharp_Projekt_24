using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnD_Archive.Migrations
{
    /// <inheritdoc />
    public partial class CharacterName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CharacterSheets",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "CharacterSheets");
        }
    }
}
