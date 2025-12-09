using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apoteker",
                columns: table => new
                {
                    ApotekId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apoteker", x => x.ApotekId);
                });

            migrationBuilder.CreateTable(
                name: "Lægehuse",
                columns: table => new
                {
                    Ydernummer = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lægehuse", x => x.Ydernummer);
                });

            migrationBuilder.CreateTable(
                name: "Recepter",
                columns: table => new
                {
                    ReceptId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientCpr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OprettelsesDato = table.Column<DateOnly>(type: "date", nullable: false),
                    Lukket = table.Column<bool>(type: "bit", nullable: false),
                    LægehusYdernummer = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recepter", x => x.ReceptId);
                    table.ForeignKey(
                        name: "FK_Recepter_Lægehuse_LægehusYdernummer",
                        column: x => x.LægehusYdernummer,
                        principalTable: "Lægehuse",
                        principalColumn: "Ydernummer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ordinationer",
                columns: table => new
                {
                    OrdinationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Lægemiddel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AntalUdleveringer = table.Column<int>(type: "int", nullable: false),
                    AntalFortagedeUdleveringer = table.Column<int>(type: "int", nullable: false),
                    ReceptId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordinationer", x => x.OrdinationId);
                    table.ForeignKey(
                        name: "FK_Ordinationer_Recepter_ReceptId",
                        column: x => x.ReceptId,
                        principalTable: "Recepter",
                        principalColumn: "ReceptId");
                });

            migrationBuilder.CreateTable(
                name: "ReceptUdleveringer",
                columns: table => new
                {
                    ReceptUdleveringId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApotekNummer = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApotekId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceptId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UdleveringsDato = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceptUdleveringer", x => x.ReceptUdleveringId);
                    table.ForeignKey(
                        name: "FK_ReceptUdleveringer_Apoteker_ApotekId",
                        column: x => x.ApotekId,
                        principalTable: "Apoteker",
                        principalColumn: "ApotekId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceptUdleveringer_Recepter_ReceptId",
                        column: x => x.ReceptId,
                        principalTable: "Recepter",
                        principalColumn: "ReceptId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ordinationer_ReceptId",
                table: "Ordinationer",
                column: "ReceptId");

            migrationBuilder.CreateIndex(
                name: "IX_Recepter_LægehusYdernummer",
                table: "Recepter",
                column: "LægehusYdernummer");

            migrationBuilder.CreateIndex(
                name: "IX_ReceptUdleveringer_ApotekId",
                table: "ReceptUdleveringer",
                column: "ApotekId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceptUdleveringer_ReceptId",
                table: "ReceptUdleveringer",
                column: "ReceptId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ordinationer");

            migrationBuilder.DropTable(
                name: "ReceptUdleveringer");

            migrationBuilder.DropTable(
                name: "Apoteker");

            migrationBuilder.DropTable(
                name: "Recepter");

            migrationBuilder.DropTable(
                name: "Lægehuse");
        }
    }
}
