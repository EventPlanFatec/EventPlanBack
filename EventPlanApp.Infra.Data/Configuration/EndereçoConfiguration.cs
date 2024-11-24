﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EventPlanApp.Domain.Entities;

namespace EventPlanApp.Infra.Data.EntityConfiguration
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.TipoLogradouro)
                .IsRequired(false)
                .HasMaxLength(100);

            builder.Property(e => e.Logradouro)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.NumeroCasa)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(e => e.Bairro)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Cidade)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Estado)
                .IsRequired()
                .HasMaxLength(2);

            builder.Property(e => e.CEP)
                .IsRequired()
                .HasMaxLength(10); 
        }
    }
}
