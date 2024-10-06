using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class OrganizacaoConfiguration : IEntityTypeConfiguration<Organizacao>
{
    public void Configure(EntityTypeBuilder<Organizacao> builder)
    {
        builder.HasKey(o => o.OrganizacaoId);

        builder.Property(o => o.CNPJ)
            .IsRequired()
            .HasMaxLength(14); // CNPJ deve ter 14 caracteres

        builder.Property(o => o.NotaMedia)
            .IsRequired()
            .HasPrecision(3, 1); // Nota média com 3 dígitos no total e 1 decimal

        builder.HasMany(o => o.UsuariosAdm)
            .WithOne(u => u.Organizacao)
            .HasForeignKey(u => u.OrganizacaoId);
    }
}
