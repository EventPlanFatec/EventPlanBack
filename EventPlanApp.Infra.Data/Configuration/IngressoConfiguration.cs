using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EventPlanApp.Domain.Entities;

namespace EventPlanApp.Infra.Data.EntityConfiguration
{
    public class IngressoConfiguration : IEntityTypeConfiguration<Ingresso>
    {
        public void Configure(EntityTypeBuilder<Ingresso> builder)
        {
            builder.HasKey(i => i.IngressoId);

            builder.Property(i => i.Valor)
                .IsRequired()
                .HasPrecision(10, 2); 

            builder.Property(i => i.QRCode)
                .IsRequired()
                .HasMaxLength(200); 

            builder.Property(i => i.NomeEvento)
                .IsRequired()
                .HasMaxLength(200); 

            builder.Property(i => i.Data)
                .IsRequired();

            builder.HasOne(i => i.UsuarioFinal)
                .WithMany(u => u.Ingressos)
                .HasForeignKey(i => i.UsuarioFinalId);

            builder.HasOne(i => i.Evento)
                .WithMany(e => e.Ingressos)
                .HasForeignKey(i => i.EventoId);
        }
    }
}
