using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RadniNalog.Data.Migrations
{
    public partial class SomeChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Ime",
                table: "Zaposlenik",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Naziv",
                table: "VrstaRada",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Ime",
                table: "MjestoRada",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Registracija",
                table: "Automobil",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Ime",
                table: "Zaposlenik",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Naziv",
                table: "VrstaRada",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ime",
                table: "MjestoRada",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Registracija",
                table: "Automobil",
                nullable: true);
        }
    }
}
