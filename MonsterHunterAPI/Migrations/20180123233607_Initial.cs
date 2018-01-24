using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MonsterHunterAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blades",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Affinity = table.Column<int>(nullable: false),
                    Defense = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ElementDamage = table.Column<int>(nullable: false),
                    ElementType = table.Column<string>(nullable: true),
                    HasChild = table.Column<bool>(nullable: false),
                    ImgUrl = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    ParentID = table.Column<int>(nullable: true),
                    Rarity = table.Column<int>(nullable: false),
                    RawDamage = table.Column<int>(nullable: false),
                    Sharpness = table.Column<string>(nullable: false),
                    Slots = table.Column<int>(nullable: false),
                    WeaponClass = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blades", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Blades_Blades_ParentID",
                        column: x => x.ParentID,
                        principalTable: "Blades",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Area = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Rarity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BladesMaterials",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BladeID = table.Column<int>(nullable: true),
                    MaterialID = table.Column<int>(nullable: true),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BladesMaterials", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BladesMaterials_Blades_BladeID",
                        column: x => x.BladeID,
                        principalTable: "Blades",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BladesMaterials_Materials_MaterialID",
                        column: x => x.MaterialID,
                        principalTable: "Materials",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaterialsLocations",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Action = table.Column<string>(nullable: false),
                    DropRate = table.Column<int>(nullable: false),
                    LocationID = table.Column<int>(nullable: true),
                    MaterialID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialsLocations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MaterialsLocations_Locations_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Locations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaterialsLocations_Materials_MaterialID",
                        column: x => x.MaterialID,
                        principalTable: "Materials",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blades_ParentID",
                table: "Blades",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_BladesMaterials_BladeID",
                table: "BladesMaterials",
                column: "BladeID");

            migrationBuilder.CreateIndex(
                name: "IX_BladesMaterials_MaterialID",
                table: "BladesMaterials",
                column: "MaterialID");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialsLocations_LocationID",
                table: "MaterialsLocations",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialsLocations_MaterialID",
                table: "MaterialsLocations",
                column: "MaterialID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BladesMaterials");

            migrationBuilder.DropTable(
                name: "MaterialsLocations");

            migrationBuilder.DropTable(
                name: "Blades");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Materials");
        }
    }
}
