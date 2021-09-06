using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Acme.Retail.BookStorePro.Migrations
{
    public partial class Updated_JudicialCase_21083016463793 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "JudicialCaseAttributesId",
                table: "AppJudicialCases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppJudicialCases_JudicialCaseAttributesId",
                table: "AppJudicialCases",
                column: "JudicialCaseAttributesId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppJudicialCases_AppJudicialCaseAttributess_JudicialCaseAttributesId",
                table: "AppJudicialCases",
                column: "JudicialCaseAttributesId",
                principalTable: "AppJudicialCaseAttributess",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppJudicialCases_AppJudicialCaseAttributess_JudicialCaseAttributesId",
                table: "AppJudicialCases");

            migrationBuilder.DropIndex(
                name: "IX_AppJudicialCases_JudicialCaseAttributesId",
                table: "AppJudicialCases");

            migrationBuilder.DropColumn(
                name: "JudicialCaseAttributesId",
                table: "AppJudicialCases");
        }
    }
}
