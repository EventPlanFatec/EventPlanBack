﻿// <auto-generated />
using System;
using EventPlanApp.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EventPlanApp.Infra.Data.Migrations
{
    [DbContext(typeof(EventPlanContext))]
    [Migration("20241125105108_estatisticas")]
    partial class estatisticas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EventoTag", b =>
                {
                    b.Property<int>("EventosEventoId")
                        .HasColumnType("int");

                    b.Property<int>("TagsTagId")
                        .HasColumnType("int");

                    b.HasKey("EventosEventoId", "TagsTagId");

                    b.HasIndex("TagsTagId");

                    b.ToTable("EventoTag");
                });

            modelBuilder.Entity("EventoUsuarioFinal", b =>
                {
                    b.Property<int>("EventosEventoId")
                        .HasColumnType("int");

                    b.Property<Guid>("UsuariosFinaisId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("EventosEventoId", "UsuariosFinaisId");

                    b.HasIndex("UsuariosFinaisId");

                    b.ToTable("UsuarioFinalEvento", (string)null);
                });

            modelBuilder.Entity("EventPlanApp.Domain.Entities.AuditLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ActionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConteudoAlteradoAntes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConteudoAlteradoDepois")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EntityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IpEndereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsSuspicious")
                        .HasColumnType("bit");

                    b.Property<string>("TipoAcao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioAdmId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AuditLogs");
                });

            modelBuilder.Entity("EventPlanApp.Domain.Entities.AvaliacaoEvento", b =>
                {
                    b.Property<int>("AvaliacaoEventoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AvaliacaoEventoId"), 1L, 1);

                    b.Property<decimal>("Avaliacao")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("EventoId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioFinalId")
                        .HasColumnType("int");

                    b.HasKey("AvaliacaoEventoId");

                    b.ToTable("Avaliacoes");
                });

            modelBuilder.Entity("EventPlanApp.Domain.Entities.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoriaId"), 1L, 1);

                    b.Property<int?>("EventoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoriaId");

                    b.HasIndex("EventoId");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("EventPlanApp.Domain.Entities.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("NumeroCasa")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("TipoLogradouro")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("EventPlanApp.Domain.Entities.Evento", b =>
                {
                    b.Property<int>("EventoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventoId"), 1L, 1);

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<TimeSpan>("HorarioFim")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("HorarioInicio")
                        .HasColumnType("time");

                    b.Property<string>("Imagens")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPrivate")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTaxaPercentual")
                        .HasColumnType("bit");

                    b.Property<string>("ListaConvidadosSerializada")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LotacaoMaxima")
                        .HasColumnType("int");

                    b.Property<string>("NomeEvento")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("NotaMedia")
                        .HasColumnType("decimal(3,1)");

                    b.Property<int>("OrganizacaoId")
                        .HasColumnType("int");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Privacidade")
                        .HasColumnType("bit");

                    b.Property<bool>("Publicado")
                        .HasColumnType("bit");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("TaxaServicoValor")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalCancelamentos")
                        .HasColumnType("int");

                    b.Property<int>("TotalInscritos")
                        .HasColumnType("int");

                    b.Property<string>("Video")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("EventoId");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("EnderecoId");

                    b.HasIndex("OrganizacaoId");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("EventPlanApp.Domain.Entities.Favorite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("EventoId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("UsuarioFinalId")
                        .HasColumnType("int");

                    b.Property<Guid>("UsuarioFinalId1")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EventoId");

                    b.HasIndex("UsuarioFinalId1");

                    b.ToTable("Favorites");
                });

            modelBuilder.Entity("EventPlanApp.Domain.Entities.Ingresso", b =>
                {
                    b.Property<int>("IngressoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IngressoId"), 1L, 1);

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("EventoId")
                        .HasColumnType("int");

                    b.Property<string>("NomeEvento")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("QRCode")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<Guid>("UsuarioFinalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Valor")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("ValorFinal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Vip")
                        .HasColumnType("bit");

                    b.HasKey("IngressoId");

                    b.HasIndex("EventoId");

                    b.HasIndex("UsuarioFinalId");

                    b.ToTable("Ingressos");
                });

            modelBuilder.Entity("EventPlanApp.Domain.Entities.Inscricao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DataInscricao")
                        .HasColumnType("datetime2");

                    b.Property<int>("EventoId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioFinalId")
                        .HasColumnType("int");

                    b.Property<Guid>("UsuarioFinalId1")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EventoId");

                    b.HasIndex("UsuarioFinalId1");

                    b.ToTable("Inscricoes");
                });

            modelBuilder.Entity("EventPlanApp.Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Permissions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("EventPlanApp.Domain.Entities.TaxaServicoConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("EventoId")
                        .HasColumnType("int");

                    b.Property<decimal?>("TaxaFixa")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TaxaPercentual")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("EventoId");

                    b.ToTable("TaxaServicoConfig");
                });

            modelBuilder.Entity("EventPlanApp.Domain.Entities.UserPreferences", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EventType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PriceRange")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserPreferences");
                });

            modelBuilder.Entity("EventPlanApp.Domain.Entities.UsuarioAdm", b =>
                {
                    b.Property<int>("AdmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdmId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("NomeUsuario")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("OrganizacaoId")
                        .HasColumnType("int");

                    b.Property<Guid?>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("AdmId");

                    b.HasIndex("OrganizacaoId");

                    b.HasIndex("RoleId");

                    b.ToTable("UsuariosAdm");
                });

            modelBuilder.Entity("EventPlanApp.Domain.Entities.UsuarioFinal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DDD")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Preferencias")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tema")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.HasIndex("RoleId");

                    b.ToTable("UsuarioFinal");
                });

            modelBuilder.Entity("EventPlanApp.Domain.Entities.Volunteer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Volunteers");
                });

            modelBuilder.Entity("EventPreference", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("EventType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("MaxPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MinPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<Guid>("UsuarioFinalId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioFinalId");

                    b.ToTable("EventPreferences");
                });

            modelBuilder.Entity("ListaEspera", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("EventoId")
                        .HasColumnType("int");

                    b.Property<Guid>("UsuarioFinalId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EventoId");

                    b.HasIndex("UsuarioFinalId");

                    b.ToTable("ListasEspera");
                });

            modelBuilder.Entity("Organizacao", b =>
                {
                    b.Property<int>("OrganizacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrganizacaoId"), 1L, 1);

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<decimal>("NotaMedia")
                        .HasPrecision(3, 1)
                        .HasColumnType("decimal(3,1)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrganizacaoId");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Organizacoes");
                });

            modelBuilder.Entity("Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TagId"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TagId");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("EventoTag", b =>
                {
                    b.HasOne("EventPlanApp.Domain.Entities.Evento", null)
                        .WithMany()
                        .HasForeignKey("EventosEventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsTagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EventoUsuarioFinal", b =>
                {
                    b.HasOne("EventPlanApp.Domain.Entities.Evento", null)
                        .WithMany()
                        .HasForeignKey("EventosEventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventPlanApp.Domain.Entities.UsuarioFinal", null)
                        .WithMany()
                        .HasForeignKey("UsuariosFinaisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EventPlanApp.Domain.Entities.Categoria", b =>
                {
                    b.HasOne("EventPlanApp.Domain.Entities.Evento", null)
                        .WithMany("Categorias")
                        .HasForeignKey("EventoId");
                });

            modelBuilder.Entity("EventPlanApp.Domain.Entities.Evento", b =>
                {
                    b.HasOne("EventPlanApp.Domain.Entities.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("EventPlanApp.Domain.Entities.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("Organizacao", "Organizacao")
                        .WithMany("Eventos")
                        .HasForeignKey("OrganizacaoId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Endereco");

                    b.Navigation("Organizacao");
                });

            modelBuilder.Entity("EventPlanApp.Domain.Entities.Favorite", b =>
                {
                    b.HasOne("EventPlanApp.Domain.Entities.Evento", "Evento")
                        .WithMany()
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventPlanApp.Domain.Entities.UsuarioFinal", "UsuarioFinal")
                        .WithMany()
                        .HasForeignKey("UsuarioFinalId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evento");

                    b.Navigation("UsuarioFinal");
                });

            modelBuilder.Entity("EventPlanApp.Domain.Entities.Ingresso", b =>
                {
                    b.HasOne("EventPlanApp.Domain.Entities.Evento", "Evento")
                        .WithMany("Ingressos")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventPlanApp.Domain.Entities.UsuarioFinal", "UsuarioFinal")
                        .WithMany("Ingressos")
                        .HasForeignKey("UsuarioFinalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evento");

                    b.Navigation("UsuarioFinal");
                });

            modelBuilder.Entity("EventPlanApp.Domain.Entities.Inscricao", b =>
                {
                    b.HasOne("EventPlanApp.Domain.Entities.Evento", "Evento")
                        .WithMany()
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventPlanApp.Domain.Entities.UsuarioFinal", "UsuarioFinal")
                        .WithMany()
                        .HasForeignKey("UsuarioFinalId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evento");

                    b.Navigation("UsuarioFinal");
                });

            modelBuilder.Entity("EventPlanApp.Domain.Entities.TaxaServicoConfig", b =>
                {
                    b.HasOne("EventPlanApp.Domain.Entities.Evento", "Evento")
                        .WithMany()
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evento");
                });

            modelBuilder.Entity("EventPlanApp.Domain.Entities.UsuarioAdm", b =>
                {
                    b.HasOne("Organizacao", "Organizacao")
                        .WithMany("UsuariosAdm")
                        .HasForeignKey("OrganizacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventPlanApp.Domain.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.Navigation("Organizacao");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("EventPlanApp.Domain.Entities.UsuarioFinal", b =>
                {
                    b.HasOne("EventPlanApp.Domain.Entities.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventPlanApp.Domain.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.Navigation("Endereco");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("EventPreference", b =>
                {
                    b.HasOne("EventPlanApp.Domain.Entities.UsuarioFinal", "UsuarioFinal")
                        .WithMany("EventPreferences")
                        .HasForeignKey("UsuarioFinalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UsuarioFinal");
                });

            modelBuilder.Entity("ListaEspera", b =>
                {
                    b.HasOne("EventPlanApp.Domain.Entities.Evento", "Evento")
                        .WithMany("ListasEspera")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventPlanApp.Domain.Entities.UsuarioFinal", "UsuarioFinal")
                        .WithMany("ListasEspera")
                        .HasForeignKey("UsuarioFinalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evento");

                    b.Navigation("UsuarioFinal");
                });

            modelBuilder.Entity("Organizacao", b =>
                {
                    b.HasOne("EventPlanApp.Domain.Entities.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("EventPlanApp.Domain.Entities.Evento", b =>
                {
                    b.Navigation("Categorias");

                    b.Navigation("Ingressos");

                    b.Navigation("ListasEspera");
                });

            modelBuilder.Entity("EventPlanApp.Domain.Entities.UsuarioFinal", b =>
                {
                    b.Navigation("EventPreferences");

                    b.Navigation("Ingressos");

                    b.Navigation("ListasEspera");
                });

            modelBuilder.Entity("Organizacao", b =>
                {
                    b.Navigation("Eventos");

                    b.Navigation("UsuariosAdm");
                });
#pragma warning restore 612, 618
        }
    }
}
