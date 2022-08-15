using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherApi.Migrations
{
    public partial class renameTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeatherDatas_LocationDatas_LocationId",
                table: "WeatherDatas");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "WeatherDatas",
                newName: "CityId");

            migrationBuilder.RenameIndex(
                name: "IX_WeatherDatas_LocationId",
                table: "WeatherDatas",
                newName: "IX_WeatherDatas_CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeatherDatas_LocationDatas_CityId",
                table: "WeatherDatas",
                column: "CityId",
                principalTable: "LocationDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeatherDatas_LocationDatas_CityId",
                table: "WeatherDatas");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "WeatherDatas",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_WeatherDatas_CityId",
                table: "WeatherDatas",
                newName: "IX_WeatherDatas_LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeatherDatas_LocationDatas_LocationId",
                table: "WeatherDatas",
                column: "LocationId",
                principalTable: "LocationDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
