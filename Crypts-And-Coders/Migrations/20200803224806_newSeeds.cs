using Microsoft.EntityFrameworkCore.Migrations;

namespace Crypts_And_Coders.Migrations
{
    public partial class newSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StatSheet",
                columns: table => new
                {
                    StatId = table.Column<int>(nullable: false),
                    CharacterId = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatSheet", x => new { x.StatId, x.CharacterId });
                    table.ForeignKey(
                        name: "FK_StatSheet_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StatSheet_Stat_StatId",
                        column: x => x.StatId,
                        principalTable: "Stat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "StatSheet",
                columns: new[] { "StatId", "CharacterId", "Level" },
                values: new object[,]
                {
                    { 1, 1, 0 },
                    { 2, 1, 0 },
                    { 2, 2, 0 },
                    { 3, 2, 0 },
                    { 1, 3, 0 },
                    { 3, 3, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StatSheet_CharacterId",
                table: "StatSheet",
                column: "CharacterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StatSheet");
        }
    }
}
