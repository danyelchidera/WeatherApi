using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherApi.Migrations
{
    public partial class renameForecast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeatherDatas_LocationDatas_CityId",
                table: "WeatherDatas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WeatherDatas",
                table: "WeatherDatas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LocationDatas",
                table: "LocationDatas");

            migrationBuilder.RenameTable(
                name: "WeatherDatas",
                newName: "WeatherForecasts");

            migrationBuilder.RenameTable(
                name: "LocationDatas",
                newName: "Cities");

            migrationBuilder.RenameIndex(
                name: "IX_WeatherDatas_CityId",
                table: "WeatherForecasts",
                newName: "IX_WeatherForecasts_CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeatherForecasts",
                table: "WeatherForecasts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WeatherForecasts_Cities_CityId",
                table: "WeatherForecasts",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeatherForecasts_Cities_CityId",
                table: "WeatherForecasts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WeatherForecasts",
                table: "WeatherForecasts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.RenameTable(
                name: "WeatherForecasts",
                newName: "WeatherDatas");

            migrationBuilder.RenameTable(
                name: "Cities",
                newName: "LocationDatas");

            migrationBuilder.RenameIndex(
                name: "IX_WeatherForecasts_CityId",
                table: "WeatherDatas",
                newName: "IX_WeatherDatas_CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeatherDatas",
                table: "WeatherDatas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocationDatas",
                table: "LocationDatas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WeatherDatas_LocationDatas_CityId",
                table: "WeatherDatas",
                column: "CityId",
                principalTable: "LocationDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
