using EventPlanApp.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

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
               .OnDelete(DeleteBehavior.ClientNoAction); // Ajuste para evitar múltiplos Cascade Deletes

        builder.HasOne(t => t.Endereco)
            .WithMany()
            .HasForeignKey(t => t.EnderecoId)
            .OnDelete(DeleteBehavior.ClientNoAction); // Mantém o Cascade no Endereco (ou vice-versa)


        builder.Property(t => t.NotaMedia)
            .HasColumnType("decimal(3,1)")
            .HasPrecision(3, 1);
    }
}
