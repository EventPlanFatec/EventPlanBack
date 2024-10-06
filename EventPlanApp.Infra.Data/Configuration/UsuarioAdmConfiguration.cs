using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EventPlanApp.Domain.Entities;

namespace EventPlanApp.Infra.Data.EntityConfiguration
{
    public class UsuarioAdmConfiguration : IEntityTypeConfiguration<UsuarioAdm>
    {
        public void Configure(EntityTypeBuilder<UsuarioAdm> builder)
        {
            builder.HasKey(u => u.AdmId); // Define a chave primária

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(200); // Define o comprimento máximo

            builder.Property(u => u.Senha)
                .IsRequired()
                .HasMaxLength(100); // Define o comprimento máximo

            builder.Property(u => u.NomeUsuario)
                .IsRequired()
                .HasMaxLength(100); // Define o comprimento máximo

            builder.Property(u => u.Telefone)
                .IsRequired()
                .HasMaxLength(15); // Define o comprimento máximo

            builder.HasOne(u => u.Organizacao) // Configura o relacionamento
                .WithMany(o => o.UsuariosAdm) // Com muitos UsuariosAdm
                .HasForeignKey(u => u.OrganizacaoId);
        }
    }
}
