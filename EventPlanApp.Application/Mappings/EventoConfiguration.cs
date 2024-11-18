using EventPlanApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class EventoConfiguration : IEntityTypeConfiguration<Evento>
{
    public void Configure(EntityTypeBuilder<Evento> builder)
    {
        builder.HasKey(e => e.EventoId);

        // Relacionamento N:N com Categorias
        builder
            .HasMany(e => e.Categorias)
            .WithMany(c => c.Eventos)
            .UsingEntity<Dictionary<string, object>>(
                "EventoCategorias",
                j => j.HasOne<Categoria>().WithMany().HasForeignKey("CategoriaId"),
                j => j.HasOne<Evento>().WithMany().HasForeignKey("EventoId"));
    }
}

public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.HasKey(c => c.CategoriaId);
        builder.Property(c => c.Nome).IsRequired().HasMaxLength(100);
    }
}
