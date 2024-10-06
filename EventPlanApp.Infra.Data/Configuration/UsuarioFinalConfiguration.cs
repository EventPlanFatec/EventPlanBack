using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EventPlanApp.Domain.Entities;

namespace EventPlanApp.Infra.Data.EntityConfiguration
{
    public class UsuarioFinalConfiguration : IEntityTypeConfiguration<UsuarioFinal>
    {
        public void Configure(EntityTypeBuilder<UsuarioFinal> builder)
        {
            builder.HasKey(u => u.Id); // Define a chave primária

            builder.Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(100); // Define o comprimento máximo

            builder.Property(u => u.Sobrenome)
                .IsRequired()
                .HasMaxLength(100); // Define o comprimento máximo

            builder.Property(u => u.Email)
                .IsRequired();

            builder.Property(u => u.Telefone)
                .IsRequired();

            builder.Property(u => u.DDD)
                .IsRequired()
                .HasMaxLength(2); // Define o comprimento máximo

            builder.Property(u => u.DataNascimento)
                .IsRequired(); // Data de nascimento é obrigatória

            // Configura a chave estrangeira para o Endereco
            builder.HasOne(u => u.Endereco)
                .WithMany() // Aqui pode ser definido se um Endereco pode ter muitos UsuariosFinais
                .HasForeignKey(u => u.EnderecoId);

            builder.HasMany(u => u.Ingressos) // Configura o relacionamento com Ingressos
                .WithOne(i => i.UsuarioFinal) // Cada ingresso tem um usuário final
                .HasForeignKey(i => i.UsuarioFinalId);

            // Configura o relacionamento com Eventos
            builder.HasMany(u => u.Eventos) // Configura o relacionamento com Eventos
                .WithMany(e => e.UsuariosFinais); // Especifica a coleção na classe Evento
        }
    }
}
