using Microsoft.EntityFrameworkCore.Migrations;

namespace Crypts_And_Coders.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enemy",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Abilities = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Species = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enemy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weapon",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    BaseDamage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnemyInLocation",
                columns: table => new
                {
                    LocationId = table.Column<int>(nullable: false),
                    EnemyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnemyInLocation", x => new { x.LocationId, x.EnemyId });
                    table.ForeignKey(
                        name: "FK_EnemyInLocation_Enemy_EnemyId",
                        column: x => x.EnemyId,
                        principalTable: "Enemy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnemyInLocation_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    WeaponId = table.Column<int>(nullable: false),
                    LocationId = table.Column<int>(nullable: false),
                    Species = table.Column<int>(nullable: false),
                    Class = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Character_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Character_Weapon_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterInventory",
                columns: table => new
                {
                    CharacterId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterInventory", x => new { x.CharacterId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_CharacterInventory_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterInventory_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Enemy",
                columns: new[] { "Id", "Abilities", "Species", "Type" },
                values: new object[,]
                {
                    { 1, "Slash", 6, "Warrior" },
                    { 2, "Smash", 7, "Beast" },
                    { 3, "Firebreath", 8, "Mythical" }
                });

            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "Id", "Name", "Value" },
                values: new object[,]
                {
                    { 1, "Health Potion", 25 },
                    { 2, "Cup", 5 },
                    { 3, "Dungeon Key", 100 }
                });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Occupied by the forces of evil, Faldor consists of open, hilly plains that separate it's eastern border with towering mountains.", "Faldor" },
                    { 2, "Plagued by the great war, Murkden remains uninhibited from all intelligent life forms, although various beasts still dwell in the deep marshes.", "Murkden" },
                    { 3, "Lyderton is full of simpletons who prefer to keep war and conflict outside of their borders. It is rich farmland with dense amounts of beautiful wildlife.", "Lyderton" }
                });

            migrationBuilder.InsertData(
                table: "Weapon",
                columns: new[] { "Id", "BaseDamage", "Name", "Type" },
                values: new object[,]
                {
                    { 1, 15, "Claymore", "Close Range" },
                    { 2, 18, "Wizard Staff", "Magical" },
                    { 3, 10, "Longbow", "Long Range" }
                });

            migrationBuilder.InsertData(
                table: "Character",
                columns: new[] { "Id", "Class", "LocationId", "Name", "Species", "WeaponId" },
                values: new object[] { 1, 3, 1, "Galdifor", 1, 1 });

            migrationBuilder.InsertData(
                table: "Character",
                columns: new[] { "Id", "Class", "LocationId", "Name", "Species", "WeaponId" },
                values: new object[] { 2, 0, 1, "Dragorn", 3, 1 });

            migrationBuilder.InsertData(
                table: "Character",
                columns: new[] { "Id", "Class", "LocationId", "Name", "Species", "WeaponId" },
                values: new object[] { 3, 4, 1, "Glen", 0, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Character_LocationId",
                table: "Character",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_WeaponId",
                table: "Character",
                column: "WeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterInventory_ItemId",
                table: "CharacterInventory",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_EnemyInLocation_EnemyId",
                table: "EnemyInLocation",
                column: "EnemyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterInventory");

            migrationBuilder.DropTable(
                name: "EnemyInLocation");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Enemy");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Weapon");
        }
    }
}
