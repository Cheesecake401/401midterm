using Microsoft.EntityFrameworkCore.Migrations;

namespace Crypts_And_Coders.Migrations
{
    public partial class addingInventorySeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Enemy",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EnemyLoot",
                columns: table => new
                {
                    CharacterId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnemyLoot", x => new { x.CharacterId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_EnemyLoot_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnemyLoot_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CharacterInventory",
                columns: new[] { "CharacterId", "ItemId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 1 },
                    { 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enemy_LocationId",
                table: "Enemy",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_EnemyLoot_ItemId",
                table: "EnemyLoot",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enemy_Location_LocationId",
                table: "Enemy",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enemy_Location_LocationId",
                table: "Enemy");

            migrationBuilder.DropTable(
                name: "EnemyLoot");

            migrationBuilder.DropIndex(
                name: "IX_Enemy_LocationId",
                table: "Enemy");

            migrationBuilder.DeleteData(
                table: "CharacterInventory",
                keyColumns: new[] { "CharacterId", "ItemId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CharacterInventory",
                keyColumns: new[] { "CharacterId", "ItemId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "CharacterInventory",
                keyColumns: new[] { "CharacterId", "ItemId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "CharacterInventory",
                keyColumns: new[] { "CharacterId", "ItemId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "CharacterInventory",
                keyColumns: new[] { "CharacterId", "ItemId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "CharacterInventory",
                keyColumns: new[] { "CharacterId", "ItemId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Enemy");
        }
    }
}
