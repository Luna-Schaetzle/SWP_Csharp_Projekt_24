using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnD_Archive.Migrations
{
    /// <inheritdoc />
    public partial class Character : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CharacterSheets",
                columns: table => new
                {
                    SheetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    CharName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSheets", x => x.SheetId);
                    table.ForeignKey(
                        name: "FK_CharacterSheets_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "charInfos",
                columns: table => new
                {
                    InfoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    personalitTraits = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Bonds = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ideals = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Flaws = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdditionalInfo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_charInfos", x => x.InfoID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "charStats",
                columns: table => new
                {
                    StatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    Dexterity = table.Column<int>(type: "int", nullable: false),
                    Constitution = table.Column<int>(type: "int", nullable: false),
                    Wisdom = table.Column<int>(type: "int", nullable: false),
                    Intelligence = table.Column<int>(type: "int", nullable: false),
                    Charisma = table.Column<int>(type: "int", nullable: false),
                    SpellSlotsLVL1 = table.Column<int>(type: "int", nullable: false),
                    SpellSlotsLVL2 = table.Column<int>(type: "int", nullable: false),
                    SpellSlotsLVL3 = table.Column<int>(type: "int", nullable: false),
                    SpellSlotsLVL4 = table.Column<int>(type: "int", nullable: false),
                    SpellSlotsLVL5 = table.Column<int>(type: "int", nullable: false),
                    SpellSlotsLVL6 = table.Column<int>(type: "int", nullable: false),
                    SpellSlotsLVL7 = table.Column<int>(type: "int", nullable: false),
                    SpellSlotsLVL8 = table.Column<int>(type: "int", nullable: false),
                    SpellSlotsLVL9 = table.Column<int>(type: "int", nullable: false),
                    ProficiencyBonus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_charStats", x => x.StatId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    InventoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Weapons = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Items = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Platin = table.Column<int>(type: "int", nullable: false),
                    Gold = table.Column<int>(type: "int", nullable: false),
                    Silver = table.Column<int>(type: "int", nullable: false),
                    Copper = table.Column<int>(type: "int", nullable: false),
                    Additonal = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.InventoryId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SpellList",
                columns: table => new
                {
                    SpellsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CharacterSheetSheetId = table.Column<int>(type: "int", nullable: false),
                    SpellLvl = table.Column<int>(type: "int", nullable: false),
                    SpellName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SpellDamage = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SpellAbility = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellList", x => x.SpellsId);
                    table.ForeignKey(
                        name: "FK_SpellList_CharacterSheets_CharacterSheetSheetId",
                        column: x => x.CharacterSheetSheetId,
                        principalTable: "CharacterSheets",
                        principalColumn: "SheetId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSheets_UserID",
                table: "CharacterSheets",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_SpellList_CharacterSheetSheetId",
                table: "SpellList",
                column: "CharacterSheetSheetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "charInfos");

            migrationBuilder.DropTable(
                name: "charStats");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "SpellList");

            migrationBuilder.DropTable(
                name: "CharacterSheets");
        }
    }
}
