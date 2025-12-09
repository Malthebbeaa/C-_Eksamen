using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class DateChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AntalFortagedeUdleveringer",
                table: "Ordinationer",
                newName: "AntalForetagedeUdleveringer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UdleveringsDato",
                table: "ReceptUdleveringer",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OprettelsesDato",
                table: "Recepter",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AntalForetagedeUdleveringer",
                table: "Ordinationer",
                newName: "AntalFortagedeUdleveringer");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "UdleveringsDato",
                table: "ReceptUdleveringer",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "OprettelsesDato",
                table: "Recepter",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
