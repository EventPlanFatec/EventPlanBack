using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EventPlanApp.Domain.Entities;
using System.Text.Json;

namespace EventPlanApp.Infra.Data.EntityConfiguration;

public class IngressoConfiguration : IEntityTypeConfiguration<Ingresso>
{
    public void Configure(EntityTypeBuilder<Ingresso> builder)
    {
        builder.HasKey(i => i.Id);
        builder.Property(i => i.Id).ValueGeneratedOnAdd();

        builder.Property(i => i.TipoIngresso)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(i => i.Valor)
            .HasPrecision(10, 2)
            .IsRequired();

        builder.Property(i => i.DataCompra)
            .IsRequired();

        builder.HasOne(i => i.Evento)
            .WithMany(e => e.Ingressos)
            .HasForeignKey(i => i.EventoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(i => i.Usuario)
            .WithMany(u => u.Ingressos)
            .HasForeignKey(i => i.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}