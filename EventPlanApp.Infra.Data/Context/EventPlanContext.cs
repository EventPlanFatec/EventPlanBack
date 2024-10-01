using EventPlanApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class EventPlanContext : DbContext
{
    public EventPlanContext(DbContextOptions<EventPlanContext> options)
        : base(options)
    {
    }

    public DbSet<UsuarioFinal> UsuariosFinais { get; set; }
    public DbSet<UsuarioAdm> UsuariosAdm { get; set; }
    public DbSet<Organizacao> Organizacoes { get; set; }
    public DbSet<Evento> Eventos { get; set; }
    public DbSet<Ingresso> Ingressos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Mapeamento UsuarioFinal
        modelBuilder.Entity<UsuarioFinal>()
            .HasKey(u => u.Id);

        modelBuilder.Entity<UsuarioFinal>()
            .HasMany(u => u.Ingressos)
            .WithOne(i => i.UsuarioFinal)
            .HasForeignKey(i => i.UsuarioFinalId)
            .OnDelete(DeleteBehavior.Cascade); // Excluir ingressos se o usuário final for excluído

        // Mapeamento UsuarioAdm
        modelBuilder.Entity<UsuarioAdm>()
            .HasKey(a => a.AdmId);

        modelBuilder.Entity<UsuarioAdm>()
            .HasMany(a => a.Organizacoes)
            .WithMany(o => o.UsuariosAdm);

        // Mapeamento Organizacao
        modelBuilder.Entity<Organizacao>()
            .HasKey(o => o.OrganizacaoId);

        modelBuilder.Entity<Organizacao>()
            .HasMany(o => o.Eventos)
            .WithOne(e => e.Organizacao)
            .HasForeignKey(e => e.OrganizacaoId)
            .OnDelete(DeleteBehavior.Cascade); // Excluir eventos se a organização for excluída

        // Mapeamento Evento
        modelBuilder.Entity<Evento>()
            .HasKey(e => e.EventoId);

        modelBuilder.Entity<Evento>()
            .HasMany(e => e.Ingressos) // Adicionando a relação com Ingressos
            .WithOne(i => i.Evento)
            .HasForeignKey(i => i.EventoId)
            .OnDelete(DeleteBehavior.Cascade); // Excluir ingressos se o evento for excluído

        // Mapeamento Ingresso
        modelBuilder.Entity<Ingresso>()
            .HasKey(i => i.IngressoId);

        modelBuilder.Entity<Ingresso>()
            .Property(i => i.Valor)
            .HasColumnType("decimal(18,2)"); // Definindo tipo da coluna para Valor

        // Exemplo para NotaMedia na entidade Evento
        modelBuilder.Entity<Evento>()
            .Property(e => e.NotaMedia)
            .HasColumnType("decimal(18,2)"); // Definindo tipo da coluna para NotaMedia

        // Exemplo para NotaMedia na entidade Organizacao
        modelBuilder.Entity<Organizacao>()
            .Property(o => o.NotaMedia)
            .HasColumnType("decimal(18,2)"); // Definindo tipo da coluna para NotaMedia
    }
}

// Fábrica de DbContext para uso em tempo de design
public class EventPlanContextFactory : IDesignTimeDbContextFactory<EventPlanContext>
{
    public EventPlanContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<EventPlanContext>();
        optionsBuilder.UseSqlServer("sua_string_de_conexao"); // Substitua pela sua string de conexão

        return new EventPlanContext(optionsBuilder.Options);
    }
}
