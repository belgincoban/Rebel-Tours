using Microsoft.EntityFrameworkCore.Migrations;

namespace RebelTours.Persistence.Migrations
{
    public partial class busMappingMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buses",
                columns: table => new
                {
                    BusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationPlate = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    SeatMapping = table.Column<int>(type: "int", nullable: false),
                    DistanceTraveled = table.Column<int>(type: "int", nullable: false),
                    BusModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buses", x => x.BusId);
                    table.ForeignKey(
                        name: "FK_Buses_BusModels_BusModelId",
                        column: x => x.BusModelId,
                        principalTable: "BusModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Buses",
                columns: new[] { "BusId", "BusModelId", "DistanceTraveled", "RegistrationPlate", "SeatMapping", "Year" },
                values: new object[] { 1, 2, 10000, "14-AA-14", 1, 2012 });

            migrationBuilder.InsertData(
                table: "Buses",
                columns: new[] { "BusId", "BusModelId", "DistanceTraveled", "RegistrationPlate", "SeatMapping", "Year" },
                values: new object[] { 2, 3, 20000, "24-BB-24", 1, 2013 });

            migrationBuilder.InsertData(
                table: "Buses",
                columns: new[] { "BusId", "BusModelId", "DistanceTraveled", "RegistrationPlate", "SeatMapping", "Year" },
                values: new object[] { 3, 3, 30000, "34-CC-34", 1, 2014 });

            migrationBuilder.CreateIndex(
                name: "IX_Buses_BusModelId",
                table: "Buses",
                column: "BusModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buses");
        }
    }
}
