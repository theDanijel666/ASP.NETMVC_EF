using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_EF_CF.Migrations
{
    /// <inheritdoc />
    public partial class Added_Deathdate_To_Author : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DatumSmrti",
                table: "Author",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatumSmrti",
                table: "Author");
        }
    }
}
