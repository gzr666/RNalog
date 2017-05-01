using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RadniNalog.Data.Migrations
{
    public partial class cascadedelete2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RadniNalog_MjestoRada_MjestoRadaID",
                table: "RadniNalog");

            migrationBuilder.DropForeignKey(
                name: "FK_RadniNalog_VrstaRada_VrstaRadaID",
                table: "RadniNalog");

            migrationBuilder.AddForeignKey(
                name: "FK_RadniNalog_MjestoRada_MjestoRadaID",
                table: "RadniNalog",
                column: "MjestoRadaID",
                principalTable: "MjestoRada",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RadniNalog_VrstaRada_VrstaRadaID",
                table: "RadniNalog",
                column: "VrstaRadaID",
                principalTable: "VrstaRada",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RadniNalog_MjestoRada_MjestoRadaID",
                table: "RadniNalog");

            migrationBuilder.DropForeignKey(
                name: "FK_RadniNalog_VrstaRada_VrstaRadaID",
                table: "RadniNalog");

            migrationBuilder.AddForeignKey(
                name: "FK_RadniNalog_MjestoRada_MjestoRadaID",
                table: "RadniNalog",
                column: "MjestoRadaID",
                principalTable: "MjestoRada",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RadniNalog_VrstaRada_VrstaRadaID",
                table: "RadniNalog",
                column: "VrstaRadaID",
                principalTable: "VrstaRada",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
