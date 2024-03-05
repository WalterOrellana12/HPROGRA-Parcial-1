using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace walterParcial1.Migrations
{
    /// <inheritdoc />
    public partial class add_CarDealershipId_in_car_model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarDealershipId",
                table: "Car",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarDealershipId",
                table: "Car");
        }
    }
}
