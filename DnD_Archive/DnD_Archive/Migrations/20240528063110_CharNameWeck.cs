using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnD_Archive.Migrations
{
    /// <inheritdoc />
    public partial class CharNameWeck : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CharName",
                table: "CharacterSheets");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CharName",
                table: "CharacterSheets",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
