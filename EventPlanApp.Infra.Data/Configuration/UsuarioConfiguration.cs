using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EventPlanApp.Domain.Entities;
using System.Text.Json;

namespace EventPlanApp.Infra.Data.EntityConfiguration;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).ValueGeneratedOnAdd();

        builder.Property(u => u.Nome)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(u => u.Sobrenome)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(u => u.Email)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(u => u.Cpf)
            .HasMaxLength(11)
            .IsRequired();

        builder.Property(u => u.DataNascimento)
            .HasMaxLength(10)
            .IsRequired();

        builder.HasIndex(u => u.Email).IsUnique();
        builder.HasIndex(u => u.Cpf).IsUnique();

        // Relacionamentos
        builder.HasOne(u => u.Role)
            .WithMany(r => r.Usuarios)  
            .HasForeignKey(u => u.RoleId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(u => u.Endereco)
            .WithMany(e => e.Usuarios) 
            .HasForeignKey(u => u.EnderecoId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(u => u.Ingressos)
            .WithOne(i => i.Usuario)
            .HasForeignKey(i => i.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(u => u.Eventos)
            .WithMany(e => e.Usuarios)
            .UsingEntity(j => j.ToTable("UsuarioEvento"));
    }
}