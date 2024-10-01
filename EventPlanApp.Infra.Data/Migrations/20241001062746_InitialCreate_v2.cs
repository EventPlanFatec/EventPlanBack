using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventPlanApp.Infra.Data.Migrations
{
    public partial class InitialCreate_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingressos_Eventos_EventoId1",
                table: "Ingressos");

            migrationBuilder.DropIndex(
                name: "IX_Ingressos_EventoId1",
                table: "Ingressos");

            migrationBuilder.DropColumn(
                name: "EventoId1",
                table: "Ingressos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventoId1",
                table: "Ingressos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingressos_EventoId1",
                table: "Ingressos",
                column: "EventoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingressos_Eventos_EventoId1",
                table: "Ingressos",
                column: "EventoId1",
                principalTable: "Eventos",
                principalColumn: "EventoId");
        }
    }
}
