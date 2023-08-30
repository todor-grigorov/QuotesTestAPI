﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuotesTestAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddTypeProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Quotes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Quotes");
        }
    }
}
