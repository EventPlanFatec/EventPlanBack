using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EventPlanApp.Domain.Entities;
using System.Text.Json;

namespace EventPlanApp.Infra.Data.Configuration;

public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();

        builder.Property(c => c.Nome)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(c => c.Descricao)
            .HasMaxLength(200);

        builder.HasMany<Evento>()
            .WithOne(e => e.Categoria)
            .HasForeignKey(e => e.CategoriaId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
