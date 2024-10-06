using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventPlanApp.Infra.Data.Migrations
{
    public partial class AdicaoDeCamposNecessarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Endereco_EnderecoId",
                table: "Eventos");

            migrationBuilder.DropForeignKey(
                name: "FK_EventoUsuarioFinal_Eventos_EventosEventoId",
                table: "EventoUsuarioFinal");

            migrationBuilder.DropForeignKey(
                name: "FK_EventoUsuarioFinal_UsuariosFinais_UsuariosFinaisId",
                table: "EventoUsuarioFinal");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizacoes_Endereco_EnderecoId",
                table: "Organizacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosFinais_Endereco_EnderecoId",
                table: "UsuariosFinais");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventoUsuarioFinal",
                table: "EventoUsuarioFinal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco");

            migrationBuilder.RenameTable(
                name: "EventoUsuarioFinal",
                newName: "UsuarioFinalEvento");

            migrationBuilder.RenameTable(
                name: "Endereco",
                newName: "Enderecos");

            migrationBuilder.RenameIndex(
                name: "IX_EventoUsuarioFinal_UsuariosFinaisId",
                table: "UsuarioFinalEvento",
                newName: "IX_UsuarioFinalEvento_UsuariosFinaisId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioFinalEvento",
                table: "UsuarioFinalEvento",
                columns: new[] { "EventosEventoId", "UsuariosFinaisId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enderecos",
                table: "Enderecos",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ListasEspera",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioFinalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListasEspera", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListasEspera_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "EventoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListasEspera_UsuariosFinais_UsuarioFinalId",
                        column: x => x.UsuarioFinalId,
                        principalTable: "UsuariosFinais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListasEspera_EventoId",
                table: "ListasEspera",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_ListasEspera_UsuarioFinalId",
                table: "ListasEspera",
                column: "UsuarioFinalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Enderecos_EnderecoId",
                table: "Eventos",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizacoes_Enderecos_EnderecoId",
                table: "Organizacoes",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioFinalEvento_Eventos_EventosEventoId",
                table: "UsuarioFinalEvento",
                column: "EventosEventoId",
                principalTable: "Eventos",
                principalColumn: "EventoId",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Enderecos_EnderecoId",
                table: "Eventos");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizacoes_Enderecos_EnderecoId",
                table: "Organizacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioFinalEvento_Eventos_EventosEventoId",
                table: "UsuarioFinalEvento");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioFinalEvento_UsuariosFinais_UsuariosFinaisId",
                table: "UsuarioFinalEvento");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosFinais_Enderecos_EnderecoId",
                table: "UsuariosFinais");

            migrationBuilder.DropTable(
                name: "ListasEspera");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioFinalEvento",
                table: "UsuarioFinalEvento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enderecos",
                table: "Enderecos");

            migrationBuilder.RenameTable(
                name: "UsuarioFinalEvento",
                newName: "EventoUsuarioFinal");

            migrationBuilder.RenameTable(
                name: "Enderecos",
                newName: "Endereco");

            migrationBuilder.RenameIndex(
                name: "IX_UsuarioFinalEvento_UsuariosFinaisId",
                table: "EventoUsuarioFinal",
                newName: "IX_EventoUsuarioFinal_UsuariosFinaisId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventoUsuarioFinal",
                table: "EventoUsuarioFinal",
                columns: new[] { "EventosEventoId", "UsuariosFinaisId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Endereco_EnderecoId",
                table: "Eventos",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventoUsuarioFinal_Eventos_EventosEventoId",
                table: "EventoUsuarioFinal",
                column: "EventosEventoId",
                principalTable: "Eventos",
                principalColumn: "EventoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventoUsuarioFinal_UsuariosFinais_UsuariosFinaisId",
                table: "EventoUsuarioFinal",
                column: "UsuariosFinaisId",
                principalTable: "UsuariosFinais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Organizacoes_Endereco_EnderecoId",
                table: "Organizacoes",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosFinais_Endereco_EnderecoId",
                table: "UsuariosFinais",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
