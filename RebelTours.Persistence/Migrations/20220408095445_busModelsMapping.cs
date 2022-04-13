using Microsoft.EntityFrameworkCore.Migrations;

namespace RebelTours.Persistence.Migrations
{
    public partial class busModelsMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusManufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusManufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    BusManufacturerId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    SeatCapacity = table.Column<int>(type: "int", nullable: false),
                    HasToilet = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusModels_BusManufacturers_BusManufacturerId",
                        column: x => x.BusManufacturerId,
                        principalTable: "BusManufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BusManufacturers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Mercedes" });

            migrationBuilder.InsertData(
                table: "BusManufacturers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Travego" });

            migrationBuilder.InsertData(
                table: "BusManufacturers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Svf" });

            migrationBuilder.InsertData(
                table: "BusModels",
                columns: new[] { "Id", "BusManufacturerId", "HasToilet", "Name", "SeatCapacity", "Type" },
                values: new object[] { 1, 1, false, "CityLiner", 52, 2 });

            migrationBuilder.InsertData(
                table: "BusModels",
                columns: new[] { "Id", "BusManufacturerId", "HasToilet", "Name", "SeatCapacity", "Type" },
                values: new object[] { 2, 2, false, "Travego", 44, 2 });

            migrationBuilder.InsertData(
                table: "BusModels",
                columns: new[] { "Id", "BusManufacturerId", "HasToilet", "Name", "SeatCapacity", "Type" },
                values: new object[] { 3, 3, false, "S 415", 48, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_BusModels_BusManufacturerId",
                table: "BusModels",
                column: "BusManufacturerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusModels");

            migrationBuilder.DropTable(
                name: "BusManufacturers");
        }
    }
}
