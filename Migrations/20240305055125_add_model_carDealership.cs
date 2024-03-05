using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace walterParcial1.Migrations
{
    /// <inheritdoc />
    public partial class add_model_carDealership : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarDealership",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    ZipCode = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarDealership", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarEDealerships",
                columns: table => new
                {
                    CarsId = table.Column<int>(type: "INTEGER", nullable: false),
                    DealershipsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarEDealerships", x => new { x.CarsId, x.DealershipsId });
                    table.ForeignKey(
                        name: "FK_CarEDealerships_CarDealership_DealershipsId",
                        column: x => x.DealershipsId,
                        principalTable: "CarDealership",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarEDealerships_Car_CarsId",
                        column: x => x.CarsId,
                        principalTable: "Car",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarEDealerships_DealershipsId",
                table: "CarEDealerships",
                column: "DealershipsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarEDealerships");

            migrationBuilder.DropTable(
                name: "CarDealership");
        }
    }
}
