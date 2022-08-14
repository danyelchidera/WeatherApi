using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherApi.Migrations
{
    public partial class locationData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeatherDatas_Locations_LocationId",
                table: "WeatherDatas");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.CreateTable(
                name: "LocationDatas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Population = table.Column<int>(type: "int", nullable: false),
                    TimeZone = table.Column<int>(type: "int", nullable: false),
                    Sunrise = table.Column<int>(type: "int", nullable: false),
                    Sunset = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationDatas", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_WeatherDatas_LocationDatas_LocationId",
                table: "WeatherDatas",
                column: "LocationId",
                principalTable: "LocationDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeatherDatas_LocationDatas_LocationId",
                table: "WeatherDatas");

            migrationBuilder.DropTable(
                name: "LocationDatas");

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Population = table.Column<int>(type: "int", nullable: false),
                    Sunrise = table.Column<int>(type: "int", nullable: false),
                    Sunset = table.Column<int>(type: "int", nullable: false),
                    TimeZone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_WeatherDatas_Locations_LocationId",
                table: "WeatherDatas",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
