using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bibosio.CatalogModule.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class Create_Base_Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "catalog");

            migrationBuilder.CreateTable(
                name: "CatalogItems",
                schema: "catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    IsUseInProductName = table.Column<bool>(type: "boolean", nullable: false),
                    IsCategory = table.Column<bool>(type: "boolean", nullable: false),
                    Sku_Value = table.Column<string>(type: "text", nullable: true),
                    ParentId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatalogItems_CatalogItems_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "catalog",
                        principalTable: "CatalogItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Options",
                schema: "catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    PriorityInProductName = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OptionValues",
                schema: "catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true),
                    OptionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OptionValues_Options_OptionId",
                        column: x => x.OptionId,
                        principalSchema: "catalog",
                        principalTable: "Options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatalogItemOptions",
                schema: "catalog",
                columns: table => new
                {
                    CatalogItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    OptionId = table.Column<Guid>(type: "uuid", nullable: false),
                    OptionValueId = table.Column<Guid>(type: "uuid", nullable: false),
                    Template = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogItemOptions", x => new { x.CatalogItemId, x.OptionId, x.OptionValueId });
                    table.ForeignKey(
                        name: "FK_CatalogItemOptions_CatalogItems_CatalogItemId",
                        column: x => x.CatalogItemId,
                        principalSchema: "catalog",
                        principalTable: "CatalogItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatalogItemOptions_OptionValues_OptionValueId",
                        column: x => x.OptionValueId,
                        principalSchema: "catalog",
                        principalTable: "OptionValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatalogItemOptions_Options_OptionId",
                        column: x => x.OptionId,
                        principalSchema: "catalog",
                        principalTable: "Options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItemOptions_OptionId",
                schema: "catalog",
                table: "CatalogItemOptions",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItemOptions_OptionValueId",
                schema: "catalog",
                table: "CatalogItemOptions",
                column: "OptionValueId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItems_ParentId",
                schema: "catalog",
                table: "CatalogItems",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_OptionValues_OptionId",
                schema: "catalog",
                table: "OptionValues",
                column: "OptionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatalogItemOptions",
                schema: "catalog");

            migrationBuilder.DropTable(
                name: "CatalogItems",
                schema: "catalog");

            migrationBuilder.DropTable(
                name: "OptionValues",
                schema: "catalog");

            migrationBuilder.DropTable(
                name: "Options",
                schema: "catalog");
        }
    }
}
