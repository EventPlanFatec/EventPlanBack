using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EventPlanApp.Domain.Entities;
using System.Text.Json;

namespace EventPlanApp.Infra.Data.EntityConfiguration;

public class EventoConfiguration : IEntityTypeConfiguration<Evento>
{
    public void Configure(EntityTypeBuilder<Evento> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedOnAdd();

        builder.Property(e => e.Nome)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.Descricao)
            .HasMaxLength(500);

        builder.Property(e => e.Data)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(e => e.Local)
            .HasMaxLength(200);

        builder.Property(e => e.ValorMin)
            .HasMaxLength(20);

        builder.HasOne(e => e.Categoria)
            .WithMany()
            .HasForeignKey(e => e.CategoriaId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(e => e.Endereco)
            .WithMany(end => end.Eventos)
            .HasForeignKey(e => e.EnderecoId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(e => e.Ingressos)
            .WithOne(i => i.Evento)
            .HasForeignKey(i => i.EventoId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}