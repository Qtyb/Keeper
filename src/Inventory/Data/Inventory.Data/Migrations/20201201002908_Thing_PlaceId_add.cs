using Microsoft.EntityFrameworkCore.Migrations;

namespace Inventory.Data.Migrations
{
    public partial class Thing_PlaceId_add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlaceId",
                table: "Things",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Things_PlaceId",
                table: "Things",
                column: "PlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Things_Places_PlaceId",
                table: "Things",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Things_Places_PlaceId",
                table: "Things");

            migrationBuilder.DropIndex(
                name: "IX_Things_PlaceId",
                table: "Things");

            migrationBuilder.DropColumn(
                name: "PlaceId",
                table: "Things");
        }
    }
}
