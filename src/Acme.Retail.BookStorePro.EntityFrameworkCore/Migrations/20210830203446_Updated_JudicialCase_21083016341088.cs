using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Acme.Retail.BookStorePro.Migrations
{
    public partial class Updated_JudicialCase_21083016341088 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PartyId",
                table: "AppJudicialCases",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AppJudicialCases_PartyId",
                table: "AppJudicialCases",
                column: "PartyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppJudicialCases_AppParties_PartyId",
                table: "AppJudicialCases",
                column: "PartyId",
                principalTable: "AppParties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppJudicialCases_AppParties_PartyId",
                table: "AppJudicialCases");

            migrationBuilder.DropIndex(
                name: "IX_AppJudicialCases_PartyId",
                table: "AppJudicialCases");

            migrationBuilder.DropColumn(
                name: "PartyId",
                table: "AppJudicialCases");
        }
    }
}
