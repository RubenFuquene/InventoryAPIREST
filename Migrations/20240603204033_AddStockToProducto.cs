﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace inventoryApiRest.Migrations
{
    /// <inheritdoc />
    public partial class AddStockToProducto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Productos",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Productos");
        }
    }
}
