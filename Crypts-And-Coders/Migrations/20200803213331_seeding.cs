using Microsoft.EntityFrameworkCore.Migrations;

namespace Crypts_And_Coders.Migrations
{
    public partial class seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stat",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stat", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Stat",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Strength" });

            migrationBuilder.InsertData(
                table: "Stat",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Cunning" });

            migrationBuilder.InsertData(
                table: "Stat",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Constitution" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stat");
        }
    }
}
