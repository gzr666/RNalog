using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RadniNalog.Data.Migrations
{
    public partial class cascadedelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RadniNalog_Automobil_AutomobilID",
                table: "RadniNalog");

            migrationBuilder.AddForeignKey(
                name: "FK_RadniNalog_Automobil_AutomobilID",
                table: "RadniNalog",
                column: "AutomobilID",
                principalTable: "Automobil",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RadniNalog_Automobil_AutomobilID",
                table: "RadniNalog");

            migrationBuilder.AddForeignKey(
                name: "FK_RadniNalog_Automobil_AutomobilID",
                table: "RadniNalog",
                column: "AutomobilID",
                principalTable: "Automobil",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
