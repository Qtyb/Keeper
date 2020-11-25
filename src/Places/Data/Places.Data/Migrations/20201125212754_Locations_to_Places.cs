using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Places.Data.Migrations
{
    public partial class Locations_to_Places : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Locations_ParentPlaceId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Users_UserId",
                table: "Locations");

            migrationBuilder.DropTable(
                name: "ThingLocations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locations",
                table: "Locations");

            migrationBuilder.RenameTable(
                name: "Locations",
                newName: "Places");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_UserId",
                table: "Places",
                newName: "IX_Places_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_ParentPlaceId",
                table: "Places",
                newName: "IX_Places_ParentPlaceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Places",
                table: "Places",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ThingPlaces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Longitude = table.Column<double>(nullable: true),
                    Latitude = table.Column<double>(nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(nullable: true),
                    ThingId = table.Column<int>(nullable: false),
                    PlaceId = table.Column<int>(nullable: false),
                    ImageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThingPlaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThingPlaces_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThingPlaces_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ThingPlaces_Things_ThingId",
                        column: x => x.ThingId,
                        principalTable: "Things",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ThingPlaces_ImageId",
                table: "ThingPlaces",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ThingPlaces_PlaceId",
                table: "ThingPlaces",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_ThingPlaces_ThingId",
                table: "ThingPlaces",
                column: "ThingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Places_ParentPlaceId",
                table: "Places",
                column: "ParentPlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Users_UserId",
                table: "Places",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_Places_ParentPlaceId",
                table: "Places");

            migrationBuilder.DropForeignKey(
                name: "FK_Places_Users_UserId",
                table: "Places");

            migrationBuilder.DropTable(
                name: "ThingPlaces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Places",
                table: "Places");

            migrationBuilder.RenameTable(
                name: "Places",
                newName: "Locations");

            migrationBuilder.RenameIndex(
                name: "IX_Places_UserId",
                table: "Locations",
                newName: "IX_Locations_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Places_ParentPlaceId",
                table: "Locations",
                newName: "IX_Locations_ParentPlaceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locations",
                table: "Locations",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ThingLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    PlaceId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    ThingId = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThingLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThingLocations_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThingLocations_Locations_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Locations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ThingLocations_Things_ThingId",
                        column: x => x.ThingId,
                        principalTable: "Things",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ThingLocations_ImageId",
                table: "ThingLocations",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ThingLocations_PlaceId",
                table: "ThingLocations",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_ThingLocations_ThingId",
                table: "ThingLocations",
                column: "ThingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Locations_ParentPlaceId",
                table: "Locations",
                column: "ParentPlaceId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Users_UserId",
                table: "Locations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
