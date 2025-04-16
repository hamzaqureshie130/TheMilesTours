using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.TheMilesTours.Migrations
{
    /// <inheritdoc />
    public partial class addCarTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RentPerDay = table.Column<int>(type: "int", nullable: false),
                    Transmission = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AirCondtion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Driver = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fuel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Colour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GeneralInformation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Base64Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarGallery",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarGallery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarGallery_Car_CarId",
                        column: x => x.CarId,
                        principalTable: "Car",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarGallery_CarId",
                table: "CarGallery",
                column: "CarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarGallery");

            migrationBuilder.DropTable(
                name: "Car");
        }
    }
}
