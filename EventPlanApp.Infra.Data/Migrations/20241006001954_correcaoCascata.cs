using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventPlanApp.Infra.Data.Migrations
{
    public partial class correcaoCascata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoLogradouro = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NumeroCasa = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizacoes",
                columns: table => new
                {
                    OrganizacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNPJ = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    NotaMedia = table.Column<decimal>(type: "decimal(3,1)", precision: 3, scale: 1, nullable: false),
                    EnderecoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizacoes", x => x.OrganizacaoId);
                    table.ForeignKey(
                        name: "FK_Organizacoes_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuariosFinais",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EnderecoId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DDD = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosFinais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuariosFinais_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    EventoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeEvento = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HorarioInicio = table.Column<TimeSpan>(type: "time", nullable: false),
                    HorarioFim = table.Column<TimeSpan>(type: "time", nullable: false),
                    LotacaoMaxima = table.Column<int>(type: "int", nullable: false),
                    EnderecoId = table.Column<int>(type: "int", nullable: false),
                    Imagens = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Video = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NotaMedia = table.Column<decimal>(type: "decimal(3,1)", precision: 3, scale: 1, nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OrganizacaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.EventoId);
                    table.ForeignKey(
                        name: "FK_Eventos_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Eventos_Organizacoes_OrganizacaoId",
                        column: x => x.OrganizacaoId,
                        principalTable: "Organizacoes",
                        principalColumn: "OrganizacaoId");
                });

            migrationBuilder.CreateTable(
                name: "UsuariosAdm",
                columns: table => new
                {
                    AdmId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NomeUsuario = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    OrganizacaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosAdm", x => x.AdmId);
                    table.ForeignKey(
                        name: "FK_UsuariosAdm_Organizacoes_OrganizacaoId",
                        column: x => x.OrganizacaoId,
                        principalTable: "Organizacoes",
                        principalColumn: "OrganizacaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventoUsuarioFinal",
                columns: table => new
                {
                    EventosEventoId = table.Column<int>(type: "int", nullable: false),
                    UsuariosFinaisId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    Valor = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    QRCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NomeEvento = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioFinalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventoId = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_Ingressos_UsuariosFinais_UsuarioFinalId",
                        column: x => x.UsuarioFinalId,
                        principalTable: "UsuariosFinais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_EnderecoId",
                table: "Eventos",
                column: "EnderecoId");

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
                name: "IX_Ingressos_UsuarioFinalId",
                table: "Ingressos",
                column: "UsuarioFinalId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizacoes_EnderecoId",
                table: "Organizacoes",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosAdm_OrganizacaoId",
                table: "UsuariosAdm",
                column: "OrganizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosFinais_EnderecoId",
                table: "UsuariosFinais",
                column: "EnderecoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventoUsuarioFinal");

            migrationBuilder.DropTable(
                name: "Ingressos");

            migrationBuilder.DropTable(
                name: "UsuariosAdm");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "UsuariosFinais");

            migrationBuilder.DropTable(
                name: "Organizacoes");

            migrationBuilder.DropTable(
                name: "Endereco");
        }
    }
}
