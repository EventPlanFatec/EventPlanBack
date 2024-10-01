using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventPlanApp.Infra.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organizacoes",
                columns: table => new
                {
                    OrganizacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNPJ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoLogradouro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    NumeroPredio = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotaMedia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UsuarioAdmId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizacoes", x => x.OrganizacaoId);
                });

            migrationBuilder.CreateTable(
                name: "UsuariosAdm",
                columns: table => new
                {
                    AdmId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NomeUsuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosAdm", x => x.AdmId);
                });

            migrationBuilder.CreateTable(
                name: "UsuariosFinais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TipoLogradouro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    NumeroCasa = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DDD = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Preferencias01 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Preferencias02 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Preferencias03 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosFinais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    EventoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeEvento = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HorarioInicio = table.Column<TimeSpan>(type: "time", nullable: false),
                    HorarioFim = table.Column<TimeSpan>(type: "time", nullable: false),
                    LotacaoMaxima = table.Column<int>(type: "int", nullable: false),
                    TipoLogradouro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    NumeroCasa = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Imagem01 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagem02 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagem03 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Video = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotaMedia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OrganizacaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.EventoId);
                    table.ForeignKey(
                        name: "FK_Eventos_Organizacoes_OrganizacaoId",
                        column: x => x.OrganizacaoId,
                        principalTable: "Organizacoes",
                        principalColumn: "OrganizacaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganizacaoUsuarioAdm",
                columns: table => new
                {
                    OrganizacoesOrganizacaoId = table.Column<int>(type: "int", nullable: false),
                    UsuariosAdmAdmId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizacaoUsuarioAdm", x => new { x.OrganizacoesOrganizacaoId, x.UsuariosAdmAdmId });
                    table.ForeignKey(
                        name: "FK_OrganizacaoUsuarioAdm_Organizacoes_OrganizacoesOrganizacaoId",
                        column: x => x.OrganizacoesOrganizacaoId,
                        principalTable: "Organizacoes",
                        principalColumn: "OrganizacaoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizacaoUsuarioAdm_UsuariosAdm_UsuariosAdmAdmId",
                        column: x => x.UsuariosAdmAdmId,
                        principalTable: "UsuariosAdm",
                        principalColumn: "AdmId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventoUsuarioFinal",
                columns: table => new
                {
                    EventosEventoId = table.Column<int>(type: "int", nullable: false),
                    UsuariosFinaisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventoUsuarioFinal", x => new { x.EventosEventoId, x.UsuariosFinaisId });
                    table.ForeignKey(
                        name: "FK_EventoUsuarioFinal_Eventos_EventosEventoId",
                        column: x => x.EventosEventoId,
                        principalTable: "Eventos",
                        principalColumn: "EventoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventoUsuarioFinal_UsuariosFinais_UsuariosFinaisId",
                        column: x => x.UsuariosFinaisId,
                        principalTable: "UsuariosFinais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingressos",
                columns: table => new
                {
                    IngressoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QRCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NomeEvento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VIP = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioFinalId = table.Column<int>(type: "int", nullable: false),
                    EventoId = table.Column<int>(type: "int", nullable: false),
                    EventoId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingressos", x => x.IngressoId);
                    table.ForeignKey(
                        name: "FK_Ingressos_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "EventoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ingressos_Eventos_EventoId1",
                        column: x => x.EventoId1,
                        principalTable: "Eventos",
                        principalColumn: "EventoId");
                    table.ForeignKey(
                        name: "FK_Ingressos_UsuariosFinais_UsuarioFinalId",
                        column: x => x.UsuarioFinalId,
                        principalTable: "UsuariosFinais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_OrganizacaoId",
                table: "Eventos",
                column: "OrganizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_EventoUsuarioFinal_UsuariosFinaisId",
                table: "EventoUsuarioFinal",
                column: "UsuariosFinaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingressos_EventoId",
                table: "Ingressos",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingressos_EventoId1",
                table: "Ingressos",
                column: "EventoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Ingressos_UsuarioFinalId",
                table: "Ingressos",
                column: "UsuarioFinalId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizacaoUsuarioAdm_UsuariosAdmAdmId",
                table: "OrganizacaoUsuarioAdm",
                column: "UsuariosAdmAdmId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventoUsuarioFinal");

            migrationBuilder.DropTable(
                name: "Ingressos");

            migrationBuilder.DropTable(
                name: "OrganizacaoUsuarioAdm");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "UsuariosFinais");

            migrationBuilder.DropTable(
                name: "UsuariosAdm");

            migrationBuilder.DropTable(
                name: "Organizacoes");
        }
    }
}
