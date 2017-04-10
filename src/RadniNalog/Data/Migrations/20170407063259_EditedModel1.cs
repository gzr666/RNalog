using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RadniNalog.Data.Migrations
{
    public partial class EditedModel1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Automobil",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Registracija = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Automobil", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MjestoRada",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MjestoRada", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VrstaRada",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrstaRada", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Zaposlenik",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zaposlenik", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RadniNalog",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AutomobilID = table.Column<int>(nullable: false),
                    Datum = table.Column<DateTime>(nullable: false),
                    Izvrsitelj2 = table.Column<string>(nullable: true),
                    Izvrsitelj3 = table.Column<string>(nullable: true),
                    Materijal = table.Column<string>(nullable: true),
                    MjestoRadaID = table.Column<int>(nullable: false),
                    OpisRadova = table.Column<string>(nullable: true),
                    PutniNalog = table.Column<int>(nullable: false),
                    Rukovoditelj = table.Column<string>(nullable: true),
                    VrstaRadaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RadniNalog", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RadniNalog_Automobil_AutomobilID",
                        column: x => x.AutomobilID,
                        principalTable: "Automobil",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RadniNalog_MjestoRada_MjestoRadaID",
                        column: x => x.MjestoRadaID,
                        principalTable: "MjestoRada",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RadniNalog_VrstaRada_VrstaRadaID",
                        column: x => x.VrstaRadaID,
                        principalTable: "VrstaRada",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RadniNalog_AutomobilID",
                table: "RadniNalog",
                column: "AutomobilID");

            migrationBuilder.CreateIndex(
                name: "IX_RadniNalog_MjestoRadaID",
                table: "RadniNalog",
                column: "MjestoRadaID");

            migrationBuilder.CreateIndex(
                name: "IX_RadniNalog_VrstaRadaID",
                table: "RadniNalog",
                column: "VrstaRadaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RadniNalog");

            migrationBuilder.DropTable(
                name: "Zaposlenik");

            migrationBuilder.DropTable(
                name: "Automobil");

            migrationBuilder.DropTable(
                name: "MjestoRada");

            migrationBuilder.DropTable(
                name: "VrstaRada");
        }
    }
}
