using Microsoft.EntityFrameworkCore.Migrations;

namespace RebelTours.Persistence.Migrations
{
    public partial class CityAndStationMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stations_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "İstanbul" },
                    { 2, "Ankara" },
                    { 3, "Bursa" },
                    { 4, "Muş" },
                    { 5, "Mersin" }
                });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CityId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Esenler" },
                    { 2, 1, "Alibeyköy" },
                    { 3, 2, "Aşri" },
                    { 4, 3, "Dudullu" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stations_CityId",
                table: "Stations",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stations");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
