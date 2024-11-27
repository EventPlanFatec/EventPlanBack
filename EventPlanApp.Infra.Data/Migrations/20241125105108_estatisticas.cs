using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventPlanApp.Infra.Data.Migrations
{
    public partial class estatisticas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventPreferences_UsuariosFinais_UsuarioFinalId",
                table: "EventPreferences");

            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_UsuariosFinais_UsuarioFinalId1",
                table: "Favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingressos_UsuariosFinais_UsuarioFinalId",
                table: "Ingressos");

            migrationBuilder.DropForeignKey(
                name: "FK_Inscricoes_UsuariosFinais_UsuarioFinalId1",
                table: "Inscricoes");

            migrationBuilder.DropForeignKey(
                name: "FK_ListasEspera_UsuariosFinais_UsuarioFinalId",
                table: "ListasEspera");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioFinalEvento_UsuariosFinais_UsuariosFinaisId",
                table: "UsuarioFinalEvento");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosFinais_Enderecos_EnderecoId",
                table: "UsuariosFinais");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosFinais_Roles_RoleId",
                table: "UsuariosFinais");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuariosFinais",
                table: "UsuariosFinais");

            migrationBuilder.RenameTable(
                name: "UsuariosFinais",
                newName: "UsuarioFinal");

            migrationBuilder.RenameIndex(
                name: "IX_UsuariosFinais_RoleId",
                table: "UsuarioFinal",
                newName: "IX_UsuarioFinal_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_UsuariosFinais_EnderecoId",
                table: "UsuarioFinal",
                newName: "IX_UsuarioFinal_EnderecoId");

            migrationBuilder.AddColumn<decimal>(
                name: "ValorFinal",
                table: "Ingressos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsTaxaPercentual",
                table: "Eventos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxaServicoValor",
                table: "Eventos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "TotalCancelamentos",
                table: "Eventos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalInscritos",
                table: "Eventos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "UsuarioFinal",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioFinal",
                table: "UsuarioFinal",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioAdmId = table.Column<int>(type: "int", nullable: false),
                    TipoAcao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConteudoAlteradoAntes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConteudoAlteradoDepois = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IpEndereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSuspicious = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxaServicoConfig",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventoId = table.Column<int>(type: "int", nullable: false),
                    TaxaFixa = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TaxaPercentual = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxaServicoConfig", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxaServicoConfig_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "EventoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaxaServicoConfig_EventoId",
                table: "TaxaServicoConfig",
                column: "EventoId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventPreferences_UsuarioFinal_UsuarioFinalId",
                table: "EventPreferences",
                column: "UsuarioFinalId",
                principalTable: "UsuarioFinal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_UsuarioFinal_UsuarioFinalId1",
                table: "Favorites",
                column: "UsuarioFinalId1",
                principalTable: "UsuarioFinal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingressos_UsuarioFinal_UsuarioFinalId",
                table: "Ingressos",
                column: "UsuarioFinalId",
                principalTable: "UsuarioFinal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inscricoes_UsuarioFinal_UsuarioFinalId1",
                table: "Inscricoes",
                column: "UsuarioFinalId1",
                principalTable: "UsuarioFinal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ListasEspera_UsuarioFinal_UsuarioFinalId",
                table: "ListasEspera",
                column: "UsuarioFinalId",
                principalTable: "UsuarioFinal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioFinal_Enderecos_EnderecoId",
                table: "UsuarioFinal",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioFinal_Roles_RoleId",
                table: "UsuarioFinal",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioFinalEvento_UsuarioFinal_UsuariosFinaisId",
                table: "UsuarioFinalEvento",
                column: "UsuariosFinaisId",
                principalTable: "UsuarioFinal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventPreferences_UsuarioFinal_UsuarioFinalId",
                table: "EventPreferences");

            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_UsuarioFinal_UsuarioFinalId1",
                table: "Favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingressos_UsuarioFinal_UsuarioFinalId",
                table: "Ingressos");

            migrationBuilder.DropForeignKey(
                name: "FK_Inscricoes_UsuarioFinal_UsuarioFinalId1",
                table: "Inscricoes");

            migrationBuilder.DropForeignKey(
                name: "FK_ListasEspera_UsuarioFinal_UsuarioFinalId",
                table: "ListasEspera");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioFinal_Enderecos_EnderecoId",
                table: "UsuarioFinal");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioFinal_Roles_RoleId",
                table: "UsuarioFinal");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioFinalEvento_UsuarioFinal_UsuariosFinaisId",
                table: "UsuarioFinalEvento");

            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "TaxaServicoConfig");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioFinal",
                table: "UsuarioFinal");

            migrationBuilder.DropColumn(
                name: "ValorFinal",
                table: "Ingressos");

            migrationBuilder.DropColumn(
                name: "IsTaxaPercentual",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "TaxaServicoValor",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "TotalCancelamentos",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "TotalInscritos",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "UsuarioFinal");

            migrationBuilder.RenameTable(
                name: "UsuarioFinal",
                newName: "UsuariosFinais");

            migrationBuilder.RenameIndex(
                name: "IX_UsuarioFinal_RoleId",
                table: "UsuariosFinais",
                newName: "IX_UsuariosFinais_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_UsuarioFinal_EnderecoId",
                table: "UsuariosFinais",
                newName: "IX_UsuariosFinais_EnderecoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuariosFinais",
                table: "UsuariosFinais",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventPreferences_UsuariosFinais_UsuarioFinalId",
                table: "EventPreferences",
                column: "UsuarioFinalId",
                principalTable: "UsuariosFinais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_UsuariosFinais_UsuarioFinalId1",
                table: "Favorites",
                column: "UsuarioFinalId1",
                principalTable: "UsuariosFinais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingressos_UsuariosFinais_UsuarioFinalId",
                table: "Ingressos",
                column: "UsuarioFinalId",
                principalTable: "UsuariosFinais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inscricoes_UsuariosFinais_UsuarioFinalId1",
                table: "Inscricoes",
                column: "UsuarioFinalId1",
                principalTable: "UsuariosFinais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ListasEspera_UsuariosFinais_UsuarioFinalId",
                table: "ListasEspera",
                column: "UsuarioFinalId",
                principalTable: "UsuariosFinais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioFinalEvento_UsuariosFinais_UsuariosFinaisId",
                table: "UsuarioFinalEvento",
                column: "UsuariosFinaisId",
                principalTable: "UsuariosFinais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosFinais_Enderecos_EnderecoId",
                table: "UsuariosFinais",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosFinais_Roles_RoleId",
                table: "UsuariosFinais",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id");
        }
    }
}
