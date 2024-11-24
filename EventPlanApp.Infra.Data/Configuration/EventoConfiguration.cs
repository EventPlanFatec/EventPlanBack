using EventPlanApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class EventoConfiguration : IEntityTypeConfiguration<Evento>
{
    public void Configure(EntityTypeBuilder<Evento> builder)
    {
        builder.HasKey(t => t.EventoId);

        builder.Property(t => t.NomeEvento)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(t => t.Descricao)
            .HasMaxLength(1000);

        builder.Property(t => t.DataInicio)
            .IsRequired();

        builder.Property(t => t.DataFim)
            .IsRequired();

        builder.Property(t => t.HorarioInicio)
            .IsRequired();

        builder.Property(t => t.HorarioFim)
            .IsRequired();

        builder.Property(t => t.LotacaoMaxima)
            .IsRequired();

        builder.Property(t => t.Video)
            .HasMaxLength(200);

        builder.Property(t => t.Genero)
            .HasMaxLength(50);

        builder.HasOne(t => t.Organizacao)
            .WithMany(o => o.Eventos)
            .HasForeignKey(t => t.OrganizacaoId)
            .OnDelete(DeleteBehavior.ClientNoAction);

        builder.HasOne(t => t.Endereco)
            .WithMany()
            .HasForeignKey(t => t.EnderecoId)
            .OnDelete(DeleteBehavior.ClientNoAction);

        builder.Property(t => t.NotaMedia)
            .HasColumnType("decimal(3,1)");

        builder.HasMany(t => t.UsuariosFinais)
            .WithMany(u => u.Eventos)
            .UsingEntity(j => j.ToTable("UsuarioFinalEvento"));

        builder.HasOne(e => e.Categoria)
            .WithMany()
            .HasForeignKey(e => e.CategoriaId)
            .OnDelete(DeleteBehavior.ClientNoAction);
    }
}
