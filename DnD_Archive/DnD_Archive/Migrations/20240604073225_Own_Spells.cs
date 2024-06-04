using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnD_Archive.Migrations
{
    /// <inheritdoc />
    public partial class Own_Spells : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpellList_CharacterSheets_CharacterSheetSheetId",
                table: "SpellList");

            migrationBuilder.DropIndex(
                name: "IX_SpellList_CharacterSheetSheetId",
                table: "SpellList");

            migrationBuilder.DropColumn(
                name: "SpellAbility",
                table: "SpellList");

            migrationBuilder.DropColumn(
                name: "SpellDamage",
                table: "SpellList");

            migrationBuilder.RenameColumn(
                name: "SpellName",
                table: "SpellList",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "SpellLvl",
                table: "SpellList",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "CharacterSheetSheetId",
                table: "SpellList",
                newName: "Range");

            migrationBuilder.RenameColumn(
                name: "SpellsId",
                table: "SpellList",
                newName: "ID");

            migrationBuilder.AddColumn<string>(
                name: "CastingTime",
                table: "SpellList",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Duration",
                table: "SpellList",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "SpellList",
                type: "varchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CastingTime",
                table: "SpellList");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "SpellList");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "SpellList");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "SpellList",
                newName: "SpellLvl");

            migrationBuilder.RenameColumn(
                name: "Range",
                table: "SpellList",
                newName: "CharacterSheetSheetId");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "SpellList",
                newName: "SpellName");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "SpellList",
                newName: "SpellsId");

            migrationBuilder.AddColumn<string>(
                name: "SpellAbility",
                table: "SpellList",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "SpellDamage",
                table: "SpellList",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_SpellList_CharacterSheetSheetId",
                table: "SpellList",
                column: "CharacterSheetSheetId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpellList_CharacterSheets_CharacterSheetSheetId",
                table: "SpellList",
                column: "CharacterSheetSheetId",
                principalTable: "CharacterSheets",
                principalColumn: "SheetId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
