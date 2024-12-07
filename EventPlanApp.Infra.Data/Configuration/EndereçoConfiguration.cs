using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EventPlanApp.Domain.Entities;
using System.Text.Json;

namespace EventPlanApp.Infra.Data.EntityConfiguration;

public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
{
    public void Configure(EntityTypeBuilder<Endereco> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedOnAdd();

        builder.Property(e => e.Logradouro)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(e => e.NumeroPredial)
            .HasMaxLength(20);

        builder.Property(e => e.Complemento)
            .HasMaxLength(100);

        builder.Property(e => e.Bairro)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.Cidade)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.Estado)
            .HasMaxLength(2)
            .IsRequired();

        builder.Property(e => e.Cep)
            .HasMaxLength(8)
            .IsRequired();

        builder.HasMany(e => e.Eventos)
            .WithOne(ev => ev.Endereco)
            .HasForeignKey(ev => ev.EnderecoId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}